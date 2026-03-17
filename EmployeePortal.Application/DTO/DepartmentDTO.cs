using System.ComponentModel.DataAnnotations;

public class DepartmentDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Department Name is required")]
    [MinLength(2, ErrorMessage = "Department must be at least 2 characters")]
    public string DepartmentName { get; set; } = "";

    public DateTime CreatedDate { get; set; } = DateTime.Now;
}