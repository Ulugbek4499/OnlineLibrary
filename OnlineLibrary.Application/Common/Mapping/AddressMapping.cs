using AutoMapper;
using OnlineLibrary.Application.UseCases.Addresses.Commands.CreateAddress;
using OnlineLibrary.Application.UseCases.Addresses.Commands.DeleteAddress;
using OnlineLibrary.Application.UseCases.Addresses.Commands.UpdateAddress;
using OnlineLibrary.Application.UseCases.Addresses.Response;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.Common.Mapping;

public class AddressMapping : Profile
{
    public AddressMapping()
    {
        CreateMap<CreateAddressCommand, Address>();
        CreateMap<DeleteAddressCommand, Address>();
        CreateMap<UpdateAddressCommand, Address>();
        CreateMap<Address, AddressResponse>();
    }
}
