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
        public Componente Albero = new Componente();

        /// <summary>
        /// Ritorna tutti i nodi presenti nell'albero.
        /// </summary>
        public List<Componente> Nodi()
        {
            Componente componente = Albero;
            List<Componente> nodi = new List<Componente>();
            if (componente.SottoNodi != null)
            {
                foreach (Componente sottoComp in componente.SottoNodi)
                {
                    TrovaNodi(sottoComp,nodi);
                }
            }
            if (componente.Nome != null) nodi.Add(componente);
            return nodi;
        }

        /// <summary>
        /// Trova il nodo o nodi selezionati.
        /// </summary>
        /// <param name="componente">Il componente da trovare.</param>
        /// <param name="nodi">I nodi dell'albero (radice e i suoi sottonodi).</param>
        /// <returns></returns>
        public List<Componente> TrovaNodi(Componente componente, List<Componente> nodi)
        {
            if (componente.SottoNodi != null)
            {
                foreach (Componente sottoComp in componente.SottoNodi)
                {
                    TrovaNodi(sottoComp, nodi);
                }
            }
            if (componente.Nome != null) nodi.Add(componente);
            return nodi;
        }

        /// <summary>
        /// Trasforma un TreeNode (WinForms.TreeView) in un Nodo (custom).
        /// </summary>
        /// <param name="TreeNode">Il TreeNode da trasformare.</param>
        /// <returns></returns>
        public Componente TreeNodeToNode(TreeNode TreeNode)
        {
            Componente Componente = new Componente();
            List<Componente> nodi = Nodi();
            foreach (Componente Nodo in nodi)
            {
                if (Nodo.Codice == TreeNode.Tag.ToString() && Nodo.SottoNodi.Count == TreeNode.Nodes.Count)
                {
                    Componente = Nodo;
                }
            }
            return Componente;
        }

        /// <summary>
        /// Trasforma un Nodo (custom) in un TreeNode (WinForms.TreeView).
        /// </summary>
        /// <param name="Node">Il nodo da trasformare.</param>
        /// <returns></returns>
        public TreeNode NodeToTreeNode(Componente Node)
        {
            string Nome = Node.Nome;
            if (!(Albero == Node) && Node.CoefficenteUtilizzo > 1)
            {
                Nome = Node.CoefficenteUtilizzo + "× " + Nome;
            }

            TreeNode treeNode = new TreeNode(Nome)
            {
                Tag = Node.Codice
            };
            if (Node.SottoNodi != null && Node.SottoNodi.Count > 0)
            {
                foreach (Componente node in Node.SottoNodi)
                {
                    treeNode.Nodes.Add(NodeToTreeNode(node));
                }
            }
            return treeNode;
        }

        /// <summary>
        /// Salva l'albero.
        /// </summary>
        public void Salva()
        {
            List<Componente> nodi = Nodi();
            if (nodi.Count == 0) return;
            SaveFileDialog Sfd_DistintaBase = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                RestoreDirectory = true,
                FileName = Albero.Nome + "_DistintaBase.xml",
                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml"
            };
            if (Sfd_DistintaBase.ShowDialog() == DialogResult.OK)
            {
                Stream filesStream = Sfd_DistintaBase.OpenFile();
                StreamWriter sw = new StreamWriter(filesStream);
                XmlSerializer serializer = new XmlSerializer(typeof(Componente));
                serializer.Serialize(sw, Albero);
                sw.Close();
                filesStream.Close();
            }
        }

        /// <summary>
        /// Carica un albero.
        /// </summary>
        public Componente Carica()
        {
            OpenFileDialog Ofd_Catalogo = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = "XML|*.xml"
            };
            Componente risultato = null;

            if (Ofd_Catalogo.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(Ofd_Catalogo.FileName))
                {
                    StreamReader stream = new StreamReader(Ofd_Catalogo.FileName);
                    XmlSerializer serializer = new XmlSerializer(typeof(Componente));
                    try
                    {
                        risultato = (Componente)serializer.Deserialize(stream);
                    }
                    catch
                    {
                        MessageBox.Show("Il file caricato non è un file di tipo 'DistintaBase'.", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    stream.Close();
                }
            }
            return risultato;
        }

        /// <summary>
        /// Carica un componente dal catalogo.
        /// </summary>
        public Componente CaricaDaCatalogo(List<Componente> Componenti)
        {
            Form3_Catalogo form3 = new Form3_Catalogo(Componenti);
            form3.ShowDialog();
            Componente nodo = form3.nodo;
            while (form3.nodo == null)
            {
                if (!form3.attendo)
                {
                    return null;
                }
            }
            return nodo;
        }

        /// <summary>
        /// Carica un nodo.
        /// </summary>
        public Componente CaricaNodoDaFile()
        {
            OpenFileDialog Ofd_Catalogo = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = "XML|*.xml"
            };
            Componente risultato = null;
            if (Ofd_Catalogo.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(Ofd_Catalogo.FileName))
                {
                    StreamReader stream = new StreamReader(Ofd_Catalogo.FileName);
                    XmlSerializer serializer = new XmlSerializer(typeof(Componente));
                    risultato = (Componente)serializer.Deserialize(stream);
                    stream.Close();
                }
            }
            return risultato;
        }
    }
}
