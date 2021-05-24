using System.Collections.Generic;
using burgershack.Interfaces;
using burgershack.Models;

namespace burgershack.Repositories
{
    public class DrinksRepository : IRepo<Drink>
    {

        public IEnumerable<Drink> Get()
        {
            throw new System.NotImplementedException();
        }
        public Drink Create(Drink data)
        {
            throw new System.NotImplementedException();
        }

        public Drink GetOne(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Drink data)
        {
            throw new System.NotImplementedException();
        }
    }

}