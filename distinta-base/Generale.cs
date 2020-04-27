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


        public List<Componente> Componenti()
        {
            List<Componente> componenti = new List<Componente>();
            List<Componente> distintaBaseNodi = ComponentiDistintaBase();
            List<Componente> catalogoNodi = ComponentiCatalogo();
            Componente compMomentaneo = new Componente();
            foreach (Componente comp in distintaBaseNodi)
            {
                compMomentaneo = Componente.DeepClone<Componente>(comp);
                bool aggiungi = true;
                foreach (Componente componente in componenti)
                {
                    if (NodiUgualiNoSottocomp(componente, compMomentaneo))
                    {
                        aggiungi = false;
                    }
                }
                if (aggiungi)
                {
                    compMomentaneo.SottoNodi = null;
                    componenti.Add(Componente.DeepClone<Componente>(compMomentaneo));
                }
            }
            foreach (Componente comp in catalogoNodi)
            {
                compMomentaneo = Componente.DeepClone<Componente>(comp);
                bool aggiungi = true;
                foreach (Componente componente in componenti)
                {
                    if (NodiUgualiNoSottocomp(componente, compMomentaneo))
                    {
                        aggiungi = false;
                    }
                }
                if (aggiungi)
                {
                    compMomentaneo.SottoNodi = null;
                    componenti.Add(Componente.DeepClone<Componente>(compMomentaneo));
                }
            }
            return componenti;
        }

        private bool codiceOK(Componente comp)
        {
            List<Componente> componenti = Componenti();
            foreach (Componente componente in componenti)
            {
                if (!ControlloCodice(comp, componente))
                {
                    return false;
                }
            }
            return true;
        }
        private bool ControlloCodice(Componente componente, Componente componenteDaControllare)
        {
            if (componente.SottoNodi != null)
            {
                foreach (Componente sottoComp in componente.SottoNodi)
                {
                    if (!ControlloCodice(componenteDaControllare, sottoComp))
                    {
                        return false;
                    }
                }
            }
            if (componenteDaControllare.Codice == componente.Codice)
            {
                if (NodiUgualiNoSottocomp(componenteDaControllare, componente))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }



        //catalogo---------------------------------------------------------------

        public void AggiungiSemilavoratoACatalogo()
        {
            Componente comp = Componente.DeepClone<Componente>(catalogo.AggiungiSemilavorato());
            if (comp == null) return;
            if (!codiceOK(comp))
            {
                MessageBox.Show("Nel semilavorato che si sta caricando è presente un componente con codice uguale a un componente presente nel programma sebbene non siano lo stesso componente", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (CatalogoContieneComp(comp))
                {
                    MessageBox.Show("Nel catalogo è già presente il semilavorato che si desidera caricare", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (CatalogoContieneCompNoSottocomp(comp))
                {
                    if (MessageBox.Show("Nel catalogo è già presente un componente uguale ma con sottocomponenti diversi, si desidera sostituire il componente?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        RimuoviComponenteDaCatalogo(comp.Codice);
                    }
                    else
                    {
                        return;
                    }
                }
                catalogo.Nodi.Add(Componente.DeepClone<Componente>(comp));
            }
        }

        public void AggiungiMateriaPrimaACatalogo()
        {
            Componente comp = Componente.DeepClone<Componente>(catalogo.AggiungiMateriaPrima(Componenti()));
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
            Componente comp = ComponenteDaCodicePerCatalogo(codice);
            if (comp == null) return;
            Componente newComp = catalogo.Modifica(comp, Componenti());
            if (newComp == null) return;
            if (!codiceOK(newComp))
            {
                MessageBox.Show("Nel componente modificato è presente un componente con codice uguale a un componente presente nel programma sebbene non siano lo stesso componente", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (CatalogoContieneComp(newComp))
                {
                    MessageBox.Show("In catalogo è già presente questo componente", "ATTENZIONE");
                    return;
                }
                RimuoviComponenteDaCatalogo(comp.Codice);
                catalogo.Nodi.Add(Componente.DeepClone<Componente>(newComp));
            }
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
            if (!codiceOK(Albero))
            {
                MessageBox.Show("Nel semilavorato che si sta caricando vi sono 1 o più componenti con codice uguale a un componente presente nel programma sebbene non siano lo stesso componente", "ATTENZIONE");
                return distintaBase.NodeToTreeNode(distintaBase.Albero);
            }
            distintaBase.Albero = Albero;
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public TreeNode CreaNuovaDistintaBase()
        {
            Componente newComp = Componente.DeepClone<Componente>(distintaBase.AggiungiMateriaPrima(Componenti()));
            if (newComp == null) return null;
            if (codiceOK(newComp))
            {
                distintaBase.Albero = newComp;
            }
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
            if (codiceOK(NewComponente))
            {
                AggiungiComponente(NewComponente, compPadre, distintaBase.Albero, new List<Componente>());
            }
            else
            {
                MessageBox.Show("Nel semilavorato che si sta caricando vi sono 1 o più componenti con codice uguale a un componente presente nel programma sebbene non siano lo stesso componente");
            }
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public TreeNode CaricaNodoDaCatalogo(TreeView treeView)
        {
            if (catalogo.Nodi.Count() == 0) { MessageBox.Show("Il catalogo è vuoto", "ATTENZIONE"); return distintaBase.NodeToTreeNode(distintaBase.Albero); }
            Componente comp = Componente.DeepClone<Componente>(distintaBase.CaricaDaCatalogo(catalogo.Nodi));
            if (comp == null) return null;
            Componente compPadre = Componente.DeepClone<Componente>(distintaBase.TreeNodeToNode(treeView.SelectedNode));
            if (codiceOK(comp))
            {
                AggiungiComponente(comp, compPadre, distintaBase.Albero, new List<Componente>());
            }
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public TreeNode CaricaTreeNodeMateriaPrima(TreeView treeView)
        {
            Componente NewComponente = Componente.DeepClone<Componente>(distintaBase.AggiungiMateriaPrima(ComponentiDistintaBase()));
            if (NewComponente == null) return distintaBase.NodeToTreeNode(distintaBase.Albero);
            Componente compPadre = Componente.DeepClone<Componente>(distintaBase.TreeNodeToNode(treeView.SelectedNode));
            if (codiceOK(NewComponente))
            {
                AggiungiComponente(NewComponente, compPadre, distintaBase.Albero, new List<Componente>());
            }
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public TreeNode ModificaNodo(TreeView treeView)
        {
            Componente compVecchio = Componente.DeepClone<Componente>(distintaBase.TreeNodeToNode(treeView.SelectedNode));
            Form2_NewNode form2 = new Form2_NewNode(compVecchio, ComponentiDistintaBase());
            form2.ShowDialog();
            Componente newComp = form2.nodo;
            while (newComp == null)
            {
                if (!form2.attendo)
                {
                    return distintaBase.NodeToTreeNode(distintaBase.Albero);
                }
            }
            newComp = Componente.DeepClone<Componente>(newComp);
            if (codiceOK(newComp))
            {
                if (treeView.Nodes.Count == 1)
                {
                    distintaBase.Albero = newComp;
                }
                else
                {
                    Componente compPadre = Componente.DeepClone<Componente>(distintaBase.TreeNodeToNode(treeView.SelectedNode.Parent));
                    ModificaComponente(newComp, compVecchio, compPadre, distintaBase.Albero);
                }
            }
            else
            {
                MessageBox.Show("Il componente ha codice uguale a un componente presente nel programma sebbene non siano lo stesso componente.\nLe modifiche non verranno appliccate", "ATTENZIONE", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        public void AggiungiComponenteACatalogo(TreeView treeView)
        {
            Componente comp = Componente.DeepClone<Componente>(distintaBase.TreeNodeToNode(treeView.SelectedNode));
            if (CatalogoContieneComp(comp))
            {
                MessageBox.Show("In catalogo è già presente questo componente", "ATTENZIONE");
                return;
            }
            else if (CatalogoContieneCompNoSottocomp(comp))
            {
                DialogResult dialogResult = MessageBox.Show("Un componente con codice uguale è già presente nel catalogo, vuoi sostituirlo?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    RimuoviComponenteDaCatalogo(comp.Codice);
                    catalogo.Nodi.Add(comp);
                }
                return;
            }
            catalogo.Nodi.Add(comp);
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
            if(nodo1.SottoNodi==null)
            {
                nodo1.SottoNodi = new List<Componente>();
            }
            if (nodo2.SottoNodi == null)
            {
                nodo2.SottoNodi = new List<Componente>();
            }
            if (nodo1.Codice == nodo2.Codice && nodo1.SottoNodi.Count == nodo2.SottoNodi.Count && nodo1.Nome == nodo2.Nome && nodo1.Descrizione == nodo2.Descrizione && nodo1.LeadTime == nodo2.LeadTime && nodo1.LeadTimeSicurezza == nodo2.LeadTimeSicurezza && nodo1.ScortaSicurezza == nodo2.ScortaSicurezza && nodo1.Lotto == nodo2.Lotto && nodo1.PeriodoDiCopertura == nodo2.PeriodoDiCopertura)
            {
                return true;
            }
            return false;
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

        private bool NodiUgualiNoSottocompNoCodice(Componente nodo1, Componente nodo2)
        {
            if (nodo1.Nome == nodo2.Nome && nodo1.Descrizione == nodo2.Descrizione && nodo1.LeadTime == nodo2.LeadTime && nodo1.LeadTimeSicurezza == nodo2.LeadTimeSicurezza && nodo1.ScortaSicurezza == nodo2.ScortaSicurezza && nodo1.Lotto == nodo2.Lotto && nodo1.PeriodoDiCopertura == nodo2.PeriodoDiCopertura)
            {
                return true;
            }
            return false;
        }



        private bool CatalogoContieneCompNoSottocomp(Componente comp)
        {
            List<Componente> componentiCatalogo = ComponentiCatalogo();
            foreach (Componente componente in componentiCatalogo)
            {
                if (NodiUgualiNoSottocomp(comp, componente))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CatalogoContieneComp(Componente comp)
        {
            List<Componente> componentiCatalogo = ComponentiCatalogo();
            foreach (Componente componente in componentiCatalogo)
            {
                if (NodiUguali(comp, componente))
                {
                    return true;
                }
            }
            return false;
        }



        private List<Componente> ComponentiDistintaBase()
        {
            List<Componente> componenti = new List<Componente>();
            distintaBase.Nodi.Clear();
            distintaBase.AggiornaNodi(distintaBase.Albero);
            List<Componente> nodiDistintaBase = distintaBase.Nodi;
            Componente compMomentaneo = new Componente();
            foreach (Componente comp in nodiDistintaBase)
            {
                compMomentaneo = Componente.DeepClone<Componente>(comp);
                bool aggiungi = true;
                foreach (Componente componente in componenti)
                {
                    if (NodiUgualiNoSottocomp(componente, compMomentaneo))
                    {
                        aggiungi = false;
                    }
                }
                if (aggiungi)
                {
                    compMomentaneo.SottoNodi = null;
                    componenti.Add(Componente.DeepClone<Componente>(compMomentaneo));
                }
            }
            return componenti;
        }

        public List<Componente> ComponentiCatalogo()
        {
            List<Componente> componenti = new List<Componente>();
            List<Componente> nodiCatalogo = catalogo.Nodi;
            Componente compMomentaneo = new Componente();
            foreach (Componente comp in nodiCatalogo)
            {
                compMomentaneo = Componente.DeepClone<Componente>(comp);
                bool aggiungi = true;
                foreach (Componente componente in componenti)
                {
                    if (NodiUgualiNoSottocomp(componente, compMomentaneo))
                    {
                        aggiungi = false;
                    }
                }
                if (aggiungi)
                {
                    componenti.Add(Componente.DeepClone<Componente>(compMomentaneo));
                }
            }
            return componenti;
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
            List<Componente> componenti = catalogo.Nodi;
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
