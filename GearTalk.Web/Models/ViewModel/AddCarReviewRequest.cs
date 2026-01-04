using GearTalk.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GearTalk.Web.Models.ViewModel
{
    public class AddCarReviewRequest
    {
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


        //SelectListItem er en innebygd klasse i ASP.NET Core MVC som brukes for <select>-elementer.
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        

    }
}
