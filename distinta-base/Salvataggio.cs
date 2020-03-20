using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace distinta_base
{
    /// <summary>
    /// Classe utilizzata per salvataggio del magazzino.
    /// </summary>
    class Salvataggio
    {
        public void SalvaAlbero(List<Nodo> nodi)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Nodo>));
            StreamWriter stream = new StreamWriter("magazzino.xml");
            serializer.Serialize(stream, nodi);
            stream.Close();
        }

        public List<Nodo> CaricaAlbero()
        {
            List<Nodo> risultato = new List<Nodo>();
            if (File.Exists("magazzino.xml"))
            {
                StreamReader stream = new StreamReader("magazzino.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(List<Nodo>));
                risultato = (List<Nodo>)serializer.Deserialize(stream);
                stream.Close();
            }
            return risultato;
        }
    }
}
