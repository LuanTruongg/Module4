using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module4.Data;
using Module4.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Module4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly ToDoContext _context;        

        public ToDosController (ToDoContext context)
        {
            _context = context;            
        }
        // GET: api/<ToDosController>
        [HttpGet]
        public async Task<List<ToDoItem>> Get()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        // GET api/<ToDosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _context.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST api/<ToDosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoItem request)
        {
            if (request == null)
                return BadRequest("Please input data");
            var result = await _context.ToDoItems.AddAsync(request);
            if (result == null)
                return BadRequest("Error");
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
        }

        // PUT api/<ToDosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] ToDoItemRequest request)
        {
            if (request == null)
                return BadRequest("Please input data");
            var getItem = await _context.ToDoItems.FindAsync(id);
            if (getItem == null)
                return NotFound();
            getItem.Id = id;
            getItem.Name = request.Name;
            getItem.IsComplete = request.IsComplete;
            try
            {
                _context.ToDoItems.Update(getItem);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = getItem.Id }, getItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Error");
            }
        }

        // DELETE api/<ToDosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.ToDoItems.FindAsync(id);
            if (item == null)
                return NotFound();
            _context.ToDoItems.Remove(item);
            await _context.SaveChangesAsync();
            return Ok("Delete Item success");
        }
    }
}
