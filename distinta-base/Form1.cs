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
        
        private Generale generale = new Generale();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreaListView();
            ControlloTreeView();
            AggiornaCatalogo();
        }




        //Catalogo---------------------------------------------------------------------------------------------------------------------------------------------------

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

        private void SalvaCatalogo()
        {
            generale.catalogo.Salva();
            AggiornaCatalogo();
        }

        private void CaricaCatalogo()
        {
            generale.catalogo.Carica();
            AggiornaCatalogo();
        }

        private void ResettaCatalogo()
        {
            generale.catalogo.Nodi.Clear();
            AggiornaCatalogo();
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
            if (MessageBox.Show("Vuoi rimuovere il componente definitivamente?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
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

            MessageBox.Show(generale.InfoComponente(Codice), "INFORMAZIONI", MessageBoxButtons.OK);
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



        private void CreaListView()
        {
            listView_catalogo.View = View.Details;
            listView_catalogo.FullRowSelect = true;
            listView_catalogo.Columns.Add("Nome", 120);
            listView_catalogo.Columns.Add("Codice", 100);
            listView_catalogo.Columns.Add("Descrizione", 220);
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
            foreach (Componente comp in generale.catalogo.Nodi)
            {
                string[] items = { comp.Nome, comp.Codice, comp.Descrizione };
                ListViewItem ListViewNodo = new ListViewItem(items);
                listView_catalogo.Items.Add(ListViewNodo);
            }
            ControlloTreeView();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //DistintaBase-----------------------------------------------------------------------------------------------------------------------------------------------

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

        private void SalvaDistintaBase()
        {
            if (treeView_DistintaBase.Nodes.Count == 0) return;
            generale.salvaDistintaBase(treeView_DistintaBase);
            ControlloTreeView();
        }//BTN salva la distinta base

        private void ResettaDistintaBase()
        {
            treeView_DistintaBase.Nodes.Clear();
            generale.distintaBase.Nodi.Clear();
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
            TreeNode treeNode = generale.NuovoNodoDistintaBase();
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
            if(MessageBox.Show("Vuoi rimuovere il componente definitivamente?","ATTENZIONE",MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
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

            MessageBox.Show(generale.InfoComponente(Codice), "INFORMAZIONI", MessageBoxButtons.OK);
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
                return;
            }
            treeView_DistintaBase.Nodes.Clear();
            treeView_DistintaBase.Nodes.Add(treeNode);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //Informazioni-----------------------------------------------------------------------------------------------------------------------------------------------

        private void distintaBaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Si può creare una nuova distinta base o caricarla da catalogo con gli appositi pulsanti.\nSi può salvare, caricare o resettare la distinta base selezionado l'apposita voce nella barra-menu.\nCon un click destro su un componente della distinta base si può eliminare, modificare, aggiungere sottocomponente, ottenere le info, aggiungere al catalogo il componente selezionato.\nCon un doppio click su un qualsiasi componente si può modificare quest'ultimo.", "TUTORIAL",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void catalogoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Si può caricare, salvare o resettare il catalogo tramite l'apposita voce nella barra-menu.\nSi può caricare un componente o crearne uno nuovo con gli appositi pulsanti.", "TUTORIAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /*private void Btn_Informazioni_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Cms_Informazioni.Show(Btn_Informazioni, e.Location);
        }

        private void Btn_Informazioni_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Btn_Informazioni.Image = Properties.Resources.IconaPremuta;
        }

        private void Btn_Informazioni_MouseUp(object sender, MouseEventArgs e)
        {
            Btn_Informazioni.Image = Properties.Resources.IconaNormale;
        }

        private void guidaSullaDistintaBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Fare click, col tasto destro del mouse, su un nodo per rimuoverlo, modificarlo, ottenere le proprie informazioni oppure aggiungere un sottonodo.";
            MessageBox.Show(text, "Guida sulla distinta base", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guidaSulCatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Fare click, col tasto destro del mouse, su un elemento del catalogo per rimuoverlo, modificarlo oppure per ottenere le proprie informazioni.";
            MessageBox.Show(text, "Guida sulla distinta base", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }*/
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}
