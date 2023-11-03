using MediatR;
using Microsoft.AspNetCore.Identity;
using ReservaVan.Motorista.Application.DTOs;
using ReservaVan.Motorista.Domain.Entities;
using ReservaVan.Motorista.Domain.Interfaces.Repositories;

namespace ReservaVan.Motorista.Application.Handlers;

public class CreateAutomovelRequestHandler : IRequestHandler<CreateAutomovelRequest, CreateAutomovelResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAutomovelRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateAutomovelResponse> Handle(CreateAutomovelRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var automovel = new Automovel();
            automovel.Marca = request.Marca;
            automovel.Modelo = request.Modelo;
            automovel.Cor = request.Cor;
            automovel.Placa = request.Placa;
            automovel.QtdVaga = request.QtdVaga;
            automovel.Usuario = await _unitOfWork.UsuarioRepository.FindByIdAsync(request.UsuarioId);

            await _unitOfWork.BeginTransaction();
            await _unitOfWork.AutomovelRepository.Insert(automovel);
            await _unitOfWork.CommitTransaction();
            

            return new CreateAutomovelResponse
            {
                UsuarioId = automovel.Usuario.Id,
                Marca = automovel.Marca,
                Modelo = automovel.Modelo,
                Cor = automovel.Cor,
                Placa = automovel.Placa,
                QtdVaga = automovel.QtdVaga,
            };
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
