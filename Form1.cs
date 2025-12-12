using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace CRM
{
    // Assurez-vous que cette classe correspond bien aux déclarations de Form1.Designer.cs
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Affiche le chemin de la DB et ouvre le dossier
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "crm.db");
            MessageBox.Show($"📂 Fichier DB utilisé:\n\n{dbPath}", "Chemin de la base");
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory);
            }
            catch { }

            // Charge le premier onglet (Clients) au démarrage
            LoadClients();

            // Initialisation des statuts pour Leads (ComboBox)
            cmbLeadStatut.Items.AddRange(new string[] { "Nouveau", "Contacté", "Qualifié", "Perdu" });
            cmbLeadStatut.SelectedIndex = 0;
        }

        // --- GESTION DU CHANGEMENT D'ONGLET ---
        private void tabControlCRM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlCRM.SelectedTab == tabPageLeads)
            {
                LoadLeads();
            }
            else if (tabControlCRM.SelectedTab == tabPageVentes)
            {
                LoadVentes();
            }
            else if (tabControlCRM.SelectedTab == tabPageClients)
            {
                LoadClients();
            }
        }

        // --- GESTION DES CLIENTS ---
        private void LoadClients()
        {
            if (dgvClients == null) return;
            try
            {
                var clients = SqliteHelper.GetClients();
                dgvClients.DataSource = clients;

                // Rafraîchir la ComboBox des ventes
                if (cmbVenteClient != null)
                {
                    cmbVenteClient.DataSource = clients;
                    cmbVenteClient.DisplayMember = "Nom";
                    cmbVenteClient.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ ERREUR de chargement des clients: {ex.Message}", "Erreur DB");
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs du client");
                return;
            }
            try
            {
                var client = new Client(txtEmail.Text, txtNom.Text, txtTelephone.Text);
                SqliteHelper.AddClient(client);
                LoadClients();
                txtNom.Clear(); txtEmail.Clear(); txtTelephone.Clear();
                MessageBox.Show("Client ajouté avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ ERREUR d'ajout: {ex.Message}");
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sélectionnez un client à supprimer");
                return;
            }
            var result = MessageBox.Show("Supprimer ce client ainsi que ses Leads et Ventes associées ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var clientId = (int)dgvClients.SelectedRows[0].Cells["Id"].Value;
                    SqliteHelper.DeleteClient(clientId);
                    LoadClients();
                    MessageBox.Show("Client supprimé.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ ERREUR de suppression: {ex.Message}");
                }
            }
        }

        private void btnModifierClient_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La fonction de modification du client sera implémentée ici.");
        }


        // --- GESTION DES LEADS ---
        private void LoadLeads()
        {
            if (dgvLeads == null) return;
            try
            {
                var leads = SqliteHelper.GetLeads();
                dgvLeads.DataSource = leads;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ ERREUR de chargement des leads: {ex.Message}", "Erreur DB");
            }
        }

        private void btnAjouterLead_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLeadNom.Text) || string.IsNullOrWhiteSpace(txtLeadEmail.Text) || string.IsNullOrWhiteSpace(txtLeadSource.Text))
            {
                MessageBox.Show("Veuillez remplir les champs Nom, Email et Source du Lead");
                return;
            }

            var lead = new Lead
            {
                ClientId = 0, // Id du client associé (à gérer si vous convertissez un lead en client)
                Description = $"Lead de {txtLeadNom.Text} | Source: {txtLeadSource.Text}",
                Statut = cmbLeadStatut.SelectedItem.ToString(),
                DateCreation = DateTime.Now
            };

            try
            {
                SqliteHelper.AddLead(lead);
                LoadLeads();
                txtLeadNom.Clear(); txtLeadEmail.Clear(); txtLeadSource.Clear();
                MessageBox.Show("Lead ajouté !");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ ERREUR d'ajout du Lead: {ex.Message}");
            }
        }

        private void btnSupprimerLead_Click(object sender, EventArgs e)
        {
            if (dgvLeads.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sélectionnez un Lead à supprimer.");
                return;
            }
            if (MessageBox.Show("Supprimer ce Lead ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var leadId = (int)dgvLeads.SelectedRows[0].Cells["Id"].Value;
                    SqliteHelper.DeleteLead(leadId);
                    LoadLeads();
                    MessageBox.Show("Lead supprimé.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ ERREUR de suppression du Lead: {ex.Message}");
                }
            }
        }

        private void btnModifierLead_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La fonction de modification du Lead sera implémentée ici.");
        }


        // --- GESTION DES VENTES ---
        private void LoadVentes()
        {
            if (dgvVentes == null) return;
            try
            {
                var ventes = SqliteHelper.GetVentes();

                // Jointure en mémoire pour afficher le Nom du Client au lieu de l'ID
                var clients = SqliteHelper.GetClients().ToDictionary(c => c.Id, c => c.Nom);
                var ventesAffichees = ventes.Select(v => new
                {
                    v.Id,
                    Client = clients.ContainsKey(v.ClientId) ? clients[v.ClientId] : "Inconnu",
                    v.Montant,
                    v.Description,
                    v.DateVente
                }).ToList();

                dgvVentes.DataSource = ventesAffichees;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ ERREUR de chargement des ventes: {ex.Message}", "Erreur DB");
            }
        }

        private void btnAjouterVente_Click(object sender, EventArgs e)
        {
            if (cmbVenteClient.SelectedValue == null || !double.TryParse(txtVenteMontant.Text, out double montant))
            {
                MessageBox.Show("Sélectionnez un client et entrez un montant valide.");
                return;
            }

            var vente = new Vente
            {
                ClientId = (int)cmbVenteClient.SelectedValue,
                Montant = montant,
                Description = txtVenteDescription.Text,
                DateVente = dtpVenteDate.Value
            };

            try
            {
                SqliteHelper.AddVente(vente);
                LoadVentes();
                txtVenteMontant.Clear();
                txtVenteDescription.Clear();
                MessageBox.Show("Vente ajoutée !");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ ERREUR d'ajout de la Vente: {ex.Message}");
            }
        }
        // Extrait de Form1.cs

        private void btnModifierClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sélectionnez la ligne du client à modifier dans le tableau.", "Erreur de sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Récupérer l'ID du client sélectionné
            var selectedRow = dgvClients.SelectedRows[0];
            var clientId = (int)selectedRow.Cells["Id"].Value;

            if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs (Nom, Email, Téléphone) pour la modification.");
                return;
            }

            try
            {
                // 2. Créer l'objet Client avec les nouvelles données et l'ID existant
                var clientModifie = new Client
                {
                    Id = clientId,
                    Nom = txtNom.Text,
                    Email = txtEmail.Text,
                    Telephone = txtTelephone.Text,
                    // La date d'inscription est conservée (non modifiée)
                };

                // 3. Appeler la méthode de mise à jour de la base de données
                SqliteHelper.UpdateClient(clientModifie);

                // 4. Recharger les clients dans le DataGridView pour afficher la modification
                LoadClients();

                // 5. Nettoyer les champs de saisie (Optionnel)
                txtNom.Clear(); txtEmail.Clear(); txtTelephone.Clear();

                MessageBox.Show($"Client ID {clientId} modifié avec succès !", "Modification réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ ERREUR lors de la modification: {ex.Message}", "Erreur DB");
            }
        }
        // Extrait de Form1.cs

        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            // S'assurer qu'une ligne est sélectionnée et qu'elle n'est pas la ligne d'ajout (si elle existait)
            if (dgvClients.SelectedRows.Count > 0)
            {
                // Récupérer la première ligne sélectionnée
                DataGridViewRow selectedRow = dgvClients.SelectedRows[0];

                // 1. Vérifier que les cellules existent et ne sont pas nulles
                if (selectedRow.Cells["Nom"].Value != null &&
                    selectedRow.Cells["Email"].Value != null &&
                    selectedRow.Cells["Telephone"].Value != null)
                {
                    // 2. Remplir les champs de texte
                    txtNom.Text = selectedRow.Cells["Nom"].Value.ToString();
                    txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                    txtTelephone.Text = selectedRow.Cells["Telephone"].Value.ToString();
                }
            }
            else
            {
                // Si aucune ligne n'est sélectionnée, vider les champs (optionnel mais propre)
                txtNom.Clear();
                txtEmail.Clear();
                txtTelephone.Clear();
            }
        }
    }
}