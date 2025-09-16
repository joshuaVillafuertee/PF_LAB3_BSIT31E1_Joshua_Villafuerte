using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PF_LAB3_BSIT31E1_Joshua_Villafuerte.Data;
using PF_LAB3_BSIT31E1_Joshua_Villafuerte.Models;

namespace PF_LAB3_BSIT31E1_Joshua_Villafuerte.Controllers
{
    [Authorize]
    public class CardsController : Controller
    {
        private readonly GreedDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CardsController(GreedDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var cards = await _context.Cards
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
            return View(cards);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var card = await _context.Cards.FindAsync(id);
            if (card == null) return NotFound();

            return View(card);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Card card, IFormFile? imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploads = Path.Combine(_env.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploads);

                    var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(imageFile.FileName)}";
                    var filePath = Path.Combine(uploads, fileName);

                    using var fs = new FileStream(filePath, FileMode.Create);
                    await imageFile.CopyToAsync(fs);

                    card.ImageUrl = $"/uploads/{fileName}";
                }

                card.CreatedAt = DateTime.Now;

                _context.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var card = await _context.Cards.FindAsync(id);
            if (card == null) return NotFound();

            return View(card);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Card updatedCard, IFormFile? imageFile)
        {
            if (id != updatedCard.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var card = await _context.Cards.FindAsync(id);
                    if (card == null) return NotFound();

                    card.Name = updatedCard.Name;
                    card.Rarity = updatedCard.Rarity;
                    card.Description = updatedCard.Description;

                    if (imageFile != null && imageFile.Length > 0)
                    {
                        var uploads = Path.Combine(_env.WebRootPath, "uploads");
                        Directory.CreateDirectory(uploads);

                        var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(imageFile.FileName)}";
                        var filePath = Path.Combine(uploads, fileName);

                        using var fs = new FileStream(filePath, FileMode.Create);
                        await imageFile.CopyToAsync(fs);

                        card.ImageUrl = $"/uploads/{fileName}";
                    }

                    _context.Update(card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(updatedCard.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(updatedCard);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var card = await _context.Cards.FindAsync(id);
            if (card == null) return NotFound();

            return View(card);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card != null)
            {
                // Delete image file if it exists
                if (!string.IsNullOrEmpty(card.ImageUrl))
                {
                    var imagePath = Path.Combine(_env.WebRootPath, card.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                _context.Cards.Remove(card);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(int id) => _context.Cards.Any(e => e.Id == id);
    }
}
