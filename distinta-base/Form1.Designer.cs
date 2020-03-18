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
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(241, 376);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // Btn_AggiungiFiglio
            // 
            this.Btn_AggiungiFiglio.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_AggiungiFiglio.Location = new System.Drawing.Point(407, 180);
            this.Btn_AggiungiFiglio.Name = "Btn_AggiungiFiglio";
            this.Btn_AggiungiFiglio.Size = new System.Drawing.Size(138, 37);
            this.Btn_AggiungiFiglio.TabIndex = 1;
            this.Btn_AggiungiFiglio.Text = "Aggiungi figlio";
            this.Btn_AggiungiFiglio.UseVisualStyleBackColor = true;
            this.Btn_AggiungiFiglio.Click += new System.EventHandler(this.Btn_AggiungiFiglio_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(407, 154);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 20);
            this.textBox1.TabIndex = 2;
            // 
            // Btn_AggiungiRadice
            // 
            this.Btn_AggiungiRadice.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_AggiungiRadice.Location = new System.Drawing.Point(407, 223);
            this.Btn_AggiungiRadice.Name = "Btn_AggiungiRadice";
            this.Btn_AggiungiRadice.Size = new System.Drawing.Size(138, 37);
            this.Btn_AggiungiRadice.TabIndex = 3;
            this.Btn_AggiungiRadice.Text = "Aggiungi radice";
            this.Btn_AggiungiRadice.UseVisualStyleBackColor = true;
            this.Btn_AggiungiRadice.Click += new System.EventHandler(this.Btn_AggiungiRadice_Click);
            // 
            // Btn_SalvaMagazzino
            // 
            this.Btn_SalvaMagazzino.Location = new System.Drawing.Point(259, 12);
            this.Btn_SalvaMagazzino.Name = "Btn_SalvaMagazzino";
            this.Btn_SalvaMagazzino.Size = new System.Drawing.Size(119, 26);
            this.Btn_SalvaMagazzino.TabIndex = 4;
            this.Btn_SalvaMagazzino.Text = "Salva magazzino";
            this.Btn_SalvaMagazzino.UseVisualStyleBackColor = true;
            this.Btn_SalvaMagazzino.Click += new System.EventHandler(this.Btn_SalvaMagazzino_Click);
            // 
            // Btm_CaricaMagazzino
            // 
            this.Btm_CaricaMagazzino.Location = new System.Drawing.Point(259, 44);
            this.Btm_CaricaMagazzino.Name = "Btm_CaricaMagazzino";
            this.Btm_CaricaMagazzino.Size = new System.Drawing.Size(119, 26);
            this.Btm_CaricaMagazzino.TabIndex = 5;
            this.Btm_CaricaMagazzino.Text = "Carica magazzino";
            this.Btm_CaricaMagazzino.UseVisualStyleBackColor = true;
            this.Btm_CaricaMagazzino.Click += new System.EventHandler(this.Btm_CaricaMagazzino_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(407, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Inserisci il nome della radice\r\n   o figlio che vuoi inserire";
            // 
            // Btn_SvuotaMagazzino
            // 
            this.Btn_SvuotaMagazzino.Location = new System.Drawing.Point(259, 76);
            this.Btn_SvuotaMagazzino.Name = "Btn_SvuotaMagazzino";
            this.Btn_SvuotaMagazzino.Size = new System.Drawing.Size(119, 26);
            this.Btn_SvuotaMagazzino.TabIndex = 7;
            this.Btn_SvuotaMagazzino.Text = "Svuota magazzino";
            this.Btn_SvuotaMagazzino.UseVisualStyleBackColor = true;
            this.Btn_SvuotaMagazzino.Click += new System.EventHandler(this.Btn_SvuotaMagazzino_Click);
            // 
            // Btn_RimuoviComponente
            // 
            this.Btn_RimuoviComponente.Location = new System.Drawing.Point(259, 108);
            this.Btn_RimuoviComponente.Name = "Btn_RimuoviComponente";
            this.Btn_RimuoviComponente.Size = new System.Drawing.Size(119, 26);
            this.Btn_RimuoviComponente.TabIndex = 8;
            this.Btn_RimuoviComponente.Text = "Rimuovi componente";
            this.Btn_RimuoviComponente.UseVisualStyleBackColor = true;
            this.Btn_RimuoviComponente.Click += new System.EventHandler(this.Btn_RimuoviComponente_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
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
    }
}

