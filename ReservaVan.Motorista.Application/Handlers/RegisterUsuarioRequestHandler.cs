using MediatR;
using ReservaVan.Motorista.Application.DTOs;
using ReservaVan.Motorista.Domain.Entities;
using ReservaVan.Motorista.Domain.Interfaces.Repositories;

namespace ReservaVan.Motorista.Application.Handlers;

public class RegisterUsuarioRequestHandler : IRequestHandler<RegisterUsuarioRequest, RegisterUsuarioResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUsuarioRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RegisterUsuarioResponse> Handle(RegisterUsuarioRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = new Usuario();
            user.Email = request.Email;
            user.UserName = request.Email;
            user.Nome = request.Nome ?? "";
            user.Sobrenome = request.Sobrenome ?? "";
            user.DataNascimento = request.DataNascimento;

            var result = await _unitOfWork.UsuarioRepository.Register(user, request.Password);
            if (!result.Succeeded)
                return new RegisterUsuarioResponse
                {
                    Errors = result.Errors.Select(s => $"{s.Code}: {s.Description}")
                };

            await _unitOfWork.SignInRepository.SignInAsync(user, isPersistent: false);

            return new RegisterUsuarioResponse
            {
                Id = new Guid(user.Id),
                Email = user.Email,
                Nome = user.Nome,
                Sobrenome = user.Sobrenome,
                DataNascimento = user.DataNascimento,
            };
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
