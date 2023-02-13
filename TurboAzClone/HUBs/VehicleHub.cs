using Entities.DTOs.VehicleDtos;
using Microsoft.AspNetCore.SignalR;

namespace TurboAzClone.HUBs
{
    public class VehicleHub:Hub
    {
        public async Task SendVehicleAsync(string user,VehiclePostDto postDto)
        {
            await Clients.Group("Support").SendAsync("ReceiveMessage",postDto);
        }
    }
}
