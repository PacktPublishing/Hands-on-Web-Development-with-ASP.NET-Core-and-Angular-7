using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DVDMovie.Models;

namespace DVDMovie {

    public class SeedData {

        public static void SeedDatabase(DataContext context) {
            if (context.Database.GetMigrations().Count() > 0
                    && context.Database.GetPendingMigrations().Count() == 0
                    && context.Movies.Count() == 0) {
                var s1 = new Studio {
                    Name = "Moonlight Entertainment",
                    City = "San Jose", State = "CA"
                };
                var s2 = new Studio {
                    Name = "Paramount",
                    City = "Chicago", State = "IL"
                };
                var s3 = new Studio {
                    Name = "MGM",
                    City = "New York", State = "NY"
                };

                context.Movies.AddRange(
                    new Movie {
                        Image = "bit.ly/2CL6JsO",
                        Name = "Titanic",
                        Description = "A 17-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.",
                        Category = "Drama", Price = 75, Studio = s1,
                        Ratings = new List<Rating> {
                            new Rating { Stars = 4 }, new Rating { Stars = 3 }}
                    },
                    new Movie {
                        Image = "bit.ly/2CLuDnP",
                        Name = "The Godfather",
                        Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son",
                        Category = "Drama", Price = 48.95m, Studio = s1,
                        Ratings = new List<Rating> {
                            new Rating { Stars = 2 }, new Rating { Stars = 5 }}
                    },
                    new Movie {
                        Image = "bit.ly/2CM080Y",
                        Name = "Team America",
                        Description = "Broadway actor Gary Johnston is recruited by the elite counter-terrorism organization",
                        Category = "Comedy", Price = 19.50m, Studio = s2,
                        Ratings = new List<Rating> {
                            new Rating { Stars = 1 }, new Rating { Stars = 3 }}
                    },
                    new Movie {
                        Image = "bit.ly/2CNWtjd",
                        Name = "Wedding Crashers",
                        Description = "Committed womanizers sneak into weddings to take advantage of the romantic tinge in the air",
                        Category = "Comedy", Price = 34.95m, Studio = s2,
                        Ratings = new List<Rating> { new Rating { Stars = 3 } }
                    },
                    new Movie {
                        Image = "bit.ly/2CJrZix",
                        Name = "Superbad",
                        Description = "Two co-dependent high school seniors are forced to deal with separation anxiety after their plan to stage a booze-soaked party goes awry",
                        Category = "Comedy", Price = 70, Studio = s2,
                        Ratings = new List<Rating> { new Rating { Stars = 1 },
                            new Rating { Stars = 4 }, new Rating { Stars = 3 }}
                    },
                    new Movie {
                        Image = "bit.ly/2CLVMag",
                        Name = "Bridget Jones's Diary",
                        Description = "A British woman is determined to improve herself while she looks for love in a year in which she keeps a personal diary.",
                        Category = "Romance", Price = 16, Studio = s3,
                        Ratings = new List<Rating> { new Rating { Stars = 5 },
                            new Rating { Stars = 4 }}
                    },
                    new Movie {
                        Image = "bit.ly/2CLuLDP",
                        Name = "Love Actually",
                        Description = "Eight very different couples deal with their love lives",
                        Category = "Romance", Price = 29.95m, Studio = s3,
                        Ratings = new List<Rating> { new Rating { Stars = 3 } }
                    },
                    new Movie {
                        Image = "bit.ly/2CLuO2t",
                        Name = "The Way We Were",
                        Description = "Two desperate people have a wonderful romance, but their political views and convictions drive them apart.",
                        Category = "Romance", Price = 75, Studio = s3
                    },
                    new Movie {
                        Image = "bit.ly/2CMG4vx",
                        Name = "Ghost",
                        Description = "After a young man is murdered, his spirit stays behind to warn his lover of impending danger, with the help of a reluctant psychic.",
                        Category = "Romance", Price = 10, Studio = s3
                    });
                context.SaveChanges();
            }
        }
    }
}