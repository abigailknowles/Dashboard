using System;

namespace PatientWarningApp.Data.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string PostCode { get; set; }

    }
}
