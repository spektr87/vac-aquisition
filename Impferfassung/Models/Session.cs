namespace Impferfassung.Models
{
    using System;
    using Impferfassung.Contracts;

    /// <summary>
    /// Application session properties.
    /// </summary>
    internal class Session : ISession
    {
        /// <summary>
        /// Gets or sets the date of operation.
        /// </summary>
        public DateTime OperationDate { get; set; }

        /// <summary>
        /// Gets or sets the default slot length.
        /// </summary>
        public int DefaultSlotLength { get; set; }

        /// <summary>
        /// Gets or sets the default number of vaccinees per slot.
        /// </summary>
        public int DefaultVaccineesPerSlot { get; set; }
    }
}