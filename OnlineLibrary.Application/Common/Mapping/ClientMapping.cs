using AutoMapper;
using OnlineLibrary.Application.UseCases.Clients.Commands.CreateClient;
using OnlineLibrary.Application.UseCases.Clients.Commands.DeleteClient;
using OnlineLibrary.Application.UseCases.Clients.Commands.UpdateClient;
using OnlineLibrary.Application.UseCases.Clients.Response;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.Common.Mapping;

public class ClientMapping : Profile
{
    public ClientMapping()
    {
        CreateMap<CreateClientCommand, Client>();
        CreateMap<DeleteClientCommand, Client>();
        CreateMap<UpdateClientCommand, Client>();
        CreateMap<Client, ClientResponse>();
    }
}
