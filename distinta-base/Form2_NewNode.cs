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
        List<string> codici = new List<string>();
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
                    };
                    if ( nodo.Nome == nodoInput.Nome && nodo.Codice == nodoInput.Codice && nodo.Descrizione == nodoInput.Descrizione && nodo.LeadTime == nodoInput.LeadTime && nodo.LeadTimeSicurezza == nodoInput.LeadTimeSicurezza && nodo.ScortaSicurezza == nodoInput.ScortaSicurezza && nodo.Lotto == nodoInput.Lotto && nodo.PeriodoDiCopertura == nodoInput.PeriodoDiCopertura)
                    {
                        nodo = nodoInput;
                        Close();
                        return;
                    }
                    if (nodo.Nome == nodoInput.Nome && nodo.Descrizione == nodoInput.Descrizione && nodo.LeadTime == nodoInput.LeadTime && nodo.LeadTimeSicurezza == nodoInput.LeadTimeSicurezza && nodo.ScortaSicurezza == nodoInput.ScortaSicurezza && nodo.Lotto == nodoInput.Lotto && nodo.PeriodoDiCopertura == nodoInput.PeriodoDiCopertura)
                    {
                        nodo = nodoInput;
                        Close();
                        return;
                    }
                    else
                    {
                        if (nodo.Codice != nodoInput.Codice && codiceOK(nodo))
                        {
                            Close();
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show("Hai modificato il componente quindi ora devi modificare il codice, mantenere le modifiche?", "ATTENZIONE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                form_codice.Focus();
                                form_codice.Clear();
                                nodo = null;
                                return;
                            }
                            else
                            {
                                form_nome.Text = nodoInput.Nome;
                                form_codice.Text = nodoInput.Codice;
                                form_descrizione.Text = nodoInput.Descrizione;
                                form_leadTime.Value = nodoInput.LeadTime;
                                form_leadTimeSicurezza.Value = nodoInput.LeadTimeSicurezza;
                                form__scortaDiSicurezza.Value = nodoInput.ScortaSicurezza;
                                form_lotto.Value = nodoInput.Lotto;
                                form_periodoDiCopertura.Value = nodoInput.PeriodoDiCopertura;
                                return;
                            }
                        }
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
                    };
                    if (codiceOK(nodo))
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

        private bool ControlloCodice(Componente componenteDaControllare, Componente componente)
        {
            if (componente.SottoNodi != null)
            {
                foreach (Componente sottoComp in componenteDaControllare.SottoNodi)
                {
                    if(!ControlloCodice(componenteDaControllare, sottoComp))
                    {
                        return false;
                    }
                }
            }
            if (componenteDaControllare.Codice == componente.Codice)
            {
                if(NodiUguali(componenteDaControllare, componente))
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

        private bool codiceOK(Componente comp)
        {
            foreach (Componente componente in Componenti)
            {
                if(!ControlloCodice(comp, componente))
                {
                    return false;
                }
            }
            return true;
        }

        private bool NodiUguali(Componente nodo1, Componente nodo2)
        {
            if (nodo1.Nome == nodo2.Nome && nodo1.Descrizione == nodo2.Descrizione && nodo1.LeadTime == nodo2.LeadTime && nodo1.LeadTimeSicurezza == nodo2.LeadTimeSicurezza && nodo1.ScortaSicurezza == nodo2.ScortaSicurezza && nodo1.Lotto == nodo2.Lotto && nodo1.PeriodoDiCopertura == nodo2.PeriodoDiCopertura)
            {
                return true;
            }
            return false;
        }



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