using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Database.entities
{
    public class DbInitializer
    {
        public static void Seed (IApplicationBuilder applicationBuilder){
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book()
                            {
                                    Title = "Co gai den tu hom qua",
                                    Description = "Hay",
                                    IsRead = true,
                                    DateRead = DateTime.Now.AddDays(-10),
                                    Rate =  10,
                                    Genre = "Fiction",
                                    CoverUrl = "Http...",
                                    DateAdded = DateTime.Now
                            }
                        ,
                            new Book()
                            {
                                    Title = "Hoa mong ao",
                                    Description = "Hay vs Vui",
                                    IsRead = false,
                                    Genre = "Detective story",
                                    CoverUrl = "Http...",
                                    DateAdded = DateTime.Now
                            }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}