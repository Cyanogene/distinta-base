using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;


namespace distinta_base
{
    /// <summary>
    /// Classe utilizzata per creare un nodo (radice inclusa)
    /// </summary>

    [Serializable]
    public class Componente
    {
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public string Codice { get; set; }
        public int LeadTime { get; set; }
        public int LeadTimeSicurezza { get; set; }
        public int ScortaSicurezza { get; set; }
        public int Lotto { get; set; }
        public int PeriodoDiCopertura { get; set; }
        public int CoefficenteUtilizzo { get; set; }
        public List<Componente> SottoNodi = new List<Componente>();

        /// <summary>
        /// Crea una copia esatta (in tutti i sensi) del componente selezionato.
        /// </summary>
        /// <param name="obj">Il componente da clonare.</param>
        /// <returns></returns>
        public static Componente DeepClone<Componente>(Componente obj)
        {
            if (obj == null) return default(Componente);
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (Componente)formatter.Deserialize(ms);
            }
        }
    }


}
