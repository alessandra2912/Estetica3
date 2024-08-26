using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using estetica.Models;

namespace estetica.Pages.Shared
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Agendamento Agendamento { get; set; }

        public IList<Paciente> Pacientes { get; set; }
        public IList<Medico> Medicos { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Pacientes = await _context.Pacientes.ToListAsync();
            Medicos = await _context.Medicos.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Agendamentos.Add(Agendamento);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
