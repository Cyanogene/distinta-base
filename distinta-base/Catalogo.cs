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
    class Catalogo
    {
        public List<Componente> Nodi = new List<Componente>();

        /// <summary>
        /// Salva un catalogo.
        /// </summary>
        public void Salva()
        {
            if (Nodi.Count == 0)
            {
                MessageBox.Show("Il catalogo è vuoto.", "Distinta Base",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            SaveFileDialog Sfd_Catalogo = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                RestoreDirectory = true,
                FileName = "Catalogo.xml",
                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml"
            };
            if (Sfd_Catalogo.ShowDialog() == DialogResult.OK)
            {
                Stream FilesStream = Sfd_Catalogo.OpenFile();
                StreamWriter Sw = new StreamWriter(FilesStream);
                XmlSerializer Serializer = new XmlSerializer(typeof(List<Componente>));
                Serializer.Serialize(Sw, Nodi);
                Sw.Close();
                FilesStream.Close();
            }
        }

        /// <summary>
        /// Carica un catalogo.
        /// </summary>
        public void Carica()
        {
            OpenFileDialog Ofd_Catalogo = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = "XML|*.xml"
            };

            List<Componente> NodiCatalogo = new List<Componente>();

            if (Ofd_Catalogo.ShowDialog() == DialogResult.OK)
            {
                List<Componente> Risultato = new List<Componente>();
                if (File.Exists(Ofd_Catalogo.FileName))
                {
                    StreamReader Stream = new StreamReader(Ofd_Catalogo.FileName);
                    XmlSerializer Serializer = new XmlSerializer(typeof(List<Componente>));
                    try
                    {
                        Risultato = (List<Componente>)Serializer.Deserialize(Stream);
                        Nodi.Clear();
                        Nodi.AddRange(Risultato);
                    }
                    catch
                    {
                        MessageBox.Show("Il file caricato non è  di tipo 'Catalogo'.", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    Stream.Close();
                }
            }
        }

        /// <summary>
        /// Carica un semilavorato in catalogo.
        /// </summary>
        public Componente AggiungiSemilavorato()
        {
            OpenFileDialog Ofd_semilavorato = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = "XML|*.xml"
            };
            if (Ofd_semilavorato.ShowDialog() == DialogResult.OK)
            {
                return CaricaComponenteDaFile(Ofd_semilavorato.FileName);
            }
            return null;
        }
        
        /// <summary>
        /// Modifica il componente selezionato.
        /// </summary>
        /// <param name="Componente">Il componente da modificare.</param>
        /// <param name="Componenti">La lista di tutti i componenti.</param>
        /// <returns></returns>
        public Componente Modifica(Componente Componente, List<Componente> Componenti)
        {
            Form2_NewNode Form2 = new Form2_NewNode(Componente, Componenti, true);
            Form2.ShowDialog();
            Componente ComponenteForm = Form2.Nodo;
            while (ComponenteForm == null)
            {
                if (!Form2.Attendo)
                {
                    return null;
                }
            }
            return Componente.DeepClone<Componente>(ComponenteForm);
        }

        /// <summary>
        /// Carica un componente da file xml.
        /// </summary>
        /// <param name="FilePosition">Il nome del file.</param>
        /// <returns></returns>
        private Componente CaricaComponenteDaFile(string FilePosition)
        {
            Componente Componente = new Componente();
            if (File.Exists(FilePosition))
            {
                StreamReader Stream = new StreamReader(FilePosition);
                XmlSerializer Serializer = new XmlSerializer(typeof(Componente));
                try
                {
                    Componente = (Componente)Serializer.Deserialize(Stream);
                }
                catch
                {
                    MessageBox.Show("Il file caricato non è un file di tipo 'Catalogo'.", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Stream.Close();
            }
            return Componente;
        }
    }
}
