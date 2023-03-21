using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zakupy.Models;

namespace Zakupy.Database
{
    public class ExpensesDb
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<ExpensesDb> Instance = 
            new AsyncLazy<ExpensesDb>(async () =>
            {
            var instance = new ExpensesDb();
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

        public ExpensesDb() 
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<Expenses>> GetItemsAsync() 
        {
            return Database.Table<Expenses>().ToListAsync();
        }

        public Task<Expenses> GetExpensesAsync(int id) 
        {
            return Database.Table<Expenses>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveExpensesAsync(Expenses item) 
        {
            if (item.Id != 0)
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
