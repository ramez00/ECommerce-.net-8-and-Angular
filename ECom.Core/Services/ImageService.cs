using ECom.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata;

namespace ECom.Core.Services;
public class ImageService : IImageService
{
    public async Task<string> UploadImageAsync(IFormFileCollection file, string folderName)
    {
        if (file is null || file.Count == 0)
            throw new ArgumentException("File is null or empty", nameof(file));

        string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);

        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        string[] paths = [];

        foreach (var f in file)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(f.FileName);
            string filePath = Path.Combine(uploadPath, fileName);
            paths.Append(filePath);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
               await f.CopyToAsync(stream);
            }
        }

        string relativePath = Path.Combine(folderName, string.Join(",", paths.Select(p => Path.GetFileName(p))));
        return relativePath;
    }

    public Task<bool> DeleteImageAsync(string imageUrl)
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imageUrl);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}
