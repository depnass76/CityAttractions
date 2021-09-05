using System.Collections.Generic;

namespace CityAttractions.Data
{
    public interface ICityRepository
    {
        IEnumerable<Thumbnail> GetAllCities();
        IEnumerable<Result> GetAllCitiesResult();
        bool SaveAll();
    }
}