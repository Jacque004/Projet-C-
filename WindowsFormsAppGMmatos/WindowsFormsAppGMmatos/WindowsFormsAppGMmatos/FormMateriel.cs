using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppGMmatos.Data;
using WindowsFormsAppGMmatos.Models;

namespace WindowsFormsAppGMmatos
{
    public partial class FormMateriel : Form
    {
        private int? _selectedId;

        public FormMateriel()
        {
            InitializeComponent();
        }

        private async void FormMateriel_Load(object sender, EventArgs e)
        {
            cboEtat.Items.AddRange(new object[]
            {
                "disponible", "loue", "maintenance", "hors_service"
            });
            cboEtat.SelectedIndex = 0;
            await ChargerAsync();
        }

        private async Task ChargerAsync()
        {
            try
            {
                var items = await ApiService.GetMaterielsAsync();
                gridMateriel.DataSource = items;
                ConfigurerColonnes();
                ViderFormulaire();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Impossible de charger le matériel.\n\n" + ex.Message +
                    "\n\nVérifiez qu'Apache/MySQL sont démarrés et que l'API est accessible.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigurerColonnes()
        {
            if (gridMateriel.Columns.Count == 0) return;
            gridMateriel.Columns["Id"].HeaderText = "ID";
            gridMateriel.Columns["Id"].Width = 50;
            gridMateriel.Columns["Reference"].HeaderText = "Référence";
            gridMateriel.Columns["Designation"].HeaderText = "Désignation";
            gridMateriel.Columns["Categorie"].HeaderText = "Catégorie";
            gridMateriel.Columns["Quantite"].HeaderText = "Qté";
            gridMateriel.Columns["PrixJour"].HeaderText = "Prix / jour";
            gridMateriel.Columns["Etat"].HeaderText = "État";
            gridMateriel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridMateriel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridMateriel.MultiSelect = false;
            gridMateriel.ReadOnly = true;
            gridMateriel.AllowUserToAddRows = false;
        }

        private void gridMateriel_SelectionChanged(object sender, EventArgs e)
        {
            if (gridMateriel.CurrentRow == null || gridMateriel.CurrentRow.DataBoundItem == null)
            {
                return;
            }

            var item = gridMateriel.CurrentRow.DataBoundItem as Materiel;
            if (item == null) return;

            _selectedId = item.Id;
            txtReference.Text = item.Reference;
            txtDesignation.Text = item.Designation;
            txtCategorie.Text = item.Categorie ?? string.Empty;
            numQuantite.Value = item.Quantite;
            numPrix.Value = item.PrixJour;
            cboEtat.SelectedItem = item.Etat ?? "disponible";
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            ViderFormulaire();
        }

        private async void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReference.Text) || string.IsNullOrWhiteSpace(txtDesignation.Text))
            {
                MessageBox.Show("Référence et désignation sont obligatoires.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = new Materiel
            {
                Id = _selectedId ?? 0,
                Reference = txtReference.Text.Trim(),
                Designation = txtDesignation.Text.Trim(),
                Categorie = txtCategorie.Text.Trim(),
                Quantite = (int)numQuantite.Value,
                PrixJour = numPrix.Value,
                Etat = cboEtat.SelectedItem != null ? cboEtat.SelectedItem.ToString() : "disponible"
            };

            try
            {
                if (_selectedId.HasValue)
                {
                    await ApiService.UpdateMaterielAsync(item);
                }
                else
                {
                    await ApiService.CreateMaterielAsync(item);
                }

                await ChargerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageBox.Show("Sélectionnez un matériel à supprimer.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Supprimer ce matériel ?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                await ApiService.DeleteMaterielAsync(_selectedId.Value);
                await ChargerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnActualiser_Click(object sender, EventArgs e)
        {
            await ChargerAsync();
        }

        private void ViderFormulaire()
        {
            _selectedId = null;
            txtReference.Clear();
            txtDesignation.Clear();
            txtCategorie.Clear();
            numQuantite.Value = 0;
            numPrix.Value = 0;
            cboEtat.SelectedIndex = 0;
            gridMateriel.ClearSelection();
            txtReference.Focus();
        }
    }
}
