using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using RecipeApp.Models;

namespace RecipeApp.Data
{
    public class RecipeDatabase
    {
        readonly SQLiteAsyncConnection database;

        public RecipeDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Recipe>().Wait();
        }

        public Task<List<Recipe>> GetRecipeAsync()
        {
            //Get all notes.
            return database.Table<Recipe>().ToListAsync();
        }

        public Task<Recipe> GetRecipeAsync(int id)
        {
            // Get a specific note.
            return database.Table<Recipe>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveRecipeAsync(Recipe note)
        {
            if (note.ID != 0)
            {
                return database.UpdateAsync(note);
            }
            else
            {
                return database.InsertAsync(note);
            }
        }

        public Task<int> DeleteRecipeAsync(Recipe note)
        {
            return database.DeleteAsync(note);
        }
    }
}