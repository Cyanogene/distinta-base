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
                MessageBox.Show("Il catalogo è vuoto.", "Distinta Base");
                return;
            }
            SaveFileDialog Sfd_Catalogo = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                RestoreDirectory = true,
                FileName = "*_Catalogo.xml",
                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml"
            };
            if (Sfd_Catalogo.ShowDialog() == DialogResult.OK)
            {
                Stream filesStream = Sfd_Catalogo.OpenFile();
                StreamWriter sw = new StreamWriter(filesStream);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Componente>));
                serializer.Serialize(sw, Nodi);
                sw.Close();
                filesStream.Close();
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
                List<Componente> risultato = new List<Componente>();
                if (File.Exists(Ofd_Catalogo.FileName))
                {
                    StreamReader stream = new StreamReader(Ofd_Catalogo.FileName);
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Componente>));
                    try
                    {
                        risultato = (List<Componente>)serializer.Deserialize(stream);
                        Nodi.Clear();
                        Nodi.AddRange(risultato);
                    }
                    catch
                    {
                        MessageBox.Show("Il file caricato non è un file di tipo 'Catalogo'.", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    stream.Close();
                }
            }
        }

        /// <summary>
        /// Carica un semilavorato.
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
        /// <param name="componente">Il componente da modificare.</param>
        /// <param name="Componenti">La lista di tutti i componenti.</param>
        /// <returns></returns>
        public Componente Modifica(Componente componente, List<Componente> Componenti)
        {
            Form2_NewNode form2 = new Form2_NewNode(componente, Componenti);
            form2.ShowDialog();
            Componente ComponenteForm = form2.nodo;
            while (ComponenteForm == null)
            {
                if (!form2.attendo)
                {
                    return null;
                }
            }
            return Componente.DeepClone<Componente>(ComponenteForm);
        }

        /// <summary>
        /// Carica un componente.
        /// </summary>
        /// <param name="filePosition">Il nome del file.</param>
        /// <returns></returns>
        private Componente CaricaComponenteDaFile(string filePosition)
        {
            Componente componente = new Componente();
            if (File.Exists(filePosition))
            {
                StreamReader stream = new StreamReader(filePosition);
                XmlSerializer serializer = new XmlSerializer(typeof(Componente));
                try
                {
                    componente = (Componente)serializer.Deserialize(stream);
                }
                catch
                {
                    MessageBox.Show("Il file caricato non è un file di tipo 'Catalogo'.", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                stream.Close();
            }
            return componente;
        }
    }
}
