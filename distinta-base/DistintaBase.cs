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
    
    class DistintaBase
    {
        public List<Node> catalogo = new List<Node>();

        public Node TreeViewToNode(TreeView TreeView)
        {
            List<Node> TreeViewInNodeList = new List<Node>();
            TreeNodeCollection TreeNodes = TreeView.Nodes;

            // Crea le radici
            foreach (TreeNode n in TreeNodes)
            {
                TreeViewInNodeList.Add(TreeNodeToNode(n));
            }
            return TreeViewInNodeList[0];
        }

        public Node TreeNodeToNode(TreeNode TreeNode)
        {
            Node TreeNodeInNode = new Node
            {
                SottoNodi = new List<Node>()
            };
            foreach (Node Nodo in catalogo)
            {
                if(Nodo.Nome == TreeNode.Text && Nodo.Codice == TreeNode.Tag.ToString())
                {
                    TreeNodeInNode = Nodo;
                }
            }

            // Crea un nodo per ogni figlio 
            foreach (TreeNode tn in TreeNode.Nodes)
            {
                TreeNodeInNode.SottoNodi.Add(TreeNodeToNode(tn));
            }
            return TreeNodeInNode;
        }
        
        /*public TreeView NodeToTreeView(Node TreeList)
        {
            TreeView TreeView = new TreeView();
            TreeView.Nodes.Add(NodeToTreeNode(TreeList));
            return TreeView;
        }*/

        public TreeNode NodeToTreeNode(Node Node)
        {
            TreeNode Nodo = new TreeNode(Node.Nome);
            Nodo.Tag = Node.Codice;
            if(Node.SottoNodi!=null)
            {
                foreach (Node node in Node.SottoNodi)
                {
                    Nodo.Nodes.Add(NodeToTreeNode(node));
                }
            }
            return Nodo;
        }
    }
}
