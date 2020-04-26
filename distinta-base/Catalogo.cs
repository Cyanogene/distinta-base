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



        public void Salva()
        {
            if (Nodi.Count == 0)
            {
                MessageBox.Show("Il catalogo è vuoto", "ATTENZIONE");
                return;
            }
            SaveFileDialog Sfd_Catalogo = new SaveFileDialog();
            Sfd_Catalogo.InitialDirectory = @"C:\";
            Sfd_Catalogo.RestoreDirectory = true;
            Sfd_Catalogo.FileName = "*.xml";
            Sfd_Catalogo.DefaultExt = "xml";
            Sfd_Catalogo.Filter = "xml files (*.xml)|*.xml";
            if (Sfd_Catalogo.ShowDialog() == DialogResult.OK)
            {
                Stream filesStream = Sfd_Catalogo.OpenFile();
                StreamWriter sw = new StreamWriter(filesStream);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Componente>));
                serializer.Serialize(sw, Nodi);
                sw.Close();
                filesStream.Close();
            }
        }//

        public void Carica()
        {
            Nodi.Clear();
            OpenFileDialog Ofd_Catalogo = new OpenFileDialog();
            Ofd_Catalogo.InitialDirectory = @"C:\";
            Ofd_Catalogo.Filter = "XML|*.xml";

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
                    }
                    catch
                    {
                        MessageBox.Show("Il file caricato non è un file di tipo catalogo, si prega di caricare un file di tipo catalogo", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    stream.Close();
                }
                Nodi.AddRange(risultato);
            }
        }//



        public Componente AggiungiSemilavorato()
        {
            OpenFileDialog Ofd_semilavorato = new OpenFileDialog();
            Ofd_semilavorato.InitialDirectory = @"C:\";
            Ofd_semilavorato.Filter = "XML|*.xml";
            if (Ofd_semilavorato.ShowDialog() == DialogResult.OK)
            {
                return CaricaComponenteDaFile(Ofd_semilavorato.FileName);
            }
            return null;
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
                    return  null;
                }
            }
            return nodo;
        }//
        
        public void Modifica(Componente componente, List<Componente> Componenti)
        {
            Form2_NewNode form2 = new Form2_NewNode(componente, Componenti);
            form2.ShowDialog();
            Componente ComponenteForm = form2.nodo;
            while (ComponenteForm == null)
            {
                if (!form2.attendo)
                {
                    return;
                }
            }
            Componente NewComponente = new Componente
            {
                Nome = ComponenteForm.Nome,
                Codice = ComponenteForm.Codice,
                LeadTime = ComponenteForm.LeadTime,
                LeadTimeSicurezza = ComponenteForm.LeadTimeSicurezza,
                Descrizione = ComponenteForm.Descrizione,
                PeriodoDiCopertura = ComponenteForm.PeriodoDiCopertura,
                ScortaSicurezza = ComponenteForm.ScortaSicurezza,
                Lotto = ComponenteForm.Lotto,
                SottoNodi = componente.SottoNodi,
            };
            Nodi.Remove(componente);
            Nodi.Add(NewComponente);
        }//

        public void SostituisciComponente(Componente comp)
        {
            List<Componente> sottonodi = new List<Componente>();
            Componente componenteDaRimuovere = new Componente();
            foreach(Componente componente in Nodi)
            {
                if(componente.Codice == comp.Codice)
                {
                    componenteDaRimuovere = componente;
                }
            }
            Nodi.Remove(componenteDaRimuovere);
            Nodi.Add(comp);
        }

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
                    MessageBox.Show("Il file caricato non è un file di tipo catalogo, si prega di caricare un file di tipo catalogo", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                stream.Close();
            }
            return componente;
        }//
        
        
    }
}
