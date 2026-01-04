using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GearTalk.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        //API Controller dosnt expect a view to be returned. the responses will be http responses som 404 , 200 osv


    }
}
