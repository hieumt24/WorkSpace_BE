using System.ComponentModel.DataAnnotations;

namespace WorkSpace.Core.Domain;

public class AvailabilitySchedule
{
    public int Id { get; set; }
    public int WorkspaceId { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    [Required]
    public TimeSpan StartTime { get; set; }

    [Required]
    public TimeSpan EndTime { get; set; }

    public bool IsAvailable { get; set; } = true;

    // Navigation properties
    public virtual WorkSpaces Workspace { get; set; }
}