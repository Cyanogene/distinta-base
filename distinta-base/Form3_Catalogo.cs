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
        public Form3_Catalogo(List<Componente> input)
        {
            nodiCatalogo = input;
            InitializeComponent();
            label1.BackColor = Color.FromArgb(232, 190, 118);
        }

        public List<Componente> nodiCatalogo { get; set; }
        public Componente nodo { get; set; }
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
            Componente n = new Componente();
            foreach (Componente node in nodiCatalogo)
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
            int i = 0;
            listView1.Items.Clear();
            foreach (Componente n in nodiCatalogo)
            {
                string[] items = { n.Nome, n.Codice, n.Descrizione };
                ListViewItem ListViewNodo = new ListViewItem(items);
                ListViewNodo.Font = new Font("Microsoft Tai Le", 12);
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
            CenterToParent();
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            string Nome = item.SubItems[0].Text;
            string Codice = item.SubItems[1].Text;
            bool aggiungere = true;
            Componente n = new Componente();
            foreach (Componente node in nodiCatalogo)
            {
                if (node.Nome == Nome && node.Codice == Codice && aggiungere)
                {
                    n = node;
                }
            }
            nodo = n;
            Close();
        }
    }
}
