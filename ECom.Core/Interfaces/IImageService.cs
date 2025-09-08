using Microsoft.AspNetCore.Http;

namespace ECom.Core.Interfaces;
public interface IImageService
{
    Task<string> UploadImageAsync(IFormFileCollection file, string imageName);
    Task<bool> DeleteImageAsync(string imageUrl);
}
