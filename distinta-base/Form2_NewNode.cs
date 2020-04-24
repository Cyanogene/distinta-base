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
        public Componente nodo;
        public bool attendo = true;
        List<Componente> Componenti = new List<Componente>();
        Componente nodoInput = null;
        //--------------------------------------


        public Form2_NewNode(Componente nodo, List<Componente> componenti)
        {
            InitializeComponent();
            ActiveControl = form_nome;
            /*form_codice.Enabled = false;
            form_codice.Text = "il codice viene assegnato automaticamente";*/
            if (nodo.Nome != null)//MODIFICO UN NODO
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
                nodoInput = nodo;
            }
            Componenti.AddRange(componenti);
        }



        private void Btn_aggiungi_Click(object sender, EventArgs e)
        {
            if (nodoInput != null)
            {
                if (form_nome.Text != "" && form_codice.Text != "" && form_descrizione.Text != "" && form_leadTime.Value > 0 && form_lotto.Value > 0 && form_periodoDiCopertura.Value > 0)
                {
                    Nome = form_nome.Text;
                    Descrizione = form_descrizione.Text;
                    LT = Convert.ToInt32(form_leadTime.Value);
                    LTS = Convert.ToInt32(form_leadTimeSicurezza.Value);
                    ScortaDiSicurezza = Convert.ToInt32(form__scortaDiSicurezza.Value);
                    Lotto = Convert.ToInt32(form_lotto.Value);
                    PeriodoDiCopertura = Convert.ToInt32(form_periodoDiCopertura.Value);
                    Codice = form_codice.Text;
                    string ThaRandomPart = nodoInput.Code.Substring(nodoInput.Code.Length - 10);
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
                        Code = Nome + LT + LTS + ScortaDiSicurezza + Lotto + PeriodoDiCopertura + ThaRandomPart,
                    };
                    if (nodo == nodoInput)
                    {
                        Close();
                        return;
                    }
                    if (nodo.Codice != nodoInput.Codice && !CodiceOK(nodo))
                    {
                        nodo.Code = Nome + LT + LTS + ScortaDiSicurezza + Lotto + PeriodoDiCopertura + RandomString(10);
                        Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Il codice è già utilizzato per un altro componente, modificarlo", "ATTENZIONE");
                        form_codice.Focus();
                        form_codice.Clear();
                        nodo = null;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("compilare tutti i campi prima di procedere", "ATTENZIONE", MessageBoxButtons.OK);
                    nodo = null;
                    return;
                }
            }
            else
            {
                if (form_nome.Text != "" && form_codice.Text != "" && form_descrizione.Text != "" && form_leadTime.Value > 0 && form_lotto.Value > 0 && form_periodoDiCopertura.Value > 0)
                {
                    Nome = form_nome.Text;
                    Descrizione = form_descrizione.Text;
                    LT = Convert.ToInt32(form_leadTime.Value);
                    LTS = Convert.ToInt32(form_leadTimeSicurezza.Value);
                    ScortaDiSicurezza = Convert.ToInt32(form__scortaDiSicurezza.Value);
                    Lotto = Convert.ToInt32(form_lotto.Value);
                    PeriodoDiCopertura = Convert.ToInt32(form_periodoDiCopertura.Value);
                    Codice = form_codice.Text;
                    string ThaRandomPart = "";
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
                        Code = Nome + LT + LTS + ScortaDiSicurezza + Lotto + PeriodoDiCopertura + RandomString(10),
                    };
                    if (!CodiceOK(nodo))
                    {
                        Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Il codice è già utilizzato per un altro componente, modificarlo", "ATTENZIONE");
                        form_codice.Focus();
                        form_codice.Clear();
                        nodo = null;
                    }
                }
                else
                {
                    MessageBox.Show("compilare tutti i campi prima di procedere", "ATTENZIONE", MessageBoxButtons.OK);
                    nodo = null;
                    return;
                }
            }
        }

        private bool CodiceOK(Componente comp)
        {
            foreach(Componente componente in Componenti)
            {
                if(comp.Codice == componente.Codice)
                {
                    return true;
                }
                foreach(Componente sottoComponente in componente.SottoNodi)
                {
                    return CodiceOK(sottoComponente);
                }
            }
            return false;
        }


                        /*foreach (string codice in Componenti)
                        {
                            if (form_codice.Text == codice)
                            {
                                MessageBox.Show("Hai applicato delle modifiche al componente, modifica il codice", "ATTENZIONE", MessageBoxButtons.OK);
                                form_codice.Focus();
                                form_codice.Clear();
                                nodo = null;
                                return;
                            }
                        }
                    }
                    foreach (string codice in Componenti)
                    {
                        if (form_codice.Text == codice)
                        {
                            MessageBox.Show("Il codice inserito è già stato utilizzato", "ATTENZIONE", MessageBoxButtons.OK);
                            form_codice.Focus();
                            form_codice.Clear();
                            nodo = null;
                            return;
                        }
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("compilare tutti i campi prima di procedere", "ATTENZIONE", MessageBoxButtons.OK);
                    nodo = null;
                }
            }
            if (form_nome.Text != "" && form_codice.Text != "" && form_descrizione.Text != "" && form_leadTime.Value > 0 && form_lotto.Value > 0 && form_periodoDiCopertura.Value > 0)
            {
                Nome = form_nome.Text;
                Descrizione = form_descrizione.Text;
                LT = Convert.ToInt32(form_leadTime.Value);
                LTS = Convert.ToInt32(form_leadTimeSicurezza.Value);
                ScortaDiSicurezza = Convert.ToInt32(form__scortaDiSicurezza.Value);
                Lotto = Convert.ToInt32(form_lotto.Value);
                PeriodoDiCopertura = Convert.ToInt32(form_periodoDiCopertura.Value);
                Codice = form_codice.Text;
                string ThaRandomPart = RandomString(10);
                if(nodoInput!=null)
                {
                    ThaRandomPart = nodoInput.Code.Substring(nodoInput.Code.Length-10);
                }
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
                    Code = Nome + LT + LTS + ScortaDiSicurezza + Lotto + PeriodoDiCopertura + ThaRandomPart,
                };
                if (nodo.Nome == nodoInput.Nome && nodo.Descrizione == nodoInput.Descrizione && nodo.LeadTime == nodoInput.LeadTime && nodo.LeadTimeSicurezza == nodoInput.LeadTimeSicurezza && nodo.ScortaSicurezza == nodoInput.ScortaSicurezza && nodo.Lotto == nodoInput.Lotto && nodo.PeriodoDiCopertura == nodoInput.PeriodoDiCopertura)
                {
                    nodo = nodoInput;
                    nodo.Codice = form_codice.Text;
                    Close();
                    return;
                }
                else if(nodoInput.Nome!=null)//mi assicuro che sia una modifica di un nodo
                {
                    foreach (string codice in Componenti)
                    {
                        if (form_codice.Text == codice)
                        {
                            MessageBox.Show("Hai applicato delle modifiche al componente, modifica il codice", "ATTENZIONE", MessageBoxButtons.OK);
                            form_codice.Focus();
                            form_codice.Clear();
                            nodo = null;
                            return;
                        }
                    }
                }
                foreach (string codice in Componenti)
                {
                    if (form_codice.Text == codice)
                    {
                        MessageBox.Show("Il codice inserito è già stato utilizzato", "ATTENZIONE", MessageBoxButtons.OK);
                        form_codice.Focus();
                        form_codice.Clear();
                        nodo = null;
                        return;
                    }
                }
                Close();
            }
            else
            {
                MessageBox.Show("compilare tutti i campi prima di procedere", "ATTENZIONE", MessageBoxButtons.OK);
                nodo = null;
            }*/
        



        private Random random = new Random();

        public string RandomString(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            attendo = false;
        }

        private void form_leadTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void form_leadTimeSicurezza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void form__scortaDiSicurezza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void form_lotto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void form_periodoDiCopertura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void Form2_NewNode_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
}