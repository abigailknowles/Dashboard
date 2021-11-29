using PatientWarningApp.Data.Entities;
using System;

namespace PatientWarningApp.Services.Models
{
    public class ReviewedMediaModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string EpilepsyRating { get; set; }
        public string Notes { get; set; }
    }
}
