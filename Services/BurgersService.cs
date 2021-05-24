using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Services
{
    public class BurgersService
    {
        private readonly BurgersRepository _repo;
        public BurgersService(BurgersRepository repo)
        {
            _repo = repo;
        }
        internal IEnumerable<Burger> Get()
        {
            return _repo.Get();
        }

        internal IEnumerable<Burger> Create(Burger newBurger)
        {
            {
                return (IEnumerable<Burger>)_repo.Create(newBurger);
            }

            // TODO do this thing
            throw new NotImplementedException();
        }
        internal Burger GetOne(int id)
        {
            Burger burger = _repo.GetOne(id);
            if (burger == null)
            {
                throw new Exception("Invalid Id");
            }
            return burger;
        }
        internal Burger Update(Burger update)
        {
            Burger original = GetOne(update.Id);
            original.Name = update.Name.Length > 0 ? update.Name : original.Name;
            original.Cost = update.Cost > 0 ? update.Cost : original.Cost;
            original.Quantity = update.Quantity > 0 ? update.Quantity : original.Quantity;
            original.Modifications = update.Modifications.Length > 0 ? update.Modifications : original.Modifications;
            if (_repo.Update(original))
            {
                return original;
            }
            throw new Exception("Something went terribly wrong");
        }
        internal void Delete(int id)
        {
            GetOne(id);
            _repo.Delete(id);
        }

    }
}