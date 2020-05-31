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
            Componente Componente = Albero;
            List<Componente> Nodi = new List<Componente>();
            if (Componente.SottoNodi != null)
            {
                foreach (Componente SottoComp in Componente.SottoNodi)
                {
                    TrovaNodi(SottoComp,Nodi);
                }
            }
            if (Componente.Nome != null) Nodi.Add(Componente);
            return Nodi;
        }

        /// <summary>
        /// Trova il nodo o nodi selezionati.
        /// </summary>
        /// <param name="Componente">Il componente da trovare.</param>
        /// <param name="Nodi">I nodi dell'albero (radice e i suoi sottonodi).</param>
        /// <returns></returns>
        public List<Componente> TrovaNodi(Componente Componente, List<Componente> Nodi)
        {
            if (Componente.SottoNodi != null)
            {
                foreach (Componente sottoComp in Componente.SottoNodi)
                {
                    TrovaNodi(sottoComp, Nodi);
                }
            }
            if (Componente.Nome != null) Nodi.Add(Componente);
            return Nodi;
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
                foreach (Componente Nodo in Node.SottoNodi)
                {
                    treeNode.Nodes.Add(NodeToTreeNode(Nodo));
                }
            }
            return treeNode;
        }

        /// <summary>
        /// Salva l'albero.
        /// </summary>
        public void Salva()
        {
            List<Componente> Nodes = Nodi();
            if (Nodes.Count == 0) return;
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
                Stream FilesStream = Sfd_DistintaBase.OpenFile();
                StreamWriter sw = new StreamWriter(FilesStream);
                XmlSerializer serializer = new XmlSerializer(typeof(Componente));
                serializer.Serialize(sw, Albero);
                sw.Close();
                FilesStream.Close();
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
                    StreamReader Strem = new StreamReader(Ofd_Catalogo.FileName);
                    XmlSerializer serializer = new XmlSerializer(typeof(Componente));
                    try
                    {
                        risultato = (Componente)serializer.Deserialize(Strem);
                    }
                    catch
                    {
                        MessageBox.Show("Il file caricato non è un file di tipo 'DistintaBase'.", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    Strem.Close();
                }
            }
            return risultato;
        }

        /// <summary>
        /// Carica un componente dal catalogo.
        /// </summary>
        public Componente CaricaDaCatalogo(List<Componente> Componenti)
        {
            Form3_Catalogo Form3 = new Form3_Catalogo(Componenti);
            Form3.ShowDialog();
            Componente Nodo = Form3.Nodo;
            while (Form3.Nodo == null)
            {
                if (!Form3.Attendo)
                {
                    return null;
                }
            }
            return Nodo;
        }

        /// <summary>
        /// Carica un componente da file xml.
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
                    StreamReader Stream = new StreamReader(Ofd_Catalogo.FileName);
                    XmlSerializer Serializer = new XmlSerializer(typeof(Componente));
                    risultato = (Componente)Serializer.Deserialize(Stream);
                    Stream.Close();
                }
            }
            return risultato;
        }
    }
}
