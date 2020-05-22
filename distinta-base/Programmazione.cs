using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Drawing;

namespace distinta_base
{
    class Programmazione
    {
        public DistintaBase distintaBase = new DistintaBase();
        public Catalogo catalogo = new Catalogo();



        // Metodi Generali---------------------------------------------------------------

        /// <summary>
        /// Apre la finestra di creazione della materia prima. Creata quest'ultima, ritorno il componente creato.
        /// </summary>
        /// <param name="Componenti">La lista di tutti i componenti.</param>
        /// <returns></returns>
        public Componente AggiungiMateriaPrima(List<Componente> Componenti, bool IsCatalogo)
        {
            Form2_NewNode form2 = new Form2_NewNode(new Componente(), Componenti, IsCatalogo);
            form2.ShowDialog();
            Componente nodo = form2.nodo;
            while (nodo == null)
            {
                if (!form2.attendo)
                {
                    return null;
                }
            }
            return nodo;
        }

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

        public List<Componente> TuttiComponenti()
        {
            List<Componente> componenti = new List<Componente>();
            List<Componente> distintaBaseNodi = NodiDistintaBase();
            List<Componente> catalogoNodi = NodiCatalogo();
            Componente compMomentaneo = new Componente();
            foreach (Componente comp in distintaBaseNodi)
            {
                compMomentaneo = Componente.DeepClone<Componente>(comp);
                compMomentaneo.SottoNodi = null;
                componenti.Add(Componente.DeepClone<Componente>(compMomentaneo));
            }
            foreach (Componente comp in catalogoNodi)
            {
                compMomentaneo = Componente.DeepClone<Componente>(comp);
                compMomentaneo.SottoNodi = null;
                componenti.Add(Componente.DeepClone<Componente>(compMomentaneo));
            }
            return componenti;
        }
        
        /// <summary>
        /// Controlla se il codice selezionato è valido.
        /// </summary>
        /// <param name="comp">Componente da controllare.</param>
        /// <param name="componenti">La lista di tutti i componenti.</param>
        /// <returns></returns>
        public bool ControllaCodice(Componente comp, Componente compVecchio, List<Componente> componenti)
        {
            foreach (Componente componente in componenti)
            {
                if (!ControlloCodiceSingoloComponente(comp, componente))
                {
                    int cont = 0;
                    List<Componente> tuttiComponenti = TuttiComponenti();
                    foreach (Componente component in tuttiComponenti)
                    {
                        if (NodiUgualiNoSottocomp(compVecchio, component))
                        {
                            cont++;
                        }
                    }
                    if (cont == 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Effettua la comparazione dei codici.
        /// </summary>
        /// <param name="componente">Componente attualmente selezionato nel ciclo di controllo.</param>
        /// <param name="componenteDaControllare">Componente da controllare.</param>
        /// <returns></returns>
        private bool ControlloCodiceSingoloComponente(Componente componente, Componente componenteDaControllare)
        {
            if (componente.SottoNodi != null)
            {
                foreach (Componente sottoComp in componente.SottoNodi)
                {
                    if (!ControlloCodiceSingoloComponente(componenteDaControllare, sottoComp))
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



        // Catalogo---------------------------------------------------------------


        /// <summary>
        /// Aggiunge il componente selezionato al catalogo.
        /// </summary>
        /// <param name="treeView">L'albero dove è presente il nodo selezionato.</param>
        public void AggiungiComponenteACatalogo(TreeView treeView)
        {
            Componente comp = Componente.DeepClone<Componente>(distintaBase.TreeNodeToNode(treeView.SelectedNode));
            if (CatalogoContieneComp(comp))
            {
                MessageBox.Show("In catalogo è già presente questo componente", "Distinta Base");
                return;
            }
            else if (CatalogoContieneCompNoControlloSottocomp(comp))
            {
                DialogResult dialogResult = MessageBox.Show("Un componente con codice uguale è già presente nel catalogo, vuoi sostituirlo?", "Distinta Base", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    RimuoviComponenteDaCatalogo(comp.Codice);
                    catalogo.Nodi.Add(comp);
                }
                return;
            }
            catalogo.Nodi.Add(comp);
        }

        /// <summary>
        /// Aggiorna la tabella del catalogo.
        /// </summary>
        /// <param name="listView">La tabella-catalogo da aggiornare.</param>
        public void AggiornaCatalogo(ListView listView)
        {
            listView.Items.Clear();
            int i = 0;
            foreach (Componente comp in catalogo.Nodi)
            {
                string[] items = { comp.Nome, comp.Codice, comp.Descrizione };
                ListViewItem ListViewNodo = new ListViewItem(items)
                {
                    Font = new Font("Microsoft Tai Le", 12)
                };
                if (i % 2 != 0)
                    ListViewNodo.BackColor = Color.FromArgb(238, 239, 249);
                listView.Items.Add(ListViewNodo);
                i++;
            }
        }

        /// <summary>
        /// Aggiunge un semilavorato nel catalogo.
        /// </summary>
        public void AggiungiSemilavoratoACatalogo()
        {
            Componente comp = catalogo.AggiungiSemilavorato();
            if (comp == null) return;
            if (!ControllaCodice(comp, new Componente(), Componenti()))
            {
                MessageBox.Show("Nel semilavorato che si sta caricando è presente un componente con codice uguale a un componente presente nel programma sebbene non siano lo stesso componente", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (CatalogoContieneComp(comp))
                {
                    MessageBox.Show("Nel catalogo è già presente il semilavorato che si desidera caricare", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (CatalogoContieneCompNoControlloSottocomp(comp))
                {
                    if (MessageBox.Show("Nel catalogo è già presente un componente uguale ma con sottocomponenti diversi, si desidera sostituire il componente?", "Distinta Base", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        RimuoviComponenteDaCatalogo(comp.Codice);
                        catalogo.Nodi.Add(comp);
                    }
                }
            }
        }

        /// <summary>
        /// Aggiunge una materia prima nel catalogo.
        /// </summary>
        public void AggiungiMateriaPrimaACatalogo()
        {
            Componente comp = AggiungiMateriaPrima(Componenti(), true);
            if (comp == null) return;
            comp.CoefficenteUtilizzo = 1;
            foreach (Componente componente in catalogo.Nodi)
            {
                if (NodiUgualiNoSottocomp(componente, comp))
                {
                    MessageBox.Show("In catalogo è già presente questo componente.", "Distinta Base",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            catalogo.Nodi.Add(comp);
        }

        /// <summary>
        /// Modifica il componente del catalogo selezionato.
        /// </summary>
        /// <param name="codice">Il codice del componente da modificare.</param>
        public void ModificaComponenteCatalogo(string codice)
        {
            Componente compVecchio = ComponenteCatalogoDaCodice(codice);
            if (compVecchio == null) return;
            Componente newComp = catalogo.Modifica(compVecchio, Componenti());
            if (newComp == null) return;

            if (!ControllaCodice(newComp, compVecchio, Componenti()))
            {
                MessageBox.Show("Nel componente modificato è presente un componente con codice uguale a un componente presente nel programma sebbene non siano lo stesso componente", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(CatalogoContieneComp(newComp))
            {
                if(!NodiUguali(compVecchio,newComp))
                {
                    MessageBox.Show("In catalogo è già presente questo componente", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }

            RimuoviComponenteDaCatalogo(compVecchio.Codice);
            catalogo.Nodi.Add(Componente.DeepClone<Componente>(newComp));
        }

        /// <summary>
        /// Rimuove un componente dal catalogo.
        /// </summary>
        /// <param name="codice">Il codice del componente da rimuovere.</param>
        public void RimuoviComponenteDaCatalogo(string codice)
        {
            catalogo.Nodi.Remove(ComponenteCatalogoDaCodice(codice));
        }

        /// <summary>
        /// Restituisce una stringa contenente le informazioni del componente selezionato.
        /// </summary>
        /// <param name="codice">Il codice del componente selezionato.</param>
        /// <returns></returns>
        public string InfoComponenteCatalogo(string codice)
        {
            Componente componente = ComponenteCatalogoDaCodice(codice);
            if (componente == null) return "selezionare un componente";
            return "Nome --> " + componente.Nome + "\nCodice --> " + componente.Codice + "\nDescrizione --> " + componente.Descrizione + "\nLeadTime --> " + componente.LeadTime + "\nLeadTimeSicurezza --> " + componente.LeadTimeSicurezza + "\nLotto --> " + componente.Lotto + "\nScortaDiSicurezza --> " + componente.ScortaSicurezza + "\nPeriodoDiCopertura --> " + componente.PeriodoDiCopertura;
        }



        //distintaBase-----------------------------------------------------------

        /// <summary>
        /// Salva una distinta base.
        /// </summary>
        public void salvaDistintaBase()
        {
            distintaBase.Salva();
        }

        /// <summary>
        /// Carica una distinta base.
        /// </summary>
        /// <returns></returns>
        public TreeNode caricaDistintaBase()
        {
            Componente Albero = Componente.DeepClone<Componente>(distintaBase.Carica());
            if (Albero == null) return distintaBase.NodeToTreeNode(distintaBase.Albero);
            if (!ControllaCodice(Albero, new Componente(), Componenti()))
            {
                MessageBox.Show("Nel semilavorato che si sta caricando vi sono 1 o più componenti con codice uguale a un componente presente nel programma sebbene non siano lo stesso componente", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return distintaBase.NodeToTreeNode(distintaBase.Albero);
            }
            distintaBase.Albero = Albero;
            if (distintaBase.Albero.CoefficenteUtilizzo != 1)
            {
                MessageBox.Show("Il componente \"base\" non può avere coefficente diverso da 1, quindi il coefficiente verrà impostato automaticamente a 1", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                distintaBase.Albero.CoefficenteUtilizzo = 1;
            }
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        /// <summary>
        /// Crea una distinta base.
        /// </summary>
        /// <returns></returns>
        public TreeNode CreaNuovaDistintaBase()
        {
            Componente newComp = AggiungiMateriaPrima(Componenti(), false);
            if (newComp == null) return null;
            if (ControllaCodice(newComp, new Componente(), Componenti()))
            {
                distintaBase.Albero = newComp;
            }
            if (distintaBase.Albero.CoefficenteUtilizzo != 1)
            {
                MessageBox.Show("Il componente \"base\" non può avere coefficente diverso da 1, quindi il coefficiente verrà impostato automaticamente a 1", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                distintaBase.Albero.CoefficenteUtilizzo = 1;
            }
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        /// <summary>
        /// Carica un componente dal catalogo
        /// </summary>
        public TreeNode CaricaDaCatalogo()
        {
            if (catalogo.Nodi.Count() == 0) { MessageBox.Show("Il catalogo è vuoto", "Distinta Base"); return null; }
            Componente comp = Componente.DeepClone<Componente>(distintaBase.CaricaDaCatalogo(catalogo.Nodi));
            if (comp == null) return null;
            distintaBase.Albero = comp;
            if (distintaBase.Albero.CoefficenteUtilizzo != 1)
            {
                MessageBox.Show("Il componente \"base\" non può avere coefficente diverso da 1, quindi il coefficiente verrà impostato automaticamente a 1", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                distintaBase.Albero.CoefficenteUtilizzo = 1;
            }
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }


        /// <summary>
        /// Rimuove il nodo selezionato
        /// </summary>
        /// <param name="treeView">L'albero dove è presente il nodo selezionato.</param>
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

        /// <summary>
        /// Carica un nodo da un file.
        /// </summary>
        /// <param name="treeView">L'albero dove caricare il nodo.</param>
        /// <returns></returns>
        public TreeNode CaricaNodoDaFile(TreeView treeView)
        {
            Componente NewComponente = Componente.DeepClone<Componente>(distintaBase.CaricaNodoDaFile());
            if (NewComponente == null) return distintaBase.NodeToTreeNode(distintaBase.Albero);
            Componente compPadre = distintaBase.TreeNodeToNode(treeView.SelectedNode);
            if (ControllaCodice(NewComponente, new Componente(), Componenti()))
            {
                AggiungiComponente(NewComponente, compPadre, distintaBase.Albero, new List<Componente>(), true);
            }
            else
            {
                MessageBox.Show("Nel semilavorato che si sta caricando vi sono 1 o più componenti con codice uguale a un componente presente nel programma sebbene non siano lo stesso componente", "Distinta Base");
            }
            if (distintaBase.Albero.CoefficenteUtilizzo != 1)
            {
                MessageBox.Show("Il componente \"base\" non può avere coefficente diverso da 1, quindi il coefficiente verrà impostato automaticamente a 1", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                distintaBase.Albero.CoefficenteUtilizzo = 1;
            }
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        /// <summary>
        /// Carica un nodo dal catalogo.
        /// </summary>
        /// <param name="treeView">L'albero dove caricare il nodo.</param>
        public TreeNode CaricaNodoDaCatalogo(TreeView treeView)
        {
            if (catalogo.Nodi.Count() == 0) { MessageBox.Show("Il catalogo è vuoto", "Distinta Base"); return distintaBase.NodeToTreeNode(distintaBase.Albero); }
            Componente comp = Componente.DeepClone<Componente>(distintaBase.CaricaDaCatalogo(catalogo.Nodi));
            if (comp == null) return null;
            Componente compPadre = distintaBase.TreeNodeToNode(treeView.SelectedNode);
            if (ControllaCodice(comp, new Componente(), Componenti()))
            {
                AggiungiComponente(comp, compPadre, distintaBase.Albero, new List<Componente>(), true);
            }
            if (distintaBase.Albero.CoefficenteUtilizzo != 1)
            {
                MessageBox.Show("Il componente \"base\" non può avere coefficente diverso da 1, quindi il coefficiente verrà impostato automaticamente a 1", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                distintaBase.Albero.CoefficenteUtilizzo = 1;
            }
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        /// <summary>
        /// Carica un TreeNode.
        /// </summary>
        /// <param name="treeView">L'albero dove caricare il TreeNode.</param></param>
        /// <returns></returns>
        public TreeNode CaricaTreeNodeMateriaPrima(TreeView treeView)
        {
            Componente NewComponente = Componente.DeepClone(AggiungiMateriaPrima(ComponentiDistintaBase(), false));
            if (NewComponente == null) return distintaBase.NodeToTreeNode(distintaBase.Albero);
            Componente compPadre = distintaBase.TreeNodeToNode(treeView.SelectedNode);
            if (ControllaCodice(NewComponente, new Componente(), Componenti()))
            {
                AggiungiComponente(NewComponente, compPadre, distintaBase.Albero, new List<Componente>(), true);
            }
            if (distintaBase.Albero.CoefficenteUtilizzo != 1)
            {
                MessageBox.Show("Il componente \"base\" non può avere coefficente diverso da 1, quindi il coefficiente verrà impostato automaticamente a 1", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                distintaBase.Albero.CoefficenteUtilizzo = 1;
            }
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        /// <summary>
        /// Modifica il nodo selezionato.
        /// </summary>
        /// <param name="treeView">L'albero dove cercare il nodo selezionato.</param></param>
        public TreeNode ModificaNodo(TreeView treeView)
        {
            Componente compVecchio = distintaBase.TreeNodeToNode(treeView.SelectedNode);
            Form2_NewNode form2 = new Form2_NewNode(compVecchio, ComponentiDistintaBase(), false);
            form2.ShowDialog();
            Componente newComp = form2.nodo;
            while (newComp == null)
            {
                if (!form2.attendo)
                {
                    return distintaBase.NodeToTreeNode(distintaBase.Albero);
                }
            }
            List<Componente> nodi = distintaBase.Nodi();
            newComp = Componente.DeepClone<Componente>(newComp);
            if (ControllaCodice(newComp, compVecchio, Componenti()))
            {
                if (nodi.Count == 1)
                {
                    distintaBase.Albero = newComp;
                }
                else
                {
                    if (!(treeView.SelectedNode.Parent == null))
                    {
                        Componente compPadre = distintaBase.TreeNodeToNode(treeView.SelectedNode.Parent);
                        ModificaComponente(newComp, compVecchio, compPadre, distintaBase.Albero);
                    }
                    else
                    {
                        newComp.SottoNodi = compVecchio.SottoNodi;
                        distintaBase.Albero = newComp;
                    }
                }
            }
            else
            {
                MessageBox.Show("Il componente ha codice uguale a un componente presente nel programma sebbene non siano lo stesso componente.\nLe modifiche non verranno appliccate", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(distintaBase.Albero.CoefficenteUtilizzo!=1)
            {
                MessageBox.Show("Il componente \"base\" non può avere coefficente diverso da 1, quindi il coefficiente verrà impostato automaticamente a 1", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                distintaBase.Albero.CoefficenteUtilizzo = 1;
            }
            return distintaBase.NodeToTreeNode(distintaBase.Albero);
        }

        /// <summary>
        /// Restituisce una stringa contenente le informazioni del componente selezionato.
        /// </summary>
        /// <param name="codice">Il codice del componente selezionato.</param>
        public string InfoComponenteDistintabase(string codice)
        {
            Componente componente = ComponenteDistintaBaseDaCodice(codice);
            if (componente == null) return "selezionare un componente";
            return "NOME --> " + componente.Nome + "\nCODICE --> " + componente.Codice + "\nDESCRIZIONE --> " + componente.Descrizione + "\nLEAD TIME --> " + componente.LeadTime + "\nLEAD TIME SICUREZZA --> " + componente.LeadTimeSicurezza + "\nLOTTO --> " + componente.Lotto + "\nSCORTA DI SICUREZZA --> " + componente.ScortaSicurezza + "\nPERIODO DI COPERTURA --> " + componente.PeriodoDiCopertura;
        }


        //metodiDiAppoggio-------------------------------------------------------


        private void AggiungiComponente(Componente comp, Componente compPadre, Componente Albero, List<Componente> NodiSoprastanti, bool ok)
        {
            if (Albero == compPadre)
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
                    foreach(Componente componente in Albero.SottoNodi)
                    {
                        if(NodiUgualiNoSottocomp(componente,comp))
                        {
                            componente.CoefficenteUtilizzo++;
                            return;
                        }
                    }
                    Albero.SottoNodi.Add(comp);
                    return;
                }
                else if (ok)
                {
                    MessageBox.Show("Un componente non può avere come sotto componente sè stesso", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ok = false;
                }
                return;
            }
            Componente newComp = Componente.DeepClone<Componente>(Albero);
            newComp.SottoNodi = null;
            NodiSoprastanti.Add(newComp);
            if (Albero.SottoNodi != null && Albero.SottoNodi.Count > 0)
            {
                foreach (Componente sottoComponente in Albero.SottoNodi)
                {
                    AggiungiComponente(comp, compPadre, sottoComponente, NodiSoprastanti, ok);
                }
            }
            NodiSoprastanti.RemoveAt(NodiSoprastanti.Count - 1);
        }

        private void EliminaComponente(Componente comp, Componente compPadre, Componente Albero)
        {
            if (NodiUguali(Albero, compPadre))
            {
                foreach (Componente sottoNodo in Albero.SottoNodi)
                {
                    if (NodiUguali(sottoNodo, comp))
                    {
                        Albero.SottoNodi.Remove(sottoNodo);
                        return;
                    }
                }
            }
            if (Albero.SottoNodi != null && Albero.SottoNodi.Count > 0)
            {
                foreach (Componente sottoComponente in Albero.SottoNodi)
                {
                    EliminaComponente(comp, compPadre, sottoComponente);
                }
            }
        }

        private void ModificaComponente(Componente comp, Componente compVecchio, Componente compPadre, Componente Albero)
        {
            if (NodiUgualiNoCodice(Albero, compPadre))
            {
                comp.SottoNodi = compVecchio.SottoNodi;
                foreach(Componente sottoNodo in Albero.SottoNodi)
                {
                    if(NodiUguali(sottoNodo,comp))
                    {
                        Albero.SottoNodi.Remove(sottoNodo);
                        Albero.SottoNodi.Add(comp);
                        return;
                    }
                }
            }
            foreach (Componente sottoComponente in Albero.SottoNodi)
            {
                ModificaComponente(comp, compVecchio, compPadre, sottoComponente);
            }
        }



        private bool NodiUguali(Componente nodo1, Componente nodo2)
        {
            int NewNodo1 = nodo1.GetHashCode();
            int NewNodo2 = nodo2.GetHashCode();
            if (NewNodo1 == NewNodo2)
                return true;
            return false;
        }

        private bool NodiUgualiNoCodice(Componente nodo1, Componente nodo2)
        {
            //Componente NewNodo1 = Componente.DeepClone(nodo1);
            //Componente NewNodo2 = Componente.DeepClone(nodo2);
            //string Codice1 = NewNodo1.Codice;
            //string Codice2 = NewNodo2.Codice;
            //NewNodo1.Codice = null;
            //NewNodo2.Codice = null;
            //if (NewNodo1 == NewNodo2)
            //    return true;
            //return false;


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



        private bool CatalogoContieneCompNoControlloSottocomp(Componente comp)
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
            List<Componente> nodi = distintaBase.Nodi();
            List<Componente> nodiDistintaBase = nodi;
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


        private List<Componente> NodiDistintaBase()
        {
            List<Componente> componenti = new List<Componente>();
            List<Componente> nodi = distintaBase.Nodi();
            List<Componente> nodiDistintaBase = nodi;
            return nodiDistintaBase;
        }

        public List<Componente> NodiCatalogo()
        {
            List<Componente> componenti = new List<Componente>();
            List<Componente> nodiCatalogo = catalogo.Nodi;
            Componente compMomentaneo = new Componente();
            foreach (Componente comp in nodiCatalogo)
            {
                compMomentaneo = Componente.DeepClone<Componente>(comp);
                compMomentaneo.SottoNodi = null;
                componenti.Add(Componente.DeepClone<Componente>(compMomentaneo));
            }
            return componenti;
        }



        public Componente ComponenteDistintaBaseDaCodice(string codice)
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

        public Componente ComponenteCatalogoDaCodice(string codice)
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
        
        //-----------------------------------------------------------------------
    }
}
