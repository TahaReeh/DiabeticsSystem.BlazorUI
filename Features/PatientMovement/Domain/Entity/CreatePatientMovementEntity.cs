namespace DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Entity
{
    public class CreatePatientMovementEntity
    {
        public required Guid CustomerId { get; set; }
        public required Guid ProductId { get; set; }
        public required Guid DoctorId { get; set; }
        public required string Barcode { get; set; }
    }
}
