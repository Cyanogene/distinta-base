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

        

        //catalogo---------------------------------------------------------------

        public void AggiungiSemilavoratoACatalogo()
        {
            Componente comp = catalogo.AggiungiSemilavorato();
            if (comp == null) return;
            if (EsisteComponente(comp))
            {
                MessageBox.Show("Nel programma c'è già un componente con codice uguale a quello del componente che si desidera caricare", "ATTENZIONE");
                return;
            }
            else if (EsistonoSottocomponentiDelCompInput(comp))
            {
                MessageBox.Show("Nel programma c'è già un componente con codice uguale a quello di un sotto-prodotto del componente che si desidera caricare", "ATTENZIONE");
                return;
            }
            else
            {
                foreach (Componente componente in catalogo.Nodi)
                {
                    if (NodiUgualiNoSottocomp(componente, comp))
                    {
                        MessageBox.Show("In catalogo è già presente questo componente", "ATTENZIONE");
                        return;
                    }
                }
                catalogo.Nodi.Add(comp);
            }
        }

        public void AggiungiMateriaPrimaACatalogo()
        {
            Componente comp = catalogo.AggiungiMateriaPrima(Componenti());
            if (comp == null) return;
            foreach(Componente componente in catalogo.Nodi)
            {
                if(NodiUgualiNoSottocomp(componente,comp))
                {
                    MessageBox.Show("In catalogo è già presente questo componente", "ATTENZIONE");
                    return;
                }
            }
            catalogo.Nodi.Add(comp);
        }

        public void ModificaComponenteCatalogo(string codice)
        {
            Componente comp = ComponenteDaCodice(codice);
            catalogo.Modifica(comp, distintaBase.Nodi);
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

        //-----------------------------------------------------------------------




        //distintaBase-----------------------------------------------------------

        public void salvaDistintaBase(TreeView treeView)
        {
            distintaBase.Salva(distintaBase.Albero);
        }

        public TreeNode caricaDistintaBase()
        {
            Componente comp = distintaBase.Carica();
            if (comp == null) return distintaBase.NodeToTreeNode(distintaBase.Albero);

            if (EsisteComponente(comp))
            {
                if (MessageBox.Show("Nel catalogo è presente un componente con lo stesso codice della distinta base che si sta caricando,proseguire il caricamento e quindi rimuovere il componente dal catalogo?", "ATTENZIONE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RimuoviComponenteDaCatalogo(comp.Codice);
                }
                else
                {
                    return distintaBase.NodeToTreeNode(distintaBase.Albero);
                }
            }
            else if (EsistonoSottocomponentiDelCompInput(comp))
            {
                if (MessageBox.Show("Nel catalogo vi è uno o più componenti uguali a sotto prodotti della distinta base che si sta caricando,proseguire il caricamento e quindi rimuovere tutti i componenti doppi dal catalogo ?", "ATTENZIONE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RimuoviComponentiDaCatalogoSeHannoCodiceUgualeASottonodiComponente(comp);
                }
                else
                {
                    return distintaBase.NodeToTreeNode(distintaBase.Albero);
                }
            }
            distintaBase.Albero = comp;
            distintaBase.Nodi.Clear();
            return distintaBase.NodeToTreeNode(comp);
        }

        public TreeNode NuovoNodoDistintaBase()
        {
            Componente comp = distintaBase.AggiungiMateriaPrima(Componenti());
            if (comp == null) return distintaBase.NodeToTreeNode(distintaBase.Albero);
            distintaBase.Albero = comp;
            return distintaBase.NodeToTreeNode(comp);
        }

        public TreeNode CaricaDaCatalogo()
        {
            if (catalogo.Nodi.Count() == 0) { MessageBox.Show("Il catalogo è vuoto", "ATTENZIONE"); return null; }
            Componente comp = distintaBase.CaricaDaCatalogo(catalogo.Nodi);
            if (comp == null) return null;
            distintaBase.Albero = comp;
            return distintaBase.NodeToTreeNode(comp);
        }



        public TreeNode RimuoviNodo(TreeView treeView)
        {
            if (treeView.SelectedNode == treeView.Nodes[0])
            {
                distintaBase.Albero = new Componente();
                return null;
            }
            else
            {
                TreeNode daEliminare = treeView.SelectedNode;
                TreeNode padre = daEliminare.Parent;
                Componente comp = distintaBase.TreeNodeToNode(daEliminare);
                Componente compPadre = distintaBase.TreeNodeToNode(padre);
                EliminaComponente(comp, compPadre, distintaBase.Albero);
            }
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public TreeNode CaricaNodoDaFile(TreeView treeView)
        {
            Componente comp = distintaBase.CaricaNodoDaFile();
            if (comp == null) return distintaBase.NodeToTreeNode(distintaBase.Albero);
            Componente compPadre = distintaBase.TreeNodeToNode(treeView.SelectedNode);
            AggiungiComponente(comp, compPadre, distintaBase.Albero, new List<Componente>());
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public TreeNode CaricaNodoDaCatalogo(TreeView treeView)
        {
            if (catalogo.Nodi.Count() == 0) { MessageBox.Show("Il catalogo è vuoto", "ATTENZIONE"); return distintaBase.NodeToTreeNode(distintaBase.Albero); }
            Componente comp = distintaBase.CaricaDaCatalogo(catalogo.Nodi);
            if (comp == null) return null;
            Componente compPadre = distintaBase.TreeNodeToNode(treeView.SelectedNode);
            AggiungiComponente(comp, compPadre, distintaBase.Albero, new List<Componente>());
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public TreeNode CaricaTreeNodeMateriaPrima(TreeView treeView)
        {
            Componente comp = distintaBase.AggiungiMateriaPrima(Componenti());
            if (comp == null) return distintaBase.NodeToTreeNode(distintaBase.Albero);
            Componente compPadre = distintaBase.TreeNodeToNode(treeView.SelectedNode);
            AggiungiComponente(comp, compPadre, distintaBase.Albero, new List<Componente>());
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public TreeNode ModificaNodo(TreeView treeView)
        {
            Componente compVecchio = distintaBase.TreeNodeToNode(treeView.SelectedNode);
            Form2_NewNode form2 = new Form2_NewNode(compVecchio, Componenti());
            form2.ShowDialog();
            Componente comp = form2.nodo;
            while (comp == null)
            {
                if (!form2.attendo)
                {
                    return distintaBase.NodeToTreeNode(distintaBase.Albero);
                }
            }
            comp.SottoNodi = compVecchio.SottoNodi;
            if(treeView.Nodes.Count==1)
            {
                distintaBase.Albero = comp;
            }
            else
            {
                Componente compPadre = distintaBase.TreeNodeToNode(treeView.SelectedNode.Parent);
                ModificaComponente(comp, compVecchio, compPadre, distintaBase.Albero);
            }
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public void AggiungiComponenteACatalogo(TreeView treeView)
        {
            Componente comp = distintaBase.TreeNodeToNode(treeView.SelectedNode);
            if (!EsisteComponente(comp))
            {
                foreach (Componente componente in catalogo.Nodi)
                {
                    if (NodiUgualiNoCodice(componente, comp))
                    {
                        MessageBox.Show("In catalogo è già presente questo componente", "ATTENZIONE");
                        return;
                    }
                }
                catalogo.Nodi.Add(comp);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Un componente con codice uguale è già presente nel catalogo, vuoi sostituirlo?", "Distinta base", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    catalogo.SostituisciComponente(comp);
                }
            }
        }
        
        //-----------------------------------------------------------------------







        private void AggiungiComponente(Componente comp, Componente compPadre, Componente Albero, List<Componente> NodiSoprastanti)
        {
            if (NodiUgualiNoCodice(Albero, compPadre))
            {
                bool Ok = true;
                foreach(Componente componente in NodiSoprastanti)
                {
                    if(NodiUgualiNoSottocomp(componente,comp))
                    {
                        Ok = false;
                    }
                }
                if(Ok && !NodiUgualiNoSottocomp(comp,compPadre))
                {
                    if (Albero.SottoNodi == null)
                    {
                        Albero.SottoNodi = new List<Componente>();
                    }
                    Albero.SottoNodi.Add(comp);
                    return;
                }
                else
                {
                    MessageBox.Show("Un componente non può avere come sotto componente sè stesso", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            NodiSoprastanti.Add(Albero);
            if (Albero.SottoNodi != null && Albero.SottoNodi.Count > 0)
            {
                foreach (Componente sottoComponente in Albero.SottoNodi)
                {
                    AggiungiComponente(comp, compPadre, sottoComponente, NodiSoprastanti);
                }
            }
        }

        private void EliminaComponente(Componente comp, Componente compPadre, Componente Albero)
        {
            if(Albero.SottoNodi!=null && Albero.SottoNodi.Count>0)
            {
                foreach (Componente sottoComponente in Albero.SottoNodi)
                {
                    EliminaComponente(comp, compPadre, sottoComponente);
                }
            }
            if (NodiUgualiNoCodice(Albero, compPadre))
            {
                Albero.SottoNodi.Remove(comp);
            }
        }

        private void ModificaComponente(Componente comp, Componente compVecchio, Componente compPadre, Componente Albero)
        {
            foreach (Componente sottoComponente in Albero.SottoNodi)
            {
                ModificaComponente(comp,compVecchio, compPadre, sottoComponente);
            }
            if (NodiUgualiNoCodice(Albero, compPadre))
            {
                Albero.SottoNodi.Remove(compVecchio);
                Albero.SottoNodi.Add(comp);
            }
        }



        private bool NodiUgualiNoCodice(Componente nodo1, Componente nodo2)
        {
            if (nodo1.SottoNodi.Count == nodo2.SottoNodi.Count && nodo1.Nome == nodo2.Nome && nodo1.Descrizione == nodo2.Descrizione && nodo1.LeadTime == nodo2.LeadTime && nodo1.LeadTimeSicurezza == nodo2.LeadTimeSicurezza && nodo1.ScortaSicurezza == nodo2.ScortaSicurezza && nodo1.Lotto == nodo2.Lotto && nodo1.PeriodoDiCopertura == nodo2.PeriodoDiCopertura)
            {
                return true;
            }
            return false;
        }

        private bool NodiUgualiNoSottocomp(Componente nodo1, Componente nodo2)
        {
            if (nodo1.Codice == nodo2.Codice && nodo1.Nome == nodo2.Nome && nodo1.Descrizione == nodo2.Descrizione && nodo1.LeadTime == nodo2.LeadTime && nodo1.LeadTimeSicurezza == nodo2.LeadTimeSicurezza && nodo1.ScortaSicurezza == nodo2.ScortaSicurezza && nodo1.Lotto == nodo2.Lotto && nodo1.PeriodoDiCopertura == nodo2.PeriodoDiCopertura)
            {
                return true;
            }
            return false;
        }

        private bool NodiUguali(Componente nodo1, Componente nodo2)
        {
            if (nodo1.Codice == nodo2.Codice && nodo1.SottoNodi.Count == nodo2.SottoNodi.Count && nodo1.Nome == nodo2.Nome && nodo1.Descrizione == nodo2.Descrizione && nodo1.LeadTime == nodo2.LeadTime && nodo1.LeadTimeSicurezza == nodo2.LeadTimeSicurezza && nodo1.ScortaSicurezza == nodo2.ScortaSicurezza && nodo1.Lotto == nodo2.Lotto && nodo1.PeriodoDiCopertura == nodo2.PeriodoDiCopertura)
            {
                return true;
            }
            return false;
        }




        public List<Componente> Componenti()
        {
            List<Componente> componenti = new List<Componente>();
            distintaBase.Nodi.Clear();
            distintaBase.AggiornaNodi(distintaBase.Albero);
            componenti.AddRange(distintaBase.Nodi);
            componenti.AddRange(catalogo.Nodi);
            return componenti;
        }



        public bool EsistonoSottocomponentiDelCompInput(Componente componente)
        {
            List<Componente> componenti = catalogo.Nodi;
            foreach (Componente comp in componenti)
            {
                if (comp.Codice == componente.Codice && !NodiUgualiNoCodice(comp, componente))
                {
                    return true;
                }
                foreach (Componente comp2 in comp.SottoNodi)
                {
                    return EsistonoSottocomponentiDelCompInput(comp2);
                }
            }
            return false;
        }

        public bool EsisteComponente(Componente componente)
        {
            List<Componente> componenti = catalogo.Nodi;
            foreach (Componente comp in componenti)
            {
                if (comp.Codice == componente.Codice && !NodiUgualiNoCodice(comp,componente))
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
                    EsistonoSottocomponentiDelCompInput(comp2);
                }
            }
        }
        
    }
}
