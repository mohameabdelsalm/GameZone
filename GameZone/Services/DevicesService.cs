﻿using GameZone.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class DevicesService : IDevicesService
    {
        private readonly AppDbContext _context;
        public DevicesService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetDevicesList()
        {
            return _context.Devices.Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                 .OrderBy(x => x.Text)
                 .AsNoTracking()
                 .ToList();
                
        }
    }
}
