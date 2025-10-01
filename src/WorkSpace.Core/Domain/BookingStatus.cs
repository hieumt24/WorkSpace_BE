using System.ComponentModel.DataAnnotations;

namespace WorkSpace.Core.Domain;

public class BookingStatus
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } // Pending, Confirmed, Cancelled, Completed, etc.

    [MaxLength(255)]
    public string Description { get; set; }

    // Navigation properties
    public virtual List<Booking> Bookings { get; set; }
}