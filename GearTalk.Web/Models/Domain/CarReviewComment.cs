namespace GearTalk.Web.Models
{
    public class CarReviewComment
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public Guid CarReviewId { get; set; }
        public DateTime DateAdded {  get; set; }
    }
}
