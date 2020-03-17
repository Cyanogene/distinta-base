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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(225, 304);
            this.treeView1.TabIndex = 0;
            // 
            // Btn_AggiungiFiglio
            // 
            this.Btn_AggiungiFiglio.Location = new System.Drawing.Point(381, 143);
            this.Btn_AggiungiFiglio.Name = "Btn_AggiungiFiglio";
            this.Btn_AggiungiFiglio.Size = new System.Drawing.Size(138, 53);
            this.Btn_AggiungiFiglio.TabIndex = 1;
            this.Btn_AggiungiFiglio.Text = "Aggiungi figlio";
            this.Btn_AggiungiFiglio.UseVisualStyleBackColor = true;
            this.Btn_AggiungiFiglio.Click += new System.EventHandler(this.Btn_AggiungiFiglio_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(396, 108);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // Btn_AggiungiRadice
            // 
            this.Btn_AggiungiRadice.Location = new System.Drawing.Point(381, 202);
            this.Btn_AggiungiRadice.Name = "Btn_AggiungiRadice";
            this.Btn_AggiungiRadice.Size = new System.Drawing.Size(138, 53);
            this.Btn_AggiungiRadice.TabIndex = 3;
            this.Btn_AggiungiRadice.Text = "Aggiungi radice";
            this.Btn_AggiungiRadice.UseVisualStyleBackColor = true;
            this.Btn_AggiungiRadice.Click += new System.EventHandler(this.Btn_AggiungiRadice_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(662, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 53);
            this.button1.TabIndex = 4;
            this.button1.Text = "Salva";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(662, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 53);
            this.button2.TabIndex = 5;
            this.button2.Text = "Carica";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btn_AggiungiRadice);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Btn_AggiungiFiglio);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button Btn_AggiungiFiglio;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Btn_AggiungiRadice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

