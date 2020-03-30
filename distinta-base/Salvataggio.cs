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
    /// Classe utilizzata per salvataggio della distinta base.
    /// </summary>
    
    class Salvataggio
    {
        public void SalvaDistintaBase(Node nodi,StreamWriter sw)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Node));
            serializer.Serialize(sw, nodi);
            sw.Close();
        }

        public Node CaricaDistintaBase(string filePosition)
        {
            Node risultato = new Node();
            if (File.Exists(filePosition))
            {
                StreamReader stream = new StreamReader(filePosition);
                XmlSerializer serializer = new XmlSerializer(typeof(Node));
                risultato = (Node)serializer.Deserialize(stream);
                stream.Close();
            }
            return risultato;
        }
    }
}
