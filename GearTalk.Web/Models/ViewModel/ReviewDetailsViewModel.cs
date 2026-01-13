using GearTalk.Web.Models.Domain;

namespace GearTalk.Web.Models.ViewModel
{
    public class ReviewDetailsViewModel
    {
        public Guid Id { get; set; }
        public string ModelName { get; set; }
        public string ShortDescription { get; set; }
        public string YouTubeVideoUrl { get; set; }
        public string Content { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }

        //FK 
        public Guid CarCategoryId { get; set; }

        //navigation one to meny
        public CarCategory category { get; set; }

        public int TotalLikes { get; set; }
        public bool Liked { get; set; }
    }
}
