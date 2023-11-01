using System.ComponentModel.DataAnnotations;

namespace ReservaVan.Motorista.Web.Models.ViewModels;

public class LoginViewModel
{
    public LoginViewModel()
    {
        ModelStateErrors = new HashSet<string>();
    }

    public string? ReturnUrl { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "E-mail")]
    public string? Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string? Password { get; set; }

    public ICollection<string> ModelStateErrors { get; set; }
}