using GearTalk.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GearTalk.Web.Models.ViewModel
{
    public class EditCarReviewRequest
    {
        public Guid Id { get; set; }
        public string ModelName { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string YouTubeVideoUrl { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }
        public Guid SelectedCategoryId { get; set; }


        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
