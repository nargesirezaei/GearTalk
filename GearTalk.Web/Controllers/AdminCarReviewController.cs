using GearTalk.Web.Models.Domain;
using GearTalk.Web.Models.ViewModel;
using GearTalk.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GearTalk.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCarReviewController : Controller
    {
        private readonly ICarReview carReviewRepository;
        private readonly ICarCategory carCategoryRepository;
        public AdminCarReviewController(ICarReview carReviewRepository, ICarCategory carCategoryRepository)
        {
            this.carReviewRepository = carReviewRepository;
            this.carCategoryRepository = carCategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await carCategoryRepository.GetAllAsync();
            var model = new AddCarReviewRequest
            {
                Categories = categories.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            };
            //var model = new 
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCarReviewRequest model)
        {
            //mapper viewModel to Domainmodel
            var carReview = new CarReview
            {
                Id = Guid.NewGuid(),

                ModelName = model.ModelName,
                Content = model.Content,
                ShortDescription = model.ShortDescription,
                YouTubeVideoUrl = model.YouTubeVideoUrl,
                Author = model.Author,
                FeaturedImageUrl = model.FeaturedImageUrl,
                UrlHandle = model.UrlHandle,

                PublishedDate = model.PublishedDate,
                Visible = model.Visible,

                CarCategoryId = model.SelectedCategoryId
            };
             await carReviewRepository.AddAsync(carReview);
            
           return RedirectToAction("List");
        }


        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var carReviews = (await carReviewRepository.GetAllAsync()).ToList();
            return View(carReviews);
        }

        [HttpGet]
        public async Task<IActionResult> Edit (Guid id)
        {
            //retrieve singel car review fra repo
            var carReview =  await carReviewRepository.GetAsync(id);


            if (carReview == null)
            {
                return NotFound();
            }
            // nå må vi mappe domain til viewmodel før vi sender de ntil view List

            var carCategories = await carCategoryRepository.GetAllAsync();
            var viewModel = new EditCarReviewRequest
            {
                Id = carReview.Id,
                ModelName = carReview.ModelName,
                Content = carReview.Content,
                ShortDescription = carReview.ShortDescription,
                YouTubeVideoUrl = carReview.YouTubeVideoUrl,
                Author = carReview.Author,
                FeaturedImageUrl = carReview.FeaturedImageUrl,
                UrlHandle = carReview.UrlHandle,
                PublishedDate = carReview.PublishedDate,
                Visible = carReview.Visible,                
                SelectedCategoryId = carReview.CarCategoryId,
                Categories = carCategories.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })

            };
            //pass modelen til view
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarReviewRequest editCarReview)
        {
            //mapping to domain
            var carReview = new CarReview
            {
                Id = editCarReview.Id,
                ModelName = editCarReview.ModelName,
                Content = editCarReview.Content,
                ShortDescription = editCarReview.ShortDescription,
                YouTubeVideoUrl= editCarReview.YouTubeVideoUrl, 
                FeaturedImageUrl = editCarReview.FeaturedImageUrl,
                UrlHandle = editCarReview.UrlHandle,
                PublishedDate = editCarReview.PublishedDate,
                Author = editCarReview.Author,
                Visible = editCarReview.Visible,
                CarCategoryId = editCarReview.SelectedCategoryId
            };
            //kaller riktig methode i repo
            var updatedReview = await carReviewRepository.UpdateAsync(carReview);
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await carReviewRepository.DeleteAsync(id);
                return RedirectToAction("List");
            }
            catch (KeyNotFoundException)
            {
                TempData["Error"] = "Car Review finnes ikke lenger!";
                return RedirectToAction("List");
            }
        }

    }
}
