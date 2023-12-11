namespace DiabeticsSystem.BlazorUI.Features.Doctor.Domain.Entity
{
    public class DoctorEntity
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
