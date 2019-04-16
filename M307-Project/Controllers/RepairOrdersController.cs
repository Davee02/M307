﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using M307_Project.Data;
using M307_Project.Models;
using M307_Project.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace M307_Project.Controllers
{
    public class RepairOrdersController : Controller
    {
        private readonly RepairsContext _context;

        public RepairOrdersController(RepairsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var pendingRepairOrders = await _context.RepairOrders
                .Include(x => x.Tool)
                .Where(x => x.RepairState == Enums.RepairState.Pending)
                .OrderByDescending(x => x.Severety)
                .ToListAsync();

            return View(pendingRepairOrders);
        }
   

        public async Task<IActionResult> Create()
        {
            var viewModel = await GetRepairOrderViewModelWithAllTools();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RepairOrder repairOrder)
        {
            if (ModelState.IsValid)
            {
                repairOrder.RepairStartDateTime = DateTime.Now;
                _context.Add(repairOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var viewModel = await GetRepairOrderViewModelWithAllTools();
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
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> FinishOrders(List<int> ids)
        {
            foreach(int id in ids)
            {
                RepairOrder repairOrder = await _context.RepairOrders.FirstAsync(x => x.Id == id);
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
            var viewModel = new RepairOrderViewModel { AllTools = toolsSelectItems };
            return viewModel;
        }

        private bool RepairOrderExists(int id)
        {
            return _context.RepairOrders.Any(e => e.Id == id);
        }
    }
}
