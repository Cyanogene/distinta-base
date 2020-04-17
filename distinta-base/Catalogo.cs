using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace distinta_base
{
    class Catalogo
    {
        public List<Componente> Nodi = new List<Componente>();

        public bool esisteComponente(Componente componente)
        {
            foreach (Componente comp in Nodi)
            {
                if (comp.Codice == componente.Codice)
                {
                    return true;
                }
            }
            return false;
        }

        public void Salva(List<Componente> nodi, StreamWriter sw)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Componente>));
            serializer.Serialize(sw, nodi);
            sw.Close();
        }

        public List<Componente> Carica(string filePosition)
        {
            List<Componente> risultato = new List<Componente>();
            if (File.Exists(filePosition))
            {
                StreamReader stream = new StreamReader(filePosition);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Componente>));
                risultato = (List<Componente>)serializer.Deserialize(stream);
                stream.Close();
            }
            return risultato;
        }
    }
}
