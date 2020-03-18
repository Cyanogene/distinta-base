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
            RimuoviNodo(treeView1.Nodes);
        }

        void RimuoviNodo(TreeNodeCollection nodi)
        {
            foreach (TreeNode node in TreeNodes)
            {
                node.Nodes.Remove(node);
            }
        }
    }
}
