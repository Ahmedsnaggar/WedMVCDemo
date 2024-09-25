namespace WedMVCDemo.Interfaces
{
    public interface IFileUpload
    {
        Task<string> UploadFileAsync(string filePath, IFormFile file);
    }
}
