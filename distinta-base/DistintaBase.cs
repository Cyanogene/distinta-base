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
        public List<Componente> Nodi = new List<Componente>();//

        public Componente Albero = new Componente();

        public void AggiornaNodi(Componente comp)
        {
            
            if(comp.SottoNodi!=null)
            {
                foreach (Componente sottoComp in comp.SottoNodi)
                {
                    AggiornaNodi(sottoComp);
                }
            }
            Nodi.Add(comp);
        }

        


        public Componente TreeNodeToNode(TreeNode TreeNode)
        {
            Componente Componente = new Componente();
            Nodi.Clear();
            AggiornaNodi(Albero);
            foreach (Componente Nodo in Nodi)
            {
                if (Nodo.Codice == TreeNode.Tag.ToString() && Nodo.SottoNodi.Count == TreeNode.Nodes.Count)
                {
                    Componente = Nodo;
                }
            }
            return Componente;
        }//

        public TreeNode NodeToTreeNode(Componente Node)
        {
            TreeNode treeNode = new TreeNode(Node.Nome);
            treeNode.Tag = Node.Codice;
            if (Node.SottoNodi != null && Node.SottoNodi.Count>0)
            {
                foreach (Componente node in Node.SottoNodi)
                {
                    treeNode.Nodes.Add(NodeToTreeNode(node));
                }
            }
            return treeNode;
        }//




        public void Salva(Componente nodo)
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
                serializer.Serialize(sw, nodo);
                sw.Close();
                filesStream.Close();
            }
        }//

        public Componente Carica()
        {
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
                    try
                    {
                        risultato = (Componente)serializer.Deserialize(stream);
                    }
                    catch
                    {
                        MessageBox.Show("Il file caricato non è un file di tipo distinta base, si prega di caricare un file di tipo distinta base", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                    stream.Close();
                }
            }

            return risultato;
        }//




        public Componente AggiungiMateriaPrima(List<Componente> Componenti)
        {
            Form2_NewNode form2 = new Form2_NewNode(new Componente(), Componenti);
            form2.ShowDialog();
            Componente nodo = form2.nodo;
            while (nodo == null)
            {
                if (!form2.attendo)
                {
                    return null;
                }
            }
            return nodo;
        }//

        public Componente CaricaDaCatalogo(List<Componente> Componenti)
        {
            Form3_Catalogo form3 = new Form3_Catalogo(Componenti);
            form3.ShowDialog();
            while (form3.nodo == null)
            {
                if (!form3.attendo)
                {
                    return null;
                }
            }
            return form3.nodo;
        }//
        
        public Componente CaricaNodoDaFile()
        {
            OpenFileDialog Ofd_Catalogo = new OpenFileDialog();
            Ofd_Catalogo.InitialDirectory = @"C:\";
            Ofd_Catalogo.Filter = "XML|*.xml";
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
