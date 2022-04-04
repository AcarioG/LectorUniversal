using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace LectorUniversal.Server.Helpers
{
    public class FileUpload : IFileUpload
    {
        private readonly IConfiguration _configuration;
        private readonly BlobServiceClient _blobServiceClient;
        public FileUpload(IConfiguration Configuration, BlobServiceClient blobServiceClient)
        {
            _configuration = Configuration;
            _blobServiceClient = blobServiceClient;
        }

        public async Task DeleteFile(string Folder, string ImgUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditFile(byte[] content, string extention, string Folder, string ImgUrl)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveFile(byte[] content, string extention, string Folder)
        {
            HttpClient _httpClient = new HttpClient();

            var container = await _httpClient.PostAsJsonAsync("api/Container", Folder);

            container.ToString();
            return "";
            //var account = CloudStorageAccount.Parse(db);
            //var Client = account.CreateCloudBlobClient();
            //var folder = Client.GetContainerReference(Folder);
            //await folder.CreateIfNotExistsAsync();
            //await folder.SetPermissionsAsync(new BlobContainerPermissions
            //{
            //    PublicAccess = BlobContainerPublicAccessType.Blob
            //});


            //var FileName = $"{Guid.NewGuid()}.{extention}";
            //var blob = await containerClient.UploadBlobAsync(FileName, new MemoryStream(content));
            //return blob.Value
            //var blob = folder.GetBlockBlobReference(FileName);
            //await blob.UploadFromByteArrayAsync(content, 0, content.Length);c
            //return blob.Uri.ToString();
        }

    }
}
