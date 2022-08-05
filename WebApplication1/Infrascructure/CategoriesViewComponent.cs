﻿using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Infrascructure;
using WebApplication1.Models;

namespace CmsShoppingCart.Infrastructure
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly CmsShoppingCartContext context;

        public CategoriesViewComponent(CmsShoppingCartContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await GetCategoriesAsync();
            return View(categories);
        }

        private Task<List<Category>> GetCategoriesAsync()
        {
            return context.Categories.OrderBy(x => x.Sorting).ToListAsync();
        }
    }
}
