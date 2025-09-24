using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebRazorEFCStudent;
using WebRazorEFCStudent.Models;

namespace WebRazorEFCStudent.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly WebRazorEFCStudent.ApplicationContext _context;

        public DeleteModel(WebRazorEFCStudent.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Students { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);

            if (course is not null)
            {
                Students = course;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                Students = student;
                _context.Students.Remove(Students);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
