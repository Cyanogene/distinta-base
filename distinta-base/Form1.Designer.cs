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
            this.modificaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.informazioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rimuoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aggiungiACatalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daCatalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creaNuovoNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_creaNuovaDistintaBase = new System.Windows.Forms.Button();
            this.Cms_ListBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rimuoviToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informazioniToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_distintaBase = new System.Windows.Forms.Label();
            this.lbl_catalogo = new System.Windows.Forms.Label();
            this.Cms_Informazioni = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.guidaSullaDistintaBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guidaSulCatalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.distintaBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caricaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resettaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caricaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salvaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resettaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manualeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cms_TreeView.SuspendLayout();
            this.Cms_ListBox.SuspendLayout();
            this.Cms_Informazioni.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_DistintaBase
            // 
            this.treeView_DistintaBase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.treeView_DistintaBase.BackColor = System.Drawing.Color.White;
            this.treeView_DistintaBase.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView_DistintaBase.Location = new System.Drawing.Point(100, 100);
            this.treeView_DistintaBase.Margin = new System.Windows.Forms.Padding(4);
            this.treeView_DistintaBase.Name = "treeView_DistintaBase";
            this.treeView_DistintaBase.Size = new System.Drawing.Size(450, 450);
            this.treeView_DistintaBase.TabIndex = 0;
            this.treeView_DistintaBase.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_DistintaBase_NodeMouseClick_1);
            this.treeView_DistintaBase.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_DistintaBase_NodeMouseDoubleClick);
            // 
            // Btn_AggiungiMateriaPrima
            // 
            this.Btn_AggiungiMateriaPrima.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_AggiungiMateriaPrima.AutoSize = true;
            this.Btn_AggiungiMateriaPrima.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Btn_AggiungiMateriaPrima.Location = new System.Drawing.Point(957, 558);
            this.Btn_AggiungiMateriaPrima.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_AggiungiMateriaPrima.Name = "Btn_AggiungiMateriaPrima";
            this.Btn_AggiungiMateriaPrima.Size = new System.Drawing.Size(223, 52);
            this.Btn_AggiungiMateriaPrima.TabIndex = 3;
            this.Btn_AggiungiMateriaPrima.Text = "AGGIUNGI \r\nMATERIA PRIMA";
            this.Btn_AggiungiMateriaPrima.UseVisualStyleBackColor = true;
            this.Btn_AggiungiMateriaPrima.Click += new System.EventHandler(this.Btn_AggiungiMateriaPrima_Click);
            // 
            // Btn_AggiungiSemilavorato
            // 
            this.Btn_AggiungiSemilavorato.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_AggiungiSemilavorato.AutoSize = true;
            this.Btn_AggiungiSemilavorato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Btn_AggiungiSemilavorato.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Btn_AggiungiSemilavorato.Location = new System.Drawing.Point(730, 558);
            this.Btn_AggiungiSemilavorato.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_AggiungiSemilavorato.Name = "Btn_AggiungiSemilavorato";
            this.Btn_AggiungiSemilavorato.Size = new System.Drawing.Size(223, 52);
            this.Btn_AggiungiSemilavorato.TabIndex = 2;
            this.Btn_AggiungiSemilavorato.Text = "AGGIUNGI \r\nSEMILAVORATO";
            this.Btn_AggiungiSemilavorato.UseVisualStyleBackColor = false;
            this.Btn_AggiungiSemilavorato.Click += new System.EventHandler(this.Btn_AggiungiSemilavorato_Click);
            // 
            // Btn_caricaDaCatalogo
            // 
            this.Btn_caricaDaCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_caricaDaCatalogo.AutoSize = true;
            this.Btn_caricaDaCatalogo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_caricaDaCatalogo.Location = new System.Drawing.Point(327, 558);
            this.Btn_caricaDaCatalogo.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_caricaDaCatalogo.Name = "Btn_caricaDaCatalogo";
            this.Btn_caricaDaCatalogo.Size = new System.Drawing.Size(223, 52);
            this.Btn_caricaDaCatalogo.TabIndex = 1;
            this.Btn_caricaDaCatalogo.Text = "CARICA COMPONENTE\r\nDA CATALOGO";
            this.Btn_caricaDaCatalogo.UseVisualStyleBackColor = true;
            this.Btn_caricaDaCatalogo.Click += new System.EventHandler(this.Btn_caricaDaCatalogo_Click);
            // 
            // listView_catalogo
            // 
            this.listView_catalogo.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView_catalogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView_catalogo.BackColor = System.Drawing.Color.White;
            this.listView_catalogo.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.listView_catalogo.HideSelection = false;
            this.listView_catalogo.HoverSelection = true;
            this.listView_catalogo.Location = new System.Drawing.Point(730, 100);
            this.listView_catalogo.Margin = new System.Windows.Forms.Padding(4);
            this.listView_catalogo.Name = "listView_catalogo";
            this.listView_catalogo.Size = new System.Drawing.Size(450, 450);
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
            this.modificaToolStripMenuItem1,
            this.informazioniToolStripMenuItem,
            this.rimuoviToolStripMenuItem,
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
            // rimuoviToolStripMenuItem
            // 
            this.rimuoviToolStripMenuItem.Name = "rimuoviToolStripMenuItem";
            this.rimuoviToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.rimuoviToolStripMenuItem.Text = "Rimuovi";
            this.rimuoviToolStripMenuItem.Click += new System.EventHandler(this.rimuoviToolStripMenuItem_Click);
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
            this.Btn_creaNuovaDistintaBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_creaNuovaDistintaBase.AutoSize = true;
            this.Btn_creaNuovaDistintaBase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_creaNuovaDistintaBase.Location = new System.Drawing.Point(100, 558);
            this.Btn_creaNuovaDistintaBase.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_creaNuovaDistintaBase.Name = "Btn_creaNuovaDistintaBase";
            this.Btn_creaNuovaDistintaBase.Size = new System.Drawing.Size(223, 52);
            this.Btn_creaNuovaDistintaBase.TabIndex = 0;
            this.Btn_creaNuovaDistintaBase.Text = "AGGIUNGI NUOVA\r\nDISTINTA BASE\r\n";
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
            // lbl_distintaBase
            // 
            this.lbl_distintaBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_distintaBase.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_distintaBase.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbl_distintaBase.Location = new System.Drawing.Point(100, 65);
            this.lbl_distintaBase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_distintaBase.MinimumSize = new System.Drawing.Size(166, 27);
            this.lbl_distintaBase.Name = "lbl_distintaBase";
            this.lbl_distintaBase.Size = new System.Drawing.Size(450, 28);
            this.lbl_distintaBase.TabIndex = 20;
            this.lbl_distintaBase.Text = "DISTINTA BASE";
            // 
            // lbl_catalogo
            // 
            this.lbl_catalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_catalogo.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_catalogo.Location = new System.Drawing.Point(730, 65);
            this.lbl_catalogo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_catalogo.MinimumSize = new System.Drawing.Size(125, 27);
            this.lbl_catalogo.Name = "lbl_catalogo";
            this.lbl_catalogo.Size = new System.Drawing.Size(450, 28);
            this.lbl_catalogo.TabIndex = 20;
            this.lbl_catalogo.Text = "CATALOGO";
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
            // 
            // guidaSulCatalogoToolStripMenuItem
            // 
            this.guidaSulCatalogoToolStripMenuItem.Name = "guidaSulCatalogoToolStripMenuItem";
            this.guidaSulCatalogoToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.guidaSulCatalogoToolStripMenuItem.Text = "Guida sul catalogo";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.distintaBaseToolStripMenuItem,
            this.catalogoToolStripMenuItem,
            this.manualeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1264, 26);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // distintaBaseToolStripMenuItem
            // 
            this.distintaBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caricaToolStripMenuItem,
            this.salvaToolStripMenuItem,
            this.resettaToolStripMenuItem});
            this.distintaBaseToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distintaBaseToolStripMenuItem.Name = "distintaBaseToolStripMenuItem";
            this.distintaBaseToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.distintaBaseToolStripMenuItem.Text = "Distinta base";
            // 
            // caricaToolStripMenuItem
            // 
            this.caricaToolStripMenuItem.Name = "caricaToolStripMenuItem";
            this.caricaToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.caricaToolStripMenuItem.Text = "Carica";
            this.caricaToolStripMenuItem.Click += new System.EventHandler(this.caricaToolStripMenuItem_Click);
            // 
            // salvaToolStripMenuItem
            // 
            this.salvaToolStripMenuItem.Name = "salvaToolStripMenuItem";
            this.salvaToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.salvaToolStripMenuItem.Text = "Salva";
            this.salvaToolStripMenuItem.Click += new System.EventHandler(this.salvaToolStripMenuItem_Click);
            // 
            // resettaToolStripMenuItem
            // 
            this.resettaToolStripMenuItem.Name = "resettaToolStripMenuItem";
            this.resettaToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.resettaToolStripMenuItem.Text = "Resetta";
            this.resettaToolStripMenuItem.Click += new System.EventHandler(this.resettaToolStripMenuItem_Click);
            // 
            // catalogoToolStripMenuItem
            // 
            this.catalogoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caricaToolStripMenuItem1,
            this.salvaToolStripMenuItem1,
            this.resettaToolStripMenuItem1});
            this.catalogoToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.catalogoToolStripMenuItem.Name = "catalogoToolStripMenuItem";
            this.catalogoToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.catalogoToolStripMenuItem.Text = "Catalogo";
            // 
            // caricaToolStripMenuItem1
            // 
            this.caricaToolStripMenuItem1.Name = "caricaToolStripMenuItem1";
            this.caricaToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.caricaToolStripMenuItem1.Text = "Carica";
            this.caricaToolStripMenuItem1.Click += new System.EventHandler(this.caricaToolStripMenuItem1_Click);
            // 
            // salvaToolStripMenuItem1
            // 
            this.salvaToolStripMenuItem1.Name = "salvaToolStripMenuItem1";
            this.salvaToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.salvaToolStripMenuItem1.Text = "Salva";
            this.salvaToolStripMenuItem1.Click += new System.EventHandler(this.salvaToolStripMenuItem1_Click);
            // 
            // resettaToolStripMenuItem1
            // 
            this.resettaToolStripMenuItem1.Name = "resettaToolStripMenuItem1";
            this.resettaToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.resettaToolStripMenuItem1.Text = "Resetta";
            this.resettaToolStripMenuItem1.Click += new System.EventHandler(this.resettaToolStripMenuItem1_Click);
            // 
            // manualeToolStripMenuItem
            // 
            this.manualeToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.manualeToolStripMenuItem.Name = "manualeToolStripMenuItem";
            this.manualeToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.manualeToolStripMenuItem.Text = "Manuale";
            this.manualeToolStripMenuItem.Click += new System.EventHandler(this.manualeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lbl_catalogo);
            this.Controls.Add(this.lbl_distintaBase);
            this.Controls.Add(this.Btn_creaNuovaDistintaBase);
            this.Controls.Add(this.listView_catalogo);
            this.Controls.Add(this.Btn_caricaDaCatalogo);
            this.Controls.Add(this.Btn_AggiungiSemilavorato);
            this.Controls.Add(this.Btn_AggiungiMateriaPrima);
            this.Controls.Add(this.treeView_DistintaBase);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(960, 540);
            this.Name = "Form1";
            this.Text = "Distinta base";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.Cms_TreeView.ResumeLayout(false);
            this.Cms_ListBox.ResumeLayout(false);
            this.Cms_Informazioni.ResumeLayout(false);
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
        private System.Windows.Forms.Label lbl_distintaBase;
        private System.Windows.Forms.Label lbl_catalogo;
        private System.Windows.Forms.ContextMenuStrip Cms_Informazioni;
        private System.Windows.Forms.ToolStripMenuItem guidaSullaDistintaBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guidaSulCatalogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caricaDaCatalogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caricaSemilavoratoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creaNuovoNodoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aggiungiACatalogoToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem distintaBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caricaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resettaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caricaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salvaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resettaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manualeToolStripMenuItem;
    }
}

