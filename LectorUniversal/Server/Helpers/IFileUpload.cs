﻿namespace LectorUniversal.Server.Helpers
{
    public interface IFileUpload
    {
        Task<string> EditFile(byte[] content, string extention, string Folder, string ImgUrl);
        Task DeleteFile(string Folder, string ImgUrl);
        Task<string> SaveFile(byte[] content, string extention, string Folder);
    }
}
