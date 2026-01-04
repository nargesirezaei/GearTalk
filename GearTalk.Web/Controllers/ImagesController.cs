using GearTalk.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
//API Controller dosnt expect a view to be returned. the responses will be http responses som 404 ,200 osv


namespace GearTalk.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

       public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
         

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            //Call a repository
            var url = await imageRepository.UploadAsync(file);

            if(url == null)
            {
                return Problem("Somthing went wrong!", null, (int)HttpStatusCode.InternalServerError);

            }
            return new JsonResult(new { link = url });
        }
    }
}
