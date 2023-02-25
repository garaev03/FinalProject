namespace Business.Services.Implementations;
public class ImageService : IImageService
{
    private readonly IWebHostEnvironment _env;
    public ImageService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public void CheckSize(IFormFile formFile, int size)
    {
        if (formFile.Length / 1024 / 1024 > 2) throw new ImageException($"Şəklin ölçüsü {size} MB-dan çox olmamalıdır.");
    }
    public void CheckType(IFormFile formFile)
    {
        if (!formFile.ContentType.Contains("image")) throw new ImageException("Ancaq şəkil daxil edilə bilər.");
    }
    public async Task<string> CreateFileAsync(string Folderpath, IFormFile formFile)
    {
        string ImageName = Guid.NewGuid() + "-" + formFile.FileName;
        string Fullpath = _env.WebRootPath + "/assets/images/" + Folderpath + "/" + ImageName;
        using (FileStream stream = new(Fullpath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
        }
        return ImageName;
    }
}