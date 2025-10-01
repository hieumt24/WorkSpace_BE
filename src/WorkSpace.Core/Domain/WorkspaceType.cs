using System.ComponentModel.DataAnnotations;

namespace WorkSpace.Core.Domain;

public class WorkspaceType
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } // Private Office, Meeting Room, Hot Desk, etc.

    [MaxLength(500)]
    public string Description { get; set; }

    // Navigation properties
    public virtual List<WorkSpaces> Workspaces { get; set; }
}