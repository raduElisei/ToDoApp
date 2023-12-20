using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models;

public class ToDoItem
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    [DataType(DataType.Date)]
    public DateTime Deadline { get; set; }
    [Required]
    [DisplayName("To Do Item Status")]
    public ToDoItemStatus ToDoItemStatus { get; set; }
}
