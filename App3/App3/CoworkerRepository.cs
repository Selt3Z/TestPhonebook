using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace App3
{
    public class CoworkerRepository
    {
        SQLiteConnection database;
        public CoworkerRepository(string filename)
        {
            //создание подключения и базы данных
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Coworker>();
        }
        public IEnumerable<Coworker> GetItems()
        {
            return (from i in database.Table<Coworker>() select i).ToList();

        }
        public Coworker GetItem(int id)
        {
            return database.Get<Coworker>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Coworker>(id);
        }
        public int SaveItem(Coworker item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
