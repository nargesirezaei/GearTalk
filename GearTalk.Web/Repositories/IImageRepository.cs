namespace GearTalk.Web.Repositories
{
    public interface IImageRepository
    {
        //only upload image
        Task<string> UploadAsync(IFormFile file); 
    }
}
