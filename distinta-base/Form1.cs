using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Input;

namespace distinta_base
{
    public partial class Form1 : Form
    {
        private Programmazione generale = new Programmazione();

        private Rectangle BtncreaNuovaDistintaBaseOriginalRect;
        private Rectangle BtncaricaDaCatalogoOriginalRect;
        private Rectangle BtnAggiungiSemilavoratoOriginalRect;

        private Rectangle BtnAggiungiMateriaPrimaOriginalRect;
        private Rectangle TreeViewDistintaBaseOriginalRect;
        private Rectangle ListView_catalogoOriginalRect;

        private Rectangle LblDistintaBaseOriginalRect;
        private Rectangle LblCatalogoOriginalRect;
        private Size formOriginalSize;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreaListView();
            ControlloTreeView();
            AggiornaCatalogo();
            lbl_catalogo.BackColor = Color.FromArgb(232, 190, 118);
            lbl_distintaBase.BackColor = Color.FromArgb(232, 190, 118);
            formOriginalSize = Size;
            ResizeInitialization();
        }


        //resizeFormElement---------------------------------------------------------------------------------------------------------------------------------------------

        private void ResizeInitialization()
        {
            // Viene inizializzata una figura per ogni componente nel form
            BtncreaNuovaDistintaBaseOriginalRect = new Rectangle(Btn_creaNuovaDistintaBase.Location.X, Btn_creaNuovaDistintaBase.Location.Y, Btn_creaNuovaDistintaBase.Width, Btn_creaNuovaDistintaBase.Height);
            BtncaricaDaCatalogoOriginalRect = new Rectangle(Btn_caricaDaCatalogo.Location.X, Btn_caricaDaCatalogo.Location.Y, Btn_caricaDaCatalogo.Width, Btn_caricaDaCatalogo.Height);
            BtnAggiungiSemilavoratoOriginalRect = new Rectangle(Btn_AggiungiSemilavorato.Location.X, Btn_AggiungiSemilavorato.Location.Y, Btn_AggiungiSemilavorato.Width, Btn_AggiungiSemilavorato.Height);
            BtnAggiungiMateriaPrimaOriginalRect = new Rectangle(Btn_AggiungiMateriaPrima.Location.X, Btn_AggiungiMateriaPrima.Location.Y, Btn_AggiungiMateriaPrima.Width, Btn_AggiungiMateriaPrima.Height);
            TreeViewDistintaBaseOriginalRect = new Rectangle(treeView_DistintaBase.Location.X, treeView_DistintaBase.Location.Y, treeView_DistintaBase.Width, treeView_DistintaBase.Height);
            ListView_catalogoOriginalRect = new Rectangle(listView_catalogo.Location.X, listView_catalogo.Location.Y, listView_catalogo.Width, listView_catalogo.Height);
            LblDistintaBaseOriginalRect = new Rectangle(lbl_distintaBase.Location.X, lbl_distintaBase.Location.Y, lbl_distintaBase.Width, lbl_distintaBase.Height);
            LblCatalogoOriginalRect = new Rectangle(lbl_catalogo.Location.X, lbl_catalogo.Location.Y, lbl_catalogo.Width, lbl_catalogo.Height);
        }

        private void ResizeChildrenControls()
        {
            // Se avviene un resize, questo metodo si occupa di chiamare tutti i metodi necessari
            ResizeControl(BtncreaNuovaDistintaBaseOriginalRect, Btn_creaNuovaDistintaBase);
            ResizeControl(BtncaricaDaCatalogoOriginalRect, Btn_caricaDaCatalogo);
            ResizeControl(BtnAggiungiSemilavoratoOriginalRect, Btn_AggiungiSemilavorato);
            ResizeControl(BtnAggiungiMateriaPrimaOriginalRect, Btn_AggiungiMateriaPrima);
            ResizeControl(TreeViewDistintaBaseOriginalRect, treeView_DistintaBase);
            ResizeControl(ListView_catalogoOriginalRect, listView_catalogo);
            ResizeControl(LblDistintaBaseOriginalRect, lbl_distintaBase);
            ResizeControl(LblCatalogoOriginalRect, lbl_catalogo);
        }
        
        private void ResizeControl(Rectangle originalControlRect, Control control)
        {
            // Metodo principale che sposta il componente in una posizione adeguata alla nuova finestra.
            float xRatio = Width / (float)formOriginalSize.Width;
            float yRatio = Height / (float)formOriginalSize.Height;

            int newX = (int)(originalControlRect.Location.X * xRatio);
            int newY = (int)(originalControlRect.Location.Y * yRatio);
            int newWidth = (int)(originalControlRect.Size.Width * xRatio);
            int newHeight = (int)(originalControlRect.Size.Height * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);
        }
               
        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeChildrenControls();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------




        //Catalogo---------------------------------------------------------------------------------------------------------------------------------------------------


        private void CaricaCatalogo()
        {
            generale.catalogo.Carica();
            AggiornaCatalogo();
        }

        private void SalvaCatalogo()
        {
            generale.catalogo.Salva();
            AggiornaCatalogo();
        }

        private void ResettaCatalogo()
        {
            generale.catalogo.Nodi.Clear();
            AggiornaCatalogo();
        }

        private void caricaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CaricaCatalogo();
        }

        private void salvaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SalvaCatalogo();
        }

        private void resettaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResettaCatalogo();
        }
        
        private void Btn_AggiungiSemilavorato_Click(object sender, EventArgs e)
        {
            generale.AggiungiSemilavoratoACatalogo();
            AggiornaCatalogo();
        }//carica la distinta base selezionata dall'utente nel catalogo

        private void Btn_AggiungiMateriaPrima_Click(object sender, EventArgs e)
        {
            //apro una nuova finestra dove l'utente deve inserire tutte le info del nuovo materiale (nome,id,descr,LT,LTS,ecc...)
            generale.AggiungiMateriaPrimaACatalogo();
            AggiornaCatalogo();
        }//crea un nodo con info date in input dall'utente

        
        private void listView_catalogo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) { return; }
            Cms_ListBox.Show(listView_catalogo, e.Location);
        }//click destro su una riga della listbox apre contextMenu

        private void rimuoviToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView_catalogo.SelectedItems.Count == 0) { return; }
            if (MessageBox.Show("Vuoi rimuovere il componente definitivamente?", "Distinta Base", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string Codice = listView_catalogo.SelectedItems[0].SubItems[1].Text;
                listView_catalogo.SelectedItems[0].Remove();
                generale.RimuoviComponenteDaCatalogo(Codice);
                AggiornaCatalogo();
            }
        }//contextMenu listbox rimuove elemento selezionato

        private void informazioniToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView_catalogo.SelectedItems.Count == 0) { return; }
            string Codice = listView_catalogo.SelectedItems[0].SubItems[1].Text;

            Box.Show(generale.InfoComponenteCatalogo(Codice), "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }//contextMenu listbox da info elemento selezionato

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_catalogo.SelectedItems.Count == 0) { return; }
            string Codice = listView_catalogo.SelectedItems[0].SubItems[1].Text;
            generale.ModificaComponenteCatalogo(Codice);
            AggiornaCatalogo();
        }//contextMenu listbox modifica elemento selezionato

        private void listView_catalogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView_catalogo.SelectedItems.Count == 0) { return; }
            string Codice = listView_catalogo.SelectedItems[0].SubItems[1].Text;
            generale.ModificaComponenteCatalogo(Codice);
            AggiornaCatalogo();
        }//doppio click su un elemento del catalogo e modifico

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //ListView---------------------------------------------------------------------------------------------------------------------------------------------------

        private void CreaListView()
        {
            listView_catalogo.View = View.Details;
            listView_catalogo.FullRowSelect = true;
            listView_catalogo.Columns.Add("Nome", 120);
            listView_catalogo.Columns.Add("Codice", 100);
            listView_catalogo.Columns.Add("Descrizione", 450);
        }//Crea le colonne della listView  (NOME CODICE DESCRIZIONE) <--- di ogni prodotto

        private void listView_catalogo_ColumnWidthChanging_1(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView_catalogo.Columns[e.ColumnIndex].Width;
        }//blocca l'allargamento delle colonne da parte dell'utente

        private void AggiornaCatalogo()
        {
            listView_catalogo.SelectedItems.Clear();
            listView_catalogo.Items.Clear();
            int i = 0;
            foreach (Componente comp in generale.catalogo.Nodi)
            {
                string[] items = { comp.Nome, comp.Codice, comp.Descrizione };
                ListViewItem ListViewNodo = new ListViewItem(items)
                {
                    Font = new Font("Microsoft Tai Le", 12)
                };
                if (i % 2 != 0)
                    ListViewNodo.BackColor = Color.FromArgb(238, 239, 249);
                listView_catalogo.Items.Add(ListViewNodo);
                i++;
            }
            ControlloTreeView();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //DistintaBase-----------------------------------------------------------------------------------------------------------------------------------------------

        private void SalvaDistintaBase()
        {
            if (treeView_DistintaBase.Nodes.Count == 0) return;
            generale.salvaDistintaBase();
            ControlloTreeView();
        }//BTN salva la distinta base

        private void ResettaDistintaBase()
        {
            treeView_DistintaBase.Nodes.Clear();
            generale.distintaBase.Albero = new Componente();
            ControlloTreeView();
        }//BTN resetta la distinta base

        private void CaricaDistintaBase()
        {
            treeView_DistintaBase.Nodes.Clear();
            TreeNode treeNode = generale.caricaDistintaBase();
            if (treeNode.Text != "")
            {
                treeView_DistintaBase.Nodes.Add(treeNode);
            }
            ControlloTreeView();
            AggiornaCatalogo();
        }//BTN carica la distinta base selezionata


        private void caricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaricaDistintaBase();
        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalvaDistintaBase();
        }

        private void resettaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResettaDistintaBase();
        }
        

        private void Btn_caricaDaCatalogo_Click(object sender, EventArgs e)
        {
            treeView_DistintaBase.Nodes.Clear();
            TreeNode treeNode = generale.CaricaDaCatalogo();
            if (treeNode != null)
            {
                treeView_DistintaBase.Nodes.Add(treeNode);
            }
            ControlloTreeView();
        } //BTN carica un nodo dal catalogo

        private void Btn_creaNuovaDistintaBase_Click(object sender, EventArgs e)
        {
            treeView_DistintaBase.Nodes.Clear();
            TreeNode treeNode = generale.CreaNuovaDistintaBase();
            if (treeNode == null) return;
            if (treeNode.Text != "")
            {
                treeView_DistintaBase.Nodes.Add(treeNode);
            }
            ControlloTreeView();
        } //BTN crea una nuova distinta base
        

        private void treeView_DistintaBase_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;//se non è stato cliccato con il tasto destro non faccio niente

            // Seleziona il nodo cliccato
            TreeNode node_here = treeView_DistintaBase.GetNodeAt(e.X, e.Y);
            treeView_DistintaBase.SelectedNode = node_here;
            if (node_here == null) return;

            //chiamo il menu a "tendina"
            Cms_TreeView.Show(treeView_DistintaBase, new Point(e.X, e.Y));

        }//click destro su un nodo mostra menu a scomparsa con cosa si può fare con un nodo

        private void rimuoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Vuoi rimuovere il componente definitivamente?", "Distinta Base", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                AggiornaTreeView(generale.RimuoviNodo(treeView_DistintaBase));
                ControlloTreeView();
            }
        }//context menu click destro nodo rimuove nodo

        private void informazioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView_DistintaBase.SelectedNode == null) return;
            if (treeView_DistintaBase.SelectedNode == null) { return; }
            string Codice = treeView_DistintaBase.SelectedNode.Tag.ToString();

            Box.Show(generale.InfoComponenteDistintabase(Codice), "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }//context menu click destro nodo mostra info

        private void daCatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView_DistintaBase.SelectedNode == null) return;
            AggiornaTreeView(generale.CaricaNodoDaCatalogo(treeView_DistintaBase));
            ControlloTreeView();
        }//context menu click destro nodo mostra caricaNodo da Catalogo

        private void daFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView_DistintaBase.SelectedNode == null) return;
            AggiornaTreeView(generale.CaricaNodoDaFile(treeView_DistintaBase));
            ControlloTreeView();
        }//context menu click destro nodo mostra caricaNodo da File

        private void creaNuovoNodoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (treeView_DistintaBase.SelectedNode == null) return;
            AggiornaTreeView(generale.CaricaTreeNodeMateriaPrima(treeView_DistintaBase));
            ControlloTreeView();
        }//context menu click destro nodo mostra creaNuovoNodo

        private void aggiungiACatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView_DistintaBase.SelectedNode == null) return;
            generale.AggiungiComponenteACatalogo(treeView_DistintaBase);
            AggiornaCatalogo();
        }//context menu click destro nodo carica il nodo in catalogo

        private void modificaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView_DistintaBase.SelectedNode == null) return;
            AggiornaTreeView(generale.ModificaNodo(treeView_DistintaBase));
            ControlloTreeView();
        }//context menu click destro nodo mi permette di modificarlo

        private void treeView_DistintaBase_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView_DistintaBase.SelectedNode == null) return;
            TreeNode tree = treeView_DistintaBase.SelectedNode;
            AggiornaTreeView(generale.ModificaNodo(treeView_DistintaBase));
            ControlloTreeView();
        }//doppio click su nodo mi permette di modificarlo



        private void ControlloTreeView()
        {
            if (treeView_DistintaBase.Nodes.Count == 0)
            {
                Btn_caricaDaCatalogo.Visible = true;
                Btn_creaNuovaDistintaBase.Visible = true;
                if (generale.catalogo.Nodi.Count() == 0)
                {
                    Btn_caricaDaCatalogo.Visible = false;
                }
            }
            else
            {
                Btn_caricaDaCatalogo.Visible = false;
                Btn_creaNuovaDistintaBase.Visible = false;
            }
        }//controlla se treeview è vuota, se vuota abilita i bottoni "crea nuova distinta base"

        private void AggiornaTreeView(TreeNode treeNode)
        {
            if (treeNode == null)
            {
                treeView_DistintaBase.Nodes.Clear();
                return;
            }
            treeView_DistintaBase.Nodes.Clear();
            treeView_DistintaBase.Nodes.Add(treeNode);
            treeView_DistintaBase.ExpandAll();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //Informazioni-----------------------------------------------------------------------------------------------------------------------------------------------

        private void distintaBaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Si può creare una nuova distinta base o caricarla da catalogo con gli appositi pulsanti.\nSi può salvare, caricare o resettare la distinta base selezionado l'apposita voce nella barra-menu.\nCon un click destro su un componente della distinta base si può eliminare, modificare, aggiungere sottocomponente, ottenere le info, aggiungere al catalogo il componente selezionato.\nCon un doppio click su un qualsiasi componente si può modificare quest'ultimo.", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void catalogoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Si può caricare, salvare o resettare il catalogo tramite l'apposita voce nella barra-menu.\nSi può caricare un componente o crearne uno nuovo con gli appositi pulsanti.", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}
