using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using M307_Project.Data;
using M307_Project.Models;
using M307_Project.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var pendingRepairOrders = await _context.RepairOrders
                .Where(x => x.RepairState == Enums.RepairState.Pending)
                .OrderByDescending(x => x.Severety)
                .ToListAsync();

            return View(pendingRepairOrders);
        }
   

        // GET: RepairOrders/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = await GetRepairOrderViewModelWithAllTools();

            return View(viewModel);
        }

        private async Task<RepairOrderViewModel> GetRepairOrderViewModelWithAllTools()
        {
            var allTools = await _context.Tools.ToListAsync();

            var toolsSelectItems = allTools
                .Select(x => new SelectListItem(x.ToolName, x.Id.ToString()))
                .ToList();
            var viewModel = new RepairOrderViewModel {AllTools = toolsSelectItems};
            return viewModel;
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

            var viewModel = await GetRepairOrderViewModelWithAllTools();
            return View(viewModel);
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

            var viewModel = await GetRepairOrderViewModelWithAllTools();
            viewModel.RepairOrder = repairOrder;
            return View(viewModel);
        }
    }
}
