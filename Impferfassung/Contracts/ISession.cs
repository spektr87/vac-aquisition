namespace Impferfassung.Contracts
{
    using System;

    /// <summary>
    /// Application session properties.
    /// </summary>
    public interface ISession
    {
        /// <summary>
        /// Gets or sets the date of operation.
        /// </summary>
        DateTime OperationDate { get; set; }

        /// <summary>
        /// Gets or sets the default slot length.
        /// </summary>
        int DefaultSlotLength { get; set; }

        /// <summary>
        /// Gets or sets the default number of vaccinees per slot.
        /// </summary>
        int DefaultVaccineesPerSlot { get; set; }
    }
}