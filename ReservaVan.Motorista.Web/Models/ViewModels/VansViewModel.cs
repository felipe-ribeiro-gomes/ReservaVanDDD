namespace ReservaVan.Motorista.Web.Models.ViewModels;

public class VansViewModel
{
    public VansViewModel()
    {
        ModelStateErrors = new HashSet<string>();
    }

    

    public ICollection<string> ModelStateErrors { get; set; }
}