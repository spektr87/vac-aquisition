namespace Impferfassung.Models
{
    using System;

    public class Vaccinee
    {
        public DateTime SlotStart { get; set; }
        public int Num { get; set; }
        public DateTime OperationDate { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Unit { get; set; }
        public bool HasVacCard { get; set; }
        public bool HasThwIdCard { get; set; }
        public bool HasCompleteDocs { get; set; }
    }
}