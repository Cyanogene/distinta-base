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
        }

        public List<Nodo> CaricaAlbero()
        {
            StreamReader stream = new StreamReader("magazzino.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Nodo>));
            List<Nodo> risultato = (List<Nodo>)serializer.Deserialize(stream);
            return risultato;
        }
    }
}
