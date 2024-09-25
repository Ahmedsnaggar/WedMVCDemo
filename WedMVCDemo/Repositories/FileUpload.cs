using WedMVCDemo.Interfaces;

namespace WedMVCDemo.Repositories
{
    public class FileUpload : IFileUpload
    {
        private IWebHostEnvironment _env;

        public FileUpload(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> UploadFileAsync(string filePath, IFormFile file)
        {
            string uploderFolder = _env.WebRootPath + filePath;
            if (!Directory.Exists(uploderFolder))
            {
                Directory.CreateDirectory(uploderFolder);
            }
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string fullImagePath = Path.Combine(uploderFolder, uniqueFileName);

            using (var stream = new FileStream(fullImagePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                stream.Dispose();
            }
            return Path.Combine(filePath, uniqueFileName);
        }
    }
}
