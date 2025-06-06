﻿using Microsoft.AspNetCore.Mvc;
using BookCatalogManagementApp.Dtos;
using BookCatalogManagementApp.Services;
using BookCatalogManagementApp.Validators;
using BookCatalogManagementApp.Extensions;


namespace BookCatalogManagementApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IBookValidator _bookValidator;

        public BooksController(IBookService bookService, IBookValidator bookValidator)
        {
            _bookService = bookService;
            _bookValidator = bookValidator;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var response = await _bookService.GetAllAsync();
            return this.HandleResponse(response, data => View(data));
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var response = await _bookService.GetByIdAsync(id);
            return this.HandleResponse(response, data => View(data));
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateBookDto dto)
        {
            var response = await _bookService.AddAsync(dto);
            return this.HandleResponse(response, _ => RedirectToAction(nameof(Index)), dto);
        }

        // GET: Books/Update/5
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            var response = await _bookService.GetByIdAsync(id);
            return this.HandleResponse(response, data => View(data.ToUpdateDto()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UpdateBookDto dto)
        {
            if (id != dto.Id)
                return NotFound();

            var response = await _bookService.UpdateAsync(dto);
            return this.HandleResponse(response, _ => RedirectToAction(nameof(Index)), dto);
        }


        // GET: Books/Delete/5
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _bookService.GetByIdAsync(id);
            return this.HandleResponse(response, data => View(data));
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromForm] int id)
        {
            var response = await _bookService.DeleteAsync(id);
            return this.HandleResponse(response, _ => RedirectToAction(nameof(Index)));
        }
    }
}
