using GearTalk.Web.Data;
using GearTalk.Web.Models.Domain;
using GearTalk.Web.Models.ViewModel;
using GearTalk.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GearTalk.Web.Controllers
{
    public class AdminCarCategoriesController : Controller
    {
        private readonly ICarCategory carCtegoryRepository;
        public AdminCarCategoriesController(ICarCategory carCtegoryRepository)
        {
            this.carCtegoryRepository = carCtegoryRepository;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddCarCategoryRequest request)
        {
            //nå vi må kalle riktig methode i repo.
            var cateory = new CarCategory
            {
                Name = request.Name,
                DisplayName = request.DisplayName,
            };

            await carCtegoryRepository.AddAsync(cateory);
            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var carCategories = await carCtegoryRepository.GetAllAsync();
            return View(carCategories);
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit(Guid Id)
        {
            //finner obj fra db 
            var category = await carCtegoryRepository.GetByIdAsync(Id);
            //hvois vi har obj so mapper vi fra domainModel to modelView
            if (category != null)
            {
                var editCarCategoryRequest = new EditCarCategoryRequest
                {
                    Id = category.Id,
                    Name = category.Name,
                    DisplayName = category.DisplayName
                };
                //so sender vi objektet til viewt som er en form med editable innhold
                return View(editCarCategoryRequest);
            }

            return View(null);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarCategoryRequest editCarCategoryRequest)
        {
            var carCategoryDomain = new CarCategory
            {
                Id = editCarCategoryRequest.Id,
                Name = editCarCategoryRequest.Name,
                DisplayName = editCarCategoryRequest.DisplayName
            };
            var updatedCategory = await carCtegoryRepository.UpdateAsync(carCategoryDomain);

            return RedirectToAction("List");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await carCtegoryRepository.DeleteAsync(id);
                return RedirectToAction(nameof(List));
            }
            catch (KeyNotFoundException)
            {
                TempData["Error"] = "Kategorien finnes ikke lenger.";
                return RedirectToAction(nameof(List));
            }
        }


    }
}

