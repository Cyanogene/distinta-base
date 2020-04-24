using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace distinta_base
{
    class Generale
    {
        public DistintaBase distintaBase = new DistintaBase();
        public Catalogo catalogo = new Catalogo();




        public void AggiungiSemilavoratoACatalogo()
        {
            Componente comp = catalogo.AggiungiSemilavorato(Componenti());
            if (comp == null) return;
            if (EsisteComponente(comp))
            {
                MessageBox.Show("Nel programma c'è già un componente con codice uguale a quello del componente che si desidera caricare", "ATTENZIONE");
                return;
            }
            else if (EsisteComponenteESottocomponenti(comp))
            {
                MessageBox.Show("Nel programma c'è già un componente con codice uguale a quello di un sotto-prodotto del componente che si desidera caricare", "ATTENZIONE");
                return;
            }
            else
            {
                catalogo.Nodi.Add(comp);
            }
        }

        public void AggiungiMateriaPrimaACatalogo()
        {
            Componente comp = catalogo.AggiungiMateriaPrima(Componenti());
            if (comp == null) return;
            catalogo.Nodi.Add(comp);
        }

        public void ModificaComponenteCatalogo(string codice)
        {
            Componente comp = ComponenteDaCodice(codice);
            Componente newComp = catalogo.Modifica(comp, Componenti());
        }

        public void RimuoviComponenteDaCatalogo(string codice)
        {
            catalogo.Nodi.Remove(ComponenteDaCodice(codice));
        }

        public string InfoComponente(string codice)
        {
            Componente componente = ComponenteDaCodice(codice);
            return "Nome --> " + componente.Nome + "\nCodice --> " + componente.Codice + "\nDescrizione --> " + componente.Descrizione + "\nLeadTime --> " + componente.LeadTime + "\nLeadTimeSicurezza --> " + componente.LeadTimeSicurezza + "\nLotto --> " + componente.Lotto + "\nScortaDiSicurezza --> " + componente.ScortaSicurezza + "\nPeriodoDiCopertura --> " + componente.PeriodoDiCopertura;
        }




        public void salvaDistintaBase(TreeView treeView)
        {
            Componente comp = distintaBase.TreeViewToNode(treeView);
            distintaBase.Salva(comp);
        }

        public TreeNode caricaDistintaBase()
        {
            Componente comp = distintaBase.Carica();
            if (comp == null) return null;
            if (EsisteComponente(comp))
            {
                if (MessageBox.Show("Nel catalogo è presente un componente con lo stesso codice della distinta base che si sta caricando,\nproseguire il caricamento e quindi rimuovere il componente dal catalogo?", "ATTENZIONE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RimuoviComponenteDaCatalogo(comp.Codice);
                }
                return null;
            }
            else if (EsisteComponenteESottocomponenti(comp))
            {
                if (MessageBox.Show("Nel catalogo vi è uno o più componenti uguali a sotto prodotti della distinta base che si sta caricando,\nproseguire il caricamento e quindi rimuovere tutti i componenti doppi dal catalogo ?", "ATTENZIONE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RimuoviComponentiDaCatalogoSeHannoCodiceUgualeASottonodiComponente(comp);
                }
                return null;
            }
            else
            {
                AggiungiANodiDistintaBase(comp);
                return distintaBase.NodeToTreeNode(comp);
            }
        }

        public TreeNode CaricaDaCatalogo()
        {
            if (catalogo.Nodi.Count() == 0) { MessageBox.Show("Il catalogo è vuoto", "ATTENZIONE"); return null; }
            Componente comp = distintaBase.CaricaDaCatalogo(catalogo.Nodi);
            if (comp == null) return null;
            AggiungiANodiDistintaBase(comp);
            return distintaBase.NodeToTreeNode(comp);
        }

        public TreeNode NuovoNodoDistintaBase()
        {
            Componente comp = distintaBase.AggiungiMateriaPrima(Componenti());
            if (comp == null) return null;
            AggiungiANodiDistintaBase(comp);
            return distintaBase.NodeToTreeNode(comp);
        }

        public void RimuoviNodoTreeView(TreeView treeView)
        {
            if (treeView.Nodes.Count == 1)
            {
                distintaBase.Nodi.Clear();
            }
            else
            {
                Componente comp = distintaBase.TreeViewToNode(treeView);
                distintaBase.Nodi.Remove(comp);
            }
        }

        public TreeNode CaricaTreeNodeDaFile()
        {
            Componente comp = distintaBase.CaricaNodoDaFile();
            if (comp == null) return null;
            AggiungiANodiDistintaBase(comp);
            return distintaBase.NodeToTreeNode(comp);
        }

        public TreeNode CaricaTreeNodeMateriaPrima()
        {
            Componente comp = distintaBase.AggiungiMateriaPrima(Componenti());
            if (comp == null) return null;
            AggiungiANodiDistintaBase(comp);
            return distintaBase.NodeToTreeNode(comp);
        }

        public TreeNode Modifica(TreeView treeView)
        {
            Componente nodo = distintaBase.TreeNodeToNode(treeView.SelectedNode);
            Form2_NewNode form2 = new Form2_NewNode(nodo, Componenti());
            form2.ShowDialog();
            Componente nuovoNodo = form2.nodo;
            while (nuovoNodo == null)
            {
                if (!form2.attendo)
                {
                    return null;
                }
            }
            List<Componente> sottoNodi = nodo.SottoNodi;
            nuovoNodo.SottoNodi = null;
            nodo.SottoNodi = null;
            distintaBase.Nodi.Remove(nodo);
            distintaBase.Nodi.Add(nuovoNodo);
            nuovoNodo.SottoNodi = sottoNodi;
            return distintaBase.NodeToTreeNode(nuovoNodo);
        }




        public List<Componente> Componenti()
        {
            List<Componente> componenti = new List<Componente>();
            componenti.AddRange(distintaBase.Nodi);
            componenti.AddRange(catalogo.Nodi);
            return componenti;
        }

        public bool EsisteComponenteESottocomponenti(Componente componente)
        {
            List<Componente> componenti = Componenti();
            foreach (Componente comp in componenti)
            {
                if (comp.Codice == componente.Codice && comp != componente)
                {
                    return true;
                }
                foreach (Componente comp2 in comp.SottoNodi)
                {
                    return EsisteComponenteESottocomponenti(comp2);
                }
            }
            return false;
        }

        public bool EsisteComponente(Componente componente)
        {
            List<Componente> componenti = Componenti();
            foreach (Componente comp in componenti)
            {
                if (comp.Codice == componente.Codice && componente != comp)
                {
                    return true;
                }
            }
            return false;
        }

        public Componente ComponenteDaCodice(string codice)
        {
            List<Componente> componenti = Componenti();
            foreach (Componente comp in componenti)
            {
                if (comp.Codice == codice)
                {
                    return comp;
                }
            }
            return null;
        }

        public void RimuoviComponentiDaCatalogoSeHannoCodiceUgualeASottonodiComponente(Componente componente)
        {
            List<Componente> componenti = Componenti();
            foreach (Componente comp in componenti)
            {
                if (comp.Codice == componente.Codice && comp != componente)
                {
                    RimuoviComponenteDaCatalogo(comp.Codice);
                }
                foreach (Componente comp2 in comp.SottoNodi)
                {
                    EsisteComponenteESottocomponenti(comp2);
                }
            }
        }

        private void AggiungiANodiDistintaBase(Componente comp)
        {
            foreach (Componente sottoComp in comp.SottoNodi)
            {
                AggiungiANodiDistintaBase(sottoComp);
            }

            if (!distintaBase.Nodi.Contains(comp))
            {
                distintaBase.Nodi.Add(comp);
            }
        }



    }
}
