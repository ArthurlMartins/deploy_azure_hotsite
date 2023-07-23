using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Hotsite.Models
{
    public class DatabaseContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));

            optionsBuilder.UseSqlServer(jAppSettings["ConnectionStrings"]["DefaultConnection"].ToString());
        }

        public DbSet<Interesse> Interesses { get; set; }

    }
}