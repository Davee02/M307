using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using M307_Project.Data;
using M307_Project.Models;
using M307_Project.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace M307_Project.Controllers
{
    public class RepairOrdersController : Controller
    {
        private readonly RepairsContext _context;

        public RepairOrdersController(RepairsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var pendingRepairOrders = _context.RepairOrders
                .Include(x => x.Tool)
                .Where(x => x.RepairState == Enums.RepairState.Pending);

            if (!string.IsNullOrEmpty(searchString))
            {
                pendingRepairOrders = pendingRepairOrders.Where(x =>
                    x.Firstname.Contains(searchString) || 
                    x.Lastname.Contains(searchString) ||
                    x.Tool.ToolName.Contains(searchString));
            }

            pendingRepairOrders = pendingRepairOrders.OrderByDescending(x => x.Severety);

            return View(await pendingRepairOrders.ToListAsync());
        }


        public async Task<IActionResult> Create()
        {
            var viewModel = await GetRepairOrderViewModelWithAllTools();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateRecaptcha]
        public async Task<IActionResult> Create(RepairOrder repairOrder)
        {
            if (ModelState.IsValid)
            {
                repairOrder.RepairStartDateTime = DateTime.Now;
                _context.Add(repairOrder);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            var viewModel = await GetRepairOrderViewModelWithAllTools();
            viewModel.RepairOrder = repairOrder;

            return View(viewModel);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateRecaptcha]
        public async Task<IActionResult> Edit(int id, RepairOrder repairOrder)
        {
            if (id != repairOrder.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var viewModel = await GetRepairOrderViewModelWithAllTools();
                viewModel.RepairOrder = repairOrder;

                return View(viewModel);
            }

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

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> FinishOrders(List<int> ids)
        {
            foreach (int id in ids)
            {
                var repairOrder = await _context.RepairOrders.FindAsync(id);
                if (repairOrder == null)
                    return NotFound($"The repair order with the id {id} could not be found");

                repairOrder.RepairState = Enums.RepairState.Finished;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        private async Task<RepairOrderViewModel> GetRepairOrderViewModelWithAllTools()
        {
            var allTools = await _context.Tools.ToListAsync();

            var toolsSelectItems = allTools
                .Select(x => new SelectListItem(x.ToolName, x.Id.ToString()))
                .ToList();

            return new RepairOrderViewModel { AllTools = toolsSelectItems };
        }

        private bool RepairOrderExists(int id)
        {
            return _context.RepairOrders.Any(e => e.Id == id);
        }
    }
}
