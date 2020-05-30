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
        private Programmazione programmazione = new Programmazione();

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
            programmazione.AggiornaCatalogo(listView_catalogo);
            ControlloTreeView();
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

        /// <summary>
        /// Se avviene un resize, questo metodo si occupa di chiamare tutti i metodi necessari
        /// </summary>
        private void ResizeChildrenControls()
        {
            ResizeControl(BtncreaNuovaDistintaBaseOriginalRect, Btn_creaNuovaDistintaBase);
            ResizeControl(BtncaricaDaCatalogoOriginalRect, Btn_caricaDaCatalogo);
            ResizeControl(BtnAggiungiSemilavoratoOriginalRect, Btn_AggiungiSemilavorato);
            ResizeControl(BtnAggiungiMateriaPrimaOriginalRect, Btn_AggiungiMateriaPrima);
            ResizeControl(TreeViewDistintaBaseOriginalRect, treeView_DistintaBase);
            ResizeControl(ListView_catalogoOriginalRect, listView_catalogo);
            ResizeControl(LblDistintaBaseOriginalRect, lbl_distintaBase);
            ResizeControl(LblCatalogoOriginalRect, lbl_catalogo);
        }

        /// <summary>
        /// Metodo principale che sposta il componente in una posizione adeguata alla nuova finestra.
        /// </summary>
        private void ResizeControl(Rectangle originalControlRect, Control control)
        {
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
            programmazione.catalogo.Carica();
            programmazione.AggiornaCatalogo(listView_catalogo);
            ControlloTreeView();
        }

        private void SalvaCatalogo()
        {
            programmazione.catalogo.Salva();
            programmazione.AggiornaCatalogo(listView_catalogo);
            ControlloTreeView();
        }

        private void ResettaCatalogo()
        {
            programmazione.catalogo.Nodi.Clear();
            programmazione.AggiornaCatalogo(listView_catalogo);
            ControlloTreeView();
        }

        /// <summary>
        /// Metodo che viene chiamato al click della voce carica nella sezione catalogo del contextMenu.
        /// </summary>
        private void caricaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CaricaCatalogo();
        }

        /// <summary>
        /// Metodo che viene chiamato al click della voce salva nella sezione catalogo del contextMenu.
        /// </summary>
        private void salvaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SalvaCatalogo();
        }

        /// <summary>
        /// Metodo che viene chiamato al click della voce resetta nella sezione catalogo del contextMenu.
        /// </summary>
        private void resettaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResettaCatalogo();
        }

        /// <summary>
        /// Carica la distinta base selezionata dall'utente nel catalogo.
        /// </summary>
        private void Btn_AggiungiSemilavorato_Click(object sender, EventArgs e)
        {
            programmazione.AggiungiSemilavoratoACatalogo();
            programmazione.AggiornaCatalogo(listView_catalogo);
            ControlloTreeView();
        }

        /// <summary>
        /// Crea un nodo con info date in input dall'utente.
        /// </summary>
        private void Btn_AggiungiMateriaPrima_Click(object sender, EventArgs e)
        {
            //apro una nuova finestra dove l'utente deve inserire tutte le info del nuovo materiale (nome,id,descr,LT,LTS,ecc...)
            programmazione.AggiungiMateriaPrimaACatalogo();
            programmazione.AggiornaCatalogo(listView_catalogo);
            ControlloTreeView();
        }

        /// <summary>
        /// Click destro su una riga della listbox chiama contextMenu.
        /// </summary>
        private void listView_catalogo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) { return; }
            Cms_ListBox.Show(listView_catalogo, e.Location);
        }

        /// <summary>
        /// ContextMenu listbox rimuove elemento selezionato.
        /// </summary>
        private void rimuoviToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView_catalogo.SelectedItems.Count == 0) { return; }
            if (MessageBox.Show("Vuoi rimuovere il componente definitivamente?", "Distinta Base", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string Codice = listView_catalogo.SelectedItems[0].SubItems[1].Text;
                listView_catalogo.SelectedItems[0].Remove();
                programmazione.RimuoviComponenteDaCatalogo(Codice);
                programmazione.AggiornaCatalogo(listView_catalogo);
                ControlloTreeView();
            }
        }

        /// <summary>
        /// ContextMenu listbox da info elemento selezionato.
        /// </summary>
        private void informazioniToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView_catalogo.SelectedItems.Count == 0) { return; }
            string Codice = listView_catalogo.SelectedItems[0].SubItems[1].Text;

            Box.Show(programmazione.InfoComponenteCatalogo(Codice), "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// ContextMenu listbox modifica elemento selezionato.
        /// </summary>
        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_catalogo.SelectedItems.Count == 0) { return; }
            string Codice = listView_catalogo.SelectedItems[0].SubItems[1].Text;
            programmazione.ModificaComponenteCatalogo(Codice);
            programmazione.AggiornaCatalogo(listView_catalogo);
            ControlloTreeView();
        }

        /// <summary>
        /// Doppio click su un elemento del catalogo e modifico.
        /// </summary>
        private void listView_catalogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView_catalogo.SelectedItems.Count == 0) { return; }
            string Codice = listView_catalogo.SelectedItems[0].SubItems[1].Text;
            programmazione.ModificaComponenteCatalogo(Codice);
            programmazione.AggiornaCatalogo(listView_catalogo);
            ControlloTreeView();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //ListView---------------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Crea le colonne della listView  (NOME CODICE DESCRIZIONE).
        /// </summary>
        private void CreaListView()
        {
            listView_catalogo.View = View.Details;
            listView_catalogo.FullRowSelect = true;
            listView_catalogo.Columns.Add("Nome", 120);
            listView_catalogo.Columns.Add("Codice", 100);
            listView_catalogo.Columns.Add("Descrizione", 450);
        }

        /// <summary>
        /// Blocca l'allargamento delle colonne da parte dell'utente.
        /// </summary>
        private void listView_catalogo_ColumnWidthChanging_1(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView_catalogo.Columns[e.ColumnIndex].Width;
        }

        /// <summary>
        /// Aggiorna la listView Catalogo ottenendo i nodi dalla lista nodi della classe catalogo.
        /// </summary>
        private void AggiornaCatalogo(ListView listView)
        {
            listView.Items.Clear();
            int i = 0;
            foreach (Componente comp in programmazione.catalogo.Nodi)
            {
                string[] items = { comp.Nome, comp.Codice, comp.Descrizione };
                ListViewItem ListViewNodo = new ListViewItem(items)
                {
                    Font = new Font("Microsoft Tai Le", 12)
                };
                if (i % 2 != 0)
                    ListViewNodo.BackColor = Color.FromArgb(238, 239, 249);
                listView.Items.Add(ListViewNodo);
                i++;
            }
            ControlloTreeView();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //DistintaBase-----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// BTN salva la distinta base.
        /// </summary>
        private void SalvaDistintaBase()
        {
            if (treeView_DistintaBase.Nodes.Count == 0)
            {
                MessageBox.Show("Creare prima una distinta base", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            programmazione.salvaDistintaBase();
            ControlloTreeView();
        }

        /// <summary>
        /// BTN resetta la distinta base.
        /// </summary>
        private void ResettaDistintaBase()
        {
            treeView_DistintaBase.Nodes.Clear();
            programmazione.distintaBase.Albero = new Componente();
            ControlloTreeView();
        }

        /// <summary>
        /// BTN carica la distinta base selezionata.
        /// </summary>
        private void CaricaDistintaBase()
        {
            treeView_DistintaBase.Nodes.Clear();
            TreeNode treeNode = programmazione.caricaDistintaBase();
            if (treeNode.Text != "")
            {
                treeView_DistintaBase.Nodes.Add(treeNode);
            }
            AggiornaCatalogo(listView_catalogo);
            ControlloTreeView();
        }

        /// <summary>
        /// Metodo che viene chiamato al click della voce carica nella sezione distintaBase del contextMenu.
        /// </summary>
        private void caricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaricaDistintaBase();
        }

        /// <summary>
        /// Metodo che viene chiamato al click della voce salva nella sezione distintaBase del contextMenu.
        /// </summary>
        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalvaDistintaBase();
        }

        /// <summary>
        /// Metodo che viene chiamato al click della voce resetta nella sezione distintaBase del contextMenu.
        /// </summary>
        private void resettaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResettaDistintaBase();
        }

        /// <summary>
        /// BTN carica un nodo dal catalogo.
        /// </summary>
        private void Btn_caricaDaCatalogo_Click(object sender, EventArgs e)
        {
            treeView_DistintaBase.Nodes.Clear();
            TreeNode treeNode = programmazione.CaricaDaCatalogo();
            if (treeNode != null)
            {
                treeView_DistintaBase.Nodes.Add(treeNode);
            }
            ControlloTreeView();
        } 

        /// <summary>
        /// BTN crea una nuova distinta base.
        /// </summary>
        private void Btn_creaNuovaDistintaBase_Click(object sender, EventArgs e)
        {
            treeView_DistintaBase.Nodes.Clear();
            TreeNode treeNode = programmazione.CreaNuovaDistintaBase();
            if (treeNode == null) return;
            if (treeNode.Text != "")
            {
                treeView_DistintaBase.Nodes.Add(treeNode);
            }
            ControlloTreeView();
        } 

        /// <summary>
        /// Click destro su un nodo mostra menu a scomparsa con cosa si può fare con un nodo.
        /// </summary>
        private void treeView_DistintaBase_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;//se non è stato cliccato con il tasto destro non faccio niente

            // Seleziona il nodo cliccato
            TreeNode node_here = treeView_DistintaBase.GetNodeAt(e.X, e.Y);
            treeView_DistintaBase.SelectedNode = node_here;
            if (node_here == null) return;

            //chiamo il menu a "tendina"
            Cms_TreeView.Show(treeView_DistintaBase, new Point(e.X, e.Y));

        }

        /// <summary>
        /// Context menu click destro nodo rimuove nodo.
        /// </summary>
        private void rimuoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Vuoi rimuovere il componente definitivamente?", "Distinta Base", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                programmazione.RimuoviNodo(treeView_DistintaBase);
                treeView_DistintaBase.SelectedNode.Remove();
                ControlloTreeView();
            }
        }

        /// <summary>
        /// Context menu click destro nodo mostra info.
        /// </summary>
        private void informazioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView_DistintaBase.SelectedNode == null) return;
            string Codice = treeView_DistintaBase.SelectedNode.Tag.ToString();

            Box.Show(programmazione.InfoComponenteDistintabase(Codice), "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Context menu click destro nodo mostra caricaNodo da Catalogo.
        /// </summary>
        private void daCatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView_DistintaBase.SelectedNode == null) return;
            TreeNode treeNode = programmazione.CaricaNodoDaCatalogo(treeView_DistintaBase);
            if (treeNode!=null)
            {
                treeView_DistintaBase.SelectedNode.Nodes.Add(treeNode);
                ControlloTreeView();
            }
        }

        /// <summary>
        /// Context menu click destro nodo mostra caricaNodo da File.
        /// </summary>
        private void daFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView_DistintaBase.SelectedNode == null) return;
            TreeNode treeNode = programmazione.CaricaNodoDaFile(treeView_DistintaBase);
            if (treeNode != null)
            {
                treeView_DistintaBase.SelectedNode.Nodes.Add(treeNode);
                ControlloTreeView();
            }
        }

        /// <summary>
        /// Context menu click destro nodo mostra creaNuovoNodo.
        /// </summary>
        private void creaNuovoNodoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (treeView_DistintaBase.SelectedNode == null) return;
            TreeNode treeNode = programmazione.CaricaTreeNodeMateriaPrima(treeView_DistintaBase);
            if (treeNode != null)
            {
                treeView_DistintaBase.SelectedNode.Nodes.Add(treeNode);
                ControlloTreeView();
            }
        }

        /// <summary>
        /// Context menu click destro nodo carica il nodo in catalogo.
        /// </summary>
        private void aggiungiACatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView_DistintaBase.SelectedNode == null) return;
            programmazione.AggiungiComponenteACatalogo(treeView_DistintaBase);
            programmazione.AggiornaCatalogo(listView_catalogo);
            ControlloTreeView();
        }

        /// <summary>
        /// Context menu click destro nodo mi permette di modificarlo.
        /// </summary>
        private void modificaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView_DistintaBase.SelectedNode == null) return;
            TreeNode treeNode = programmazione.ModificaNodo(treeView_DistintaBase);
            if (treeNode != null)
            {
                if(treeView_DistintaBase.SelectedNode.Parent==null)
                {
                    treeView_DistintaBase.Nodes.Clear();
                    treeView_DistintaBase.Nodes.Add(treeNode);
                }
                else
                {
                    TreeNode treeNodePadre = treeView_DistintaBase.SelectedNode.Parent;
                    treeNodePadre.Nodes.Remove(treeView_DistintaBase.SelectedNode);
                    treeNodePadre.Nodes.Add(treeNode);
                    ControlloTreeView();
                }
            }
        }

        /// <summary>
        /// Doppio click su nodo mi permette di modificarlo.
        /// </summary>
        private void treeView_DistintaBase_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView_DistintaBase.SelectedNode == null) return;
            TreeNode treeNode = programmazione.ModificaNodo(treeView_DistintaBase);
            if (treeNode != null)
            {
                if (treeView_DistintaBase.SelectedNode.Parent == null)
                {

                }
                else
                {
                    TreeNode treeNodePadre = treeView_DistintaBase.SelectedNode.Parent;
                    treeNodePadre.Nodes.Remove(treeView_DistintaBase.SelectedNode);
                    treeNodePadre.Nodes.Add(treeNode);
                    ControlloTreeView();
                }
            }
        }


        /// <summary>
        /// Controlla se treeview è vuota, se vuota abilita i bottoni "crea nuova distinta base".
        /// </summary>
        private void ControlloTreeView()
        {
            if (treeView_DistintaBase.Nodes.Count == 0)
            {
                Btn_caricaDaCatalogo.Visible = true;
                Btn_creaNuovaDistintaBase.Visible = true;
                if (programmazione.catalogo.Nodi.Count() == 0)
                {
                    Btn_caricaDaCatalogo.Visible = false;
                }
            }
            else
            {
                Btn_caricaDaCatalogo.Visible = false;
                Btn_creaNuovaDistintaBase.Visible = false;
            }
        }
        

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //Informazioni-----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Chiamato quando viene cliccata la voce informazioni distintaBase nel menu info del contextMenu.
        /// </summary>
        private void distintaBaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Si può creare una nuova distinta base o caricarla da catalogo con gli appositi pulsanti." +
                "\nSi può salvare, caricare o resettare la distinta base selezionado l'apposita voce nella barra-menu." +
                "\nCon un click destro su un componente della distinta base si può eliminare, modificare, aggiungere" +
                " un sottocomponente, ottenere le info o aggiungere al catalogo un componente.\nCon " +
                "un doppio click su un qualsiasi componente si può modificare quest'ultimo.", "Distinta Base", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Chiamato quando viene cliccata la voce informazioni catalogo nel menu info del contextMenu.
        /// </summary>
        private void catalogoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Si può caricare, salvare o resettare il catalogo tramite l'apposita voce nella barra-menu." +
                "\nSi può caricare un componente o crearne uno nuovo con gli appositi pulsanti.", 
                "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Chiamato quando viene cliccata la voce Manuale online distintaBase nel menu info del contextMenu. 
        /// </summary>
        private void manualeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vuoi aprire il manuale online?", "Gestione materiali", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://google.com");
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}
