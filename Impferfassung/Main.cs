namespace Impferfassung
{
    using Impferfassung.Contracts;
    using Impferfassung.Data;
    using Impferfassung.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Main form of the application.
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        /// A factory for creating contexts with the fkvaccination database.
        /// </summary>
        private readonly IDbContextFactory<FkVaccinationContext> contextFactory;

        private readonly IServiceProvider serviceProvider;

        private List<Vaccinee> vaccinees = new();

        private const string MSG_ENTITY_INVALID = "Der gewählte Eintrag ist ungültig.";
        private const string MSG_ENTITY_NOT_FOUND = "Eintrag wurde in der Datenbank nicht gefunden.";
        private const string MSG_NO_ENTRY_SELECTED = "Kein Eintrag ausgewählt.";

        /// <summary>
        /// Current application session properties.
        /// </summary>
        private readonly ISession session;

        private readonly DateTimePicker datePicker;

        /// <summary>
        /// Initializes a new instance of the <see cref="Main" /> class.
        /// </summary>
        /// <param name="contextFactory">A factory for creating contexts with the fkvaccination database.</param>
        /// <param name="session">The current application session.</param>
        /// <param name="serviceProvider">Provides a mechanism for retrieving service objects.</param>
        public Main(
            IDbContextFactory<FkVaccinationContext> contextFactory,
            ISession session,
            IServiceProvider serviceProvider)
        {
            this.contextFactory = contextFactory;
            this.serviceProvider = serviceProvider;
            this.session = session;

            this.InitializeComponent();

            this.datePicker = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Width = 100,
                Value = this.session.OperationDate
            };

            this.datePicker.ValueChanged += this.DatePicker_ValueChanged;

            this.statusStrip.Items.Insert(1, new ToolStripControlHost(datePicker));
        }

        /// <summary>
        /// Handles the Load event of this form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Main_Load(object sender, EventArgs e)
        {
            await this.RefreshDataGridViewsAsync();
        }

        /// <summary>
        /// Handles the ValueChanged event of datePicker.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            this.session.OperationDate = this.datePicker.Value;
            await this.RefreshDataGridViewsAsync();
        }

        /// <summary>
        /// Handles the MouseDown event of dgvVaccinationSlots.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void DgvVaccinationSlots_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            var dgv = sender as DataGridView;
            var hitTest = dgv.HitTest(e.X, e.Y);

            if (hitTest.RowIndex >= 0)
            {
                // Enable item edit menu items
                this.tsmiVacSlotsEdit.Enabled = true;
                this.tsmiVacSlotsDelete.Enabled = true;

                // Select hit cell if not already
                if (!dgv.Rows[hitTest.RowIndex].Selected)
                {
                    dgv.ClearSelection();
                    dgv.Rows[hitTest.RowIndex].Selected = true;
                }
            }
            else
            {
                dgv.ClearSelection();

                // Disable item edit menu items
                this.tsmiVacSlotsEdit.Enabled = false;
                this.tsmiVacSlotsDelete.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of dgvVaccinationSlots.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DgvVaccinationSlots_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvVaccinationSlots.SelectedRows.Count < 1 ||
                this.dgvVaccinationSlots.SelectedRows[0].Cells["SlotStart"].Value is not DateTime slotStart)
            {
                return;
            }

            this.dgvVaccinees.DataSource = this.vaccinees
                .Where(v => v.SlotStart == slotStart)
                .OrderBy(v => v.Num)
                .ToList();

            this.tboSearch.Text = String.Empty;
        }

        /// <summary>
        /// Handles the CellValueChanged event of dgvVaccinees.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private async void DgvVaccinees_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var rowData = this.dgvVaccinees.Rows[e.RowIndex];

            if (rowData.Cells["SlotStart"].Value is not DateTime slotStart ||
                rowData.Cells["Num"].Value is not int num)
            {
                MessageBox.Show(MSG_ENTITY_INVALID);
                return;
            }

            var modifiedItem = this.vaccinees.FirstOrDefault(v =>
                v.SlotStart == slotStart &&
                v.Num == num);

            try
            {
                using var context = this.contextFactory.CreateDbContext();

                // Get entity
                var entity = await context.Vaccinees.FirstOrDefaultAsync(v => 
                    v.SlotStart == slotStart &&
                    v.Num == num);

                if (entity == null)
                {
                    MessageBox.Show(MSG_ENTITY_NOT_FOUND);
                    return;
                }

                switch (this.dgvVaccinees.Columns[e.ColumnIndex].Name)
                {
                    case "Surname":
                        entity.Surname = modifiedItem.Surname;
                        break;
                    case "GivenName":
                        entity.GivenName = modifiedItem.GivenName;
                        break;
                    case "BirthDate":
                        entity.BirthDate = modifiedItem.BirthDate;
                        break;
                    case "Unit":
                        entity.Unit = modifiedItem.Unit;
                        break;
                    case "HasVacCard":
                        entity.HasVacCard = modifiedItem.HasVacCard;
                        break;
                    case "HasThwIdCard":
                        entity.HasThwIdCard = modifiedItem.HasThwIdCard;
                        break;
                    case "HasCompleteDocs":
                        entity.HasCompleteDocs = modifiedItem.HasCompleteDocs;
                        break;
                    default:
                        MessageBox.Show(MSG_ENTITY_INVALID);
                        return;
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the DataBindingComplete event of dgvVaccinees.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewBindingCompleteEventArgs"/> instance containing the event data.</param>
        private void DgvVaccinees_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        /// <summary>
        /// Handles the DataError event of dgvVaccinees.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
        private void DgvVaccinees_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (this.dgvVaccinees.Columns[e.ColumnIndex].Name == "BirthDate")
            {
                MessageBox.Show("Das eingegebene Geburtsdatum hat ein ungültiges Format.");
                return;
            }
            else
            {
                MessageBox.Show(e.Exception.Message);
            }
        }

        /// <summary>
        /// Asynchronously updates all datagridviews with the data layer.
        /// </summary>
        /// <returns>Returns a task object representing the asynchronous operation.</returns>
        private async Task RefreshDataGridViewsAsync()
        {
            try
            {
                using var context = this.contextFactory.CreateDbContext();

                // Vaccination Slots

                // Save currently selected vaccination slot
                DateTime? selectedVacSlot = null;

                if (this.dgvVaccinationSlots.SelectedRows.Count > 0)
                {
                    selectedVacSlot = (DateTime)this.dgvVaccinationSlots.SelectedRows[0].Cells["SlotStart"].Value;
                }

                this.dgvVaccinationSlots.DataSource = await context.VaccinationSlots
                    .Where(vs => vs.OperationDate == this.session.OperationDate)
                    .Select(vs => new
                    {
                        vs.SlotStart,
                        SlotEnd = vs.SlotStart.AddMinutes(vs.SlotLength),
                        vs.MaxVaccinees,
                        ActVaccinees = 0
                    })
                    .ToListAsync();

                this.dgvVaccinationSlots.Columns["SlotStart"].HeaderText = "Start";
                this.dgvVaccinationSlots.Columns["SlotStart"].DefaultCellStyle.Format = "HH:mm";
                this.dgvVaccinationSlots.Columns["SlotStart"].Width = 50;
                this.dgvVaccinationSlots.Columns["SlotEnd"].HeaderText = "Ende";
                this.dgvVaccinationSlots.Columns["SlotEnd"].DefaultCellStyle.Format = "HH:mm";
                this.dgvVaccinationSlots.Columns["SlotEnd"].Width = 50;
                this.dgvVaccinationSlots.Columns["MaxVaccinees"].HeaderText = "geplant";
                this.dgvVaccinationSlots.Columns["MaxVaccinees"].Width = 50;
                this.dgvVaccinationSlots.Columns["ActVaccinees"].HeaderText = "erfasst";
                this.dgvVaccinationSlots.Columns["ActVaccinees"].Width = 50;
                this.dgvVaccinationSlots.Columns["ActVaccinees"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Re-select the last vaccination slot
                if (this.dgvVaccinationSlots.Rows.Count > 0)
                {
                    if (selectedVacSlot.HasValue)
                    {
                        foreach (DataGridViewRow row in this.dgvVaccinationSlots.Rows)
                        {
                            if (row.Cells["SlotStart"].Value is DateTime slotStart &&
                                slotStart == selectedVacSlot)
                            {
                                row.Selected = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        this.dgvVaccinationSlots.Rows[0].Selected = true;
                    }

                    selectedVacSlot = (DateTime)this.dgvVaccinationSlots.SelectedRows[0].Cells["SlotStart"].Value;
                }

                // Vaccinees
                this.vaccinees = await context.Vaccinees
                    .Where(vac => vac.OperationDate == this.session.OperationDate)
                    .Select(vac => vac)
                    .ToListAsync();

                this.dgvVaccinees.CellValueChanged -= this.DgvVaccinees_CellValueChanged;

                if (selectedVacSlot.HasValue)
                {
                    this.dgvVaccinees.DataSource = this.vaccinees
                        .Where(v => v.SlotStart == selectedVacSlot.Value)
                        .OrderBy(v => v.SlotStart)
                        .ThenBy(v => v.Num)
                        .ToList();
                }
                else
                {
                    this.dgvVaccinees.DataSource = this.vaccinees;
                }

                this.dgvVaccinees.Columns["SlotStart"].HeaderText = "Slot Start";
                this.dgvVaccinees.Columns["SlotStart"].DefaultCellStyle.Format = "HH:mm";
                this.dgvVaccinees.Columns["SlotStart"].DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                this.dgvVaccinees.Columns["SlotStart"].Width = 50;
                this.dgvVaccinees.Columns["SlotStart"].ReadOnly = true;
                this.dgvVaccinees.Columns["Num"].HeaderText = "lfd #";
                this.dgvVaccinees.Columns["Num"].Width = 40;
                this.dgvVaccinees.Columns["Num"].DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                this.dgvVaccinees.Columns["Num"].ReadOnly = true;
                this.dgvVaccinees.Columns["Num"].ReadOnly = true;
                this.dgvVaccinees.Columns["OperationDate"].Visible = false;
                this.dgvVaccinees.Columns["Surname"].HeaderText = "Nachname";
                this.dgvVaccinees.Columns["Surname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvVaccinees.Columns["GivenName"].HeaderText = "Vorname";
                this.dgvVaccinees.Columns["GivenName"].Width = 150;
                this.dgvVaccinees.Columns["BirthDate"].HeaderText = "Geburtsdatum";
                this.dgvVaccinees.Columns["BirthDate"].DefaultCellStyle.Format = "dd.MM.yy";
                this.dgvVaccinees.Columns["Unit"].HeaderText = "Ortsverband";
                this.dgvVaccinees.Columns["Unit"].Width = 150;
                this.dgvVaccinees.Columns["HasVacCard"].HeaderText = "Impfausweis";
                this.dgvVaccinees.Columns["HasThwIdCard"].HeaderText = "THW Ausweis";
                this.dgvVaccinees.Columns["HasCompleteDocs"].HeaderText = "Dokumente vollständig";

                this.tboSearch.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.dgvVaccinees.CellValueChanged += this.DgvVaccinees_CellValueChanged;
            }
        }

        /// <summary>
        /// Handles the Click event of tsbToolsRefresh.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void TsbToolsRefresh_Click(object sender, EventArgs e)
        {
            await this.RefreshDataGridViewsAsync();
        }

        /// <summary>
        /// Handles the Click event of tsmiVacSlotsNew.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void TsmiVacSlotsNew_Click(object sender, EventArgs e)
        {
            // Open create dialog
            using var dialog = this.serviceProvider.GetService<EditVaccinationSlot>();
            dialog.LoadItem(new VaccinationSlot
            {
                OperationDate = this.session.OperationDate,
                SlotStart = this.session.OperationDate.AddHours(DateTime.Today.Hour).AddMinutes(DateTime.Today.Minute),
                SlotLength = this.session.DefaultSlotLength,
                MaxVaccinees = session.DefaultVaccineesPerSlot
            });
            dialog.Text = "Impfslot erstellen";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                using var context = this.contextFactory.CreateDbContext();

                await context.VaccinationSlots.AddAsync(new VaccinationSlot
                {
                    OperationDate = this.session.OperationDate,
                    SlotStart = dialog.SlotStart,
                    SlotLength = dialog.SlotLength,
                    MaxVaccinees = dialog.MaxVaccinees
                });

                if (await context.SaveChangesAsync() > 0)
                {
                    await this.RefreshDataGridViewsAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Enter event of tboSearch.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TboSearch_Enter(object sender, EventArgs e)
        {
            this.tboSearch.Text = String.Empty;
        }

        /// <summary>
        /// Handles the TextChanged event of tboSearch.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TboSearch_TextChanged(object sender, EventArgs e)
        {
            var searchText = this.tboSearch.Text.ToLower();

            this.dgvVaccinees.DataSource = this.vaccinees
                .Where(v =>
                    (v.Surname != null && v.Surname.ToLower().Contains(searchText)) ||
                    (v.GivenName != null && v.GivenName.ToLower().Contains(searchText)) ||
                    (v.BirthDate?.ToString("dd.MM.yy") ?? String.Empty).Contains(searchText) ||
                    (v.Unit != null && v.Unit.ToLower().Contains(searchText)))
                .OrderBy(v => v.SlotStart)
                .ThenBy(v => v.Num)
                .ToList();

            if (!String.IsNullOrEmpty(searchText))
            {
                this.dgvVaccinationSlots.ClearSelection();
            }
        }

        /// <summary>
        /// Handles the Click event of tsmiVacSlotsEdit.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void TsmiVacSlotsEdit_Click(object sender, EventArgs e)
        {
            // Get selected item
            if (this.dgvVaccinationSlots.SelectedRows[0].Cells["SlotStart"].Value is not DateTime initialSlotStart ||
                this.dgvVaccinationSlots.SelectedRows[0].Cells["MaxVaccinees"].Value is not int initialSlotLength)
            {
                MessageBox.Show(MSG_NO_ENTRY_SELECTED);
                return;
            }

            try
            {
                using var context = this.contextFactory.CreateDbContext();

                // Get entity
                var entity = await context.VaccinationSlots
                    .FirstOrDefaultAsync(vs => vs.SlotStart == initialSlotStart);

                if (entity is null)
                {
                    MessageBox.Show(MSG_ENTITY_NOT_FOUND);
                    return;
                }

                // Open edit dialog
                using var dialog = this.serviceProvider.GetService<EditVaccinationSlot>();
                dialog.LoadItem(entity);

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // Update entity in data layer
                context.VaccinationSlots.Remove(entity);
                await context.VaccinationSlots.AddAsync(new VaccinationSlot
                {
                    OperationDate = this.session.OperationDate,
                    SlotStart = dialog.SlotStart,
                    SlotLength = dialog.SlotLength,
                    MaxVaccinees = dialog.MaxVaccinees
                });

                //if (dialog.SlotLength != initialSlotLength ||
                //    dialog.SlotStart != initialSlotStart)
                //{
                //    var vaccinees = await context.Vaccinees
                //        .Where(v => v.SlotStart == )
                //}

                if (await context.SaveChangesAsync() > 0)
                {
                    await this.RefreshDataGridViewsAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        /// Handles the Click event of tsmiVacSlotsDelete.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void TsmiVacSlotsDelete_Click(object sender, EventArgs e)
        {
            // Get selected item
            if (this.dgvVaccinationSlots.SelectedRows[0].Cells["SlotStart"].Value is not DateTime slotStart)
            {
                MessageBox.Show(MSG_NO_ENTRY_SELECTED);
                return;
            }

            try
            {
                using var context = this.contextFactory.CreateDbContext();

                // Get entity
                var entity = await context.VaccinationSlots
                    .FirstOrDefaultAsync(vs => vs.SlotStart == slotStart);

                if (entity is null)
                {
                    MessageBox.Show(MSG_ENTITY_NOT_FOUND);
                    return;
                }

                // Remove entity from data layer
                context.VaccinationSlots.Remove(entity);

                if (await context.SaveChangesAsync() > 0)
                {
                    await this.RefreshDataGridViewsAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void TssiAbout_ButtonClick(object sender, EventArgs e)
        {
            using var dialog = new About();
            dialog.ShowDialog();
        }
    }
}