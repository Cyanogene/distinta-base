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
            this.Btn_AggiungiMateriaPrima = new System.Windows.Forms.Button();
            this.Btn_AggiungiSemilavorato = new System.Windows.Forms.Button();
            this.Btn_caricaDaCatalogo = new System.Windows.Forms.Button();
            this.listView_catalogo = new System.Windows.Forms.ListView();
            this.Cms_TreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aggiungiSottonodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caricaDaCatalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caricaSemilavoratoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creaNuovoNodoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rimuoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.informazioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aggiungiACatalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.Cms_Informazioni = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.guidaSullaDistintaBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guidaSulCatalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_Informazioni = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.distintaBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caricaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resettaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caricaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salvaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resettaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Cms_TreeView.SuspendLayout();
            this.Cms_ListBox.SuspendLayout();
            this.Cms_Informazioni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Informazioni)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_DistintaBase
            // 
            this.treeView_DistintaBase.Location = new System.Drawing.Point(16, 89);
            this.treeView_DistintaBase.Name = "treeView_DistintaBase";
            this.treeView_DistintaBase.Size = new System.Drawing.Size(392, 407);
            this.treeView_DistintaBase.TabIndex = 0;
            this.treeView_DistintaBase.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_DistintaBase_NodeMouseClick_1);
            this.treeView_DistintaBase.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_DistintaBase_NodeMouseDoubleClick);
            // 
            // Btn_AggiungiMateriaPrima
            // 
            this.Btn_AggiungiMateriaPrima.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_AggiungiMateriaPrima.Location = new System.Drawing.Point(639, 89);
            this.Btn_AggiungiMateriaPrima.Name = "Btn_AggiungiMateriaPrima";
            this.Btn_AggiungiMateriaPrima.Size = new System.Drawing.Size(106, 66);
            this.Btn_AggiungiMateriaPrima.TabIndex = 11;
            this.Btn_AggiungiMateriaPrima.Text = "Aggiungi materia prima";
            this.Btn_AggiungiMateriaPrima.UseVisualStyleBackColor = true;
            this.Btn_AggiungiMateriaPrima.Click += new System.EventHandler(this.Btn_AggiungiMateriaPrima_Click);
            // 
            // Btn_AggiungiSemilavorato
            // 
            this.Btn_AggiungiSemilavorato.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_AggiungiSemilavorato.Location = new System.Drawing.Point(639, 161);
            this.Btn_AggiungiSemilavorato.Name = "Btn_AggiungiSemilavorato";
            this.Btn_AggiungiSemilavorato.Size = new System.Drawing.Size(106, 66);
            this.Btn_AggiungiSemilavorato.TabIndex = 12;
            this.Btn_AggiungiSemilavorato.Text = "Aggiungi semilavorato";
            this.Btn_AggiungiSemilavorato.UseVisualStyleBackColor = true;
            this.Btn_AggiungiSemilavorato.Click += new System.EventHandler(this.Btn_AggiungiSemilavorato_Click);
            // 
            // Btn_caricaDaCatalogo
            // 
            this.Btn_caricaDaCatalogo.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.Btn_caricaDaCatalogo.Location = new System.Drawing.Point(414, 161);
            this.Btn_caricaDaCatalogo.Name = "Btn_caricaDaCatalogo";
            this.Btn_caricaDaCatalogo.Size = new System.Drawing.Size(98, 66);
            this.Btn_caricaDaCatalogo.TabIndex = 17;
            this.Btn_caricaDaCatalogo.Text = "Carica componente da catalogo";
            this.Btn_caricaDaCatalogo.UseVisualStyleBackColor = true;
            this.Btn_caricaDaCatalogo.Click += new System.EventHandler(this.Btn_caricaDaCatalogo_Click);
            // 
            // listView_catalogo
            // 
            this.listView_catalogo.HideSelection = false;
            this.listView_catalogo.Location = new System.Drawing.Point(751, 89);
            this.listView_catalogo.Name = "listView_catalogo";
            this.listView_catalogo.Size = new System.Drawing.Size(402, 407);
            this.listView_catalogo.TabIndex = 18;
            this.listView_catalogo.UseCompatibleStateImageBehavior = false;
            this.listView_catalogo.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView_catalogo_ColumnWidthChanging_1);
            this.listView_catalogo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_catalogo_MouseClick);
            this.listView_catalogo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_catalogo_MouseDoubleClick);
            // 
            // Cms_TreeView
            // 
            this.Cms_TreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aggiungiSottonodoToolStripMenuItem,
            this.rimuoviToolStripMenuItem,
            this.modificaToolStripMenuItem1,
            this.informazioniToolStripMenuItem,
            this.aggiungiACatalogoToolStripMenuItem});
            this.Cms_TreeView.Name = "Cms_TreeView";
            this.Cms_TreeView.Size = new System.Drawing.Size(183, 114);
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
            // caricaDaCatalogoToolStripMenuItem
            // 
            this.caricaDaCatalogoToolStripMenuItem.Name = "caricaDaCatalogoToolStripMenuItem";
            this.caricaDaCatalogoToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.caricaDaCatalogoToolStripMenuItem.Text = "Carica da catalogo";
            this.caricaDaCatalogoToolStripMenuItem.Click += new System.EventHandler(this.daCatalogoToolStripMenuItem_Click);
            // 
            // caricaSemilavoratoToolStripMenuItem
            // 
            this.caricaSemilavoratoToolStripMenuItem.Name = "caricaSemilavoratoToolStripMenuItem";
            this.caricaSemilavoratoToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.caricaSemilavoratoToolStripMenuItem.Text = "Carica semilavorato";
            this.caricaSemilavoratoToolStripMenuItem.Click += new System.EventHandler(this.daFileToolStripMenuItem_Click);
            // 
            // creaNuovoNodoToolStripMenuItem1
            // 
            this.creaNuovoNodoToolStripMenuItem1.Name = "creaNuovoNodoToolStripMenuItem1";
            this.creaNuovoNodoToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
            this.creaNuovoNodoToolStripMenuItem1.Text = "Crea nuovo nodo";
            this.creaNuovoNodoToolStripMenuItem1.Click += new System.EventHandler(this.creaNuovoNodoToolStripMenuItem_Click_1);
            // 
            // rimuoviToolStripMenuItem
            // 
            this.rimuoviToolStripMenuItem.Name = "rimuoviToolStripMenuItem";
            this.rimuoviToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.rimuoviToolStripMenuItem.Text = "Rimuovi";
            this.rimuoviToolStripMenuItem.Click += new System.EventHandler(this.rimuoviToolStripMenuItem_Click);
            // 
            // modificaToolStripMenuItem1
            // 
            this.modificaToolStripMenuItem1.Name = "modificaToolStripMenuItem1";
            this.modificaToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.modificaToolStripMenuItem1.Text = "Modifica";
            this.modificaToolStripMenuItem1.Click += new System.EventHandler(this.modificaToolStripMenuItem1_Click);
            // 
            // informazioniToolStripMenuItem
            // 
            this.informazioniToolStripMenuItem.Name = "informazioniToolStripMenuItem";
            this.informazioniToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.informazioniToolStripMenuItem.Text = "Informazioni";
            this.informazioniToolStripMenuItem.Click += new System.EventHandler(this.informazioniToolStripMenuItem_Click);
            // 
            // aggiungiACatalogoToolStripMenuItem
            // 
            this.aggiungiACatalogoToolStripMenuItem.Name = "aggiungiACatalogoToolStripMenuItem";
            this.aggiungiACatalogoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.aggiungiACatalogoToolStripMenuItem.Text = "Aggiungi a catalogo";
            this.aggiungiACatalogoToolStripMenuItem.Click += new System.EventHandler(this.aggiungiACatalogoToolStripMenuItem_Click);
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
            this.Btn_creaNuovaDistintaBase.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.Btn_creaNuovaDistintaBase.Location = new System.Drawing.Point(414, 89);
            this.Btn_creaNuovaDistintaBase.Name = "Btn_creaNuovaDistintaBase";
            this.Btn_creaNuovaDistintaBase.Size = new System.Drawing.Size(98, 66);
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
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "DISTINTA BASE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(747, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "CATALOGO";
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
            // Btn_Informazioni
            // 
            this.Btn_Informazioni.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Informazioni.Image = global::distinta_base.Properties.Resources.IconaNormale;
            this.Btn_Informazioni.Location = new System.Drawing.Point(1110, 7);
            this.Btn_Informazioni.Name = "Btn_Informazioni";
            this.Btn_Informazioni.Size = new System.Drawing.Size(72, 79);
            this.Btn_Informazioni.TabIndex = 21;
            this.Btn_Informazioni.TabStop = false;
            this.Btn_Informazioni.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Btn_Informazioni_MouseClick);
            this.Btn_Informazioni.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Informazioni_MouseDown);
            this.Btn_Informazioni.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Informazioni_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.distintaBaseToolStripMenuItem,
            this.catalogoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // distintaBaseToolStripMenuItem
            // 
            this.distintaBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caricaToolStripMenuItem,
            this.salvaToolStripMenuItem,
            this.resettaToolStripMenuItem});
            this.distintaBaseToolStripMenuItem.Name = "distintaBaseToolStripMenuItem";
            this.distintaBaseToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.distintaBaseToolStripMenuItem.Text = "Distinta base";
            // 
            // caricaToolStripMenuItem
            // 
            this.caricaToolStripMenuItem.Name = "caricaToolStripMenuItem";
            this.caricaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.caricaToolStripMenuItem.Text = "Carica";
            this.caricaToolStripMenuItem.Click += new System.EventHandler(this.caricaToolStripMenuItem_Click);
            // 
            // salvaToolStripMenuItem
            // 
            this.salvaToolStripMenuItem.Name = "salvaToolStripMenuItem";
            this.salvaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salvaToolStripMenuItem.Text = "Salva";
            this.salvaToolStripMenuItem.Click += new System.EventHandler(this.salvaToolStripMenuItem_Click);
            // 
            // resettaToolStripMenuItem
            // 
            this.resettaToolStripMenuItem.Name = "resettaToolStripMenuItem";
            this.resettaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resettaToolStripMenuItem.Text = "Resetta";
            this.resettaToolStripMenuItem.Click += new System.EventHandler(this.resettaToolStripMenuItem_Click);
            // 
            // catalogoToolStripMenuItem
            // 
            this.catalogoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caricaToolStripMenuItem1,
            this.salvaToolStripMenuItem1,
            this.resettaToolStripMenuItem1});
            this.catalogoToolStripMenuItem.Name = "catalogoToolStripMenuItem";
            this.catalogoToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.catalogoToolStripMenuItem.Text = "Catalogo";
            // 
            // caricaToolStripMenuItem1
            // 
            this.caricaToolStripMenuItem1.Name = "caricaToolStripMenuItem1";
            this.caricaToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.caricaToolStripMenuItem1.Text = "Carica";
            this.caricaToolStripMenuItem1.Click += new System.EventHandler(this.caricaToolStripMenuItem1_Click);
            // 
            // salvaToolStripMenuItem1
            // 
            this.salvaToolStripMenuItem1.Name = "salvaToolStripMenuItem1";
            this.salvaToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.salvaToolStripMenuItem1.Text = "Salva";
            this.salvaToolStripMenuItem1.Click += new System.EventHandler(this.salvaToolStripMenuItem1_Click);
            // 
            // resettaToolStripMenuItem1
            // 
            this.resettaToolStripMenuItem1.Name = "resettaToolStripMenuItem1";
            this.resettaToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.resettaToolStripMenuItem1.Text = "Resetta";
            this.resettaToolStripMenuItem1.Click += new System.EventHandler(this.resettaToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 636);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Btn_Informazioni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_creaNuovaDistintaBase);
            this.Controls.Add(this.listView_catalogo);
            this.Controls.Add(this.Btn_caricaDaCatalogo);
            this.Controls.Add(this.Btn_AggiungiSemilavorato);
            this.Controls.Add(this.Btn_AggiungiMateriaPrima);
            this.Controls.Add(this.treeView_DistintaBase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Distinta base";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Cms_TreeView.ResumeLayout(false);
            this.Cms_ListBox.ResumeLayout(false);
            this.Cms_Informazioni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Informazioni)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_DistintaBase;
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
        private System.Windows.Forms.ToolStripMenuItem aggiungiACatalogoToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem distintaBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caricaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resettaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caricaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salvaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resettaToolStripMenuItem1;
    }
}

