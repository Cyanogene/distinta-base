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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView_DistintaBase = new System.Windows.Forms.TreeView();
            this.Btn_SalvaDistintaBase = new System.Windows.Forms.Button();
            this.Btn_CaricaDistintaBase = new System.Windows.Forms.Button();
            this.Btn_resettaDistintaBase = new System.Windows.Forms.Button();
            this.Btn_AggiungiMateriaPrima = new System.Windows.Forms.Button();
            this.Btn_AggiungiSemilavorato = new System.Windows.Forms.Button();
            this.Btn_caricaDaCatalogo = new System.Windows.Forms.Button();
            this.listView_catalogo = new System.Windows.Forms.ListView();
            this.Cms_TreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rimuoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aggiungiSottonodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informazioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.daCatalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creaNuovoNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_creaNuovaDistintaBase = new System.Windows.Forms.Button();
            this.Cms_ListBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rimuoviToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informazioniToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Informazioni = new System.Windows.Forms.PictureBox();
            this.Cms_Informazioni = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.guidaSullaDistintaBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guidaSulCatalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caricaDaCatalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caricaSemilavoratoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creaNuovoNodoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Cms_TreeView.SuspendLayout();
            this.Cms_ListBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Informazioni)).BeginInit();
            this.Cms_Informazioni.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_DistintaBase
            // 
            this.treeView_DistintaBase.Location = new System.Drawing.Point(12, 105);
            this.treeView_DistintaBase.Name = "treeView_DistintaBase";
            this.treeView_DistintaBase.Size = new System.Drawing.Size(373, 302);
            this.treeView_DistintaBase.TabIndex = 0;
            this.treeView_DistintaBase.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_DistintaBase_NodeMouseClick_1);
            this.treeView_DistintaBase.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_DistintaBase_NodeMouseDoubleClick);
            // 
            // Btn_SalvaDistintaBase
            // 
            this.Btn_SalvaDistintaBase.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.Btn_SalvaDistintaBase.Location = new System.Drawing.Point(201, 414);
            this.Btn_SalvaDistintaBase.Name = "Btn_SalvaDistintaBase";
            this.Btn_SalvaDistintaBase.Size = new System.Drawing.Size(183, 45);
            this.Btn_SalvaDistintaBase.TabIndex = 4;
            this.Btn_SalvaDistintaBase.Text = "Salva Distinta base";
            this.Btn_SalvaDistintaBase.UseVisualStyleBackColor = true;
            this.Btn_SalvaDistintaBase.Click += new System.EventHandler(this.Btn_SalvaDistintaBase_Click);
            // 
            // Btn_CaricaDistintaBase
            // 
            this.Btn_CaricaDistintaBase.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.Btn_CaricaDistintaBase.Location = new System.Drawing.Point(391, 163);
            this.Btn_CaricaDistintaBase.Name = "Btn_CaricaDistintaBase";
            this.Btn_CaricaDistintaBase.Size = new System.Drawing.Size(138, 52);
            this.Btn_CaricaDistintaBase.TabIndex = 5;
            this.Btn_CaricaDistintaBase.Text = "Carica DistintaBase";
            this.Btn_CaricaDistintaBase.UseVisualStyleBackColor = true;
            this.Btn_CaricaDistintaBase.Click += new System.EventHandler(this.Btn_CaricaDistintaBase_Click);
            // 
            // Btn_resettaDistintaBase
            // 
            this.Btn_resettaDistintaBase.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.Btn_resettaDistintaBase.Location = new System.Drawing.Point(12, 414);
            this.Btn_resettaDistintaBase.Name = "Btn_resettaDistintaBase";
            this.Btn_resettaDistintaBase.Size = new System.Drawing.Size(183, 45);
            this.Btn_resettaDistintaBase.TabIndex = 7;
            this.Btn_resettaDistintaBase.Text = "Resetta distinta base";
            this.Btn_resettaDistintaBase.UseVisualStyleBackColor = true;
            this.Btn_resettaDistintaBase.Click += new System.EventHandler(this.Btn_resettaDistintaBase_Click);
            // 
            // Btn_AggiungiMateriaPrima
            // 
            this.Btn_AggiungiMateriaPrima.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_AggiungiMateriaPrima.Location = new System.Drawing.Point(662, 414);
            this.Btn_AggiungiMateriaPrima.Name = "Btn_AggiungiMateriaPrima";
            this.Btn_AggiungiMateriaPrima.Size = new System.Drawing.Size(165, 45);
            this.Btn_AggiungiMateriaPrima.TabIndex = 11;
            this.Btn_AggiungiMateriaPrima.Text = "Aggiungi materia prima";
            this.Btn_AggiungiMateriaPrima.UseVisualStyleBackColor = true;
            this.Btn_AggiungiMateriaPrima.Click += new System.EventHandler(this.Btn_AggiungiMateriaPrima_Click);
            // 
            // Btn_AggiungiSemilavorato
            // 
            this.Btn_AggiungiSemilavorato.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_AggiungiSemilavorato.Location = new System.Drawing.Point(841, 414);
            this.Btn_AggiungiSemilavorato.Name = "Btn_AggiungiSemilavorato";
            this.Btn_AggiungiSemilavorato.Size = new System.Drawing.Size(165, 45);
            this.Btn_AggiungiSemilavorato.TabIndex = 12;
            this.Btn_AggiungiSemilavorato.Text = "Aggiungi semilavorato";
            this.Btn_AggiungiSemilavorato.UseVisualStyleBackColor = true;
            this.Btn_AggiungiSemilavorato.Click += new System.EventHandler(this.Btn_AggiungiSemilavorato_Click);
            // 
            // Btn_caricaDaCatalogo
            // 
            this.Btn_caricaDaCatalogo.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.Btn_caricaDaCatalogo.Location = new System.Drawing.Point(391, 221);
            this.Btn_caricaDaCatalogo.Name = "Btn_caricaDaCatalogo";
            this.Btn_caricaDaCatalogo.Size = new System.Drawing.Size(138, 52);
            this.Btn_caricaDaCatalogo.TabIndex = 17;
            this.Btn_caricaDaCatalogo.Text = "Carica prodotto da catalogo";
            this.Btn_caricaDaCatalogo.UseVisualStyleBackColor = true;
            this.Btn_caricaDaCatalogo.Click += new System.EventHandler(this.Btn_caricaDaCatalogo_Click);
            // 
            // listView_catalogo
            // 
            this.listView_catalogo.HideSelection = false;
            this.listView_catalogo.Location = new System.Drawing.Point(662, 105);
            this.listView_catalogo.Name = "listView_catalogo";
            this.listView_catalogo.Size = new System.Drawing.Size(344, 302);
            this.listView_catalogo.TabIndex = 18;
            this.listView_catalogo.UseCompatibleStateImageBehavior = false;
            this.listView_catalogo.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView_catalogo_ColumnWidthChanging_1);
            this.listView_catalogo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_catalogo_MouseClick);
            this.listView_catalogo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_catalogo_MouseDoubleClick);
            // 
            // Cms_TreeView
            // 
            this.Cms_TreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rimuoviToolStripMenuItem,
            this.aggiungiSottonodoToolStripMenuItem,
            this.informazioniToolStripMenuItem,
            this.modificaToolStripMenuItem1});
            this.Cms_TreeView.Name = "Cms_TreeView";
            this.Cms_TreeView.Size = new System.Drawing.Size(183, 92);
            // 
            // rimuoviToolStripMenuItem
            // 
            this.rimuoviToolStripMenuItem.Name = "rimuoviToolStripMenuItem";
            this.rimuoviToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.rimuoviToolStripMenuItem.Text = "Rimuovi";
            this.rimuoviToolStripMenuItem.Click += new System.EventHandler(this.rimuoviToolStripMenuItem_Click);
            // 
            // aggiungiSottonodoToolStripMenuItem
            // 
            this.aggiungiSottonodoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caricaDaCatalogoToolStripMenuItem,
            this.caricaSemilavoratoToolStripMenuItem,
            this.creaNuovoNodoToolStripMenuItem1});
            this.aggiungiSottonodoToolStripMenuItem.Name = "aggiungiSottonodoToolStripMenuItem";
            this.aggiungiSottonodoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.aggiungiSottonodoToolStripMenuItem.Text = "Aggiungi Sottonodo";
            // 
            // informazioniToolStripMenuItem
            // 
            this.informazioniToolStripMenuItem.Name = "informazioniToolStripMenuItem";
            this.informazioniToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.informazioniToolStripMenuItem.Text = "Informazioni";
            this.informazioniToolStripMenuItem.Click += new System.EventHandler(this.informazioniToolStripMenuItem_Click);
            // 
            // modificaToolStripMenuItem1
            // 
            this.modificaToolStripMenuItem1.Name = "modificaToolStripMenuItem1";
            this.modificaToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.modificaToolStripMenuItem1.Text = "Modifica";
            this.modificaToolStripMenuItem1.Click += new System.EventHandler(this.modificaToolStripMenuItem1_Click);
            // 
            // daCatalogoToolStripMenuItem
            // 
            this.daCatalogoToolStripMenuItem.Name = "daCatalogoToolStripMenuItem";
            this.daCatalogoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.daCatalogoToolStripMenuItem.Text = "Carica da catalogo";
            this.daCatalogoToolStripMenuItem.Click += new System.EventHandler(this.daCatalogoToolStripMenuItem_Click);
            // 
            // daFileToolStripMenuItem
            // 
            this.daFileToolStripMenuItem.Name = "daFileToolStripMenuItem";
            this.daFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.daFileToolStripMenuItem.Text = "Carica semilavorato";
            this.daFileToolStripMenuItem.Click += new System.EventHandler(this.daFileToolStripMenuItem_Click);
            // 
            // creaNuovoNodoToolStripMenuItem
            // 
            this.creaNuovoNodoToolStripMenuItem.Name = "creaNuovoNodoToolStripMenuItem";
            this.creaNuovoNodoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.creaNuovoNodoToolStripMenuItem.Text = "Crea nuovo nodo";
            this.creaNuovoNodoToolStripMenuItem.Click += new System.EventHandler(this.creaNuovoNodoToolStripMenuItem_Click_1);
            // 
            // Btn_creaNuovaDistintaBase
            // 
            this.Btn_creaNuovaDistintaBase.Location = new System.Drawing.Point(391, 105);
            this.Btn_creaNuovaDistintaBase.Name = "Btn_creaNuovaDistintaBase";
            this.Btn_creaNuovaDistintaBase.Size = new System.Drawing.Size(138, 52);
            this.Btn_creaNuovaDistintaBase.TabIndex = 19;
            this.Btn_creaNuovaDistintaBase.Text = "Crea nuova DistintaBase";
            this.Btn_creaNuovaDistintaBase.UseVisualStyleBackColor = true;
            this.Btn_creaNuovaDistintaBase.Click += new System.EventHandler(this.Btn_creaNuovaDistintaBase_Click);
            // 
            // Cms_ListBox
            // 
            this.Cms_ListBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rimuoviToolStripMenuItem1,
            this.modificaToolStripMenuItem,
            this.informazioniToolStripMenuItem1});
            this.Cms_ListBox.Name = "Cms_ListBox";
            this.Cms_ListBox.Size = new System.Drawing.Size(142, 70);
            // 
            // rimuoviToolStripMenuItem1
            // 
            this.rimuoviToolStripMenuItem1.Name = "rimuoviToolStripMenuItem1";
            this.rimuoviToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.rimuoviToolStripMenuItem1.Text = "Rimuovi";
            this.rimuoviToolStripMenuItem1.Click += new System.EventHandler(this.rimuoviToolStripMenuItem1_Click);
            // 
            // modificaToolStripMenuItem
            // 
            this.modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            this.modificaToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.modificaToolStripMenuItem.Text = "Modifica";
            this.modificaToolStripMenuItem.Click += new System.EventHandler(this.modificaToolStripMenuItem_Click);
            // 
            // informazioniToolStripMenuItem1
            // 
            this.informazioniToolStripMenuItem1.Name = "informazioniToolStripMenuItem1";
            this.informazioniToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.informazioniToolStripMenuItem1.Text = "Informazioni";
            this.informazioniToolStripMenuItem1.Click += new System.EventHandler(this.informazioniToolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(8, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "DISTINTA BASE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(658, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "CATALOGO";
            // 
            // Btn_Informazioni
            // 
            this.Btn_Informazioni.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Informazioni.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Informazioni.Image")));
            this.Btn_Informazioni.Location = new System.Drawing.Point(1002, -1);
            this.Btn_Informazioni.Name = "Btn_Informazioni";
            this.Btn_Informazioni.Size = new System.Drawing.Size(71, 80);
            this.Btn_Informazioni.TabIndex = 21;
            this.Btn_Informazioni.TabStop = false;
            this.Btn_Informazioni.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Btn_Informazioni_MouseClick);
            this.Btn_Informazioni.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Informazioni_MouseDown);
            this.Btn_Informazioni.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Informazioni_MouseUp);
            // 
            // Cms_Informazioni
            // 
            this.Cms_Informazioni.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guidaSullaDistintaBaseToolStripMenuItem,
            this.guidaSulCatalogoToolStripMenuItem});
            this.Cms_Informazioni.Name = "Cms_Informazioni";
            this.Cms_Informazioni.Size = new System.Drawing.Size(202, 48);
            // 
            // guidaSullaDistintaBaseToolStripMenuItem
            // 
            this.guidaSullaDistintaBaseToolStripMenuItem.Name = "guidaSullaDistintaBaseToolStripMenuItem";
            this.guidaSullaDistintaBaseToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.guidaSullaDistintaBaseToolStripMenuItem.Text = "Guida sulla distinta base";
            this.guidaSullaDistintaBaseToolStripMenuItem.Click += new System.EventHandler(this.guidaSullaDistintaBaseToolStripMenuItem_Click);
            // 
            // guidaSulCatalogoToolStripMenuItem
            // 
            this.guidaSulCatalogoToolStripMenuItem.Name = "guidaSulCatalogoToolStripMenuItem";
            this.guidaSulCatalogoToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.guidaSulCatalogoToolStripMenuItem.Text = "Guida sul catalogo";
            this.guidaSulCatalogoToolStripMenuItem.Click += new System.EventHandler(this.guidaSulCatalogoToolStripMenuItem_Click);
            // 
            // caricaDaCatalogoToolStripMenuItem
            // 
            this.caricaDaCatalogoToolStripMenuItem.Name = "caricaDaCatalogoToolStripMenuItem";
            this.caricaDaCatalogoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.caricaDaCatalogoToolStripMenuItem.Text = "Carica da catalogo";
            this.caricaDaCatalogoToolStripMenuItem.Click += new System.EventHandler(this.daCatalogoToolStripMenuItem_Click);
            // 
            // caricaSemilavoratoToolStripMenuItem
            // 
            this.caricaSemilavoratoToolStripMenuItem.Name = "caricaSemilavoratoToolStripMenuItem";
            this.caricaSemilavoratoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.caricaSemilavoratoToolStripMenuItem.Text = "Carica semilavorato";
            this.caricaSemilavoratoToolStripMenuItem.Click += new System.EventHandler(this.daFileToolStripMenuItem_Click);
            // 
            // creaNuovoNodoToolStripMenuItem1
            // 
            this.creaNuovoNodoToolStripMenuItem1.Name = "creaNuovoNodoToolStripMenuItem1";
            this.creaNuovoNodoToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.creaNuovoNodoToolStripMenuItem1.Text = "Crea nuovo nodo";
            this.creaNuovoNodoToolStripMenuItem1.Click += new System.EventHandler(this.creaNuovoNodoToolStripMenuItem_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 619);
            this.Controls.Add(this.Btn_Informazioni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_creaNuovaDistintaBase);
            this.Controls.Add(this.listView_catalogo);
            this.Controls.Add(this.Btn_caricaDaCatalogo);
            this.Controls.Add(this.Btn_AggiungiSemilavorato);
            this.Controls.Add(this.Btn_AggiungiMateriaPrima);
            this.Controls.Add(this.Btn_resettaDistintaBase);
            this.Controls.Add(this.Btn_CaricaDistintaBase);
            this.Controls.Add(this.Btn_SalvaDistintaBase);
            this.Controls.Add(this.treeView_DistintaBase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Distinta base";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Cms_TreeView.ResumeLayout(false);
            this.Cms_ListBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Informazioni)).EndInit();
            this.Cms_Informazioni.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_DistintaBase;
        private System.Windows.Forms.Button Btn_SalvaDistintaBase;
        private System.Windows.Forms.Button Btn_CaricaDistintaBase;
        private System.Windows.Forms.Button Btn_resettaDistintaBase;
        private System.Windows.Forms.Button Btn_AggiungiMateriaPrima;
        private System.Windows.Forms.Button Btn_AggiungiSemilavorato;
        private System.Windows.Forms.Button Btn_caricaDaCatalogo;
        private System.Windows.Forms.ListView listView_catalogo;
        private System.Windows.Forms.ContextMenuStrip Cms_TreeView;
        private System.Windows.Forms.ToolStripMenuItem rimuoviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aggiungiSottonodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem daCatalogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem daFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informazioniToolStripMenuItem;
        private System.Windows.Forms.Button Btn_creaNuovaDistintaBase;
        private System.Windows.Forms.ContextMenuStrip Cms_ListBox;
        private System.Windows.Forms.ToolStripMenuItem rimuoviToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem informazioniToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem creaNuovoNodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox Btn_Informazioni;
        private System.Windows.Forms.ContextMenuStrip Cms_Informazioni;
        private System.Windows.Forms.ToolStripMenuItem guidaSullaDistintaBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guidaSulCatalogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caricaDaCatalogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caricaSemilavoratoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creaNuovoNodoToolStripMenuItem1;
    }
}

