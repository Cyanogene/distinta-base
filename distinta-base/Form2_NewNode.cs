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
    //TUTTE LE PARTI COMMENTATE IN QUESTO NAMESPACE SERVONO ALL'ASSEGNAZIONE AUTOMATICA DEL CODICE, NON CANCELLARE

    public partial class Form2_NewNode : Form
    {
        //variabili NODO------------------------
        string Nome = "";
        string Codice = "";
        string Descrizione = "";
        int LT = 0;
        int LTS = 0;
        int ScortaDiSicurezza = 0;
        int Lotto = 0;
        int PeriodoDiCopertura = 0;
        int CoefficenteUtilizzo = 0;
        public Componente nodo;
        public bool attendo = true;
        List<Componente> Componenti = new List<Componente>();
        Componente nodoInput = null;
        //--------------------------------------

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
                nodoInput = nodo;
            }
            Componenti.AddRange(componenti);
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

        private void CheckCode()
        {
            if (codiceOK(nodo))
            {
                Close();
                return;
            }

            else
            {
                MessageBox.Show("Il codice inserito è già in uso per un altro componente", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nodo = null;
                form_codice.Clear();
                form_codice.Focus();
                return;
            }
        }

        private bool ControlloCodice(Componente componenteDaControllare, Componente componente)
        {
            if (componente.SottoNodi != null)
            {
                foreach (Componente sottoComp in componenteDaControllare.SottoNodi)
                {
                    if (!ControlloCodice(componenteDaControllare, sottoComp))
                    {
                        return false;
                    }
                }
            }
            if (componenteDaControllare.Codice == componente.Codice)
            {
                if (nodoInput != null)
                {
                    if (NodiUgualiNoCodiceNoSottocomp(componenteDaControllare, componente) || (NodiUgualiNoCodiceNoSottocomp(componente, nodoInput) && contatoreCodice(componente.Codice) == 1))
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
                    if (NodiUgualiNoCodiceNoSottocomp(componenteDaControllare, componente))
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

        private int contatoreCodice(string codice)
        {
            int n = 0;
            foreach (Componente comp in Componenti)
            {
                n += contatoreCodiceSecondario(codice, comp);
            }
            return n;
        }

        public int contatoreCodiceSecondario(string codice, Componente comp)
        {
            int n = 0;
            if (comp.Codice == codice)
            {
                n++;
            }
            if (comp.SottoNodi != null)
            {
                foreach (Componente sottoComp in comp.SottoNodi)
                {
                    n += contatoreCodiceSecondario(codice, sottoComp);
                }
            }
            return n;
        }

        private bool codiceOK(Componente comp)
        {
            foreach (Componente componente in Componenti)
            {
                if (!ControlloCodice(comp, componente))
                {
                    return false;
                }
            }
            return true;
        }

        private bool NodiUgualiNoCodiceNoSottocomp(Componente nodo1, Componente nodo2)
        {
            if (nodo1.Nome == nodo2.Nome && nodo1.Descrizione == nodo2.Descrizione && nodo1.LeadTime == nodo2.LeadTime && nodo1.LeadTimeSicurezza == nodo2.LeadTimeSicurezza && nodo1.ScortaSicurezza == nodo2.ScortaSicurezza && nodo1.Lotto == nodo2.Lotto && nodo1.PeriodoDiCopertura == nodo2.PeriodoDiCopertura)
            {
                return true;
            }
            return false;
        }

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
            nodo = new Componente
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

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            attendo = false;
        }

        private void Form2_NewNode_Load(object sender, EventArgs e)
        {
            CenterToParent();
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
    }
}