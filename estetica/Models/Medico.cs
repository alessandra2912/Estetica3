using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace estetica.Models
{
    public class CadastroMedicoModel : PageModel
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string Especialidade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}