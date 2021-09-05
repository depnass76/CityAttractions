using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CityAttractions.Data
{
    public class CitySeeder
    {
        private readonly CityContext _ctx;
        private readonly IWebHostEnvironment _env;

        public CitySeeder(CityContext ctx,IWebHostEnvironment env)
        {
            this._ctx = ctx;
            this._env = env;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.root.Any())
            {
                //need to create sample data
                var filePath = Path.Combine(_env.ContentRootPath,"Data/city.json");
                var json = File.ReadAllText(filePath);
                var showCity = JsonSerializer.Deserialize<Root>(json);
                _ctx.root.AddRange(showCity);
                _ctx.SaveChanges();
            }
        }
    }
}
