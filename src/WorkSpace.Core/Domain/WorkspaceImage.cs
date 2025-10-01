using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSpace.Core.Domain;

public class WorkspaceImage
{
    public int Id { get; set; }
    public int WorkspaceId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(max)")]
    public string ImageUrl { get; set; }

    [MaxLength(255)]
    public string Caption { get; set; }

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual WorkSpaces Workspace { get; set; }
}