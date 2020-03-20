namespace distinta_base
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.Btn_AggiungiFiglio = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Btn_AggiungiRadice = new System.Windows.Forms.Button();
            this.Btn_SalvaMagazzino = new System.Windows.Forms.Button();
            this.Btm_CaricaMagazzino = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_SvuotaMagazzino = new System.Windows.Forms.Button();
            this.Btn_RimuoviComponente = new System.Windows.Forms.Button();
            this.txt_NomeProdotto = new System.Windows.Forms.TextBox();
            this.Btn_AggiungiMateriaPrima = new System.Windows.Forms.Button();
            this.Btn_AggiungiSemilavorato = new System.Windows.Forms.Button();
            this.txt_Codice = new System.Windows.Forms.TextBox();
            this.txt_Quantità = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(260, 172);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // Btn_AggiungiFiglio
            // 
            this.Btn_AggiungiFiglio.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_AggiungiFiglio.Location = new System.Drawing.Point(12, 275);
            this.Btn_AggiungiFiglio.Name = "Btn_AggiungiFiglio";
            this.Btn_AggiungiFiglio.Size = new System.Drawing.Size(138, 37);
            this.Btn_AggiungiFiglio.TabIndex = 1;
            this.Btn_AggiungiFiglio.Text = "Aggiungi figlio";
            this.Btn_AggiungiFiglio.UseVisualStyleBackColor = true;
            this.Btn_AggiungiFiglio.Click += new System.EventHandler(this.Btn_AggiungiFiglio_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 249);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 20);
            this.textBox1.TabIndex = 2;
            // 
            // Btn_AggiungiRadice
            // 
            this.Btn_AggiungiRadice.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_AggiungiRadice.Location = new System.Drawing.Point(12, 318);
            this.Btn_AggiungiRadice.Name = "Btn_AggiungiRadice";
            this.Btn_AggiungiRadice.Size = new System.Drawing.Size(138, 37);
            this.Btn_AggiungiRadice.TabIndex = 3;
            this.Btn_AggiungiRadice.Text = "Aggiungi radice";
            this.Btn_AggiungiRadice.UseVisualStyleBackColor = true;
            this.Btn_AggiungiRadice.Click += new System.EventHandler(this.Btn_AggiungiRadice_Click);
            // 
            // Btn_SalvaMagazzino
            // 
            this.Btn_SalvaMagazzino.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.Btn_SalvaMagazzino.Location = new System.Drawing.Point(278, 12);
            this.Btn_SalvaMagazzino.Name = "Btn_SalvaMagazzino";
            this.Btn_SalvaMagazzino.Size = new System.Drawing.Size(138, 37);
            this.Btn_SalvaMagazzino.TabIndex = 4;
            this.Btn_SalvaMagazzino.Text = "Salva magazzino";
            this.Btn_SalvaMagazzino.UseVisualStyleBackColor = true;
            this.Btn_SalvaMagazzino.Click += new System.EventHandler(this.Btn_SalvaMagazzino_Click);
            // 
            // Btm_CaricaMagazzino
            // 
            this.Btm_CaricaMagazzino.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.Btm_CaricaMagazzino.Location = new System.Drawing.Point(278, 55);
            this.Btm_CaricaMagazzino.Name = "Btm_CaricaMagazzino";
            this.Btm_CaricaMagazzino.Size = new System.Drawing.Size(138, 37);
            this.Btm_CaricaMagazzino.TabIndex = 5;
            this.Btm_CaricaMagazzino.Text = "Carica magazzino";
            this.Btm_CaricaMagazzino.UseVisualStyleBackColor = true;
            this.Btm_CaricaMagazzino.Click += new System.EventHandler(this.Btm_CaricaMagazzino_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Inserisci il nome della radice\r\n   o figlio che vuoi inserire";
            // 
            // Btn_SvuotaMagazzino
            // 
            this.Btn_SvuotaMagazzino.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.Btn_SvuotaMagazzino.Location = new System.Drawing.Point(278, 98);
            this.Btn_SvuotaMagazzino.Name = "Btn_SvuotaMagazzino";
            this.Btn_SvuotaMagazzino.Size = new System.Drawing.Size(138, 37);
            this.Btn_SvuotaMagazzino.TabIndex = 7;
            this.Btn_SvuotaMagazzino.Text = "Svuota magazzino";
            this.Btn_SvuotaMagazzino.UseVisualStyleBackColor = true;
            this.Btn_SvuotaMagazzino.Click += new System.EventHandler(this.Btn_SvuotaMagazzino_Click);
            // 
            // Btn_RimuoviComponente
            // 
            this.Btn_RimuoviComponente.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.Btn_RimuoviComponente.Location = new System.Drawing.Point(668, 243);
            this.Btn_RimuoviComponente.Name = "Btn_RimuoviComponente";
            this.Btn_RimuoviComponente.Size = new System.Drawing.Size(138, 45);
            this.Btn_RimuoviComponente.TabIndex = 8;
            this.Btn_RimuoviComponente.Text = "Rimuovi componente";
            this.Btn_RimuoviComponente.UseVisualStyleBackColor = true;
            this.Btn_RimuoviComponente.Click += new System.EventHandler(this.Btn_RimuoviComponente_Click);
            // 
            // txt_NomeProdotto
            // 
            this.txt_NomeProdotto.Location = new System.Drawing.Point(524, 29);
            this.txt_NomeProdotto.Name = "txt_NomeProdotto";
            this.txt_NomeProdotto.Size = new System.Drawing.Size(138, 20);
            this.txt_NomeProdotto.TabIndex = 10;
            this.txt_NomeProdotto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_NomeProdotto_KeyPress);
            // 
            // Btn_AggiungiMateriaPrima
            // 
            this.Btn_AggiungiMateriaPrima.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_AggiungiMateriaPrima.Location = new System.Drawing.Point(524, 192);
            this.Btn_AggiungiMateriaPrima.Name = "Btn_AggiungiMateriaPrima";
            this.Btn_AggiungiMateriaPrima.Size = new System.Drawing.Size(138, 45);
            this.Btn_AggiungiMateriaPrima.TabIndex = 11;
            this.Btn_AggiungiMateriaPrima.Text = "Aggiungi materia prima";
            this.Btn_AggiungiMateriaPrima.UseVisualStyleBackColor = true;
            this.Btn_AggiungiMateriaPrima.Click += new System.EventHandler(this.Btn_AggiungiMateriaPrima_Click);
            // 
            // Btn_AggiungiSemilavorato
            // 
            this.Btn_AggiungiSemilavorato.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_AggiungiSemilavorato.Location = new System.Drawing.Point(524, 243);
            this.Btn_AggiungiSemilavorato.Name = "Btn_AggiungiSemilavorato";
            this.Btn_AggiungiSemilavorato.Size = new System.Drawing.Size(138, 45);
            this.Btn_AggiungiSemilavorato.TabIndex = 12;
            this.Btn_AggiungiSemilavorato.Text = "Aggiungi semilavorato";
            this.Btn_AggiungiSemilavorato.UseVisualStyleBackColor = true;
            this.Btn_AggiungiSemilavorato.Click += new System.EventHandler(this.Btn_AggiungiSemilavorato_Click);
            // 
            // txt_Codice
            // 
            this.txt_Codice.Location = new System.Drawing.Point(524, 72);
            this.txt_Codice.Name = "txt_Codice";
            this.txt_Codice.Size = new System.Drawing.Size(138, 20);
            this.txt_Codice.TabIndex = 13;
            // 
            // txt_Quantità
            // 
            this.txt_Quantità.Location = new System.Drawing.Point(524, 115);
            this.txt_Quantità.Name = "txt_Quantità";
            this.txt_Quantità.Size = new System.Drawing.Size(138, 20);
            this.txt_Quantità.TabIndex = 14;
            this.txt_Quantità.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Quantità_KeyPress);
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(668, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(260, 172);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView1_ColumnWidthChanging);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.label2.Location = new System.Drawing.Point(521, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Quantità";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.label3.Location = new System.Drawing.Point(521, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Codice";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.label4.Location = new System.Drawing.Point(521, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Nome prodotto";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 400);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txt_Quantità);
            this.Controls.Add(this.txt_Codice);
            this.Controls.Add(this.Btn_AggiungiSemilavorato);
            this.Controls.Add(this.Btn_AggiungiMateriaPrima);
            this.Controls.Add(this.txt_NomeProdotto);
            this.Controls.Add(this.Btn_RimuoviComponente);
            this.Controls.Add(this.Btn_SvuotaMagazzino);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btm_CaricaMagazzino);
            this.Controls.Add(this.Btn_SalvaMagazzino);
            this.Controls.Add(this.Btn_AggiungiRadice);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Btn_AggiungiFiglio);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Distinta base";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button Btn_AggiungiFiglio;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Btn_AggiungiRadice;
        private System.Windows.Forms.Button Btn_SalvaMagazzino;
        private System.Windows.Forms.Button Btm_CaricaMagazzino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_SvuotaMagazzino;
        private System.Windows.Forms.Button Btn_RimuoviComponente;
        private System.Windows.Forms.TextBox txt_NomeProdotto;
        private System.Windows.Forms.Button Btn_AggiungiMateriaPrima;
        private System.Windows.Forms.Button Btn_AggiungiSemilavorato;
        private System.Windows.Forms.TextBox txt_Codice;
        private System.Windows.Forms.TextBox txt_Quantità;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

