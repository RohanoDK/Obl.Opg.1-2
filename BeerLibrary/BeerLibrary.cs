using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerLibrary
{
    public class BeersRepository
    {
        private List<Beer> _beers;

        public BeersRepository()
        {
            _beers = new List<Beer>
            {
                new Beer(1, "Tuborg", 5.0),
                new Beer(2, "Carlsberg", 4.8),
                new Beer(3, "Heineken", 5.0),
                new Beer(4, "Guinness", 4.2),
                new Beer(5, "Budweiser", 5.0)
            };
        }

        public List<Beer> Get(double? minAbv = null, double? maxAbv = null, string sortBy = null)
        {
            var beers = _beers.ToList();

            // Filter by Abv
            if (minAbv != null)
                beers = beers.Where(b => b.Abv >= minAbv).ToList();
            if (maxAbv != null)
                beers = beers.Where(b => b.Abv <= maxAbv).ToList();

            // Sort
            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.ToLower() == "name")
                    beers = beers.OrderBy(b => b.BeerName).ToList();
                else if (sortBy.ToLower() == "abv")
                    beers = beers.OrderBy(b => b.Abv).ToList();
            }

            return new List<Beer>(beers);
        }

        public Beer GetById(int id)
        {
            return _beers.FirstOrDefault(b => b.Id == id);
        }

        public Beer Add(Beer beer)
        {
            if (beer == null)
                throw new ArgumentNullException(nameof(beer));

            beer.Id = _beers.Any() ? _beers.Max(b => b.Id) + 1 : 1;
            _beers.Add(beer);
            return beer;
        }

        public Beer Delete(int id)
        {
            var beerToDelete = _beers.FirstOrDefault(b => b.Id == id);
            if (beerToDelete != null)
                _beers.Remove(beerToDelete);
            return beerToDelete;
        }

        public Beer Update(int id, Beer values)
        {
            var beerToUpdate = _beers.FirstOrDefault(b => b.Id == id);
            if (beerToUpdate != null)
            {
                beerToUpdate.Id = values.Id;
                beerToUpdate.BeerName = values.BeerName;
                beerToUpdate.Abv = values.Abv;
            }
            return beerToUpdate;
        }
    }
}
