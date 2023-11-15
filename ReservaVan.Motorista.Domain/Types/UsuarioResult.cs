using System.Globalization;

namespace ReservaVan.Motorista.Domain.Types;

public class UsuarioResult
{
    private readonly List<UsuarioError> _errors = new List<UsuarioError>();

    public bool Succeeded { get; protected set; }

    public IEnumerable<UsuarioError> Errors => _errors;

    public static UsuarioResult Success => new UsuarioResult { Succeeded = true };

    public static UsuarioResult Failed(params UsuarioError[] errors)
    {
        var result = new UsuarioResult { Succeeded = false };
        if (errors != null)
        {
            result._errors.AddRange(errors);
        }
        return result;
    }

    public override string ToString()
    {
        return Succeeded ?
               "Succeeded" :
               string.Format(CultureInfo.InvariantCulture, "{0} : {1}", "Failed", string.Join(",", Errors.Select(x => x.Code).ToList()));
    }
}
