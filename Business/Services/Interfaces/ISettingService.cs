namespace Business.Services.Interfaces
{
    public interface ISettingService
    {
        SettingGetDto Get();
        SettingUpdateDto GetUpdate();
        Task UpdateAsync(SettingUpdateDto updateDto);
    }
}