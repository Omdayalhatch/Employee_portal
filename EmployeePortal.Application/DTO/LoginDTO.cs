using System.ComponentModel.DataAnnotations;

public class LoginDTO
{
    [Required(ErrorMessage = "Username or Email is required")]
    public string Username { get; set; } = "";

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = "";
    [EmailAddress(ErrorMessage = "Invalid Email")]
    public string Email { get; set; } = "";
}