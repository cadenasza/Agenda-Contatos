using Contact_Book.Data;
using Contact_Book.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contact_Book.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _context.Contact.ToListAsync();
            return Ok(contacts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _context.Contact.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (contact is null) return NotFound();
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(Contact contact)
        {
            _context.Contact.Add(contact);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, Contact updatedContact)
        {
            var contact = await _context.Contact.FirstOrDefaultAsync(c => c.Id == id);
            if (contact is null) return NotFound();

            if (updatedContact is null) return BadRequest("Dados inválidos.");
            if (string.IsNullOrWhiteSpace(updatedContact.Name) || string.IsNullOrWhiteSpace(updatedContact.Email))
                return BadRequest("Nome e Email são obrigatórios.");

            contact.Name = updatedContact.Name;
            contact.Email = updatedContact.Email;
            contact.Phone = updatedContact.Phone;
            contact.Address = updatedContact.Address;

            await _context.SaveChangesAsync();
            return Ok(contact);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _context.Contact.FindAsync(id);
            if (contact is null)
                return NotFound();

            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
