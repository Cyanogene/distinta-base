using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace distinta_base
{

    public partial class Form2_NewNode : Form
    {
        string Nome = "";
        string Codice = "";
        string Descrizione = "";
        int LT = 0;
        int LTS = 0;
        int ScortaDiSicurezza = 0;
        int Lotto = 0;
        int PeriodoDiCopertura = 0;
        int CoefficenteUtilizzo = 0;

        public Componente Nodo;
        Componente NodoInput = null;
        List<Componente> Componenti = new List<Componente>();
        public bool Attendo = true;

        public Form2_NewNode(Componente nodo, List<Componente> componenti, bool IsCatalogoOrRoot)
        {
            InitializeComponent();
            ActiveControl = form_nome;
            /*form_codice.Enabled = false;
            form_codice.Text = "il codice viene assegnato automaticamente";*/

            label1.BackColor = Color.FromArgb(232, 190, 118);
            if (IsCatalogoOrRoot)
            {
                form_coeffDiUtilizzo.Visible = false;
                label3.Visible = false;
                pictureBox8.Visible = false;
            }

            if (nodo.Nome != null)
            {
                label1.Text = "MODIFICA COMPONENTE";
                Btn_aggiungi.Text = "CONFERMA";
                form_nome.Text = nodo.Nome;
                form_codice.Text = nodo.Codice;
                form_descrizione.Text = nodo.Descrizione;
                form_leadTime.Value = nodo.LeadTime;
                form_leadTimeSicurezza.Value = nodo.LeadTimeSicurezza;
                form__scortaDiSicurezza.Value = nodo.ScortaSicurezza;
                form_lotto.Value = nodo.Lotto;
                form_periodoDiCopertura.Value = nodo.PeriodoDiCopertura;
                form_coeffDiUtilizzo.Value = nodo.CoefficenteUtilizzo;
                NodoInput = nodo;
            }
            Componenti.AddRange(componenti);
        }


        private void Form2_NewNode_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Attendo = false;
        }
        
        private void form_codice_Validating(object sender, CancelEventArgs e)
        {
            bool ris = form_codice.Text.All(char.IsLetterOrDigit);
            if (!ris)
            {
                MessageBox.Show("Il codice può essere composto solo da lettere e numeri.", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form_codice.Text = "";
                form_codice.Focus();
                return;
            }
        }



        private void Btn_aggiungi_Click(object sender, EventArgs e)
        {
            if (form_nome.Text != "" && form_codice.Text != "" && form_descrizione.Text != "")
            {
                CreaNodo();
                CheckCode();
            }
            else
            {
                MessageBox.Show("Compila tutti i campi vuoti.", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        /// <summary>
        /// Crea un nodo con i dati ricevuti in input dall'interfaccia.
        /// </summary>
        private void CreaNodo()
        {
            Nome = form_nome.Text;
            Descrizione = form_descrizione.Text;
            LT = Convert.ToInt32(form_leadTime.Value);
            LTS = Convert.ToInt32(form_leadTimeSicurezza.Value);
            ScortaDiSicurezza = Convert.ToInt32(form__scortaDiSicurezza.Value);
            Lotto = Convert.ToInt32(form_lotto.Value);
            PeriodoDiCopertura = Convert.ToInt32(form_periodoDiCopertura.Value);
            Codice = form_codice.Text;
            CoefficenteUtilizzo = Convert.ToInt32(form_coeffDiUtilizzo.Value);
            Nodo = new Componente
            {
                Nome = Nome,
                Codice = Codice,
                Descrizione = Descrizione,
                LeadTime = LT,
                LeadTimeSicurezza = LTS,
                ScortaSicurezza = ScortaDiSicurezza,
                Lotto = Lotto,
                PeriodoDiCopertura = PeriodoDiCopertura,
                CoefficenteUtilizzo = CoefficenteUtilizzo,
            };
        }

        /// <summary>
        /// Controlla il codice del nuovo nodo, se è ok restituisce il nodo altrimenti comunica all'utente che il codice va cambiato.
        /// </summary>
        private void CheckCode()
        {
            if (codiceOK(Nodo))
            {
                Close();
                return;
            }

            else
            {
                MessageBox.Show("Il codice inserito è già in uso per un altro componente", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Nodo = null;
                form_codice.Clear();
                form_codice.Focus();
                return;
            }
        }

        /// <summary>
        /// Restituisce true se il codice del nodo ricevuto in input (componenteDaControllare) va bene.
        /// </summary>
        private bool ControlloCodice(Componente ComponenteDaControllare, Componente Componente)
        {
            if (Componente.SottoNodi != null)
            {
                foreach (Componente SottoComponente in ComponenteDaControllare.SottoNodi)
                {
                    if (!ControlloCodice(ComponenteDaControllare, SottoComponente))
                    {
                        return false;
                    }
                }
            }
            if (ComponenteDaControllare.Codice == Componente.Codice)
            {
                if (NodoInput != null)
                {
                    if (NodiUgualiNoCodiceNoSottocomp(ComponenteDaControllare, Componente) || (NodiUgualiNoCodiceNoSottocomp(Componente, NodoInput) && ContatoreCodice(Componente.Codice) == 1))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (NodiUgualiNoCodiceNoSottocomp(ComponenteDaControllare, Componente))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        /// <summary>
        /// Restituisce true se il codice del nodo ricevuto in input (componenteDaControllare) va bene (lavora insieme al metodo ControlloCodice).
        /// </summary>
        private bool codiceOK(Componente Componente)
        {
            foreach (Componente Comp in Componenti)
            {
                if (!ControlloCodice(Componente, Comp))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Restituisce il numero di volte che il codice è utilizzato nei componenti del programma.
        /// </summary>
        private int ContatoreCodice(string Codice)
        {
            int n = 0;
            foreach (Componente Componente in Componenti)
            {
                n += contatoreCodiceSecondario(Codice, Componente);
            }
            return n;
        }

        /// <summary>
        /// Restituisce il numero di volte che il codice è utilizzato nei componenti del programma (lavora insieme al metodo contatoreCodice).
        /// </summary>
        private int contatoreCodiceSecondario(string Codice, Componente Componente)
        {
            int Contatore = 0;
            if (Componente.Codice == Codice)
            {
                Contatore++;
            }
            if (Componente.SottoNodi != null)
            {
                foreach (Componente sottoComp in Componente.SottoNodi)
                {
                    Contatore += contatoreCodiceSecondario(Codice, sottoComp);
                }
            }
            return Contatore;
        }
        
        /// <summary>
        /// Restituisce true se i nodi dati in input hanno tutte le variabili uguali eccetto i sottonodi.
        /// </summary>
        private bool NodiUgualiNoCodiceNoSottocomp(Componente Nodo1, Componente Nodo2)
        {
            if (Nodo1.Nome == Nodo2.Nome && Nodo1.Descrizione == Nodo2.Descrizione && Nodo1.LeadTime == Nodo2.LeadTime && Nodo1.LeadTimeSicurezza == Nodo2.LeadTimeSicurezza && Nodo1.ScortaSicurezza == Nodo2.ScortaSicurezza && Nodo1.Lotto == Nodo2.Lotto && Nodo1.PeriodoDiCopertura == Nodo2.PeriodoDiCopertura)
            {
                return true;
            }
            return false;
        }


        
    }
}