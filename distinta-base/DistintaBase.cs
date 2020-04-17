using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace distinta_base
{
    /// <summary>
    /// Classe utilizzata per creare un albero.
    /// </summary>
    
    class DistintaBase
    {
        public List<Componente> Nodi = new List<Componente>();

        public Componente TreeViewToNode(TreeView TreeView)
        {
            List<Componente> TreeViewInNodeList = new List<Componente>();
            TreeNodeCollection TreeNodes = TreeView.Nodes;

            // Crea le radici
            foreach (TreeNode n in TreeNodes)
            {
                TreeViewInNodeList.Add(TreeNodeToNode(n));
            }
            return TreeViewInNodeList[0];
        }

        public Componente TreeNodeToNode(TreeNode TreeNode)
        {
            Componente TreeNodeInNode = new Componente
            {
                SottoNodi = new List<Componente>()
            };
            foreach (Componente Nodo in Nodi)
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
        
        public TreeNode NodeToTreeNode(Componente Node)
        {
            TreeNode Nodo = new TreeNode(Node.Nome);
            Nodo.Tag = Node.Codice;
            if(Node.SottoNodi!=null)
            {
                foreach (Componente node in Node.SottoNodi)
                {
                    Nodo.Nodes.Add(NodeToTreeNode(node));
                }
            }
            return Nodo;
        }

        public void Salva(Componente nodi, StreamWriter sw)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Componente));
            serializer.Serialize(sw, nodi);
            sw.Close();
        }

        public Componente Carica(string filePosition)
        {
            Componente risultato = new Componente();
            if (File.Exists(filePosition))
            {
                StreamReader stream = new StreamReader(filePosition);
                XmlSerializer serializer = new XmlSerializer(typeof(Componente));
                risultato = (Componente)serializer.Deserialize(stream);
                stream.Close();
            }
            return risultato;
        }
    }
}
