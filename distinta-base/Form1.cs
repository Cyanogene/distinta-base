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
    [Serializable]
    public partial class Form1 : Form
    {
        private Componente comp;
        public Form1()
        {
            InitializeComponent();
            comp = new Componente();
        }

        private void Btn_AggiungiFiglio_Click(object sender, EventArgs e)
        {
            TreeNode nodo = new TreeNode(textBox1.Text);
            treeView1.SelectedNode.Nodes.Add(nodo);
        }

        private void Btn_AggiungiRadice_Click(object sender, EventArgs e)
        {
            TreeNode nodo = new TreeNode(textBox1.Text);
            treeView1.Nodes.Add(nodo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nodo.SalvaAlbero(Nodo.CreaAlbero(treeView1));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<TreeNode> nodi = Nodo.CreaTreeAlbero(Nodo.CaricaAlbero());
            treeView1.Nodes.Clear();
            treeView1.Nodes.AddRange(nodi.ToArray());
        }

        //    treeView1.Nodes.Add("Parent");
        //    treeView1.Nodes[0].Nodes.Add("Child 1");
        //    treeView1.Nodes[0].Nodes.Add("Child 2");
        //    treeView1.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
        //    treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
    }
}
