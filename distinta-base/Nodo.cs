using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace distinta_base
{
    [Serializable]
    public class Nodo
    {
        public string val { get; set; }

        public List<Nodo> figli;

        public static List<Nodo> CreaAlbero(TreeView treeView)
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

        private static Nodo CreaNodo(TreeNode treeNode)
        {
            Nodo n = new Nodo
            {
                val = treeNode.Text,
                figli = new List<Nodo>()
            };

            // Crea un nodo per ogni figlio 
            foreach (TreeNode tn in treeNode.Nodes)
            {
                n.figli.Add(CreaNodo(tn));
            }
            return n;
        }

        public static void SalvaAlbero(List<Nodo> nodos)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Nodo>));
            StreamWriter stream = new StreamWriter("magazzino.xml");
            serializer.Serialize(stream, nodos);
        }

        public static List<Nodo> CaricaAlbero()
        {
            StreamReader stream = new StreamReader("magazzino.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Nodo>));
            List<Nodo> ciao = (List<Nodo>) serializer.Deserialize(stream);
            return ciao;
        }

        public static List<TreeNode> CreaTreeAlbero(List<Nodo> ciao)
        {
            List<TreeNode> t = new List<TreeNode>();

            foreach (Nodo n in ciao)
            {
                t.Add(CreaTreeNodo(n));
            }
            return t;
        }
        
        public static TreeNode CreaTreeNodo(Nodo n)
        {
            TreeNode ris = new TreeNode(n.val);
            foreach (Nodo q in n.figli)
            {
                ris.Nodes.Add(CreaTreeNodo(q));
            }
            return ris;
        }
    }
}
