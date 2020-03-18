using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace distinta_base
{
    /// <summary>
    /// Classe utilizzata per creare un nodo (radice inclusa)
    /// </summary>
    [Serializable]
    public class Nodo
    {
        public string Nome { get; set; }
        public List<Nodo> Figli { get; set; }
    }
}
