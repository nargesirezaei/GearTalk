
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace GearTalk.Web.Repositories
{
    public class CloudinaryImageRepository : IImageRepository
    {
        //private readonly IConfiguration configuration;
        //private readonly Account account;
        private readonly Cloudinary cloudinary;
        public CloudinaryImageRepository(IConfiguration configuration/*, Account account*/)
        {
            //this.configuration = configuration;
            ////initialized an cloudinary account using ApiKey and secret that stored in appseting 
            //this.account = new Account(configuration.GetSection("Cloudinary")["CloudName"],
            //                      configuration.GetSection("Cloudinary")["ApiKey"],
            //                      configuration.GetSection("Cloudinary")["ApiSecret"]);

            var account = new Account(
            configuration["Cloudinary:CloudName"],
            configuration["Cloudinary:ApiKey"],
            configuration["Cloudinary:ApiSecret"]
        );

            cloudinary = new Cloudinary(account);
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
           // //once we have the client 
           //var client = new Cloudinary(account);
           

            //
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.Name, file.OpenReadStream()),
                DisplayName = file.Name,
            };


            //the client has been initialized over, will call the method UploadAsync and send the 
            //uploadParams and pass the file and displayname as parameter to this method.
            //var uploadResult = await client.UploadAsync(uploadParams);
            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            //finally when the pic are uploaded here we check that result was succesful or not
            if (uploadResult != null && uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {

                //return the url
                return uploadResult.SecureUri.ToString();
            }
            return null;
        }
    }
}
