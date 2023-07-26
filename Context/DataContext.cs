using CarShopMaui.Models;
using SQLite;

namespace CarShopMaui.Context
{
    public class DataContext
    {
        SQLiteAsyncConnection _connection;

        async Task Init()
        {
            if (_connection is not null)
                return;

            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "CarShopDb.db3"),
                SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);

            _ = await _connection.CreateTableAsync<Car>();

        }

        public async Task<List<Car>> GetFavorites()
        {
            await Init();
            return await _connection.Table<Car>().ToListAsync();
        }

        public async Task<Car> GetCarById(int id)
        {
            await Init();
            return await _connection.Table<Car>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SetFavorite(Car car)
        {
            await Init();

            var _car = await GetCarById(car.Id);
          
            if (_car is not null)
                return false;

            return await _connection.InsertAsync(car) == 1;
        }
    }
}
