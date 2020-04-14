namespace distinta_base
{
    partial class Form2_NewNode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.form_nome = new System.Windows.Forms.TextBox();
            this.form_codice = new System.Windows.Forms.TextBox();
            this.form_descrizione = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_aggiungi = new System.Windows.Forms.Button();
            this.lbl_descrizione = new System.Windows.Forms.Label();
            this.lbl_leadTime = new System.Windows.Forms.Label();
            this.lbl_nome = new System.Windows.Forms.Label();
            this.lbl_codice = new System.Windows.Forms.Label();
            this.lbl_lotto = new System.Windows.Forms.Label();
            this.lbl_leadTimeSicurezza = new System.Windows.Forms.Label();
            this.lbl_periodoDiCopertura = new System.Windows.Forms.Label();
            this.lbl_scortaDiSicurezza = new System.Windows.Forms.Label();
            this.form_leadTime = new System.Windows.Forms.NumericUpDown();
            this.form_leadTimeSicurezza = new System.Windows.Forms.NumericUpDown();
            this.form__scortaDiSicurezza = new System.Windows.Forms.NumericUpDown();
            this.form_lotto = new System.Windows.Forms.NumericUpDown();
            this.form_periodoDiCopertura = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.form_leadTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form_leadTimeSicurezza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form__scortaDiSicurezza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form_lotto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form_periodoDiCopertura)).BeginInit();
            this.SuspendLayout();
            // 
            // form_nome
            // 
            this.form_nome.Location = new System.Drawing.Point(273, 78);
            this.form_nome.Name = "form_nome";
            this.form_nome.Size = new System.Drawing.Size(212, 20);
            this.form_nome.TabIndex = 0;
            // 
            // form_codice
            // 
            this.form_codice.Location = new System.Drawing.Point(273, 104);
            this.form_codice.Name = "form_codice";
            this.form_codice.Size = new System.Drawing.Size(212, 20);
            this.form_codice.TabIndex = 0;
            // 
            // form_descrizione
            // 
            this.form_descrizione.Location = new System.Drawing.Point(273, 130);
            this.form_descrizione.Name = "form_descrizione";
            this.form_descrizione.Size = new System.Drawing.Size(281, 20);
            this.form_descrizione.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(127, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "CREAZIONE NUOVA MATERIA PRIMA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Compilare tutti i campi e quindi premere il bottone";
            // 
            // Btn_aggiungi
            // 
            this.Btn_aggiungi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_aggiungi.Location = new System.Drawing.Point(427, 318);
            this.Btn_aggiungi.Name = "Btn_aggiungi";
            this.Btn_aggiungi.Size = new System.Drawing.Size(127, 37);
            this.Btn_aggiungi.TabIndex = 2;
            this.Btn_aggiungi.Text = "AGGIUNGI";
            this.Btn_aggiungi.UseVisualStyleBackColor = true;
            this.Btn_aggiungi.Click += new System.EventHandler(this.Btn_aggiungi_Click);
            // 
            // lbl_descrizione
            // 
            this.lbl_descrizione.AutoSize = true;
            this.lbl_descrizione.Location = new System.Drawing.Point(128, 137);
            this.lbl_descrizione.Name = "lbl_descrizione";
            this.lbl_descrizione.Size = new System.Drawing.Size(80, 13);
            this.lbl_descrizione.TabIndex = 3;
            this.lbl_descrizione.Text = "DESCRIZIONE";
            // 
            // lbl_leadTime
            // 
            this.lbl_leadTime.AutoSize = true;
            this.lbl_leadTime.Location = new System.Drawing.Point(128, 163);
            this.lbl_leadTime.Name = "lbl_leadTime";
            this.lbl_leadTime.Size = new System.Drawing.Size(61, 13);
            this.lbl_leadTime.TabIndex = 3;
            this.lbl_leadTime.Text = "LEADTIME";
            // 
            // lbl_nome
            // 
            this.lbl_nome.AutoSize = true;
            this.lbl_nome.Location = new System.Drawing.Point(128, 85);
            this.lbl_nome.Name = "lbl_nome";
            this.lbl_nome.Size = new System.Drawing.Size(39, 13);
            this.lbl_nome.TabIndex = 3;
            this.lbl_nome.Text = "NOME";
            // 
            // lbl_codice
            // 
            this.lbl_codice.AutoSize = true;
            this.lbl_codice.Location = new System.Drawing.Point(128, 111);
            this.lbl_codice.Name = "lbl_codice";
            this.lbl_codice.Size = new System.Drawing.Size(47, 13);
            this.lbl_codice.TabIndex = 3;
            this.lbl_codice.Text = "CODICE";
            // 
            // lbl_lotto
            // 
            this.lbl_lotto.AutoSize = true;
            this.lbl_lotto.Location = new System.Drawing.Point(128, 241);
            this.lbl_lotto.Name = "lbl_lotto";
            this.lbl_lotto.Size = new System.Drawing.Size(43, 13);
            this.lbl_lotto.TabIndex = 3;
            this.lbl_lotto.Text = "LOTTO";
            // 
            // lbl_leadTimeSicurezza
            // 
            this.lbl_leadTimeSicurezza.AutoSize = true;
            this.lbl_leadTimeSicurezza.Location = new System.Drawing.Point(128, 189);
            this.lbl_leadTimeSicurezza.Name = "lbl_leadTimeSicurezza";
            this.lbl_leadTimeSicurezza.Size = new System.Drawing.Size(125, 13);
            this.lbl_leadTimeSicurezza.TabIndex = 3;
            this.lbl_leadTimeSicurezza.Text = "LEADTIME SICUREZZA";
            // 
            // lbl_periodoDiCopertura
            // 
            this.lbl_periodoDiCopertura.AutoSize = true;
            this.lbl_periodoDiCopertura.Location = new System.Drawing.Point(128, 267);
            this.lbl_periodoDiCopertura.Name = "lbl_periodoDiCopertura";
            this.lbl_periodoDiCopertura.Size = new System.Drawing.Size(140, 13);
            this.lbl_periodoDiCopertura.TabIndex = 3;
            this.lbl_periodoDiCopertura.Text = "PERIODO DI COPERTURA";
            // 
            // lbl_scortaDiSicurezza
            // 
            this.lbl_scortaDiSicurezza.AutoSize = true;
            this.lbl_scortaDiSicurezza.Location = new System.Drawing.Point(128, 215);
            this.lbl_scortaDiSicurezza.Name = "lbl_scortaDiSicurezza";
            this.lbl_scortaDiSicurezza.Size = new System.Drawing.Size(129, 13);
            this.lbl_scortaDiSicurezza.TabIndex = 3;
            this.lbl_scortaDiSicurezza.Text = "SCORTA DI SICUREZZA";
            // 
            // form_leadTime
            // 
            this.form_leadTime.Location = new System.Drawing.Point(273, 156);
            this.form_leadTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.form_leadTime.Name = "form_leadTime";
            this.form_leadTime.Size = new System.Drawing.Size(50, 20);
            this.form_leadTime.TabIndex = 4;
            this.form_leadTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.form_leadTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.form_leadTime_KeyPress);
            // 
            // form_leadTimeSicurezza
            // 
            this.form_leadTimeSicurezza.Location = new System.Drawing.Point(273, 182);
            this.form_leadTimeSicurezza.Name = "form_leadTimeSicurezza";
            this.form_leadTimeSicurezza.Size = new System.Drawing.Size(50, 20);
            this.form_leadTimeSicurezza.TabIndex = 4;
            this.form_leadTimeSicurezza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.form_leadTimeSicurezza_KeyPress);
            // 
            // form__scortaDiSicurezza
            // 
            this.form__scortaDiSicurezza.Location = new System.Drawing.Point(273, 208);
            this.form__scortaDiSicurezza.Name = "form__scortaDiSicurezza";
            this.form__scortaDiSicurezza.Size = new System.Drawing.Size(50, 20);
            this.form__scortaDiSicurezza.TabIndex = 4;
            this.form__scortaDiSicurezza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.form__scortaDiSicurezza_KeyPress);
            // 
            // form_lotto
            // 
            this.form_lotto.Location = new System.Drawing.Point(273, 234);
            this.form_lotto.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.form_lotto.Name = "form_lotto";
            this.form_lotto.Size = new System.Drawing.Size(50, 20);
            this.form_lotto.TabIndex = 4;
            this.form_lotto.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.form_lotto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.form_lotto_KeyPress);
            // 
            // form_periodoDiCopertura
            // 
            this.form_periodoDiCopertura.Location = new System.Drawing.Point(273, 260);
            this.form_periodoDiCopertura.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.form_periodoDiCopertura.Name = "form_periodoDiCopertura";
            this.form_periodoDiCopertura.Size = new System.Drawing.Size(50, 20);
            this.form_periodoDiCopertura.TabIndex = 4;
            this.form_periodoDiCopertura.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.form_periodoDiCopertura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.form_periodoDiCopertura_KeyPress);
            // 
            // Form2_NewNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 514);
            this.Controls.Add(this.form_periodoDiCopertura);
            this.Controls.Add(this.form_lotto);
            this.Controls.Add(this.form__scortaDiSicurezza);
            this.Controls.Add(this.form_leadTimeSicurezza);
            this.Controls.Add(this.form_leadTime);
            this.Controls.Add(this.lbl_scortaDiSicurezza);
            this.Controls.Add(this.lbl_codice);
            this.Controls.Add(this.lbl_periodoDiCopertura);
            this.Controls.Add(this.lbl_leadTimeSicurezza);
            this.Controls.Add(this.lbl_leadTime);
            this.Controls.Add(this.lbl_lotto);
            this.Controls.Add(this.lbl_nome);
            this.Controls.Add(this.lbl_descrizione);
            this.Controls.Add(this.Btn_aggiungi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.form_descrizione);
            this.Controls.Add(this.form_codice);
            this.Controls.Add(this.form_nome);
            this.Name = "Form2_NewNode";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.form_leadTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form_leadTimeSicurezza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form__scortaDiSicurezza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form_lotto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form_periodoDiCopertura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox form_nome;
        private System.Windows.Forms.TextBox form_codice;
        private System.Windows.Forms.TextBox form_descrizione;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_aggiungi;
        private System.Windows.Forms.Label lbl_descrizione;
        private System.Windows.Forms.Label lbl_leadTime;
        private System.Windows.Forms.Label lbl_nome;
        private System.Windows.Forms.Label lbl_codice;
        private System.Windows.Forms.Label lbl_lotto;
        private System.Windows.Forms.Label lbl_leadTimeSicurezza;
        private System.Windows.Forms.Label lbl_periodoDiCopertura;
        private System.Windows.Forms.Label lbl_scortaDiSicurezza;
        private System.Windows.Forms.NumericUpDown form_leadTime;
        private System.Windows.Forms.NumericUpDown form_leadTimeSicurezza;
        private System.Windows.Forms.NumericUpDown form__scortaDiSicurezza;
        private System.Windows.Forms.NumericUpDown form_lotto;
        private System.Windows.Forms.NumericUpDown form_periodoDiCopertura;
    }
}