using System.ComponentModel.DataAnnotations;

namespace WorkSpace.Core.Domain;

public class BookingParticipant
{
    public int Id { get; set; }
    public int BookingId { get; set; }

    [MaxLength(100)]
    public string FullName { get; set; }

    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; }

    // Navigation properties
    public virtual Booking Booking { get; set; }
}