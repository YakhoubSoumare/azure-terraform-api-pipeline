using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Models;

namespace TaskManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly TaskManagerContext _context;

        public TaskItemsController(TaskManagerContext context)
        {
            _context = context;
        }

        // GET: api/TaskItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTaskItems()
        {
            var taskItems = await _context.TaskItems.ToListAsync();
            
            if(!taskItems.Any()){
                return NotFound();
            }

            // Response.Headers.Append("X-Deployment-Test", "Updated API deployed!");
            return taskItems;
        }

        // GET: api/TaskItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(long id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        // PUT: api/TaskItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(long id, TaskItem taskItem)
        {
            if (id != taskItem.Id)
            {
                return BadRequest();
            }

            // _context.Entry(taskItem).State = EntityState.Modified;
            var existingItem = await _context.TaskItems.FindAsync(id);

            if(existingItem == null)
            {
                return NotFound();
            }

            bool statusChanged = existingItem.Status != taskItem.Status;

            // Copy values from incoming item and track only the changes
            _context.Entry(existingItem).CurrentValues.SetValues(taskItem); // need to find way to only update changed


            try
            {
                await _context.SaveChangesAsync();

                string? statusChangedMessage;
                if(statusChanged){
                    // Here I can trigger an Azure serverless function later

                    // emulating the payload of http trigger function
                    statusChangedMessage = $"'{existingItem.Title}' status changed from '{existingItem.RequestTeam}' to '{existingItem.ReceivingTeam}'";
                    if(!string.IsNullOrWhiteSpace(existingItem.ReviewMessage)){
                        statusChangedMessage += $". Message: {existingItem.ReviewMessage}";
                    }

                    

                    Response.Headers.Append("X-Status-Changed", statusChangedMessage);

                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // returning ok for now to see header in response
            // return NoContent();
            return Ok();
        }

        // POST: api/TaskItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskItem>> PostTaskItem(TaskItem taskItem)
        {
            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskItem), new { id = taskItem.Id }, taskItem);
            
        }

        // DELETE: api/TaskItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(long id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskItemExists(long id)
        {
            return _context.TaskItems.Any(e => e.Id == id);
        }
    }
}
