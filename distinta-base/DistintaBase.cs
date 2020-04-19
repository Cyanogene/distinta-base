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
        private List<Componente> Componenti = new List<Componente>();

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
                if (Nodo.Nome == TreeNode.Text && Nodo.Codice == TreeNode.Tag.ToString())
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
            if (Node.SottoNodi != null)
            {
                foreach (Componente node in Node.SottoNodi)
                {
                    Nodo.Nodes.Add(NodeToTreeNode(node));
                }
            }
            return Nodo;
        }




        public void Salva()
        {
            if (Nodi.Count == 0) return;
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
                XmlSerializer serializer = new XmlSerializer(typeof(Componente));
                serializer.Serialize(sw, Nodi);
                sw.Close();
                filesStream.Close();
            }
        }

        public Componente Carica(List<Componente> componenti)
        {
            Nodi.Clear();
            Componenti = componenti;
            OpenFileDialog Ofd_Catalogo = new OpenFileDialog();
            Ofd_Catalogo.InitialDirectory = @"C:\";
            Ofd_Catalogo.Filter = "XML|*.xml";
            Componente risultato = new Componente();

            if (Ofd_Catalogo.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(Ofd_Catalogo.FileName))
                {
                    StreamReader stream = new StreamReader(Ofd_Catalogo.FileName);
                    XmlSerializer serializer = new XmlSerializer(typeof(Componente));
                    risultato = (Componente)serializer.Deserialize(stream);
                    stream.Close();
                }
                Nodi.Add(risultato);
            }
            return risultato;
        }



        public bool EsisteComponente(Componente componente)
        {
            foreach (Componente comp in Componenti)
            {
                if (comp.Codice == componente.Codice)
                {
                    return true;
                }
                foreach (Componente comp2 in comp.SottoNodi)
                {
                    return EsisteComponente(comp2);
                }
            }
            return false;
        }

        private Componente CaricaComponenteDaFile(string filePosition)
        {
            Componente componente = new Componente();
            if (File.Exists(filePosition))
            {

                StreamReader stream = new StreamReader(filePosition);
                XmlSerializer serializer = new XmlSerializer(typeof(Componente));
                componente = (Componente)serializer.Deserialize(stream);
                stream.Close();
            }
            return componente;
        }
        
        public void CaricaNodoDaFile(List<Componente> componenti)
        {
            Componenti = componenti;
            OpenFileDialog Ofd_Catalogo = new OpenFileDialog();
            Ofd_Catalogo.InitialDirectory = @"C:\";
            Ofd_Catalogo.Filter = "XML|*.xml";
            Componente risultato = new Componente();

            if (Ofd_Catalogo.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(Ofd_Catalogo.FileName))
                {
                    StreamReader stream = new StreamReader(Ofd_Catalogo.FileName);
                    XmlSerializer serializer = new XmlSerializer(typeof(Componente));
                    risultato = (Componente)serializer.Deserialize(stream);
                    stream.Close();
                }
                if (!EsisteComponente(risultato))
                {
                    Nodi.Add(risultato);
                }
            }
        }
        
    }
}
