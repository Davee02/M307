using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using M307_Project.Data;
using M307_Project.Models;

namespace M307_Project.Controllers
{
    public class RepairOrdersController : Controller
    {
        private readonly RepairsContext _context;

        public RepairOrdersController(RepairsContext context)
        {
            _context = context;
        }

        // GET: RepairOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.RepairOrders.ToListAsync());
        }

        // GET: RepairOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairOrder = await _context.RepairOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairOrder == null)
            {
                return NotFound();
            }

            return View(repairOrder);
        }

        // GET: RepairOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RepairOrders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RepairOrder repairOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repairOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repairOrder);
        }

        // GET: RepairOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairOrder = await _context.RepairOrders.FindAsync(id);
            if (repairOrder == null)
            {
                return NotFound();
            }
            return View(repairOrder);
        }

        // POST: RepairOrders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RepairOrder repairOrder)
        {
            if (id != repairOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repairOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairOrderExists(repairOrder.Id))
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
            return View(repairOrder);
        }

       

        private bool RepairOrderExists(int id)
        {
            return _context.RepairOrders.Any(e => e.Id == id);
        }
    }
}
