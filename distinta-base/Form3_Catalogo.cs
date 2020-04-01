using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace distinta_base
{
    public partial class Form3_Catalogo : Form
    {
        public Form3_Catalogo(List<Node> input)
        {
            nodiCatalogo = input;
            InitializeComponent();
        }

        public List<Node> nodiCatalogo { get; set; }
        public Node nodo { get; set; }
        public bool attendo = true;

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                //messaggeBox
                return;
            }

            ListViewItem item = listView1.SelectedItems[0];
            string Nome = item.SubItems[0].Text;
            string Codice = item.SubItems[1].Text;
            bool aggiungere = true;
            Node n = new Node();
            foreach (Node node in nodiCatalogo)
            {
                if (node.Nome == Nome && node.Codice == Codice && aggiungere)
                {
                    n = node;
                }
            }
            nodo = n;
            Close();
        }

        private void AggiornaCatalogo()
        {
            listView1.Items.Clear();
            foreach (Node n in nodiCatalogo)
            {
                string[] items = { n.Nome, n.Codice, n.Descrizione };
                ListViewItem ListViewNodo = new ListViewItem(items);
                listView1.Items.Add(ListViewNodo);
            }
        }//aggiorna il catalogo listbox guardando la list<node> catalogo;

        private void CreaListView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Nome", 90);
            listView1.Columns.Add("Codice", 80);
            listView1.Columns.Add("Descrizione", 170);
        }//Crea le colonne della listView  (NOME CODICE DESCRIZIONE) <--- di ogni prodotto

        private void Form3_Catalogo_FormClosed(object sender, FormClosedEventArgs e)
        {
            attendo = false;
        }

        private void Form3_Catalogo_Load(object sender, EventArgs e)
        {
            CreaListView();
            AggiornaCatalogo();
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
        }
    }
}
