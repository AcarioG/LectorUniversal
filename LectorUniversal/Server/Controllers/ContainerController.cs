using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LectorUniversal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly BlobServiceClient _blobServiceClient;

        public ContainerController(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        [HttpPost]
        public async Task PostAsync([FromBody]string Folder)
        {
            BlobContainerClient blobContainer = _blobServiceClient.GetBlobContainerClient(Folder);

            try
            {
                await blobContainer.CreateIfNotExistsAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
