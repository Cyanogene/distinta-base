﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace distinta_base
{
    public partial class Form3_Catalogo : Form
    {
        public Componente Nodo { get; set; }
        public bool Attendo = true;
        private Programmazione Programmazione = new Programmazione();

        public Form3_Catalogo(List<Componente> input)
        {
            InitializeComponent();
            label1.BackColor = Color.FromArgb(232, 190, 118);
            Programmazione.Catalogo.Nodi = input;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Seleziona un componente.", "Distinta Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PrendiElementoSelezionato();
        }

        /// <summary>
        /// Crea gli header della tabella.
        /// </summary>
        private void CreaListView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Nome", 90);
            listView1.Columns.Add("Codice", 80);
            listView1.Columns.Add("Descrizione", 170);
        }

        /// <summary>
        /// Salva il componente selezionato in una variabile globale "nodo".
        /// </summary>
        private void PrendiElementoSelezionato()
        {
            ListViewItem Item = listView1.SelectedItems[0];
            string Nome = Item.SubItems[0].Text;
            string Codice = Item.SubItems[1].Text;

            foreach (Componente Componente in Programmazione.Catalogo.Nodi)
            {
                if (Componente.Codice == Codice)
                {
                    Nodo = Componente;
                    Close();
                    return;
                }
            }
        }

        private void Form3_Catalogo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Attendo = false;
        }

        private void Form3_Catalogo_Load(object sender, EventArgs e)
        {
            CreaListView();
            Programmazione.AggiornaCatalogo(listView1);
            CenterToParent();
        }

        // Blocca qualsiasi cambiamento di misura delle colonne.
        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
        }

        // Salva il componente in una variabile globale "nodo" cliccando 2 volte sul componente.
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PrendiElementoSelezionato();
        }
    }
}
