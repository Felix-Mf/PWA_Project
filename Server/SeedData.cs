using PWA_Project.Server.Data;
using PWA_Project.Shared;
using System;
using System.Collections.Generic;

namespace PWA_Project.Server
{
    public class SeedData
    {
        const int NumCourses = 5;
        static Random Random = new Random();

        public static void Initialize(ApplicationDbContext db)
        {
            db.Course.RemoveRange(db.Course);
            db.Course.AddRange(CreateSeedData("Course"));
            db.SaveChanges();
        }

        private static IEnumerable<Course> CreateSeedData(string entity)
        {
            if(entity == "Course")
            {
                var titles = new[] { "Firma 1", "Firma 2", "Firma 3", "Firma 4", "Firma 5", "Firma 6", "Firma 7", "Firma 8", "Firma 9", "Firma 10" };
                var descriptions = new[] { "Arbeitsschutz", "COVID-19", "IT", "Programmierung", "Vertrieb", "Forschung", "Marketing", "Beratung", "Verkauf", "Außendienst" };

                for (var i = 0; i < NumCourses; i++)
                {
                    yield return new Course
                    {
                        Titel = PickRandom(titles),
                        Description = PickRandom(descriptions)
                    };
                }

            }
            else if(entity == "Test")
            {

            }
            else if(entity == "Question")
            {

            }
            else if(entity == "Answer")
            {

            }
        }

        private static int PickRandomRange(int minInc, int maxExc)
        {
            return Random.Next(minInc, maxExc);
        }

        private static T PickRandom<T>(T[] values)
        {
            return values[Random.Next(values.Length)];
        }

        public static T PickRandomEnum<T>()
        {
            return PickRandom((T[])Enum.GetValues(typeof(T)));
        }
    }
}
