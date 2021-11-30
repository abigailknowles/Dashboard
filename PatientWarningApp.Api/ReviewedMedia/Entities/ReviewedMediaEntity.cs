namespace PatientWarningApp.Api.ReviewedMedia.Entities
{
    public class ReviewedMediaEntity
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public string EpilepsyRating { get; set; }
        public string SeizureTriggerTimes { get; set; }
        public string Notes { get; set; }

    }
}
