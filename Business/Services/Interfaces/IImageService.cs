namespace Business.Services.Interfaces;
public interface IImageService
{
    void CheckType(IFormFile formFile);
    void CheckSize(IFormFile formFile, int size);
    Task<string> CreateFileAsync(string Folderpath,IFormFile formFile);
}
