namespace Impferfassung
{
    using Impferfassung.Models;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Form for editing vaccination slots.
    /// </summary>
    public partial class EditVaccinationSlot : Form
    {
        /// <summary>
        /// The slot length in minutes.
        /// </summary>
        private int slotLength;

        /// <summary>
        /// The planned number of vaccinees.
        /// </summary>
        private int maxVaccinees;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditVaccinationSlot" /> class.
        /// </summary>
        public EditVaccinationSlot()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets whether changes were made to the edited vaccination slot item.
        /// </summary>
        public bool HasChanges { get; private set; }

        /// <summary>
        /// Gets the slot start time.
        /// </summary>
        public DateTime SlotStart => this.dtpStartTime.Value;

        /// <summary>
        /// Gets the slot length in minutes.
        /// </summary>
        public int SlotLength
        {
            get => this.slotLength;
            private set
            {
                if (this.slotLength == value)
                {
                    return;
                }

                this.slotLength = value;
                this.nudDuration.Value = value;
                this.UpdateSlotEndTime();
                this.HasChanges = true;
            }
        }

        /// <summary>
        /// Gets the planned number of vaccinees.
        /// </summary>
        public int MaxVaccinees
        {
            get => this.maxVaccinees;
            private set
            {
                if (this.maxVaccinees == value)
                {
                    return;
                }

                this.maxVaccinees = value;
                this.nudPlannedVaccinees.Value = value;
                this.HasChanges = true;
            }
        }

        /// <summary>
        /// Loads a <see cref="VaccinationSlot"/> item for editing.
        /// </summary>
        /// <param name="item">The item.</param>
        public void LoadItem(VaccinationSlot item)
        {
            this.dtpStartTime.Value = item.SlotStart;
            this.SlotLength = item.SlotLength;
            this.MaxVaccinees = item.MaxVaccinees;
            this.HasChanges = false;
        }

        /// <summary>
        /// Handles the Click event of btnOK.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the ValueChanged event of dtpStartTime.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateSlotEndTime();
            this.HasChanges = true;
        }

        /// <summary>
        /// Handles the ValueChanged event of nudDuration.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void NudDuration_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateSlotEndTime();
        }

        /// <summary>
        /// Handles the ValueChanged event of nudPlannedVaccinees.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void NudPlannedVaccinees_ValueChanged(object sender, EventArgs e)
        {
            this.MaxVaccinees = Convert.ToInt32(this.nudPlannedVaccinees.Value);
        }

        /// <summary>
        /// Adjusts the end time datetimepicker value according to selected start time and duration.
        /// </summary>
        private void UpdateSlotEndTime()
        {
            this.dtpEndTime.Value = this.dtpStartTime.Value.AddMinutes(Convert.ToInt32(this.nudDuration.Value));
        }
    }
}