namespace GearTalk.Web.Models
{
    public class CarReviewLike
    {

        public Guid Id { get; set; }    
        public Guid CarReviewId { get; set; }
        public Guid UserId { get; set; }

    }
}
