namespace TurboAzClone.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin,SuperAdmin")]
public class SettingsController : Controller
{
    private readonly ISettingService _settingService;
    private readonly SettingUpdateDtoValidation _settingValidation;
    public SettingsController(ISettingService settingService, SettingUpdateDtoValidation settingValidation)
    {
        _settingService = settingService;
        _settingValidation = settingValidation;
    }

    public IActionResult Index()
        => View(_settingService.Get());

    public IActionResult Update()
        => View(_settingService.GetUpdate());
    [HttpPost]
    public async Task<IActionResult> Update(SettingUpdateDto updateDto)
    {
        var result = await _settingValidation.ValidateAsync(updateDto);
        if (result.IsValid)
        {
            await _settingService.UpdateAsync(updateDto);
            return RedirectToAction("index", "settings");
        }
        return View();
    }
}