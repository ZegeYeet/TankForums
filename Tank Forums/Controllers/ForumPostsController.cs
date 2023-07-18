using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tank_Forums.Data;
using Tank_Forums.Models;

namespace Tank_Forums.Controllers
{
    public class ForumPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForumPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ForumPosts
        public async Task<IActionResult> Index()
        {
            var forumPosts = from post in _context.ForumPost select post;
            forumPosts = forumPosts.OrderByDescending(i => i.postDate);

            return _context.ForumPost != null ?
                        View("Index", await forumPosts.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.WowClass'  is null.");
        }

        // GET: ForumPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ForumPost == null)
            {
                return NotFound();
            }

            var forumPost = await _context.ForumPost
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (forumPost == null)
            {
                return NotFound();
            }

            return View(forumPost);
        }

        public async Task<IActionResult> NavClassSelection(string navClass)
        {
            var forumPosts = from post in _context.ForumPost select post;
            forumPosts = forumPosts.Where(j => j.className.Contains(navClass));
            forumPosts = forumPosts.OrderByDescending(i => i.postDate);

            return _context.ForumPost != null ?
                        View("Index", await forumPosts.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.WowClass'  is null.");
        }

        // GET: ForumPosts/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ForumPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("className,postTitle,postBody")] ForumPost forumPost)
        {
            forumPost.authorName = User.Identity.Name;

            if (ModelState.IsValid)
            {
                _context.Add(forumPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forumPost);
        }

        // GET: ForumPosts/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ForumPost == null)
            {
                return NotFound();
            }

            var forumPost = await _context.ForumPost.FindAsync(id);
            if (forumPost == null)
            {
                return NotFound();
            }
            return View(forumPost);
        }

        // POST: ForumPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,className,authorName,classIcon,postDate,postTitle,postBody,postLikes,postDislikes")] ForumPost forumPost)
        {
            if (id != forumPost.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forumPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumPostExists(forumPost.PostId))
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
            return View(forumPost);
        }

        // GET: ForumPosts/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ForumPost == null)
            {
                return NotFound();
            }

            var forumPost = await _context.ForumPost
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (forumPost == null)
            {
                return NotFound();
            }

            return View(forumPost);
        }

        // POST: ForumPosts/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ForumPost == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ForumPost'  is null.");
            }
            var forumPost = await _context.ForumPost.FindAsync(id);
            if (forumPost != null)
            {
                _context.ForumPost.Remove(forumPost);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumPostExists(int id)
        {
          return (_context.ForumPost?.Any(e => e.PostId == id)).GetValueOrDefault();
        }
    }
}
