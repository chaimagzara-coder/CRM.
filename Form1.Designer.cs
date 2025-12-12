namespace CRM
{
    partial class Form1
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

        // ⭐⭐ DÉCLARATIONS DE VARIABLES GLOBALES (TOUS LES CONTRÔLES)

        // Contrôles Principaux
        private System.Windows.Forms.TabControl tabControlCRM;
        private System.Windows.Forms.TabPage tabPageClients;
        private System.Windows.Forms.TabPage tabPageLeads;
        private System.Windows.Forms.TabPage tabPageVentes;

        // Clients
        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelTel;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifierClient;
        private System.Windows.Forms.DataGridView dgvClients;

        // Leads
        private System.Windows.Forms.Label labelLeadNom;
        private System.Windows.Forms.Label labelLeadEmail;
        private System.Windows.Forms.Label labelLeadSource;
        private System.Windows.Forms.Label labelLeadStatut;
        private System.Windows.Forms.TextBox txtLeadNom;
        private System.Windows.Forms.TextBox txtLeadEmail;
        private System.Windows.Forms.TextBox txtLeadSource;
        private System.Windows.Forms.ComboBox cmbLeadStatut;
        private System.Windows.Forms.Button btnAjouterLead;
        private System.Windows.Forms.Button btnModifierLead;
        private System.Windows.Forms.Button btnSupprimerLead;
        private System.Windows.Forms.DataGridView dgvLeads;

        // Ventes
        private System.Windows.Forms.Label labelVenteClient;
        private System.Windows.Forms.Label labelVenteDate;
        private System.Windows.Forms.Label labelVenteMontant;
        private System.Windows.Forms.Label labelVenteDescription;
        private System.Windows.Forms.ComboBox cmbVenteClient;
        private System.Windows.Forms.DateTimePicker dtpVenteDate;
        private System.Windows.Forms.TextBox txtVenteMontant;
        private System.Windows.Forms.TextBox txtVenteDescription;
        private System.Windows.Forms.Button btnAjouterVente;
        private System.Windows.Forms.DataGridView dgvVentes;


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlCRM = new System.Windows.Forms.TabControl();
            this.tabPageClients = new System.Windows.Forms.TabPage();
            this.tabPageLeads = new System.Windows.Forms.TabPage();
            this.tabPageVentes = new System.Windows.Forms.TabPage();

            // Initialisation des contrôles Clients
            this.labelNom = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelTel = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifierClient = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.dgvClients = new System.Windows.Forms.DataGridView();

            // Initialisation des contrôles Leads
            this.labelLeadNom = new System.Windows.Forms.Label();
            this.labelLeadEmail = new System.Windows.Forms.Label();
            this.labelLeadSource = new System.Windows.Forms.Label();
            this.labelLeadStatut = new System.Windows.Forms.Label();
            this.txtLeadNom = new System.Windows.Forms.TextBox();
            this.txtLeadEmail = new System.Windows.Forms.TextBox();
            this.txtLeadSource = new System.Windows.Forms.TextBox();
            this.cmbLeadStatut = new System.Windows.Forms.ComboBox();
            this.btnAjouterLead = new System.Windows.Forms.Button();
            this.btnModifierLead = new System.Windows.Forms.Button();
            this.btnSupprimerLead = new System.Windows.Forms.Button();
            this.dgvLeads = new System.Windows.Forms.DataGridView();

            // Initialisation des contrôles Ventes
            this.labelVenteClient = new System.Windows.Forms.Label();
            this.labelVenteDate = new System.Windows.Forms.Label();
            this.labelVenteMontant = new System.Windows.Forms.Label();
            this.labelVenteDescription = new System.Windows.Forms.Label();
            this.cmbVenteClient = new System.Windows.Forms.ComboBox();
            this.dtpVenteDate = new System.Windows.Forms.DateTimePicker();
            this.txtVenteMontant = new System.Windows.Forms.TextBox();
            this.txtVenteDescription = new System.Windows.Forms.TextBox();
            this.btnAjouterVente = new System.Windows.Forms.Button();
            this.dgvVentes = new System.Windows.Forms.DataGridView();

            // Suspension de la mise en page
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentes)).BeginInit();
            this.tabControlCRM.SuspendLayout();
            this.tabPageClients.SuspendLayout();
            this.tabPageLeads.SuspendLayout();
            this.tabPageVentes.SuspendLayout();
            this.SuspendLayout();

            // 
            // tabControlCRM
            // 
            this.tabControlCRM.Controls.Add(this.tabPageClients);
            this.tabControlCRM.Controls.Add(this.tabPageLeads);
            this.tabControlCRM.Controls.Add(this.tabPageVentes);
            this.tabControlCRM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCRM.Location = new System.Drawing.Point(0, 0);
            this.tabControlCRM.Name = "tabControlCRM";
            this.tabControlCRM.SelectedIndex = 0;
            this.tabControlCRM.Size = new System.Drawing.Size(800, 500);
            this.tabControlCRM.TabIndex = 0;
            this.tabControlCRM.SelectedIndexChanged += new System.EventHandler(this.tabControlCRM_SelectedIndexChanged);

            // 
            // tabPageClients
            // 
            this.tabPageClients.Controls.Add(this.dgvClients);
            this.tabPageClients.Controls.Add(this.btnSupprimer);
            this.tabPageClients.Controls.Add(this.btnModifierClient);
            this.tabPageClients.Controls.Add(this.btnAjouter);
            this.tabPageClients.Controls.Add(this.txtTelephone);
            this.tabPageClients.Controls.Add(this.txtEmail);
            this.tabPageClients.Controls.Add(this.txtNom);
            this.tabPageClients.Controls.Add(this.labelTel);
            this.tabPageClients.Controls.Add(this.labelEmail);
            this.tabPageClients.Controls.Add(this.labelNom);
            this.tabPageClients.Location = new System.Drawing.Point(4, 24);
            this.tabPageClients.Name = "tabPageClients";
            this.tabPageClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClients.Size = new System.Drawing.Size(792, 472);
            this.tabPageClients.TabIndex = 0;
            this.tabPageClients.Text = "Clients";
            this.tabPageClients.UseVisualStyleBackColor = true;

            // 
            // tabPageLeads
            // 
            this.tabPageLeads.Controls.Add(this.dgvLeads);
            this.tabPageLeads.Controls.Add(this.btnSupprimerLead);
            this.tabPageLeads.Controls.Add(this.btnModifierLead);
            this.tabPageLeads.Controls.Add(this.btnAjouterLead);
            this.tabPageLeads.Controls.Add(this.cmbLeadStatut);
            this.tabPageLeads.Controls.Add(this.txtLeadSource);
            this.tabPageLeads.Controls.Add(this.txtLeadEmail);
            this.tabPageLeads.Controls.Add(this.txtLeadNom);
            this.tabPageLeads.Controls.Add(this.labelLeadStatut);
            this.tabPageLeads.Controls.Add(this.labelLeadSource);
            this.tabPageLeads.Controls.Add(this.labelLeadEmail);
            this.tabPageLeads.Controls.Add(this.labelLeadNom);
            this.tabPageLeads.Location = new System.Drawing.Point(4, 24);
            this.tabPageLeads.Name = "tabPageLeads";
            this.tabPageLeads.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLeads.Size = new System.Drawing.Size(792, 472);
            this.tabPageLeads.TabIndex = 1;
            this.tabPageLeads.Text = "Leads";
            this.tabPageLeads.UseVisualStyleBackColor = true;

            // 
            // tabPageVentes
            // 
            this.tabPageVentes.Controls.Add(this.dgvVentes);
            this.tabPageVentes.Controls.Add(this.btnAjouterVente);
            this.tabPageVentes.Controls.Add(this.txtVenteDescription);
            this.tabPageVentes.Controls.Add(this.labelVenteDescription);
            this.tabPageVentes.Controls.Add(this.txtVenteMontant);
            this.tabPageVentes.Controls.Add(this.dtpVenteDate);
            this.tabPageVentes.Controls.Add(this.cmbVenteClient);
            this.tabPageVentes.Controls.Add(this.labelVenteMontant);
            this.tabPageVentes.Controls.Add(this.labelVenteDate);
            this.tabPageVentes.Controls.Add(this.labelVenteClient);
            this.tabPageVentes.Location = new System.Drawing.Point(4, 24);
            this.tabPageVentes.Name = "tabPageVentes";
            this.tabPageVentes.Size = new System.Drawing.Size(792, 472);
            this.tabPageVentes.TabIndex = 2;
            this.tabPageVentes.Text = "Historique des ventes";
            this.tabPageVentes.UseVisualStyleBackColor = true;

            // ----------------------------------------------------
            // Configuration détaillée des Contrôles (Positionnement et Propriétés)
            // ----------------------------------------------------

            // --- Clients ---

            // Labels
            this.labelNom.AutoSize = true; this.labelNom.Location = new System.Drawing.Point(30, 30); this.labelNom.Text = "Nom";
            this.labelEmail.AutoSize = true; this.labelEmail.Location = new System.Drawing.Point(30, 70); this.labelEmail.Text = "Email";
            this.labelTel.AutoSize = true; this.labelTel.Location = new System.Drawing.Point(30, 110); this.labelTel.Text = "Téléphone";

            // TextBoxes
            this.txtNom.Location = new System.Drawing.Point(120, 25); this.txtNom.Size = new System.Drawing.Size(200, 23);
            this.txtEmail.Location = new System.Drawing.Point(120, 65); this.txtEmail.Size = new System.Drawing.Size(200, 23);
            this.txtTelephone.Location = new System.Drawing.Point(120, 105); this.txtTelephone.Size = new System.Drawing.Size(200, 23);

            // Buttons
            this.btnAjouter.Location = new System.Drawing.Point(30, 150); this.btnAjouter.Size = new System.Drawing.Size(120, 30); this.btnAjouter.Text = "Ajouter Client";
            this.btnModifierClient.Location = new System.Drawing.Point(160, 150); this.btnModifierClient.Size = new System.Drawing.Size(120, 30); this.btnModifierClient.Text = "Modifier";
            this.btnSupprimer.Location = new System.Drawing.Point(290, 150); this.btnSupprimer.Size = new System.Drawing.Size(120, 30); this.btnSupprimer.Text = "Supprimer";

            // DataGridView
            this.dgvClients.AllowUserToAddRows = false; this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(30, 200); this.dgvClients.ReadOnly = true;
            this.dgvClients.Size = new System.Drawing.Size(730, 250);
            this.dgvClients.SelectionChanged += new System.EventHandler(this.dgvClients_SelectionChanged);
            // --- Leads ---

            // Labels
            this.labelLeadNom.AutoSize = true; this.labelLeadNom.Location = new System.Drawing.Point(30, 30); this.labelLeadNom.Text = "Nom";
            this.labelLeadEmail.AutoSize = true; this.labelLeadEmail.Location = new System.Drawing.Point(30, 70); this.labelLeadEmail.Text = "Email";
            this.labelLeadSource.AutoSize = true; this.labelLeadSource.Location = new System.Drawing.Point(300, 30); this.labelLeadSource.Text = "Source";
            this.labelLeadStatut.AutoSize = true; this.labelLeadStatut.Location = new System.Drawing.Point(300, 70); this.labelLeadStatut.Text = "Statut";

            // TextBoxes & ComboBox
            this.txtLeadNom.Location = new System.Drawing.Point(120, 25); this.txtLeadNom.Size = new System.Drawing.Size(150, 23);
            this.txtLeadEmail.Location = new System.Drawing.Point(120, 65); this.txtLeadEmail.Size = new System.Drawing.Size(150, 23);
            this.txtLeadSource.Location = new System.Drawing.Point(380, 25); this.txtLeadSource.Size = new System.Drawing.Size(150, 23);
            this.cmbLeadStatut.Location = new System.Drawing.Point(380, 65); this.cmbLeadStatut.Size = new System.Drawing.Size(150, 23);
            this.cmbLeadStatut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Buttons
            this.btnAjouterLead.Location = new System.Drawing.Point(30, 150); this.btnAjouterLead.Size = new System.Drawing.Size(120, 30); this.btnAjouterLead.Text = "Ajouter Lead";
            this.btnModifierLead.Location = new System.Drawing.Point(160, 150); this.btnModifierLead.Size = new System.Drawing.Size(120, 30); this.btnModifierLead.Text = "Modifier";
            this.btnSupprimerLead.Location = new System.Drawing.Point(290, 150); this.btnSupprimerLead.Size = new System.Drawing.Size(120, 30); this.btnSupprimerLead.Text = "Supprimer";

            // DataGridView
            this.dgvLeads.AllowUserToAddRows = false; this.dgvLeads.AllowUserToDeleteRows = false;
            this.dgvLeads.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLeads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeads.Location = new System.Drawing.Point(30, 200); this.dgvLeads.ReadOnly = true;
            this.dgvLeads.Size = new System.Drawing.Size(730, 250);

            // --- Ventes ---

            // Labels
            this.labelVenteClient.AutoSize = true; this.labelVenteClient.Location = new System.Drawing.Point(30, 30); this.labelVenteClient.Text = "Client";
            this.labelVenteDate.AutoSize = true; this.labelVenteDate.Location = new System.Drawing.Point(30, 70); this.labelVenteDate.Text = "Date";
            this.labelVenteMontant.AutoSize = true; this.labelVenteMontant.Location = new System.Drawing.Point(30, 110); this.labelVenteMontant.Text = "Montant";
            this.labelVenteDescription.AutoSize = true; this.labelVenteDescription.Location = new System.Drawing.Point(300, 30); this.labelVenteDescription.Text = "Description";

            // Controls
            this.cmbVenteClient.Location = new System.Drawing.Point(120, 25); this.cmbVenteClient.Size = new System.Drawing.Size(150, 23);
            this.dtpVenteDate.Location = new System.Drawing.Point(120, 65); this.dtpVenteDate.Size = new System.Drawing.Size(150, 23);
            this.txtVenteMontant.Location = new System.Drawing.Point(120, 105); this.txtVenteMontant.Size = new System.Drawing.Size(150, 23);
            this.txtVenteDescription.Location = new System.Drawing.Point(380, 25); this.txtVenteDescription.Size = new System.Drawing.Size(350, 70); this.txtVenteDescription.Multiline = true;

            // Buttons
            this.btnAjouterVente.Location = new System.Drawing.Point(30, 150); this.btnAjouterVente.Size = new System.Drawing.Size(150, 30); this.btnAjouterVente.Text = "Ajouter la vente";

            // DataGridView
            this.dgvVentes.AllowUserToAddRows = false; this.dgvVentes.AllowUserToDeleteRows = false;
            this.dgvVentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentes.Location = new System.Drawing.Point(30, 200); this.dgvVentes.ReadOnly = true;
            this.dgvVentes.Size = new System.Drawing.Size(730, 250);


            // ----------------------------------------------------
            // LIAISON DES ÉVÉNEMENTS
            // ----------------------------------------------------

            // Clients
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            this.btnModifierClient.Click += new System.EventHandler(this.btnModifierClient_Click);
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);

            // Leads
            this.btnAjouterLead.Click += new System.EventHandler(this.btnAjouterLead_Click);
            this.btnModifierLead.Click += new System.EventHandler(this.btnModifierLead_Click);
            this.btnSupprimerLead.Click += new System.EventHandler(this.btnSupprimerLead_Click);

            // Ventes
            this.btnAjouterVente.Click += new System.EventHandler(this.btnAjouterVente_Click);


            // ----------------------------------------------------
            // Form1 et Finalisation
            // ----------------------------------------------------

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.tabControlCRM);
            this.Name = "Form1";
            this.Text = "CRM - Gestion Complète";
            this.Load += new System.EventHandler(this.Form1_Load);

            // Reprise de la mise en page
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentes)).EndInit();
            this.tabControlCRM.ResumeLayout(false);
            this.tabPageClients.ResumeLayout(false);
            this.tabPageClients.PerformLayout();
            this.tabPageLeads.ResumeLayout(false);
            this.tabPageLeads.PerformLayout();
            this.tabPageVentes.ResumeLayout(false);
            this.tabPageVentes.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}