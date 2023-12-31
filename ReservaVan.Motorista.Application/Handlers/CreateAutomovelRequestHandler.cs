﻿using AutoMapper;
using MediatR;
using ReservaVan.Motorista.Application.DTOs;
using ReservaVan.Motorista.Domain.Entities;
using ReservaVan.Motorista.Domain.Interfaces.Repositories;

namespace ReservaVan.Motorista.Application.Handlers;

public class CreateAutomovelRequestHandler : IRequestHandler<CreateAutomovelRequest, CreateAutomovelResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateAutomovelRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        var mappingConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CreateAutomovelRequest, Automovel>()
                .ForMember(d => d.Id, opts => opts.Ignore())
                .ForMember(d => d.EditadoPor, opts => opts.Ignore())
                .ForMember(d => d.EditadoEm, opts => opts.Ignore())
                .ForMember(d => d.Usuario, opts => opts.MapFrom(s => unitOfWork.UsuarioRepository.FirstOrDefault(s.UsuarioId)))
                .ForMember(d => d.Viagens, opts => opts.Ignore())
                ;

            cfg.CreateMap<Automovel, CreateAutomovelResponse>()
                .ForMember(d => d.UsuarioId, opts => opts.MapFrom(s => s.Usuario.Id))
                ;
        });

        mappingConfig.AssertConfigurationIsValid();

        _mapper = mappingConfig.CreateMapper();
    }

    public async Task<CreateAutomovelResponse> Handle(CreateAutomovelRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var automovel = _mapper.Map<Automovel>(request);

            await _unitOfWork.BeginTransaction();
            await _unitOfWork.AutomovelRepository.Insert(automovel);
            await _unitOfWork.CommitTransaction();

            var result = _mapper.Map<CreateAutomovelResponse>(automovel);

            return result;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
