using Azure.Storage.Blobs;

namespace LectorUniversal.Server.Helpers
{
    public class FileUpload : IFileUpload
    {
        private readonly string db;
        private string comicContainer = "comics";
        private string mangasContainer = "mangas";
        public FileUpload(IConfiguration configuration)
        {
            db = configuration.GetConnectionString("AzureStorage");
        }

        public async Task DeleteFile(string Folder, string ImgUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditFile(byte[] content, string extention, string Folder, string ImgUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveFile(byte[] content, string extention, string Folder)
        {
            throw new NotImplementedException();
        }
    }
}
