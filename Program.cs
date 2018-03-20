using System;
using System.Linq;

namespace NetCoreForEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new AppDbContext())
            {
                var test = dbContext._test.ToList();   
            }
        }
    }
}
