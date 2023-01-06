using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    [Required]
    public string DisplayName { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", 
        ErrorMessage = "Password must be complex")]
    public string Password { get; set; }
    
    [Required]
    public string UserName { get; set; }
}


// (?=.*\\d) ... * any char in the pw, \\d one must be a number
// (?=.*[a-z]) ... one of the chars needs to be in lower case
// (?=.*[A-Z]) ... one of the chars needs to be in upper case
// {4,8} ... pw needs to be 4-8 chars long