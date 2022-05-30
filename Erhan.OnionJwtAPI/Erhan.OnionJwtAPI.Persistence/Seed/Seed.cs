using Erhan.MovieTicketSystem.Domain;
using Erhan.MovieTicketSystem.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Persistence.Seed
{
    public class Seed
    {
        public static async Task SeedData(TicketDBContext context)
        {
            if (context.Gender.Any() 
                && context.AppRole.Any() 
                //&& context.Hall.Any() 
                //&& context.Chair.Any() 
                //&& context.MovieHall.Any() 
                //&& context.Movie.Any()
                ) return;

            List<Gender> Genders = new List<Gender>
            {
                new Gender { Definition = "Unknown" },
                new Gender { Definition = "Male" },
                new Gender { Definition = "Female" },
                new Gender { Definition = "Other" },
            };
            List<AppRole> AppRoles = new List<AppRole>
            {
                new AppRole{ Definition = "Member" },
                new AppRole{ Definition = "Admin" },
            };
            //Movie Movies = new Movie
            //{
            //    Actors = "nolan",
            //    Description = "güzel bir film",
            //    ImageUrl = "image.jpg",
            //    ReleaseDate = DateTime.Now,
            //    Name = "Interstellar"
            //};
            //List<Hall> Halls = new List<Hall>
            //{
            //    new Hall{Hallname = "Yeşil Salon"},
            //    new Hall{Hallname = "Kırmızı Salon"},
            //    new Hall{Hallname = "Turkuaz Salon"},
            //};
            //MovieHall MovieHalls = new MovieHall
            //{
            //    HallId = 1,
            //    MovieId = 1,
            //    MovieDate = DateTime.Now,
            //};
            //List<Chair> Chairs = new List<Chair>
            //{
            //    new Chair{HallId = 1},
            //    new Chair{HallId = 1},
            //    new Chair{HallId = 1},
            //    new Chair{HallId = 1},
            //    new Chair{HallId = 3},
            //    new Chair{HallId = 3},
            //    new Chair{HallId = 3},
            //    new Chair{HallId = 3},
            //    new Chair{HallId = 3},
            //    new Chair{HallId = 2},
            //    new Chair{HallId = 2},
            //    new Chair{HallId = 2},
            //};

            //await context.Hall.AddRangeAsync(Halls);
            //await context.Chair.AddRangeAsync(Chairs);
            //await context.Movie.AddAsync(Movies);
            //await context.MovieHall.AddAsync(MovieHalls);
            await context.Gender.AddRangeAsync(Genders);
            await context.AppRole.AddRangeAsync(AppRoles);

            await context.SaveChangesAsync();
        }
    }
}
