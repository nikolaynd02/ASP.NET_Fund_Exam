using Library.Data.Models;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Contracts
{
    public interface IBookService
    {
        public Task<IEnumerable<BookViewModel>> GetAllAsync();

        public Task<IEnumerable<Category>> GetCategoriesAsync();

        public Task AddBookAsync(AddBookViewModel model);

        public Task AddToCollection(int bookId, string userId);

        public Task<IEnumerable<BookViewModel>> GetMineAsync(string userId);

        public Task RemoveFromCollection(int bookIdId, string userId);
    }
}
