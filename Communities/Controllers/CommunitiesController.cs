using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Communities.Data;
using Communities.Models;
using Communities.Models.ViewModels;

namespace Communities.Controllers
{
    public class CommunitiesController : Controller
    {
        private readonly CommunitiesContext _context;

        public CommunitiesController(CommunitiesContext context)
        {
            _context = context;
        }

        // GET: Communities
        public async Task<IActionResult> Index()
        {
              return _context.Community != null ? 
                          View(await _context.Community.Include(c => c.Category).Include(c => c.Owner).ToListAsync()) :
                          Problem("Entity set 'CommunitiesContext.Community'  is null.");
        }

        // GET: Communities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Community == null)
            {
                return NotFound();
            }

            var community = await _context.Community
                .Include(c => c.Category)
                .Include(c => c.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }

        // GET: Communities/Create
        public IActionResult Create()
        {
            var viewModel = new CommunityFormViewModel();
            viewModel.CategoryList = _context.Category.ToList();
            viewModel.UserList = _context.User.ToList();
            
            return View(viewModel);
        }

        // POST: Communities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Community community)
        {
            _context.Add(community);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Communities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Community == null)
            {
                return NotFound();
            }

            var community = await _context.Community
                .Include(c => c.Category)
                .Include(c => c.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (community == null)
            {
                return NotFound();
            }

            var viewModel = new CommunityFormViewModel();
            viewModel.CategoryList = _context.Category.ToList();
            viewModel.UserList = _context.User.ToList();
            viewModel.Community = community;

            return View(viewModel);
        }

        // POST: Communities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Community community)
        {
            if (id != community.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(community);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityExists(community.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Communities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Community == null)
            {
                return NotFound();
            }

            var community = await _context.Community
                .FirstOrDefaultAsync(m => m.Id == id);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }

        // POST: Communities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Community == null)
            {
                return Problem("Entity set 'CommunitiesContext.Community'  is null.");
            }
            var community = await _context.Community.FindAsync(id);
            if (community != null)
            {
                _context.Community.Remove(community);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommunityExists(int id)
        {
          return (_context.Community?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
