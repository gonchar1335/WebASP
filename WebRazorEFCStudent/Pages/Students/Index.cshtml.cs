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
    public class IndexModel : PageModel
    {
        private readonly WebRazorEFCStudent.ApplicationContext _context;

        public IndexModel(WebRazorEFCStudent.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students.ToListAsync();
        }
    }
}
