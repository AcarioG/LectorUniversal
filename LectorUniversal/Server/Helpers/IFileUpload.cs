namespace LectorUniversal.Server.Helpers
{
    public interface IFileUpload
    {
        Task<string> EditFile(byte[] content, string extention, string actualFolder, string newFolder, string ImgUrl, string Type);
        Task DeleteFile(string Folder, string Type, string ImgUrl);
        Task<string> SaveFile(byte[] content, string extention, string Type, string Folder);


    }
}
