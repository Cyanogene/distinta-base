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
            Componente comp = Componente.DeepClone<Componente>(catalogo.AggiungiSemilavorato());
            if (comp == null) return;
            if (EsisteCompDiversoConCodiceUgualeCat(comp))
            {
                MessageBox.Show("Nel programma c'è già un componente con codice uguale a quello del componente che si desidera caricare", "ATTENZIONE");
                return;
            }
            else if (EsistonoSottocomponentiDelCompInputCat(comp))
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
                catalogo.Nodi.Add(Componente.DeepClone<Componente>(comp));
            }
        }

        public void AggiungiMateriaPrimaACatalogo()
        {
            Componente comp = Componente.DeepClone<Componente>(catalogo.AggiungiMateriaPrima(ComponentiCatalogo())); 
            if (comp == null) return;
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

        public void ModificaComponenteCatalogo(string codice)
        {
            Componente comp = Componente.DeepClone<Componente>(ComponenteDaCodicePerCatalogo(codice));
            if (comp == null) return;
            catalogo.Modifica(comp, distintaBase.Nodi);
        }

        public void RimuoviComponenteDaCatalogo(string codice)
        {
            catalogo.Nodi.Remove(ComponenteDaCodicePerCatalogo(codice));
        }

        

        //-----------------------------------------------------------------------




        //distintaBase-----------------------------------------------------------

        public void salvaDistintaBase()
        {
            distintaBase.Salva(distintaBase.Albero);
        }

        public TreeNode caricaDistintaBase()
        {
            Componente Albero = Componente.DeepClone<Componente>(distintaBase.Carica());
            if (Albero == null) return distintaBase.NodeToTreeNode(distintaBase.Albero);

            if (ComponenteEsisteInDistintaBase(Albero))
            {
                if (MessageBox.Show("Nella distinta base sono già presenti 1 o più componenti con codice presente nel semilavorato che si sta caricando", "ATTENZIONE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RimuoviComponenteDaCatalogo(Albero.Codice);
                }
                else
                {
                    return distintaBase.NodeToTreeNode(distintaBase.Albero);
                }
            }
            distintaBase.Albero = Albero;
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public TreeNode CreaNuovaDistintaBase()
        {
            Componente NouvoNodo = Componente.DeepClone<Componente>(distintaBase.AggiungiMateriaPrima(ComponentiDistintaBase())); 
            if (NouvoNodo == null) return null;
            Componente NewComponente = new Componente
            {
                Nome = NouvoNodo.Nome,
                Codice = NouvoNodo.Codice,
                LeadTime = NouvoNodo.LeadTime,
                LeadTimeSicurezza = NouvoNodo.LeadTimeSicurezza,
                Descrizione = NouvoNodo.Descrizione,
                PeriodoDiCopertura = NouvoNodo.PeriodoDiCopertura,
                ScortaSicurezza = NouvoNodo.ScortaSicurezza,
                Lotto = NouvoNodo.Lotto,
                SottoNodi = NouvoNodo.SottoNodi,
                Code = RandomString(100),
            };
            distintaBase.Albero = NewComponente;
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public TreeNode CaricaDaCatalogo()
        {
            if (catalogo.Nodi.Count() == 0) { MessageBox.Show("Il catalogo è vuoto", "ATTENZIONE"); return null; }
            Componente comp = Componente.DeepClone<Componente>(distintaBase.CaricaDaCatalogo(catalogo.Nodi));
            if (comp == null) return null;
            distintaBase.Albero = comp;
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
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
                Componente comp = Componente.DeepClone<Componente>(distintaBase.TreeNodeToNode(daEliminare)); 
                Componente compPadre = Componente.DeepClone<Componente>(distintaBase.TreeNodeToNode(padre)); 
                EliminaComponente(comp, compPadre, distintaBase.Albero);
            }
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public TreeNode CaricaNodoDaFile(TreeView treeView)
        {
            Componente NewComponente = Componente.DeepClone<Componente>(distintaBase.CaricaNodoDaFile()); 
            if (NewComponente == null) return distintaBase.NodeToTreeNode(distintaBase.Albero);
            Componente compPadre = Componente.DeepClone<Componente>(distintaBase.TreeNodeToNode(treeView.SelectedNode)); 
            AggiungiComponente(NewComponente, compPadre, distintaBase.Albero, new List<Componente>());
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public TreeNode CaricaNodoDaCatalogo(TreeView treeView)
        {
            if (catalogo.Nodi.Count() == 0) { MessageBox.Show("Il catalogo è vuoto", "ATTENZIONE"); return distintaBase.NodeToTreeNode(distintaBase.Albero); }
            Componente comp = Componente.DeepClone<Componente>(distintaBase.CaricaDaCatalogo(catalogo.Nodi)); 
            if (comp == null) return null;
            Componente compPadre = Componente.DeepClone<Componente>(distintaBase.TreeNodeToNode(treeView.SelectedNode)); 
            AggiungiComponente(comp, compPadre, distintaBase.Albero, new List<Componente>());
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public TreeNode CaricaTreeNodeMateriaPrima(TreeView treeView)
        {
            Componente NewComponente = Componente.DeepClone<Componente>(distintaBase.AggiungiMateriaPrima(ComponentiDistintaBase())); 
            if (NewComponente == null) return distintaBase.NodeToTreeNode(distintaBase.Albero);
            Componente compPadre = Componente.DeepClone<Componente>(distintaBase.TreeNodeToNode(treeView.SelectedNode)); 
            AggiungiComponente(NewComponente, compPadre, distintaBase.Albero, new List<Componente>());
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public TreeNode ModificaNodo(TreeView treeView)
        {
            Componente compVecchio = Componente.DeepClone<Componente>(distintaBase.TreeNodeToNode(treeView.SelectedNode)); 
            Form2_NewNode form2 = new Form2_NewNode(compVecchio, ComponentiDistintaBase());
            form2.ShowDialog();
            Componente comp = form2.nodo;
            while (comp == null)
            {
                if (!form2.attendo)
                {
                    return distintaBase.NodeToTreeNode(distintaBase.Albero);
                }
            }
            comp = Componente.DeepClone<Componente>(comp);
            if (treeView.Nodes.Count == 1)
            {
                distintaBase.Albero = comp;
            }
            else
            {
                Componente compPadre = Componente.DeepClone<Componente>(distintaBase.TreeNodeToNode(treeView.SelectedNode.Parent)); 
                ModificaComponente(comp, compVecchio, compPadre, distintaBase.Albero);
            }
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public void AggiungiComponenteACatalogo(TreeView treeView)
        {
            Componente comp = Componente.DeepClone<Componente>(distintaBase.TreeNodeToNode(treeView.SelectedNode)); 
            if (!ComponenteEsisteInDistintaBase(comp))
            {
                foreach (Componente componente in catalogo.Nodi)
                {
                    if (NodiUguali(componente, comp))
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
            if (NodiUguali(Albero, compPadre))
            {
                bool Ok = true;
                foreach (Componente componente in NodiSoprastanti)
                {
                    if (NodiUgualiNoSottocomp(componente, comp))
                    {
                        Ok = false;
                    }
                }
                if (Ok && !NodiUgualiNoSottocomp(comp, compPadre))
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
            if (Albero.SottoNodi != null && Albero.SottoNodi.Count > 0)
            {
                foreach (Componente sottoComponente in Albero.SottoNodi)
                {
                    EliminaComponente(comp, compPadre, sottoComponente);
                }
            }
            if (NodiUguali(Albero, compPadre))
            {
                Albero.SottoNodi.Remove(comp);
            }
        }

        private void ModificaComponente(Componente comp, Componente compVecchio, Componente compPadre, Componente Albero)
        {
            foreach (Componente sottoComponente in Albero.SottoNodi)
            {
                ModificaComponente(comp, compVecchio, compPadre, sottoComponente);
            }
            if (NodiUgualiNoCodice(Albero, compPadre))
            {
                Albero.SottoNodi.Remove(compVecchio);
                Albero.SottoNodi.Add(comp);
            }
        }



        private bool NodiUguali(Componente nodo1, Componente nodo2)
        {
            if (nodo1.Code == nodo2.Code && nodo1.Codice == nodo2.Codice && nodo1.SottoNodi.Count == nodo2.SottoNodi.Count && nodo1.Nome == nodo2.Nome && nodo1.Descrizione == nodo2.Descrizione && nodo1.LeadTime == nodo2.LeadTime && nodo1.LeadTimeSicurezza == nodo2.LeadTimeSicurezza && nodo1.ScortaSicurezza == nodo2.ScortaSicurezza && nodo1.Lotto == nodo2.Lotto && nodo1.PeriodoDiCopertura == nodo2.PeriodoDiCopertura)
            {
                return true;
            }
            return false;
        }

        private bool NodiUgualiNoCodice(Componente nodo1, Componente nodo2)
        {
            if (nodo1.Code == nodo2.Code && nodo1.SottoNodi.Count == nodo2.SottoNodi.Count && nodo1.Nome == nodo2.Nome && nodo1.Descrizione == nodo2.Descrizione && nodo1.LeadTime == nodo2.LeadTime && nodo1.LeadTimeSicurezza == nodo2.LeadTimeSicurezza && nodo1.ScortaSicurezza == nodo2.ScortaSicurezza && nodo1.Lotto == nodo2.Lotto && nodo1.PeriodoDiCopertura == nodo2.PeriodoDiCopertura)
            {
                return true;
            }
            return false;
        }

        private bool NodiUgualiNoSottocomp(Componente nodo1, Componente nodo2)
        {
            if (nodo1.Code == nodo2.Code && nodo1.Codice == nodo2.Codice && nodo1.Nome == nodo2.Nome && nodo1.Descrizione == nodo2.Descrizione && nodo1.LeadTime == nodo2.LeadTime && nodo1.LeadTimeSicurezza == nodo2.LeadTimeSicurezza && nodo1.ScortaSicurezza == nodo2.ScortaSicurezza && nodo1.Lotto == nodo2.Lotto && nodo1.PeriodoDiCopertura == nodo2.PeriodoDiCopertura)
            {
                return true;
            }
            return false;
        }

        private bool NodiUgualiNoSottocompNoCodice(Componente nodo1, Componente nodo2)
        {
            if (nodo1.Code == nodo2.Code && nodo1.Nome == nodo2.Nome && nodo1.Descrizione == nodo2.Descrizione && nodo1.LeadTime == nodo2.LeadTime && nodo1.LeadTimeSicurezza == nodo2.LeadTimeSicurezza && nodo1.ScortaSicurezza == nodo2.ScortaSicurezza && nodo1.Lotto == nodo2.Lotto && nodo1.PeriodoDiCopertura == nodo2.PeriodoDiCopertura)
            {
                return true;
            }
            return false;
        }

        




        public List<Componente> ComponentiDistintaBase()
        {
            List<Componente> componenti = new List<Componente>();
            if (distintaBase.Albero.Codice != null)
            {
                distintaBase.Nodi.Clear();
                distintaBase.AggiornaNodi(distintaBase.Albero);
                componenti.AddRange(distintaBase.Nodi);
            }
            return componenti;
        }

        public List<Componente> ComponentiCatalogo()
        {
            List<Componente> componenti = new List<Componente>();
            componenti.AddRange(catalogo.Nodi);
            return componenti;
        }

        public bool EsisteCompDiversoConCodiceUgualeCat(Componente componente)
        {
            List<Componente> TuttiIComponentiESottocomponenti = TuttiIComponeti(ComponentiCatalogo(), new List<Componente>());
            foreach (Componente comp in TuttiIComponentiESottocomponenti)
            {
                if (comp.Codice == componente.Codice && !NodiUgualiNoSottocompNoCodice(comp, componente))
                {
                    return true;
                }
            }
            return false;
        }

        public bool EsistonoSottocomponentiDelCompInputCat(Componente componente)
        {
            List<Componente> TuttiIComponentiESottocomponenti = TuttiIComponeti(ComponentiCatalogo(), new List<Componente>());
            List<Componente> componenti = ComponentiCatalogo();
            foreach (Componente comp in componenti)
            {
                if (comp.Codice == componente.Codice && !NodiUgualiNoSottocompNoCodice(comp, componente))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ComponenteEsisteInDistintaBase(Componente componente)
        {
            List<Componente> TuttiIComponentiESottocomponenti = TuttiIComponeti(ComponentiDistintaBase(), new List<Componente>());
            foreach (Componente comp in TuttiIComponentiESottocomponenti)
            {
                if (comp.Codice == componente.Codice && !NodiUgualiNoSottocompNoCodice(comp, componente))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Componente> TuttiIComponeti(List<Componente> componenti, List<Componente> tuttiIComponenti)
        {
            foreach(Componente comp in componenti)
            {
                Componente componente = new Componente
                {
                    Nome = comp.Nome,
                    Codice = comp.Codice,
                    LeadTime = comp.LeadTime,
                    LeadTimeSicurezza = comp.LeadTimeSicurezza,
                    Descrizione = comp.Descrizione,
                    PeriodoDiCopertura = comp.PeriodoDiCopertura,
                    ScortaSicurezza = comp.ScortaSicurezza,
                    Lotto = comp.Lotto,
                    SottoNodi = null,
                    Code = RandomString(100),
                };
                if (!tuttiIComponenti.Contains(componente))
                {
                    tuttiIComponenti.Add(componente);
                }
                if (comp.SottoNodi != null && comp.SottoNodi.Count > 0)
                {
                    tuttiIComponenti = (TuttiIComponeti(comp.SottoNodi, tuttiIComponenti));
                }
            }
            return tuttiIComponenti;
        }
        
        public Componente ComponenteDaCodicePerDistintaBase(string codice)
        {
            List<Componente> componenti = ComponentiDistintaBase();
            if (componenti == null) return null;
            foreach (Componente comp in componenti)
            {
                if (comp.Codice == codice)
                {
                    return comp;
                }
            }
            return null;
        }

        public Componente ComponenteDaCodicePerCatalogo(string codice)
        {
            List<Componente> componenti = ComponentiCatalogo();
            if (componenti == null) return null;
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
            List<Componente> componenti = ComponentiCatalogo();
            foreach (Componente comp in componenti)
            {
                if (comp.Codice == componente.Codice && comp != componente)
                {
                    RimuoviComponenteDaCatalogo(comp.Codice);
                }
                foreach (Componente comp2 in comp.SottoNodi)
                {
                    EsistonoSottocomponentiDelCompInputCat(comp2);
                }
            }
        }

        private Random random = new Random();

        public string RandomString(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string InfoComponenteCatalogo(string codice)
        {
            Componente componente = ComponenteDaCodicePerCatalogo(codice);
            if (componente == null) return "selezionare un componente";
            return "Nome --> " + componente.Nome + "\nCodice --> " + componente.Codice + "\nDescrizione --> " + componente.Descrizione + "\nLeadTime --> " + componente.LeadTime + "\nLeadTimeSicurezza --> " + componente.LeadTimeSicurezza + "\nLotto --> " + componente.Lotto + "\nScortaDiSicurezza --> " + componente.ScortaSicurezza + "\nPeriodoDiCopertura --> " + componente.PeriodoDiCopertura;
        }

        public string InfoComponenteDistintabase(string codice)
        {
            Componente componente = ComponenteDaCodicePerDistintaBase(codice);
            if (componente == null) return "selezionare un componente";
            return "Nome --> " + componente.Nome + "\nCodice --> " + componente.Codice + "\nDescrizione --> " + componente.Descrizione + "\nLeadTime --> " + componente.LeadTime + "\nLeadTimeSicurezza --> " + componente.LeadTimeSicurezza + "\nLotto --> " + componente.Lotto + "\nScortaDiSicurezza --> " + componente.ScortaSicurezza + "\nPeriodoDiCopertura --> " + componente.PeriodoDiCopertura;
        }
    }
}
