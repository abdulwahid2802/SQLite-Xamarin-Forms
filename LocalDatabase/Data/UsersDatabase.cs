using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LocalDatabase.Model;
using SQLite;
namespace LocalDatabase.Data
{
    public class UsersDatabase
    {
        readonly SQLiteAsyncConnection database;

        public UsersDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<UserModel>().Wait();
        }

        public Task<List<UserModel>> GetUsersAsync()
        {
            return database.Table<UserModel>().ToListAsync();
        }

        public Task<List<UserModel>> GetUsersByNameAsync(string name)
        {
            return database.QueryAsync<UserModel>("SELECT * FROM [UserModel] WHERE [Name] = ?", name);
        }

        public Task<UserModel> GetUserAsync(int id)
        {
            return database.Table<UserModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(UserModel user)
        {
            if (user.ID != 0)
            {
                return database.UpdateAsync(user);
            }
            else
            {
                return database.InsertAsync(user);
            }
        }

        public Task<int> DeleteTableAsync<T>()
        {
            return database.DeleteAllAsync<T>();
        }

        public Task<int> DeleteUserAsync(UserModel user)
        {
            return database.DeleteAsync(user);

        }


    }
}
