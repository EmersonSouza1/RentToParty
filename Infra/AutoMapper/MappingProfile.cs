using AutoMapper;

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

            CreateMap<PessoaPutRequest, PessoaModel>().ReverseMap();

            CreateMap<PessoaResponse, PessoaModel>()
                .ForMember(x => x.IdPessoa, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ViaCepResponse, EnderecoModel>()
                .ForMember(x => x.IdEndereco, opt => opt.Ignore())
                .ForMember(x => x.Cep, opt => opt.Ignore())
                .ForSourceMember(x => x.Estado, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.CodigoIBGE, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.Cod_DDD, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.Cep, opt => opt.DoNotValidate())
                .ReverseMap();

            CreateMap<EnderecoRequest, EnderecoModel>()
                .ForMember(x => x.IdEndereco, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<EnderecoResponse, EnderecoModel>()
                .ForMember(x => x.IdEndereco, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<EnderecoPutRequest, EnderecoModel>()
                .ForMember(x => x.IdEndereco, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<EnderecoResponse, EnderecoRequest>()

                .ReverseMap();

            CreateMap<ImovelResponse, ImovelModel>().ReverseMap();

            CreateMap<ImovelRequest, ImovelModel>().ReverseMap();

            CreateMap<ImovelPutRequest, ImovelModel>().ReverseMap();

        }
    }
}
