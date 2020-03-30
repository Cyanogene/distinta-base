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
        public Form2_NewNode(string titolo, string button, Node nodo)
        {
            InitializeComponent();
            ActiveControl = form_nome;
            if(titolo!="" && button !="")
            {
                label1.Text = titolo;
                Btn_aggiungi.Text = button;
            }
            if (nodo.Nome != null)
            {
                form_nome.Text = nodo.Nome;
                form_codice.Text = nodo.Codice;
                form_descrizione.Text = nodo.Descrizione;
                form_leadTime.Value = nodo.LeadTime;
                form_leadTimeSicurezza.Value = nodo.LeadTimeSicurezza;
                form__scortaDiSicurezza.Value = nodo.ScortaSicurezza;
                form_lotto.Value = nodo.Lotto;
                form_periodoDiCopertura.Value = nodo.PeriodoDiCopertura;
                nodo = null;
            }
        }
        
        public string Nome = "";
        public string Codice = "";
        public string Descrizione = "";
        public int LT = 0;
        public int LTS = 0;
        public int ScortaDiSicurezza = 0;
        public int Lotto = 0;
        public int PeriodoDiCopertura = 0;
        public Node nodo;
        public bool attendo = true;

        private void Btn_aggiungi_Click(object sender, EventArgs e)
        {
            if (form_nome.Text != "" && form_codice.Text != "" && form_descrizione.Text != "" && form_leadTime.Value > 0 && form_lotto.Value > 0 && form_periodoDiCopertura.Value > 0)
            {
                Nome = form_nome.Text;
                Codice = form_codice.Text;
                Descrizione = form_descrizione.Text;
                LT = Convert.ToInt32(form_leadTime.Value);
                LTS = Convert.ToInt32(form_leadTimeSicurezza.Value);
                ScortaDiSicurezza = Convert.ToInt32(form__scortaDiSicurezza.Value);
                Lotto = Convert.ToInt32(form_lotto.Value);
                PeriodoDiCopertura = Convert.ToInt32(form_periodoDiCopertura.Value);
                nodo = new Node
                {
                    Nome = Nome,
                    Codice = Codice,
                    Descrizione = Descrizione,
                    LeadTime = LT,
                    LeadTimeSicurezza = LTS,
                    ScortaSicurezza = ScortaDiSicurezza,
                    Lotto  = Lotto,
                    PeriodoDiCopertura = PeriodoDiCopertura
                };
                Close();
            }
            else
            {
                MessageBox.Show("compilare tutti i campi prima di procedere", "ATTENZIONE", MessageBoxButtons.OK);
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            attendo = false;
        }
    }
}