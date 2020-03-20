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
    public partial class Form1 : Form
    {
        private Componente componente;
        private Salvataggio salvataggio;
        List<TreeNode> TreeNodes = new List<TreeNode>();

        public Form1()
        {
            InitializeComponent();
            componente = new Componente();
            salvataggio = new Salvataggio();
        }

        private void Btn_AggiungiFiglio_Click(object sender, EventArgs e)
        {
            AggiungiNodo(treeView1.Nodes);
            textBox1.Text = "";
        }

        void AggiungiNodo(TreeNodeCollection nodi)
        {
            foreach (TreeNode node in TreeNodes)
            {
                TreeNode nodo = new TreeNode(textBox1.Text);
                node.Nodes.Add(nodo);
            }
        }

        private void Btn_AggiungiRadice_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                TreeNode nodo = new TreeNode(textBox1.Text);
                treeView1.Nodes.Add(nodo);
                textBox1.Text = "";
            }
        }

        private void Btn_SvuotaMagazzino_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
        }

        private void Btn_SalvaMagazzino_Click(object sender, EventArgs e)
        {
            salvataggio.SalvaAlbero(componente.CreaAlbero(treeView1));
        }

        private void Btm_CaricaMagazzino_Click(object sender, EventArgs e)
        {
            List<TreeNode> nodi = componente.CreaTreeAlbero(salvataggio.CaricaAlbero());
            treeView1.Nodes.Clear();
            treeView1.Nodes.AddRange(nodi.ToArray());
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                TreeNodes.Add(e.Node);
            }
            else
            {
                TreeNodes.Remove(e.Node);
            }
            
        }

        private void Btn_RimuoviComponente_Click(object sender, EventArgs e)
        {
            //RimuoviNodo(treeView1.Nodes);
            foreach (ListViewItem l in listView1.Items)
            {
                if (l.Checked)
                {
                    listView1.Items.Remove(l);
                }
            }
        }

        void RimuoviNodo(TreeNodeCollection nodi)
        {
            foreach (TreeNode node in TreeNodes)
            {
                node.Nodes.Remove(node);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Nome Prodotto", 150);
            listView1.Columns.Add("Codice", 50);
            listView1.Columns.Add("Quantità", 55);
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
        }

        private void Btn_AggiungiMateriaPrima_Click(object sender, EventArgs e)
        {
            List<TextBox> controllo = new List<TextBox>() { txt_NomeProdotto, txt_Codice, txt_Quantità };

            foreach (TextBox c in controllo)
            {
                if (c.Text == string.Empty)
                {
                    MessageBox.Show("Controlla che tutti i campi siano compilati correttamente.", "Distinta base", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            string[] arr = new string[4];
            ListViewItem itm;
            arr[0] = txt_NomeProdotto.Text;
            arr[1] = txt_Codice.Text;
            arr[2] = txt_Quantità.Text;
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);
            textBox1.Text = "";
        }

        private void txt_Quantità_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_NomeProdotto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Btn_AggiungiSemilavorato_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in listView1.Items)
            {
                if (l.Checked)
                {
                    listView1.Items.Remove(l);
                }
            }
        }
    }
}
