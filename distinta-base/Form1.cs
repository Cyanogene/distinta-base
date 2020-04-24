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

        private DistintaBase distintaBase = new DistintaBase();
        private Catalogo catalogo = new Catalogo();
        List<Componente> Componenti = new List<Componente>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreaListView();
            ControlloTreeView();
            AggiornaCatalogo();
            MenuBar();
        }

        void MenuBar()
        {
            Menu = new MainMenu();

            MenuItem DistintaBase = new MenuItem("Distinta base");
            MenuItem Catalogo = new MenuItem("Catalogo");

            Menu.MenuItems.Add(DistintaBase);
            Menu.MenuItems.Add(Catalogo);

            DistintaBase.MenuItems.Add("Salva", new EventHandler(Btn_SalvaDistintaBase_Click));
            DistintaBase.MenuItems.Add("Carica", new EventHandler(Btn_CaricaDistintaBase_Click));
            DistintaBase.MenuItems.Add("Resetta", new EventHandler(Btn_resettaDistintaBase_Click));

            Catalogo.MenuItems.Add("Salva", new EventHandler(btn_salvaCatalogo_Click));
            Catalogo.MenuItems.Add("Carica", new EventHandler(btn_caricaCatalogo_Click));
            Catalogo.MenuItems.Add("Resetta", new EventHandler(btn_resettaCatalogo_Click));
        }




        //Catalogo---------------------------------------------------------------------------------------------------------------------------------------------------


        private void Btn_AggiungiSemilavorato_Click(object sender, EventArgs e)
        {
            catalogo.AggiungiSemilavorato(Componenti);
            AggiornaCatalogo();
        }//carica la distinta base selezionata dall'utente nel catalogo

        private void Btn_AggiungiMateriaPrima_Click(object sender, EventArgs e)
        {
            //apro una nuova finestra dove l'utente deve inserire tutte le info del nuovo materiale (nome,id,descr,LT,LTS,ecc...)
            catalogo.AggiungiMateriaPrima(Componenti);
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
            string Codice = listView_catalogo.SelectedItems[0].SubItems[1].Text;

            listView_catalogo.SelectedItems[0].Remove();
            catalogo.RimuoviComponente(Codice);
            AggiornaCatalogo();
        }//contextMenu listbox rimuove elemento selezionato

        private void informazioniToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView_catalogo.SelectedItems.Count == 0) { return; }
            string Codice = listView_catalogo.SelectedItems[0].SubItems[1].Text;

            MessageBox.Show(catalogo.Info(Codice), "INFORMAZIONI", MessageBoxButtons.OK);
        }//contextMenu listbox da info elemento selezionato

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_catalogo.SelectedItems.Count == 0) { return; }
            string Codice = listView_catalogo.SelectedItems[0].SubItems[1].Text;

            catalogo.Modifica(Componenti, Codice);
            AggiornaCatalogo();
        }//contextMenu listbox modifica elemento selezionato

        private void listView_catalogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView_catalogo.SelectedItems.Count == 0) { return; }
            string Codice = listView_catalogo.SelectedItems[0].SubItems[1].Text;

            catalogo.Modifica(Componenti, Codice);
            AggiornaCatalogo();
        }//doppio click su un elemento del catalogo e modifico



        private void btn_caricaCatalogo_Click(object sender, EventArgs e)
        {
            catalogo.Carica();
            AggiornaCatalogo();
        }

        private void btn_salvaCatalogo_Click(object sender, EventArgs e)
        {
            catalogo.Salva();
            AggiornaCatalogo();
        }

        private void btn_resettaCatalogo_Click(object sender, EventArgs e)
        {
            catalogo.Nodi.Clear();
            AggiornaCatalogo();
        }



        private void CreaListView()
        {
            listView_catalogo.View = View.Details;
            listView_catalogo.FullRowSelect = true;
            listView_catalogo.Columns.Add("Nome", 90);
            listView_catalogo.Columns.Add("Codice", 120);
            listView_catalogo.Columns.Add("Descrizione", 180);
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
            foreach (Componente comp in catalogo.Nodi)
            {
                string[] items = { comp.Nome, comp.Codice, comp.Descrizione };
                ListViewItem ListViewNodo = new ListViewItem(items);
                listView_catalogo.Items.Add(ListViewNodo);
            }
            if (catalogo.Nodi.Count == 0)
            {
                btn_resettaCatalogo.Visible = false;
                btn_salvaCatalogo.Visible = false;
                btn_caricaCatalogo.Visible = true;
            }
            else
            {
                btn_resettaCatalogo.Visible = true;
                btn_salvaCatalogo.Visible = true;
                btn_caricaCatalogo.Visible = false;
            }
            Componenti.Clear();
            Componenti.AddRange(catalogo.Nodi);
            Componenti.AddRange(distintaBase.Nodi);
            ControlloTreeView();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //DistintaBase-----------------------------------------------------------------------------------------------------------------------------------------------

        private void Btn_SalvaDistintaBase_Click(object sender, EventArgs e)
        {
            if (treeView_DistintaBase.Nodes.Count == 0) return;
            distintaBase.Salva(distintaBase.TreeViewToNode(treeView_DistintaBase));
        } //BTN salva la distinta base

        private void Btn_resettaDistintaBase_Click(object sender, EventArgs e)
        {
            treeView_DistintaBase.Nodes.Clear();
            distintaBase.Nodi.Clear();
            ControlloTreeView();
        } //BTN resetta la distinta base

        private void Btn_CaricaDistintaBase_Click(object sender, EventArgs e)
        {
            treeView_DistintaBase.Nodes.Clear();
            distintaBase.Nodi.Clear();
            treeView_DistintaBase.Nodes.Add(distintaBase.NodeToTreeNode(distintaBase.Carica(Componenti)));
            ControlloTreeView();
        } //BTN carica la distinta base selezionata



        private void Btn_caricaDaCatalogo_Click(object sender, EventArgs e)
        {
            Form3_Catalogo form3 = new Form3_Catalogo(catalogo.Nodi);
            form3.ShowDialog();
            while (form3.nodo == null)
            {
                if (!form3.attendo)
                {
                    return;
                }
            }
            Componente node = form3.nodo;
            treeView_DistintaBase.Nodes.Add(distintaBase.NodeToTreeNode(node));
            ControlloTreeView();
            distintaBase.Nodi.Add(node);
        } //BTN carica un nodo dal catalogo

        private void Btn_creaNuovaDistintaBase_Click(object sender, EventArgs e)
        {
            Form2_NewNode form2 = new Form2_NewNode(new Componente(), Componenti);
            form2.ShowDialog();
            Componente nodo = form2.nodo;
            while (nodo == null)
            {
                if (!form2.attendo)
                {
                    return;
                }
            }
            distintaBase.Nodi.Add(nodo);
            treeView_DistintaBase.Nodes.Add(distintaBase.NodeToTreeNode(nodo));
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
            if (treeView_DistintaBase.Nodes.Count == 1)
            {
                distintaBase.Nodi.Remove(distintaBase.TreeViewToNode(treeView_DistintaBase));
            }
            else
            {
                distintaBase.Nodi.Remove(distintaBase.TreeNodeToNode(treeView_DistintaBase.SelectedNode));
            }
            treeView_DistintaBase.SelectedNode.Remove();
            ControlloTreeView();
        }//context menu click destro nodo rimuove nodo

        private void informazioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Componente nodo = distintaBase.TreeNodeToNode(treeView_DistintaBase.SelectedNode);
            string info = "Nome --> " + nodo.Nome + "\nCodice --> " + nodo.Codice + "\nDescrizione --> " + nodo.Descrizione + "\nLeadTime --> " + nodo.LeadTime + "\nLeadTimeSicurezza --> " + nodo.LeadTimeSicurezza + "\nLotto --> " + nodo.Lotto + "\nScortaDiSicurezza --> " + nodo.ScortaSicurezza + "\nPeriodoDiCopertura --> " + nodo.PeriodoDiCopertura;
            MessageBox.Show(info, "INFORMAZIONI", MessageBoxButtons.OK);
        }//context menu click destro nodo mostra info

        private void daCatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (catalogo.Nodi.Count == 0)
            {
                //messsageBox catalogo vuoto
                return;
            }
            Form3_Catalogo form3 = new Form3_Catalogo(catalogo.Nodi);
            form3.ShowDialog();
            while (form3.nodo == null)
            {
                if (!form3.attendo)
                {
                    return;
                }
            }
            Componente node = form3.nodo;
            treeView_DistintaBase.SelectedNode.Nodes.Add(distintaBase.NodeToTreeNode(node)); ControlloTreeView();
            ControlloTreeView();
            distintaBase.Nodi.Add(node);
            listView_catalogo.SelectedItems.Clear();
        }//context menu click destro nodo mostra caricaNodo da Catalogo

        private void daFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            distintaBase.CaricaNodoDaFile(Componenti);
            ControlloTreeView();
        }//context menu click destro nodo mostra caricaNodo da File

        private void creaNuovoNodoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2_NewNode form2 = new Form2_NewNode(new Componente(), Componenti);
            form2.ShowDialog();
            Componente nodo = form2.nodo;
            while (nodo == null)
            {
                if (!form2.attendo)
                {
                    return;
                }
            }
            treeView_DistintaBase.SelectedNode.Nodes.Add(distintaBase.NodeToTreeNode(nodo));
            ControlloTreeView();
            distintaBase.Nodi.Add(nodo);
        }//context menu click destro nodo mostra creaNuovoNodo

        private void aggiungiACatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Componente componente = distintaBase.TreeNodeToNode(treeView_DistintaBase.SelectedNode);
            if (!catalogo.EsisteComponenteInCatalogo(componente))
            {
                catalogo.Nodi.Add(componente);
            }
            else
            {
                DialogResult dialogResult =  MessageBox.Show("Il componente è già presente nel catalogo, vuoi sostituirlo?", "Distinta base", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                if(dialogResult == DialogResult.Yes)
                {
                    catalogo.SostitusciComponente(componente);
                }
            }
            AggiornaCatalogo();
        }//context menu click destro nodo carica il nodo in catalogo

        private void modificaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Componente nodo = distintaBase.TreeNodeToNode(treeView_DistintaBase.SelectedNode);
            Form2_NewNode form2 = new Form2_NewNode(nodo, Componenti);
            form2.ShowDialog();
            Componente nuovoNodo = form2.nodo;
            while (nuovoNodo == null)
            {
                if (!form2.attendo)
                {
                    return;
                }
            }
            nuovoNodo.SottoNodi = nodo.SottoNodi;
            distintaBase.Nodi.Remove(nodo);
            distintaBase.Nodi.Add(nuovoNodo);
            int index = treeView_DistintaBase.Nodes.IndexOf(treeView_DistintaBase.SelectedNode);
            treeView_DistintaBase.Nodes.RemoveAt(index);
            treeView_DistintaBase.Nodes.Insert(index, distintaBase.NodeToTreeNode(nuovoNodo));
            return;
        }//context menu click destro nodo mi permette di modificarlo

        private void treeView_DistintaBase_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Componente nodo = distintaBase.TreeNodeToNode(treeView_DistintaBase.SelectedNode);
            Form2_NewNode form2 = new Form2_NewNode(nodo, Componenti);
            form2.ShowDialog();
            Componente nuovoNodo = form2.nodo;
            while (nuovoNodo == null)
            {
                if (!form2.attendo)
                {
                    return;
                }
            }
            nuovoNodo.SottoNodi = nodo.SottoNodi;
            distintaBase.Nodi.Remove(nodo);
            distintaBase.Nodi.Add(nuovoNodo);
            int index = treeView_DistintaBase.Nodes.IndexOf(treeView_DistintaBase.SelectedNode);
            treeView_DistintaBase.Nodes.RemoveAt(index);
            treeView_DistintaBase.Nodes.Insert(index, distintaBase.NodeToTreeNode(nuovoNodo));
            return;
        }//doppio click su nodo mi permette di modificarlo



        private void ControlloTreeView()
        {
            if (treeView_DistintaBase.Nodes.Count == 0)
            {
                Btn_CaricaDistintaBase.Visible = true;
                Btn_caricaDaCatalogo.Visible = true;
                Btn_creaNuovaDistintaBase.Visible = true;
                Btn_resettaDistintaBase.Visible = false;
                Btn_SalvaDistintaBase.Visible = false;
                if (catalogo.Nodi.Count() == 0)
                {
                    Btn_caricaDaCatalogo.Visible = false;
                }
            }
            else
            {
                Btn_caricaDaCatalogo.Visible = false;
                Btn_CaricaDistintaBase.Visible = false;
                Btn_creaNuovaDistintaBase.Visible = false;
                Btn_resettaDistintaBase.Visible = true;
                Btn_SalvaDistintaBase.Visible = true;
            }
            Componenti.Clear();
            Componenti.AddRange(distintaBase.Nodi);
            Componenti.AddRange(catalogo.Nodi);
        }//controlla se treeview è vuota, se vuota abilita i bottoni "crea nuova distinta base"

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //Informazioni-----------------------------------------------------------------------------------------------------------------------------------------------

        private void Btn_Informazioni_MouseClick(object sender, MouseEventArgs e)
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
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}
