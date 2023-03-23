using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zakupy.Models;

namespace Zakupy.Database
{
    public class ExpensesDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<ExpensesDatabase> Instance = 
            new AsyncLazy<ExpensesDatabase>(async () =>
            {
            var instance = new ExpensesDatabase();
                try
                {
                    CreateTableResult result = await Database.CreateTableAsync<Expenses>();
                }
                catch (Exception ex)
                {
                    throw;
                }
            
            return instance;
        });

        public ExpensesDatabase() 
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<Expenses>> GetItemsAsync() 
        {
            return Database.Table<Expenses>().ToListAsync();
        }
        public Task<List<Expenses>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Expenses>("SELECT * FROM [Expenses]");
        }

        public Task<Expenses> GetItemAsync(int id)
        {
            return Database.Table<Expenses>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveExpensesAsync(Expenses item)
        { 
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else 
            {
                return Database.InsertAsync(item);
            }
        }

    }
}
