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
        public DistintaBase DistintaBase = new DistintaBase();
        public Catalogo Catalogo = new Catalogo();


        // Metodi Generali---------------------------------------------------------------


        /// <summary>
        /// Apre la finestra di creazione della materia prima. Creata quest'ultima, ritorno il componente creato.
        /// </summary>
        /// <param name="Componenti">La lista di tutti i componenti.</param>
        /// <returns></returns>
        public Componente AggiungiMateriaPrima(List<Componente> Componenti, bool IsCatalogoOrRoot)
        {
            Form2_NewNode form2 = new Form2_NewNode(new Componente(), Componenti, IsCatalogoOrRoot);
            form2.ShowDialog();
            Componente Componente = form2.Nodo;
            while (Componente == null)
            {
                if (!form2.Attendo)
                {
                    return null;
                }
            }
            return Componente;
        }

        /// <summary>
        /// Restituisce una lista di Componenti senza doppioni (non considerando i sottoComponenti).
        /// </summary>
        public List<Componente> Componenti()
        {
            List<Componente> Componenti = new List<Componente>();
            List<Componente> NodiDistintaBase = ComponentiDistintaBase();
            List<Componente> NodiCatalogo = ComponentiCatalogo();

            Componente CompMomentaneo = new Componente();
            foreach (Componente Comp in NodiDistintaBase)
            {
                CompMomentaneo = Componente.DeepClone<Componente>(Comp);
                bool Agggiungi = true;
                foreach (Componente componente in Componenti)
                {
                    if (NodiUgualiNoSottocomp(componente, CompMomentaneo))
                    {
                        Agggiungi = false;
                    }
                }
                if (Agggiungi)
                {
                    CompMomentaneo.SottoNodi = null;
                    Componenti.Add(Componente.DeepClone<Componente>(CompMomentaneo));
                }
            }
            foreach (Componente Comp in NodiCatalogo)
            {
                CompMomentaneo = Componente.DeepClone<Componente>(Comp);
                bool Aggiungi = true;
                foreach (Componente Componente in Componenti)
                {
                    if (NodiUgualiNoSottocomp(Componente, CompMomentaneo))
                    {
                        Aggiungi = false;
                    }
                }
                if (Aggiungi)
                {
                    CompMomentaneo.SottoNodi = null;
                    Componenti.Add(Componente.DeepClone<Componente>(CompMomentaneo));
                }
            }
            return Componenti;
        }

        /// <summary>
        /// Restituisce una lista di Componenti senza doppioni.
        /// </summary>
        public List<Componente> TuttiComponenti()
        {
            List<Componente> Componenti = new List<Componente>();
            List<Componente> DistintaBaseNodi = DistintaBase.Nodi();
            List<Componente> CatalogoNodi = NodiCatalogo();
            Componente CompMomentaneo = new Componente();
            foreach (Componente Comp in DistintaBaseNodi)
            {
                CompMomentaneo = Componente.DeepClone<Componente>(Comp);
                CompMomentaneo.SottoNodi = null;
                Componenti.Add(Componente.DeepClone<Componente>(CompMomentaneo));
            }
            foreach (Componente comp in CatalogoNodi)
            {
                CompMomentaneo = Componente.DeepClone<Componente>(comp);
                CompMomentaneo.SottoNodi = null;
                Componenti.Add(Componente.DeepClone<Componente>(CompMomentaneo));
            }
            return Componenti;
        }

        /// <summary>
        /// Controlla se il codice selezionato è valido.
        /// </summary>
        /// <param name="Comp">Componente da controllare.</param>
        /// <param name="Componenti">La lista di tutti i componenti.</param>
        /// <returns></returns>
        public bool ControllaCodice(Componente Comp, Componente CompDaSostituire, List<Componente> Componenti)
        {
            foreach (Componente Componente in Componenti)
            {
                if (!ControlloCodiceSingoloComponente(Comp, Componente))
                {
                    int Cont = 0;
                    List<Componente> TuttiIComponenti = TuttiComponenti();
                    foreach (Componente Component in TuttiIComponenti)
                    {
                        if (NodiUgualiNoSottocomp(CompDaSostituire, Component))
                        {
                            Cont++;
                        }
                    }
                    if (Cont == 1)
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
        /// <param name="Componente">Componente attualmente selezionato nel ciclo di controllo.</param>
        /// <param name="ComponenteDaControllare">Componente da controllare.</param>
        /// <returns></returns>
        private bool ControlloCodiceSingoloComponente(Componente Componente, Componente ComponenteDaControllare)
        {
            if (Componente.SottoNodi != null)
            {
                foreach (Componente SottoComp in Componente.SottoNodi)
                {
                    if (!ControlloCodiceSingoloComponente(ComponenteDaControllare, SottoComp))
                    {
                        return false;
                    }
                }
            }

            if (ComponenteDaControllare.Codice == Componente.Codice)
            {
                if (NodiUgualiNoSottocomp(ComponenteDaControllare, Componente))
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
        /// Restituisce il componente che in catalogo ha codice uguale alla stringa ricevuta in input (codice).
        /// </summary>
        public Componente ComponenteCatalogoDaCodice(string Codice)
        {
            List<Componente> Componenti = Catalogo.Nodi;
            if (Componenti == null) return null;
            foreach (Componente Comp in Componenti)
            {
                if (Comp.Codice == Codice)
                {
                    return Comp;
                }
            }
            return null;
        }

        /// <summary>
        /// Restituisce una lista di componenti del catalogo.
        /// </summary>
        public List<Componente> ComponentiCatalogo()
        {
            List<Componente> Componenti = new List<Componente>();
            List<Componente> NodiCatalogo = Catalogo.Nodi;
            Componente CompMomentaneo = new Componente();
            foreach (Componente Comp in NodiCatalogo)
            {
                CompMomentaneo = Componente.DeepClone<Componente>(Comp);
                bool Aggiungi = true;
                foreach (Componente Componente in Componenti)
                {
                    if (NodiUgualiNoSottocomp(Componente, CompMomentaneo))
                    {
                        Aggiungi = false;
                    }
                }
                if (Aggiungi)
                {
                    Componenti.Add(Componente.DeepClone<Componente>(CompMomentaneo));
                }
            }
            return Componenti;
        }

        /// <summary>
        /// Aggiunge il componente selezionato al catalogo.
        /// </summary>
        /// <param name="TreeView">L'albero dove è presente il nodo selezionato.</param>
        public void AggiungiComponenteACatalogo(TreeView TreeView)
        {
            Componente Comp = Componente.DeepClone<Componente>(DistintaBase.TreeNodeToNode(TreeView.SelectedNode));
            if (CatalogoContieneComp(Comp))
            {
                MessageBox.Show("In catalogo è già presente questo componente", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (CatalogoContieneCompNoControlloSottocomp(Comp))
            {
                DialogResult dialogResult = MessageBox.Show("Un componente con codice uguale è già presente nel catalogo, vuoi sostituirlo?", "Distinta Base", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    RimuoviComponenteDaCatalogo(Comp.Codice);
                    Catalogo.Nodi.Add(Comp);
                }
                return;
            }
            Catalogo.Nodi.Add(Comp);
        }

        /// <summary>
        /// Aggiorna la tabella del catalogo.
        /// </summary>
        /// <param name="ListView">La tabella-catalogo da aggiornare.</param>
        public void AggiornaCatalogo(ListView ListView)
        {
            ListView.Items.Clear();
            int i = 0;
            foreach (Componente Comp in Catalogo.Nodi)
            {
                string[] items = { Comp.Nome, Comp.Codice, Comp.Descrizione };
                ListViewItem ListViewNodo = new ListViewItem(items)
                {
                    Font = new Font("Microsoft Tai Le", 12)
                };
                if (i % 2 != 0)
                    ListViewNodo.BackColor = Color.FromArgb(238, 239, 249);
                ListView.Items.Add(ListViewNodo);
                i++;
            }
        }

        /// <summary>
        /// Aggiunge un semilavorato nel catalogo.
        /// </summary>
        public void AggiungiSemilavoratoACatalogo()
        {
            Componente Comp = Catalogo.AggiungiSemilavorato();
            if (Comp == null) return;
            if (!ControllaCodice(Comp, new Componente(), Componenti()))
            {
                MessageBox.Show("Nel semilavorato che si sta caricando è presente un componente con codice uguale a un componente presente nel programma sebbene non siano lo stesso componente", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (CatalogoContieneComp(Comp))
                {
                    MessageBox.Show("Nel catalogo è già presente il semilavorato che si desidera caricare", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (CatalogoContieneCompNoControlloSottocomp(Comp))
                {
                    if (MessageBox.Show("Nel catalogo è già presente un componente uguale ma con sottocomponenti diversi, si desidera sostituire il componente?", "Distinta Base", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        RimuoviComponenteDaCatalogo(Comp.Codice);
                        Catalogo.Nodi.Add(Comp);
                    }
                }
            }
            Catalogo.Nodi.Add(Comp);
        }

        /// <summary>
        /// Aggiunge una materia prima nel catalogo.
        /// </summary>
        public void AggiungiMateriaPrimaACatalogo()
        {
            Componente Comp = AggiungiMateriaPrima(Componenti(), true);
            if (Comp == null) return;
            Comp.CoefficenteUtilizzo = 1;
            foreach (Componente Componente in Catalogo.Nodi)
            {
                if (NodiUgualiNoSottocomp(Componente, Comp))
                {
                    MessageBox.Show("In catalogo è già presente questo componente.", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Catalogo.Nodi.Add(Comp);
        }

        /// <summary>
        /// Il componente del catalogo selezionato.
        /// </summary>
        /// <param name="Codice">Il codice del componente da modificare.</param>
        public void ModificaComponenteCatalogo(string Codice)
        {
            Componente CompVechio = ComponenteCatalogoDaCodice(Codice);
            if (CompVechio == null) return;
            Componente NewComp = Catalogo.Modifica(CompVechio, TuttiComponenti());
            if (NewComp == null) return;

            if (CatalogoContieneComp(NewComp))
            {
                if (!NodiUguali(CompVechio, NewComp))
                {
                    MessageBox.Show("In catalogo è già presente questo componente", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }

            if (!ControllaCodice(NewComp, CompVechio, Componenti()))
            {
                MessageBox.Show("Nel componente modificato è presente un componente con codice uguale a un componente presente nel programma sebbene non siano lo stesso componente", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            RimuoviComponenteDaCatalogo(CompVechio.Codice);
            Catalogo.Nodi.Add(Componente.DeepClone<Componente>(NewComp));
        }

        /// <summary>
        /// Rimuove un componente dal catalogo.
        /// </summary>
        /// <param name="Codice">Il codice del componente da rimuovere.</param>
        public void RimuoviComponenteDaCatalogo(string Codice)
        {
            Catalogo.Nodi.Remove(ComponenteCatalogoDaCodice(Codice));
        }

        /// <summary>
        /// Restituisce una stringa contenente le informazioni del componente selezionato.
        /// </summary>
        /// <param name="Codice">Il codice del componente selezionato.</param>
        /// <returns></returns>
        public string InfoComponenteCatalogo(string Codice)
        {
            Componente Componente = ComponenteCatalogoDaCodice(Codice);
            if (Componente == null) return "selezionare un componente";
            return "NOME --> " + Componente.Nome + "\nCODICE --> " + Componente.Codice + "\nDESCRIZIONE --> " + Componente.Descrizione + "\nLEAD TIME --> " + Componente.LeadTime + "\nLEAD TIME SICUREZZA --> " + Componente.LeadTimeSicurezza + "\nLOTTO --> " + Componente.Lotto + "\nSCORTA DI SICUREZZA --> " + Componente.ScortaSicurezza + "\nPERIODO DI COPERTURA --> " + Componente.PeriodoDiCopertura;
        }



        //distintaBase-----------------------------------------------------------


        /// <summary>
        /// Ritorna un componente usando il suo codice.
        /// </summary>
        /// <param name="Codice">Il codice del componente.</param>
        public Componente ComponenteDistintaBaseDaCodice(string Codice)
        {
            List<Componente> Componenti = ComponentiDistintaBase();
            if (Componenti == null) return null;
            foreach (Componente Comp in Componenti)
            {
                if (Comp.Codice == Codice)
                {
                    return Comp;
                }
            }
            return null;
        }

        /// <summary>
        /// Salva una distinta base.
        /// </summary>
        public void salvaDistintaBase()
        {
            DistintaBase.Salva();
        }

        /// <summary>
        /// Carica una distinta base.
        /// </summary>
        /// <returns></returns>
        public TreeNode caricaDistintaBase()
        {
            Componente Albero = Componente.DeepClone<Componente>(DistintaBase.Carica());
            if (Albero == null) return DistintaBase.NodeToTreeNode(DistintaBase.Albero);
            if (!ControllaCodice(Albero, new Componente(), Componenti()))
            {
                MessageBox.Show("Nel semilavorato che si sta caricando vi sono 1 o più componenti con codice uguale a un componente presente nel programma sebbene non siano lo stesso componente", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DistintaBase.NodeToTreeNode(DistintaBase.Albero);
            }
            DistintaBase.Albero = Albero;
            return DistintaBase.NodeToTreeNode(DistintaBase.Albero);
        }

        /// <summary>
        /// Crea una distinta base.
        /// </summary>
        /// <returns></returns>
        public TreeNode CreaNuovaDistintaBase()
        {
            Componente NewComp = AggiungiMateriaPrima(Componenti(), true);
            if (NewComp == null) return null;
            if (ControllaCodice(NewComp, new Componente(), s()))
            {
                DistintaBase.Albero = NewComp;
            }
            return DistintaBase.NodeToTreeNode(DistintaBase.Albero);
        }

        /// <summary>
        /// Carica un componente dal catalogo.
        /// </summary>
        public TreeNode CaricaDaCatalogo()
        {
            if (Catalogo.Nodi.Count() == 0) { MessageBox.Show("Il catalogo è vuoto", "Distinta Base"); return null; }
            Componente Comp = Componente.DeepClone(DistintaBase.CaricaDaCatalogo(Catalogo.Nodi));
            if (Comp == null) return null;
            DistintaBase.Albero = Comp;
            return DistintaBase.NodeToTreeNode(DistintaBase.Albero);
        }
        
        /// <summary>
        /// Rimuove il nodo selezionato.
        /// </summary>
        /// <param name="TreeView">L'albero dove è presente il nodo selezionato.</param>
        public void RimuoviNodo(TreeView TreeView)
        {
            if (TreeView.SelectedNode == TreeView.Nodes[0])
            {
                DistintaBase.Albero = new Componente();
            }
            else
            {
                TreeNode CompDaEliminare = TreeView.SelectedNode;
                TreeNode CompPadra = CompDaEliminare.Parent;
                Componente Comp = DistintaBase.TreeNodeToNode(CompDaEliminare);
                Componente compPadre = DistintaBase.TreeNodeToNode(CompPadra);
                EliminaComponente(Comp, compPadre, DistintaBase.Albero);
            }
        }

        /// <summary>
        /// Carica un nodo da un file.
        /// </summary>
        /// <param name="TreeView">L'albero dove caricare il nodo.</param>
        /// <returns></returns>
        public TreeNode CaricaNodoDaFile(TreeView TreeView)
        {
            Componente NewComponente = Componente.DeepClone(DistintaBase.CaricaNodoDaFile());
            if (NewComponente == null) return null;
            Componente CompPadre = DistintaBase.TreeNodeToNode(TreeView.SelectedNode);
            if (ControllaCodice(NewComponente, new Componente(), Componenti()))
            {
                if (!AggiungiComponente(NewComponente, CompPadre, DistintaBase.Albero, new List<Componente>(), true))
                    return null;
            }
            else
            {
                MessageBox.Show("Nel semilavorato che si sta caricando vi sono 1 o più componenti con codice uguale a un componente presente nel programma sebbene non siano lo stesso componente", "Distinta Base");
                return null;
            }
            return DistintaBase.NodeToTreeNode(NewComponente);
        }

        /// <summary>
        /// Carica un nodo dal catalogo.
        /// </summary>
        /// <param name="TreeView">L'albero dove caricare il nodo.</param>
        public TreeNode CaricaNodoDaCatalogo(TreeView TreeView)
        {
            if (Catalogo.Nodi.Count() == 0) { MessageBox.Show("Il catalogo è vuoto", "Distinta Base"); return null; }
            Componente Comp = Componente.DeepClone(DistintaBase.CaricaDaCatalogo(Catalogo.Nodi));
            if (Comp == null) return null;
            Componente CompPadra = DistintaBase.TreeNodeToNode(TreeView.SelectedNode);
            if (ControllaCodice(Comp, new Componente(), Componenti()))
            {
                if (!AggiungiComponente(Comp, CompPadra, DistintaBase.Albero, new List<Componente>(), true))
                    return null;
            }
            return DistintaBase.NodeToTreeNode(Comp);
        }

        /// <summary>
        /// Carica un TreeNode.
        /// </summary>
        /// <param name="TreeView">L'albero dove caricare il TreeNode.</param></param>
        /// <returns></returns>
        public TreeNode CaricaTreeNodeMateriaPrima(TreeView TreeView)
        {
            Componente NewComponente = Componente.DeepClone(AggiungiMateriaPrima(ComponentiDistintaBase(), false));
            if (NewComponente == null) return null;
            Componente CompPadre = DistintaBase.TreeNodeToNode(TreeView.SelectedNode);
            if (ControllaCodice(NewComponente, new Componente(), Componenti()))
            {
                if (!AggiungiComponente(NewComponente, CompPadre, DistintaBase.Albero, new List<Componente>(), true))
                    return null;
            }
            return DistintaBase.NodeToTreeNode(NewComponente);
        }

        /// <summary>
        /// Modifica il nodo selezionato.
        /// </summary>
        /// <param name="TreeView">L'albero dove cercare il nodo selezionato.</param></param>
        public TreeNode ModificaNodo(TreeView TreeView)
        {
            bool IsRadice = false;
            Componente CompVecchio = DistintaBase.TreeNodeToNode(TreeView.SelectedNode);
            if (TreeView.SelectedNode.Parent == null)
            {
                IsRadice = true;
            }
            Form2_NewNode Form2 = new Form2_NewNode(CompVecchio, TuttiComponenti(), IsRadice);
            Form2.ShowDialog();
            Componente NewComp = Form2.Nodo;
            List<Componente> nodi = DistintaBase.Nodi();
            NewComp = Componente.DeepClone(NewComp);
            if (NewComp == null) return null;
            if (ControllaCodice(NewComp, CompVecchio, Componenti()))
            {
                if (nodi.Count == 1)
                {
                    DistintaBase.Albero = NewComp;
                    return DistintaBase.NodeToTreeNode(DistintaBase.Albero);
                }
                else
                {
                    if (!(TreeView.SelectedNode.Parent == null))
                    {
                        Componente CompPadre = DistintaBase.TreeNodeToNode(TreeView.SelectedNode.Parent);
                        ModificaComponente(NewComp, CompVecchio, CompPadre, DistintaBase.Albero);
                    }
                    else
                    {
                        NewComp.SottoNodi = CompVecchio.SottoNodi;
                        DistintaBase.Albero = NewComp;
                    }
                }
            }
            else
            {
                MessageBox.Show("Il componente ha codice uguale a un componente presente nel programma sebbene non siano lo stesso componente.\nLe modifiche non verranno appliccate", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return DistintaBase.NodeToTreeNode(NewComp);
        }

        /// <summary>
        /// Restituisce una stringa contenente le informazioni del componente selezionato.
        /// </summary>
        /// <param name="Codice">Il codice del componente selezionato.</param>
        public string InfoComponenteDistintabase(string Codice)
        {
            Componente Componente = ComponenteDistintaBaseDaCodice(Codice);
            if (Componente == null) return "selezionare un componente";
            return "NOME --> " + Componente.Nome + "\nCODICE --> " + Componente.Codice + "\nDESCRIZIONE --> " + Componente.Descrizione + "\nLEAD TIME --> " + Componente.LeadTime + "\nLEAD TIME SICUREZZA --> " + Componente.LeadTimeSicurezza + "\nLOTTO --> " + Componente.Lotto + "\nSCORTA DI SICUREZZA --> " + Componente.ScortaSicurezza + "\nPERIODO DI COPERTURA --> " + Componente.PeriodoDiCopertura;
        }


        //metodiDiAppoggio-------------------------------------------------------

        /// <summary>
        /// Aggiunge un componente alla variabile albero in distintaBase.
        /// </summary>
        private bool AggiungiComponente(Componente Comp, Componente CompPadre, Componente Albero, List<Componente> NodiSoprastanti, bool OK)
        {
            if (Albero == CompPadre)
            {
                bool Ok = true;
                foreach (Componente Componente in NodiSoprastanti)
                {
                    if (NodiUgualiNoSottocomp(Componente, Comp))
                        Ok = false;
                }

                if (Ok && !NodiUgualiNoSottocomp(Comp, CompPadre))
                {
                    if (Albero.SottoNodi == null)
                        Albero.SottoNodi = new List<Componente>();

                    foreach (Componente Componente in Albero.SottoNodi)
                    {
                        if (NodiUgualiNoSottocomp(Componente, Comp))
                        {
                            MessageBox.Show("Il componente che si desidera aggiungere è già presente nel nodo, modificare il coefficiente di utilizzo", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }
                    Albero.SottoNodi.Add(Comp);
                    return true;
                }
                else if (OK)
                {
                    MessageBox.Show("Un componente non può avere come sotto componente sè stesso", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            Componente NewComp = Componente.DeepClone(Albero);
            NewComp.SottoNodi = null;
            NodiSoprastanti.Add(NewComp);
            if (Albero.SottoNodi != null && Albero.SottoNodi.Count > 0)
            {
                foreach (Componente SottoComponente in Albero.SottoNodi)
                {
                    if (AggiungiComponente(Comp, CompPadre, SottoComponente, NodiSoprastanti, OK))
                        return true;
                }
            }
            NodiSoprastanti.RemoveAt(NodiSoprastanti.Count - 1);
            return false;
        }


        /// <summary>
        /// Elimina un componente dalla variabile albero in distintaBase.
        /// </summary>
        private void EliminaComponente(Componente Comp, Componente CompPadre, Componente Albero)
        {
            if (NodiUguali(Albero, CompPadre))
            {
                foreach (Componente SottoNodo in Albero.SottoNodi)
                {
                    if (NodiUguali(SottoNodo, Comp))
                    {
                        Albero.SottoNodi.Remove(SottoNodo);
                        return;
                    }
                }
            }
            if (Albero.SottoNodi != null && Albero.SottoNodi.Count > 0)
            {
                foreach (Componente sottoComponente in Albero.SottoNodi)
                {
                    EliminaComponente(Comp, CompPadre, sottoComponente);
                }
            }
        }

        /// <summary>
        /// Modifica un componente nella variabile albero in distintaBase.
        /// </summary>
        private void ModificaComponente(Componente Comp, Componente CompVecchio, Componente CompPadre, Componente Albero)
        {
            if (NodiUguali(Albero, CompPadre))
            {
                Comp.SottoNodi = CompVecchio.SottoNodi;
                foreach (Componente SottoNodo in Albero.SottoNodi)
                {
                    if (NodiUguali(SottoNodo, CompVecchio))
                    {
                        Albero.SottoNodi.Remove(SottoNodo);
                        Albero.SottoNodi.Add(Comp);
                        return;
                    }
                }
            }
            foreach (Componente SottoComponente in Albero.SottoNodi)
            {
                ModificaComponente(Comp, CompVecchio, CompPadre, SottoComponente);
            }
        }

        /// <summary>
        /// Controlla se 2 nodi sono uguali (non controlla i codici).
        /// </summary>
        private bool NodiUgualiNoCodice(Componente Comp1, Componente Comp2)
        {
            Componente Nodo1 = Componente.DeepClone(Comp1);
            Componente Nodo2 = Componente.DeepClone(Comp2);
            Nodo1.Codice = null;
            Nodo2.Codice = null;
            return NodiUguali(Nodo1, Nodo2);
        }

        /// <summary>
        /// Controlla se 2 nodi sono uguali (non controlla i sottocomponenti).
        /// </summary>
        private bool NodiUgualiNoSottocomp(Componente Comp1, Componente Como2)
        {
            Componente Nodo1 = Componente.DeepClone(Comp1);
            Componente Nodo2 = Componente.DeepClone(Como2);
            Nodo1.SottoNodi = new List<Componente>();
            Nodo2.SottoNodi = new List<Componente>();
            return NodiUguali(Nodo1, Nodo2);
        }

        /// <summary>
        /// Controlla se 2 nodi sono uguali.
        /// </summary>
        private bool NodiUguali(Componente Nodo1, Componente Nodo2)
        {
            if (Nodo1.Codice == Nodo2.Codice && Nodo1.Nome == Nodo2.Nome && Nodo1.Descrizione == Nodo2.Descrizione && Nodo1.LeadTime == Nodo2.LeadTime && Nodo1.LeadTimeSicurezza == Nodo2.LeadTimeSicurezza && Nodo1.ScortaSicurezza == Nodo2.ScortaSicurezza && Nodo1.Lotto == Nodo2.Lotto && Nodo1.PeriodoDiCopertura == Nodo2.PeriodoDiCopertura)
            {
                if (Nodo1.SottoNodi.Count == Nodo2.SottoNodi.Count)
                {
                    for (int i = 0; i < Nodo1.SottoNodi.Count; i++)
                    {
                        if (!(NodiUguali(Nodo1.SottoNodi[i], Nodo2.SottoNodi[i])))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }


        /// <summary>
        /// Controlla se il catalogo contiene il componente selezionato (non controlla i sottoComponenti).
        /// </summary>
        /// <param name="Comp">Il componente da controllare.</param>
        private bool CatalogoContieneCompNoControlloSottocomp(Componente Comp)
        {
            List<Componente> ComponentiInCatalogo = ComponentiCatalogo();
            foreach (Componente Componente in ComponentiInCatalogo)
            {
                if (NodiUgualiNoSottocomp(Comp, Componente))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Controlla se il catalogo contiene il componente selezionato.
        /// </summary>
        /// <param name="Comp">Il componente da controllare.</param>
        private bool CatalogoContieneComp(Componente Comp)
        {
            List<Componente> ComponentiInCatalogo = ComponentiCatalogo();
            foreach (Componente Componente in ComponentiInCatalogo)
            {
                if (NodiUguali(Comp, Componente))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Restituisce una lista di componenti della distinta base.
        /// </summary>
        private List<Componente> ComponentiDistintaBase()
        {
            List<Componente> Componenti = new List<Componente>();
            List<Componente> Nodi = DistintaBase.Nodi();
            List<Componente> NodiDistintaBase = Nodi;
            Componente CompMomentaneo = new Componente();
            foreach (Componente Comp in NodiDistintaBase)
            {
                CompMomentaneo = Componente.DeepClone<Componente>(Comp);
                bool Aggiungi = true;
                foreach (Componente Componente in Componenti)
                {
                    if (NodiUgualiNoSottocomp(Componente, CompMomentaneo))
                    {
                        Aggiungi = false;
                    }
                }
                if (Aggiungi)
                {
                    CompMomentaneo.SottoNodi = null;
                    Componenti.Add(Componente.DeepClone<Componente>(CompMomentaneo));
                }
            }
            return Componenti;
        }

        /// <summary>
        /// Inserisce tutti i componenti del catalogo in una lista.
        /// </summary>
        public List<Componente> NodiCatalogo()
        {
            List<Componente> Componenti = new List<Componente>();
            List<Componente> NodiCatalogo = Catalogo.Nodi;
            Componente CompMomentaneo = new Componente();
            foreach (Componente Comp in NodiCatalogo)
            {
                CompMomentaneo = Componente.DeepClone<Componente>(Comp);
                CompMomentaneo.SottoNodi = null;
                Componenti.Add(Componente.DeepClone<Componente>(CompMomentaneo));
            }
            return Componenti;
        }
    }
}
