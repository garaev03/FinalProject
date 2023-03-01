namespace Entities.DTOs.SettingDtos;
public class SettingUpdateDto
{
    public string? TelephoneNumber { get; set; }
    public string? FacebookLink { get; set; }
    public string? InstagramLink { get; set; }
    public string? Email { get; set; }
    public string? FooterLeft { get; set; }
    public string? FooterRight { get; set; }
    public IFormFile? formFile { get; set; }
}