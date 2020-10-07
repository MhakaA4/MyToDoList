using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MitchelleList.Infrastructure;
using MitchelleList.Models;

namespace MitchelleList.Controllers
{
    public class todoController : Controller
    {
        //accesss to database dependency
        private readonly MitchelleListContext context;

        public todoController(MitchelleListContext context)
        {
            this.context = context;
        }
        //now able to use the database in contoller
        public async Task<ActionResult> Index()
        {
            IQueryable<todolist> ListItems = from i in context.todolist orderby i.Id select i;


            List<todolist> todolist = await ListItems.ToListAsync();


            return View(todolist);
        }

        //Method which allows us to create a list entry (1)
        public IActionResult Create() => View();

        //Post Method 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(todolist Item)
        {
            if (ModelState.IsValid)
            {
                context.Add(Item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Item was added succsessfully";

                return RedirectToAction("Index");

            }

            return View(Item);
        }
        // Method that enables us to make edits to the list (2)
        public async Task<ActionResult> Edit(int id)
        {
            todolist Item = await context.todolist.FindAsync(id);
            if (Item == null)
            {
                return NotFound();
            }

            return View(Item);

        }
        //Post Method for Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(todolist Item)
        {
            if (ModelState.IsValid)
            {
                context.Update(Item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Item was updated successfully";

                return RedirectToAction("Index");

            }

            return View(Item);
        } 
        
        //Delete Item from list (3)
        public async Task<ActionResult> Delete(int id)
        {
            todolist Item = await context.todolist.FindAsync(id);
            if (Item == null)
            {
                TempData["Error"] = "The Item does not exist ";
              
            }
            else
            {
                context.todolist.Remove(Item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Item has been deleted.";
            }

            return RedirectToAction("Index");
        }
    }
}
