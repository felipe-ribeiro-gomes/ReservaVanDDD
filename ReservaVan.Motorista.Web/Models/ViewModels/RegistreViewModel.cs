using ReservaVan.Motorista.Domain.Types;
using System.ComponentModel.DataAnnotations;

namespace ReservaVan.Motorista.Web.Models.ViewModels;

public class RegistreViewModel
{
    public string? ReturnUrl { get; set; }

    public IList<AuthScheme>? ExternalLogins { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "E-mail")]
    public string? Email { get; set; } = default!;

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string? Password { get; set; } = default!;

    [DataType(DataType.Password)]
    [Display(Name = "Confirme a senha")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string? ConfirmPassword { get; set; } = default!;

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Text)]
    [Display(Name = "Nome")]
    public string? Nome { get; set; } = default!;

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Text)]
    [Display(Name = "Sobrenome")]
    public string? Sobrenome { get; set; } = default!;

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Data de Nascimento")]
    public DateTime? DataNascimento { get; set; } = default!;

    public IEnumerable<string> Errors { get; set; } = new List<string>();
}