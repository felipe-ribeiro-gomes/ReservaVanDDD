using System.Diagnostics.CodeAnalysis;

namespace ReservaVan.Motorista.Domain.Types
{
    public class AuthScheme
    {
        public AuthScheme(string name, string? displayName, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type handlerType)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (handlerType == null)
            {
                throw new ArgumentNullException(nameof(handlerType));
            }
            //if (!typeof(IAuthenticationHandler).IsAssignableFrom(handlerType))
            //{
            //    throw new ArgumentException("handlerType must implement IAuthenticationHandler.");
            //}

            Name = name;
            HandlerType = handlerType;
            DisplayName = displayName;
        }

        public string Name { get; }

        public string? DisplayName { get; }

        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        public Type HandlerType { get; }
    }
}
