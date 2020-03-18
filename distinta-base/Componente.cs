using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace distinta_base
{
    /// <summary>
    /// Classe utilizzata per creare un albero.
    /// </summary>
    class Componente
    {
        public List<Nodo> CreaAlbero(TreeView treeView)
        {
            List<Nodo> nodi = new List<Nodo>();
            TreeNodeCollection nodes = treeView.Nodes;

            // Crea le radici
            foreach (TreeNode n in nodes)
            {
                nodi.Add(CreaNodo(n));
            }
            return nodi;
        }

        public Nodo CreaNodo(TreeNode treeNode)
        {
            Nodo n = new Nodo
            {
                Nome = treeNode.Text,
                Figli = new List<Nodo>()
            };

            // Crea un nodo per ogni figlio 
            foreach (TreeNode tn in treeNode.Nodes)
            {
                n.Figli.Add(CreaNodo(tn));
            }
            return n;
        }



        public List<TreeNode> CreaTreeAlbero(List<Nodo> ciao)
        {
            List<TreeNode> t = new List<TreeNode>();

            foreach (Nodo n in ciao)
            {
                t.Add(CreaTreeNodo(n));
            }
            return t;
        }

        public TreeNode CreaTreeNodo(Nodo n)
        {
            TreeNode ris = new TreeNode(n.Nome);
            foreach (Nodo q in n.Figli)
            {
                ris.Nodes.Add(CreaTreeNodo(q));
            }
            return ris;
        }
    }
}
