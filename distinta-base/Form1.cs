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
        Form2_NewNode form2;
        public Form1()
        {
            InitializeComponent();
            distintaBase = new DistintaBase();
            salvataggio = new Salvataggio();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreaListView();
            ControlloTreeView();
        }

        private DistintaBase distintaBase;
        private Salvataggio salvataggio;
        List<Node> Catalogo = new List<Node>();
        //List<Node> NodiTreeView = new List<Node>();


        //Catalogo---------------------------------------------------------------------------------------------------------------------------------------------------

        private void Btn_AggiungiSemilavorato_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ofd_semilavorato = new OpenFileDialog();
            Ofd_semilavorato.InitialDirectory = @"C:\";
            Ofd_semilavorato.Filter = "XML|*.xml";
            if (Ofd_semilavorato.ShowDialog() == DialogResult.OK)
            {
                string filePosition = Ofd_semilavorato.FileName;
                Node semilavorato = salvataggio.CaricaDistintaBase(filePosition);
                Catalogo.Add(semilavorato);
                AggiornaCatalogo();
            }
        }//carica la distinta base selezionata dall'utente nel catalogo

        private void Btn_AggiungiMateriaPrima_Click(object sender, EventArgs e)
        {
            //apro una nuova finestra dove l'utente deve inserire tutte le info del nuovo materiale (nome,id,descr,LT,LTS,ecc...)
            form2 = new Form2_NewNode("", "", new Node());
            form2.ShowDialog();
            Node nodo = form2.nodo;
            while (nodo == null)
            {
                if (!form2.attendo)
                {
                    return;
                }
            }
            Catalogo.Add(nodo);
            AggiornaCatalogo();

        }//crea un nodo con info date in input dall'utente



        private void listView_catalogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView_catalogo.SelectedItems.Count == 0) { return; }
            ListViewItem item = listView_catalogo.SelectedItems[0];
            string Nome = item.SubItems[0].Text;
            string Codice = item.SubItems[1].Text;
            bool OK = true;
            foreach (Node nodo in Catalogo)
            {
                if (nodo.Nome == Nome && nodo.Codice == Codice && OK)
                {
                    Form2_NewNode form2 = new Form2_NewNode("MODIFICA MATERIALE", "MODIFICA", nodo);
                    form2.ShowDialog();
                    Node nuovoNodo = form2.nodo;
                    while (nuovoNodo == null)
                    {
                        if (!form2.attendo)
                        {
                            return;
                        }
                    }
                    nuovoNodo.SottoNodi = nodo.SottoNodi;
                    Catalogo.Remove(nodo);
                    Catalogo.Add(nuovoNodo);
                    AggiornaCatalogo();
                    OK = false;
                    listView_catalogo.SelectedItems.Clear();
                    return;
                }
            }
        }//doppio click su un elemento del catalogo e modifico



        private void listView_catalogo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) { return; }
            Cms_ListBox.Show(listView_catalogo, e.Location);
        }//click destro su una riga della listbox apre contextMenu

        private void rimuoviToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView_catalogo.SelectedItems.Count == 0) { return; }
            ListViewItem item = listView_catalogo.SelectedItems[0];
            string Nome = item.SubItems[0].Text;
            string Codice = item.SubItems[1].Text;
            bool OK = true;
            foreach (Node nodo in Catalogo)
            {
                if (nodo.Nome == Nome && nodo.Codice == Codice && OK)
                {
                    Catalogo.Remove(nodo);
                    OK = false;
                    AggiornaCatalogo();
                    listView_catalogo.SelectedItems.Clear();
                    return;
                }
            }
        }//contextMenu listbox rimuove elemento selezionato

        private void informazioniToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView_catalogo.SelectedItems.Count == 0) { return; }
            ListViewItem item = listView_catalogo.SelectedItems[0];
            string Nome = item.SubItems[0].Text;
            string Codice = item.SubItems[1].Text;
            bool OK = true;
            foreach (Node nodo in Catalogo)
            {
                if (nodo.Nome == Nome && nodo.Codice == Codice && OK)
                {
                    string info = "Nome --> " + nodo.Nome + "\nCodice --> " + nodo.Codice + "\nDescrizione --> " + nodo.Descrizione + "\nLeadTime --> " + nodo.LeadTime + "\nLeadTimeSicurezza --> " + nodo.LeadTimeSicurezza + "\nLotto --> " + nodo.Lotto + "\nScortaDiSicurezza --> " + nodo.ScortaSicurezza + "\nPeriodoDiCopertura --> " + nodo.PeriodoDiCopertura;
                    OK = false;
                    listView_catalogo.SelectedItems.Clear();
                    MessageBox.Show(info, "INFORMAZIONI", MessageBoxButtons.OK);
                }
            }
        }//contextMenu listbox da info elemento selezionato

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_catalogo.SelectedItems.Count == 0) { return; }
            ListViewItem item = listView_catalogo.SelectedItems[0];
            string Nome = item.SubItems[0].Text;
            string Codice = item.SubItems[1].Text;
            bool OK = true;
            foreach (Node nodo in Catalogo)
            {
                if (nodo.Nome == Nome && nodo.Codice == Codice && OK)
                {
                    Form2_NewNode form2 = new Form2_NewNode("MODIFICA MATERIALE", "MODIFICA", nodo);
                    form2.ShowDialog();
                    Node nuovoNodo = form2.nodo;
                    while (nuovoNodo == null)
                    {
                        if (!form2.attendo)
                        {
                            return;
                        }
                    }
                    nuovoNodo.SottoNodi = nodo.SottoNodi;
                    Catalogo.Remove(nodo);
                    Catalogo.Add(nuovoNodo);
                    AggiornaCatalogo();
                    OK = false;
                    listView_catalogo.SelectedItems.Clear();
                    return;
                }
            }
        }//contextMenu listbox modifica elemento selezionato



        private void AggiornaCatalogo()
        {
            listView_catalogo.Items.Clear();
            foreach (Node n in Catalogo)
            {
                string[] items = { n.Nome, n.Codice, n.Descrizione };
                ListViewItem ListViewNodo = new ListViewItem(items);
                listView_catalogo.Items.Add(ListViewNodo);
            }
        }//aggiorna il catalogo listbox guardando la list<node> catalogo;

        private void CreaListView()
        {
            listView_catalogo.View = View.Details;
            listView_catalogo.FullRowSelect = true;
            listView_catalogo.Columns.Add("Nome", 90);
            listView_catalogo.Columns.Add("Codice", 80);
            listView_catalogo.Columns.Add("Descrizione", 170);
        }//Crea le colonne della listView  (NOME CODICE DESCRIZIONE) <--- di ogni prodotto

        private void listView_catalogo_ColumnWidthChanging_1(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView_catalogo.Columns[e.ColumnIndex].Width;
        }//blocca l'allargamento delle colonne da parte dell'utente

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //DistintaBase-----------------------------------------------------------------------------------------------------------------------------------------------

        private void Btn_SalvaDistintaBase_Click(object sender, EventArgs e)
        {
            SaveFileDialog Sfd_DistintaBase = new SaveFileDialog();
            Sfd_DistintaBase.InitialDirectory = @"C:\";
            Sfd_DistintaBase.RestoreDirectory = true;
            Sfd_DistintaBase.FileName = "*.xml";
            Sfd_DistintaBase.DefaultExt = "xml";
            Sfd_DistintaBase.Filter = "xml files (*.xml)|*.xml";
            if (Sfd_DistintaBase.ShowDialog() == DialogResult.OK)
            {
                Stream filesStream = Sfd_DistintaBase.OpenFile();
                StreamWriter sw = new StreamWriter(filesStream);
                //distintaBase.catalogo = NodiTreeView;
                salvataggio.SalvaDistintaBase(distintaBase.TreeViewToNode(treeView_DistintaBase), sw);
                sw.Close();
                filesStream.Close();
                treeView_DistintaBase.Nodes.Clear();
                ControlloTreeView();
            }
        } //BTN salva la distinta base

        private void Btn_resettaDistintaBase_Click(object sender, EventArgs e)
        {
            treeView_DistintaBase.Nodes.Clear();
            distintaBase.catalogo.Clear();
            ControlloTreeView();
        } //BTN resetta la distinta base



        private void Btn_CaricaDistintaBase_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ofd_DistintaBase = new OpenFileDialog();
            Ofd_DistintaBase.InitialDirectory = @"C:\";
            Ofd_DistintaBase.Filter = "XML|*.xml";
            Node nodo = new Node();
            if (Ofd_DistintaBase.ShowDialog() == DialogResult.OK)
            {
                string filePosition = Ofd_DistintaBase.FileName;
                treeView_DistintaBase.Nodes.Clear();
                nodo = salvataggio.CaricaDistintaBase(filePosition);
                treeView_DistintaBase.Nodes.Add(distintaBase.NodeToTreeNode(nodo));
            }
            ControlloTreeView();
            distintaBase.catalogo.Add(nodo);
        } //BTN carica la distinta base selezionata

        private void Btn_caricaDaCatalogo_Click(object sender, EventArgs e)
        {
            //prende il prodotto selezionato nella listbox(catalogo) e lo aggiunge alla treeview che è vuota
            /*if (listView_catalogo.SelectedItems.Count == 0) return;

            ListViewItem item = listView_catalogo.SelectedItems[0];
            string Nome = item.SubItems[0].Text;
            string Codice = item.SubItems[1].Text;
            bool aggiungere = true;
            Node nodo = new Node();
            foreach (Node node in Catalogo)
            {
                if (node.Nome == Nome && node.Codice == Codice && aggiungere)
                {
                    nodo = node;
                    treeView_DistintaBase.Nodes.Add(distintaBase.NodeToTreeNode(node));
                    aggiungere = false;
                    listView_catalogo.SelectedItems.Clear();
                }
            }
            ControlloTreeView();
            distintaBase.catalogo.Add(nodo);*/
            if(Catalogo.Count==0)
            {
                //messsageBox catalogo vuoto
                return;
            }
            Form3_Catalogo form3 = new Form3_Catalogo(Catalogo);
            form3.ShowDialog();
            while (form3.nodo == null)
            {
                if(!form3.attendo)
                {
                    return;
                }
            }
            Node node = form3.nodo;
            treeView_DistintaBase.Nodes.Add(distintaBase.NodeToTreeNode(node));
            ControlloTreeView();
            distintaBase.catalogo.Add(node);
            listView_catalogo.SelectedItems.Clear();
        } //BTN carica un nodo dal catalogo

        private void Btn_creaNuovaDistintaBase_Click(object sender, EventArgs e)
        {
            string titolo = "CREAZIONE NUOVA DISTINTA BASE";
            string button = "CREA";
            form2 = new Form2_NewNode(titolo, button, new Node());
            form2.ShowDialog();
            Node nodo = form2.nodo;
            while (nodo == null)
            {
                if (!form2.attendo)
                {
                    return;
                }
            }
            treeView_DistintaBase.Nodes.Add(distintaBase.NodeToTreeNode(nodo));
            ControlloTreeView();
            distintaBase.catalogo.Add(nodo);
        } //BTN crea una nuova distinta base



        private void treeView_DistintaBase_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Node nodo = distintaBase.TreeNodeToNode(treeView_DistintaBase.SelectedNode);
            Form2_NewNode form2 = new Form2_NewNode("MODIFICA MATERIALE", "MODIFICA", nodo);
            form2.ShowDialog();
            Node nuovoNodo = form2.nodo;
            while (nuovoNodo == null)
            {
                if (!form2.attendo)
                {
                    return;
                }
            }
            nuovoNodo.SottoNodi = nodo.SottoNodi;
            distintaBase.catalogo.Remove(nodo);
            distintaBase.catalogo.Add(nuovoNodo);
            treeView_DistintaBase.Nodes.Remove(treeView_DistintaBase.SelectedNode);
            treeView_DistintaBase.Nodes.Insert(treeView_DistintaBase.Nodes.Count, distintaBase.NodeToTreeNode(nuovoNodo));
            treeView_DistintaBase.SelectedNode = distintaBase.NodeToTreeNode(nuovoNodo);
            return;
        }//doppio click su nodo mi permette di modificarlo



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
            treeView_DistintaBase.SelectedNode.Remove();
            ControlloTreeView();
        }//context menu click destro nodo rimuove nodo

        private void informazioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //distintaBase.catalogo = NodiTreeView;
            Node nodo = distintaBase.TreeNodeToNode(treeView_DistintaBase.SelectedNode);
            string info = "Nome --> " + nodo.Nome + "\nCodice --> " + nodo.Codice + "\nDescrizione --> " + nodo.Descrizione + "\nLeadTime --> " + nodo.LeadTime + "\nLeadTimeSicurezza --> " + nodo.LeadTimeSicurezza + "\nLotto --> " + nodo.Lotto + "\nScortaDiSicurezza --> " + nodo.ScortaSicurezza + "\nPeriodoDiCopertura --> " + nodo.PeriodoDiCopertura;
            MessageBox.Show(info, "INFORMAZIONI", MessageBoxButtons.OK);
        }//context menu click destro nodo mostra info

        private void daCatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (listView_catalogo.SelectedItems.Count == 0) return;

            ListViewItem item = listView_catalogo.SelectedItems[0];
            string Nome = item.SubItems[0].Text;
            string Codice = item.SubItems[1].Text;
            bool aggiungere = true;
            Node nodo = new Node();
            foreach (Node node in Catalogo)
            {
                if (node.Nome == Nome && node.Codice == Codice && aggiungere)
                {
                    treeView_DistintaBase.SelectedNode.Nodes.Add(distintaBase.NodeToTreeNode(node));
                    nodo = node;
                    aggiungere = false;
                    listView_catalogo.SelectedItems.Clear();
                }
            }
            distintaBase.catalogo.Add(nodo);
            ControlloTreeView();*/
            if (Catalogo.Count == 0)
            {
                //messsageBox catalogo vuoto
                return;
            }
            Form3_Catalogo form3 = new Form3_Catalogo(Catalogo);
            form3.ShowDialog();
            while (form3.nodo == null)
            {
                if (!form3.attendo)
                {
                    return;
                }
            }
            Node node = form3.nodo;
            treeView_DistintaBase.SelectedNode.Nodes.Add(distintaBase.NodeToTreeNode(node)); ControlloTreeView();
            ControlloTreeView();
            distintaBase.catalogo.Add(node);
            listView_catalogo.SelectedItems.Clear();
        }//context menu click destro nodo mostra caricaNodo da Catalogo

        private void daFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ofd_DistintaBase = new OpenFileDialog();
            Ofd_DistintaBase.Filter = "XML|*.xml";
            Node nodo = new Node();
            if (Ofd_DistintaBase.ShowDialog() == DialogResult.OK)
            {
                string filePosition = Ofd_DistintaBase.FileName;
                nodo = salvataggio.CaricaDistintaBase(filePosition);
                treeView_DistintaBase.SelectedNode.Nodes.Add(distintaBase.NodeToTreeNode(nodo));
            }
            distintaBase.catalogo.Add(nodo);
            ControlloTreeView();
        }//context menu click destro nodo mostra caricaNodo da File

        private void creaNuovoNodoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string titolo = "CREAZIONE NUOVO NODO";
            string button = "CREA";
            form2 = new Form2_NewNode(titolo, button, new Node());
            form2.ShowDialog();
            Node nodo = form2.nodo;
            while (nodo == null)
            {
                if (!form2.attendo)
                {
                    return;
                }
            }
            treeView_DistintaBase.SelectedNode.Nodes.Add(distintaBase.NodeToTreeNode(nodo));
            ControlloTreeView();
            distintaBase.catalogo.Add(nodo);
        }//context menu click destro nodo mostra creaNuovoNodo
        




    private void ControlloTreeView()
    {
        if (treeView_DistintaBase.Nodes.Count == 0)
        {
            Btn_caricaDaCatalogo.Visible = true;
            Btn_CaricaDistintaBase.Visible = true;
            Btn_creaNuovaDistintaBase.Visible = true;
            Btn_resettaDistintaBase.Visible = false;
            Btn_SalvaDistintaBase.Visible = false;
        }
        else
        {
            Btn_caricaDaCatalogo.Visible = false;
            Btn_CaricaDistintaBase.Visible = false;
            Btn_creaNuovaDistintaBase.Visible = false;
            Btn_resettaDistintaBase.Visible = true;
            Btn_SalvaDistintaBase.Visible = true;
        }
    }//controlla se treeview è vuota, se vuota abilita i bottoni "crea nuova distinta base"

        private void modificaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Node nodo = distintaBase.TreeNodeToNode(treeView_DistintaBase.SelectedNode);
            Form2_NewNode form2 = new Form2_NewNode("MODIFICA MATERIALE", "MODIFICA", nodo);
            form2.ShowDialog();
            Node nuovoNodo = form2.nodo;
            while (nuovoNodo == null)
            {
                if (!form2.attendo)
                {
                    return;
                }
            }
            nuovoNodo.SottoNodi = nodo.SottoNodi;
            distintaBase.catalogo.Remove(nodo);
            distintaBase.catalogo.Add(nuovoNodo);
            treeView_DistintaBase.Nodes.Remove(treeView_DistintaBase.SelectedNode);
            treeView_DistintaBase.Nodes.Insert(treeView_DistintaBase.Nodes.Count, distintaBase.NodeToTreeNode(nuovoNodo));
            treeView_DistintaBase.SelectedNode = distintaBase.NodeToTreeNode(nuovoNodo);
            return;
        }

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
