using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApplication1.Infrascructure;

namespace WebApplication1.Models
{
    public class SeedData
    {
        public static void Initalize(IServiceProvider serviceProvider)
        {
            using (var context = new CmsShoppingCartContext
                (serviceProvider.GetRequiredService<DbContextOptions<CmsShoppingCartContext>>()))
            {
                if (context.Pages.Any())
                {
                    return;
                }
                else 
                {
                    context.Pages.AddRange(
                        new Page
                        {
                            Title = "Home",
                            Slug = "home",
                            Content = "home page",
                            Sorting = 0
                        },
                        new Page
                        {
                             Title = "About us",
                             Slug = "about-us",
                             Content = "about us",
                             Sorting = 100
                        },
                        new Page
                        {
                             Title = "Services",
                             Slug = "services",
                             Content = "services",
                             Sorting = 100
                        },
                        new Page
                        {
                              Title = "Contact",
                              Slug = "contact",
                              Content = "contact",
                              Sorting = 100
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
