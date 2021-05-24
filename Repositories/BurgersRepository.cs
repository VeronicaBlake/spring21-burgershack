using System.Collections.Generic;
using System.Data;
using burgershack.Interfaces;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{
    public class BurgersRepository : IRepo<Burger>
    {
        private readonly IDbConnection _db;
        public BurgersRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Burger> Get()
        {
            string sql = "SELECT * FROM burgers";
            return _db.Query<Burger>(sql);
        }
        public Burger Create(Burger newBurger)
        {
            string sql = @"
            INSERT INTO burgers
            (id, name, cost, quantity, modifications, itemType)
            VALUES 
            (@Id, @Name, @Cost, @Quantity, @Modifications, @ItemType);
            SELECT LAST_INSERT_ID()";
            newBurger.Id = _db.ExecuteScalar<int>(sql, newBurger);
            return newBurger;
        }

        public Burger GetOne(int id)
        {
            string sql = "SELECT * FROM burgers WHERE id = @id";
            return _db.QueryFirstOrDefault<Burger>(sql, new { id });
        }
        //NOTE we will do the same thing in the IRepo making it a bool and return a public bool with the delete 
        public bool Update(Burger original)
        {
            string sql = @"
           UPDATE burgers
           SET
           name = @Name
           cost = @Cost
           quantity = @Quantity
           modifications = @Modifications
           WHERE id=@Id
           ";
            int affectedRows = _db.Execute(sql, original);
            return affectedRows == 1;
        }
        public bool Delete(int id)
        {
            string sql = "DELETE FROM burger WHERE id = @id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }
    }

}