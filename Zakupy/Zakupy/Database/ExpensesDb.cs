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

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<Expenses>();
        }

        public ExpensesDb() 
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<Expenses>> GetItemsAsync() 
        {
            return Database.Table<Expenses>().ToListAsync();
        }

        public async Task<Expenses> GetExpensesAsync(int id) 
        {
            await Init();
            return await Database.Table<Expenses>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveExpensesAsync(Expenses item) 
        {

            await Init();
            if (item.Id != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);


            /*if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else 
            {
                return Database.InsertAsync(item);
            }*/
        }

    }
}
