    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;



    [ApiController]
    [Route("api/[controller]")]
    public class StudentDetailsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public StudentDetailsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> StudentDetailAdd([FromBody] StudentDetails student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return Ok(student);
        }
        [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _db.Students.ToListAsync();
        return Ok(list);

    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] StudentDetails updated)
    {
        var existing = await _db.Students.FindAsync(id);

        if (existing == null)
        { 
        return NotFound();          // 404 wali line
        }

        existing.Name = updated.Name;
        existing.Email = updated.Email;
        existing.Course = updated.Course;
        existing.Year = updated.Year;
        existing.Status = updated.Status;
        
        

        await _db.SaveChangesAsync();
        return Ok(existing);
    }
[HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id)
{
    var student = await _db.Students.FindAsync(id);

    if (student == null)
    {
        return NotFound();
    }

    _db.Students.Remove(student);
    await _db.SaveChangesAsync();

    return NoContent();
}
    }