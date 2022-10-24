using Library.Contracts;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookService bookService;

        public BooksController(IBookService _bookService)
        {
            this.bookService = _bookService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await bookService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddBookViewModel()
            {
                Categories = await bookService.GetCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await bookService.AddBookAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {

            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await bookService.AddToCollection(bookId, userId);

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");
            }
            return RedirectToAction(nameof(All));

        }

        [HttpGet]
        public async Task<IActionResult> AllMyBooks()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await bookService.GetMineAsync(userId);


            return View("Mine", model);

        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await bookService.RemoveFromCollection(bookId, userId);

            return RedirectToAction(nameof(AllMyBooks));
        }
    }
}
