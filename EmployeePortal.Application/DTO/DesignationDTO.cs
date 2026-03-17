using System.ComponentModel.DataAnnotations;

public class DesignationDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Designation Name is required")]
    [MinLength(2, ErrorMessage = "Designation must be at least 2 characters")]
    public string DesignationName { get; set; } = "";

    [Required(ErrorMessage = "Department is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Select valid Department")]
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;
}