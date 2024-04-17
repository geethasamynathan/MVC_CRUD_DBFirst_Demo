using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD_DBFirst_Demo.Models;

namespace MVC_CRUD_DBFirst_Demo.Controllers
{
    public class PurchaseDetailsController : Controller
    {
        private readonly QuickKartContext _context;

        public PurchaseDetailsController(QuickKartContext context)
        {
            _context = context;
        }

        // GET: PurchaseDetails
        public async Task<IActionResult> Index()
        {
            var quickKartContext = _context.PurchaseDetails.Include(p => p.Email).Include(p => p.Product);
            return View(await quickKartContext.ToListAsync());
        }

        // GET: PurchaseDetails/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await _context.PurchaseDetails
                .Include(p => p.Email)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            return View(purchaseDetail);
        }

        // GET: PurchaseDetails/Create
        public IActionResult Create()
        {
            ViewData["EmailId"] = new SelectList(_context.Users, "EmailId", "EmailId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

        // POST: PurchaseDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseId,EmailId,ProductId,QuantityPurchased,DateOfPurchase")] PurchaseDetail purchaseDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmailId"] = new SelectList(_context.Users, "EmailId", "EmailId", purchaseDetail.EmailId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", purchaseDetail.ProductId);
            return View(purchaseDetail);
        }

        // GET: PurchaseDetails/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await _context.PurchaseDetails.FindAsync(id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }
            ViewData["EmailId"] = new SelectList(_context.Users, "EmailId", "EmailId", purchaseDetail.EmailId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", purchaseDetail.ProductId);
            return View(purchaseDetail);
        }

        // POST: PurchaseDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PurchaseId,EmailId,ProductId,QuantityPurchased,DateOfPurchase")] PurchaseDetail purchaseDetail)
        {
            if (id != purchaseDetail.PurchaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseDetailExists(purchaseDetail.PurchaseId))
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
            ViewData["EmailId"] = new SelectList(_context.Users, "EmailId", "EmailId", purchaseDetail.EmailId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", purchaseDetail.ProductId);
            return View(purchaseDetail);
        }

        // GET: PurchaseDetails/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await _context.PurchaseDetails
                .Include(p => p.Email)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            return View(purchaseDetail);
        }

        // POST: PurchaseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var purchaseDetail = await _context.PurchaseDetails.FindAsync(id);
            if (purchaseDetail != null)
            {
                _context.PurchaseDetails.Remove(purchaseDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseDetailExists(long id)
        {
            return _context.PurchaseDetails.Any(e => e.PurchaseId == id);
        }
    }
}
