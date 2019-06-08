using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MyScriptureJournal2.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournal2Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournal2Context>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Cannon = "Old Testament",
                        Accessed = DateTime.Parse("2019-1-1"),
                        Book = "Proverbs",
                        Chapter = 31,
                        Verse = 10,
                        Notes = "A very good scripture"
                    },

                    new Scripture
                    {
                        Cannon = "New Testament",
                        Accessed = DateTime.Parse("2019-2-1"),
                        Book = "Matthew",
                        Chapter = 25,
                        Verse = 40,
                        Notes = " We need to serve our fellow men. "
                    },

                    new Scripture
                    {
                        Cannon = "Book of Mormon",
                        Accessed = DateTime.Parse("2019-3-1"),
                        Book = "Alma",
                        Chapter = 37,
                        Verse = 35,
                        Notes = "Learn while we are young"
                    },

                  new Scripture
                  {
                      Cannon = "Doctrine and Covenants",
                      Accessed = DateTime.Parse("2019-4-1"),
                      Book = "N/A",
                      Chapter = 137,
                      Verse = 9,
                      Notes = "Judge by works"
                  },
                  new Scripture
                  {
                      Cannon = "Pearl Of Great Price",
                      Accessed = DateTime.Parse("2019-5-1"),
                      Book = "Articles of Faith",
                      Chapter = 1,
                      Verse = 13,
                      Notes = "We believe"
                  }
                );
                context.SaveChanges();
            }
        }
    }
}