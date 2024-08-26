namespace ClinicaEsteticaApp.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime DtaAgendamento { get; set; }
        public TimeSpan Hora { get; set; }
        public string Especialidade { get; set; }

        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
    }
}
