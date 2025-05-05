using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services
{
    public interface IDevicesService
    {
        public IEnumerable<SelectListItem> GetDevicesList();
    }
}
