using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Infrascructure;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly CmsShoppingCartContext context;

        public CategoriesController(CmsShoppingCartContext context)
        {
            this.context = context;
        }

        //GET /ADMIN/categories/
        public async Task<IActionResult> Index()
        {
            return View(await context.Categories.OrderBy(x => x.Sorting).ToListAsync());
        }

        //GET /ADMIN/categories/create
        public IActionResult Create() => View();

        //POST /ADMIN/categories/create/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.Slug = category.Name.ToLower().Replace(" ", "-");
                category.Sorting = 100;

                var slug = await context.Categories.FirstOrDefaultAsync(x => x.Slug == category.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The category already exists.");
                    return View(category);
                }

                context.Add(category);
                await context.SaveChangesAsync();

                TempData["Success"] = "The category has been added!";

                return RedirectToAction("Index");
            }

            return View(category);
        }

        //GET /ADMIN/PAGES/edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Category category = await context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        //POST /ADMIN/Categories/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                category.Slug = category.Name.ToLower().Replace(" ", "-");

                var slug = await context.Categories.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.Slug == category.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The category already exists.");
                    return View(category);
                }

                context.Update(category);
                await context.SaveChangesAsync();

                TempData["Success"] = "The category has been edited!";

                return RedirectToAction("Edit", new { id });
            }

            return View(category);
        }

        //GET /ADMIN/Categories/delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Category category = await context.Categories.FindAsync(id);
            if (category == null)
            {
                TempData["Error"] = "The category does not exist!";
            }
            else
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                TempData["Success"] = "The category has been deleted!";
            }

            return RedirectToAction("Index");

        }


        //POST /ADMIN/Categories/reorder
        [HttpPost]
        public async Task<IActionResult> Reorder(int[] id)
        {
            int count = 1;

            foreach (var categoriesId in id)
            {
                Category category = await context.Categories.FindAsync(categoriesId);
                category.Sorting = count;
                context.Update(category);
                await context.SaveChangesAsync();
                count++;
            }

            return Ok();
        }

    }
}
