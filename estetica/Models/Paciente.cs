using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace estetica.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtaNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
