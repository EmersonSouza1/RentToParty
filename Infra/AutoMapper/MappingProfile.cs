using AutoMapper;
using ViaCepConsumer.Models;
using RentToParty.Model;
using RentToParty.Request;
using RentToParty.Response;

namespace RentToParty.Infra.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PessoaRequest, PessoaModel >()
                .ForMember(x => x.IdPessoa, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PessoaResponse, PessoaModel>().ReverseMap();

            CreateMap<EnderecoRequest, EnderecoModel>()
                .ForMember(x => x.IdEndereco, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PessoaResponse, PessoaModel>()
                  .ForMember(x => x.IdPessoa, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<EnderecoRequest, EnderecoModel>().ReverseMap();

            CreateMap<SearchResult, EnderecoModel>()
                .ForMember(d => d.Logradouro, opt => opt.MapFrom( s => s.Rua))
                .ForMember(d => d.Complemento, opt => opt.Ignore())
                .ForMember(d => d.Cep, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ImovelResponse, ImovelModel>().ReverseMap();

        }
    }
}
