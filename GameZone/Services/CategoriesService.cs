﻿using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly AppDbContext _context;
        public CategoriesService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetCategoryList()
        {
           return _context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
            .OrderBy(c => c.Text)
            .AsNoTracking()
            .ToList();
             
        }
    }
}
