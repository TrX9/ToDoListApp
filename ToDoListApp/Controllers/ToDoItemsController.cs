using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ToDoItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItems([FromQuery] bool? isCompleted, [FromQuery] int? priorityLevel)
        {
            var query = _context.ToDoItems.Include(t => t.Priority).Include(t => t.User).AsQueryable();

            if (isCompleted.HasValue)
            {
                query = query.Where(t => t.IsCompleted == isCompleted.Value);
            }

            if (priorityLevel.HasValue)
            {
                query = query.Where(t => t.Priority.Level == priorityLevel.Value);
            }

            return await query.ToListAsync();
        }

        // GET: api/ToDoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(int id)
        {
            var toDoItem = await _context.ToDoItems.Include(t => t.Priority).Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return toDoItem;
        }

        // PUT: api/ToDoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem(int id, ToDoItem toDoItem)
        {
            if (id != toDoItem.Id)
            {
                return BadRequest();
            }

            var user = await _context.Users.FindAsync(toDoItem.UserId);
            if (user == null)
            {
                return BadRequest("Invalid UserId");
            }

            var existingItem = await _context.ToDoItems.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Title = toDoItem.Title;
            existingItem.Description = toDoItem.Description;
            existingItem.IsCompleted = toDoItem.IsCompleted;
            existingItem.DueDate = toDoItem.DueDate;
            existingItem.PriorityId = toDoItem.PriorityId;
            existingItem.UserId = toDoItem.UserId;
            _context.Entry(existingItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e1)
            {
                if (!ToDoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ToDoItems
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItem toDoItem)
        {
            var user = await _context.Users.FindAsync(toDoItem.UserId);
            if (user == null)
            {
                return BadRequest("Invalid UserId");
            }

            _context.ToDoItems.Add(toDoItem);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e1)
            {
                return NotFound(e1.Message);
            }
            return CreatedAtAction("GetToDoItem", new { id = toDoItem.Id }, toDoItem);
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            _context.ToDoItems.Remove(toDoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoItemExists(int id)
        {
            return _context.ToDoItems.Any(e => e.Id == id);
        }
    }
}
