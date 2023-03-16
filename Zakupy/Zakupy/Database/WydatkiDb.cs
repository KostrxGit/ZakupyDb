using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zakupy.Database
{
    public  class WydatkiDb
    {
        SQLiteAsyncConnection Database;

        public WydatkiDb()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<Wydatki>();
        }


        public async Task<int> SaveItemAsync(Wydatki item)
        {
            await Init();
            if (item.ID != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

    }
}
