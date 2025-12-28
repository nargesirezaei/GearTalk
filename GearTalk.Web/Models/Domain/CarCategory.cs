namespace GearTalk.Web.Models.Domain
{
    public class CarCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public ICollection<CarReview> CarReviews { get; set; }
    }
}
