using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityAttractions.Data
{
    public class CityRepository : ICityRepository
    {
        private readonly CityContext _ctx;

        public CityRepository(CityContext ctx)
        {
            this._ctx = ctx;
        }

        public IEnumerable<Thumbnail> GetAllCities()
        {
            return  _ctx.thumbnail
                       .OrderBy(p => p.rId)
                       .ToList();
        }

        public IEnumerable<Result> GetAllCitiesResult()
        {
            return _ctx.result
                       .OrderBy(p => p.rId)
                       .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges()>0;
        }
    }
}
