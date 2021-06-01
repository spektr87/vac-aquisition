namespace Impferfassung.Models
{
    using System;

    public class VaccinationSlot
    {
        /// <summary>
        /// Gets or sets the date of operation.
        /// </summary>
        public DateTime OperationDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time the slots is planned to begin.
        /// </summary>
        public DateTime SlotStart { get; set; }

        /// <summary>
        /// Gets or sets the length of the slot in minutes.
        /// </summary>
        public int SlotLength { get; set; }

        /// <summary>
        /// Gets or sets the planned maximum number of vaccinees.
        /// </summary>
        public int MaxVaccinees { get; set; }
    }
}