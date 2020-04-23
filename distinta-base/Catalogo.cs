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
        private List<Componente> Componenti = new List<Componente>();



        public void Salva()
        {
            if (Nodi.Count == 0)
            {
                //messaggio che dice che non puo salvare perchè non c'è nulla da salvare
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
        }

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
                    risultato = (List<Componente>)serializer.Deserialize(stream);
                    stream.Close();
                }
                Nodi.AddRange(risultato);
            }
        }



        public bool EsisteComponente(Componente componente)
        {
            foreach (Componente comp in Componenti)
            {
                if (comp.Codice == componente.Codice)
                {
                    return true;
                }
                foreach(Componente comp2 in comp.SottoNodi)
                {
                    return EsisteComponente(comp2);
                }
            }
            return false;
        }

        public bool EsisteComponenteInCatalogo(Componente comp)
        {
            foreach(Componente componente in Nodi)
            {
                if(comp.Codice == componente.Codice)
                {
                    return true;
                }
            }
            return false;
        }


        public void AggiungiSemilavorato(List<Componente> componenti)
        {
            Componenti = componenti;
            OpenFileDialog Ofd_semilavorato = new OpenFileDialog();
            Ofd_semilavorato.InitialDirectory = @"C:\";
            Ofd_semilavorato.Filter = "XML|*.xml";
            if (Ofd_semilavorato.ShowDialog() == DialogResult.OK)
            {
                Componente semilavorato = CaricaComponenteDaFile(Ofd_semilavorato.FileName);
                if (!EsisteComponente(semilavorato))
                {
                    Nodi.Add(semilavorato);
                }
            }
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

        public void AggiungiMateriaPrima(List<Componente> Componenti)
        {
            Form2_NewNode form2 = new Form2_NewNode(new Componente(), Componenti);
            form2.ShowDialog();
            Componente nodo = form2.nodo;
            while (nodo == null)
            {
                if (!form2.attendo)
                {
                    return;
                }
            }
            if (!EsisteComponente(nodo))
            {
                Nodi.Add(nodo);
            }
        }

        public string Info(string codice)
        {
            foreach (Componente nodo in Nodi)
            {
                if (nodo.Codice == codice)
                {
                    return "Nome --> " + nodo.Nome + "\nCodice --> " + nodo.Codice + "\nDescrizione --> " + nodo.Descrizione + "\nLeadTime --> " + nodo.LeadTime + "\nLeadTimeSicurezza --> " + nodo.LeadTimeSicurezza + "\nLotto --> " + nodo.Lotto + "\nScortaDiSicurezza --> " + nodo.ScortaSicurezza + "\nPeriodoDiCopertura --> " + nodo.PeriodoDiCopertura;
                }
            }
            return "";
        }

        public void Modifica(List<Componente> componenti, string Codice)
        {
            Componenti = componenti;
            foreach (Componente nodo in Nodi)
            {
                if (nodo.Codice == Codice)
                {
                    Form2_NewNode form2 = new Form2_NewNode(nodo, Componenti);
                    form2.ShowDialog();
                    Componente nuovoNodo = form2.nodo;
                    while (nuovoNodo == null)
                    {
                        if (!form2.attendo)
                        {
                            return;
                        }
                    }
                    nuovoNodo.SottoNodi = nodo.SottoNodi;
                    Nodi.Remove(nodo);
                    Nodi.Add(nuovoNodo);
                    return;
                }
            }
        }
        
        public void RimuoviComponente(string Codice)
        {
            List<Componente> daRimuovere = new List<Componente>();
            foreach (Componente nodo in Nodi)
            {
                if (nodo.Codice == Codice)
                {
                    daRimuovere.Add(nodo);
                }
            }
            foreach(Componente comp in daRimuovere)
            {
                Nodi.Remove(comp);
            }
        }

        public void SostitusciComponente(Componente componente)
        {
            Componente compDaRimuovere = new Componente();
            foreach(Componente comp in Nodi)
            {
                if(comp.Codice == componente.Codice)
                {
                    compDaRimuovere = comp;
                }
            }
            Nodi.Remove(compDaRimuovere);
            Nodi.Add(componente);
        }
    }
}
