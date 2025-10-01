using System.ComponentModel.DataAnnotations;

namespace WorkSpace.Core.Domain;

public class Amenity
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } // WiFi, Projector, Coffee, etc.

    [MaxLength(255)]
    public string Description { get; set; }

    [MaxLength(50)]
    public string IconClass { get; set; } // For UI

    // Navigation properties
    public virtual List<WorkspaceAmenity> WorkspaceAmenities { get; set; }
}