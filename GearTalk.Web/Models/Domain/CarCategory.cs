namespace GearTalk.Web.Models.Domain
{
    public class CarCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        //Oppslag (lookup), navigation meny to one
        public ICollection<CarReview> CarReviews { get; set; }
    }
}
