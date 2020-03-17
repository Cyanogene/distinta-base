using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace distinta_base
{
    class Componente
    {
        List<TreeNode> tree = new List<TreeNode>();

        public void AggiungiComponente(string text)
        {
            tree.Add(new TreeNode(text));
        }

        public void SalvaAlbero(List<TreeNode> treeNodes)
        {
            XmlSerializer sasd = new XmlSerializer(typeof(List<TreeNode>));
            StreamWriter sadas = new StreamWriter("sadasd.xml");
        }
    }
}
