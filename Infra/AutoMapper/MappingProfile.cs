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
            #region Pessoa

            CreateMap<PessoaRequest, PessoaModel >()
                .ForMember(x => x.IdPessoa, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PessoaPutRequest, PessoaModel>().ReverseMap();

            CreateMap<PessoaResponse, PessoaModel>().ReverseMap();

            CreateMap<PessoaSimplesResponse, PessoaModel>()
                .ForMember(x => x.IdPessoa, opt => opt.Ignore())
                .ForMember(x => x.CPF_CNPJ, opt => opt.Ignore())
                .ForMember(x => x.DtaNascimento, opt => opt.Ignore())
                .ForMember(x => x.IdEndereco, opt => opt.Ignore())
                .ForMember(x => x.Endereco, opt => opt.Ignore())
                .ReverseMap();

            #endregion

            #region Endereco
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
                .ReverseMap();

            CreateMap<EnderecoPutRequest, EnderecoModel>().ReverseMap();

            CreateMap<EnderecoResponse, EnderecoRequest>().ReverseMap();

            CreateMap<EnderecoResponse, EnderecoSimplesResponse>().ReverseMap();

            CreateMap<EnderecoSimplesResponse, EnderecoModel>()
                .ForMember(x => x.IdEndereco, opt => opt.Ignore())
                .ForMember(x => x.Bairro, opt => opt.Ignore())
                .ForSourceMember(x => x.Logradouro_Numero, opt => opt.DoNotValidate());

            CreateMap<EnderecoModel, EnderecoSimplesResponse>()
                .ForMember(x => x.Logradouro_Numero, opt => opt.MapFrom(s => s.Logradouro + " - Numero: " + s.Numero));

            #endregion

            #region Imovel

            CreateMap<ImovelResponse, ImovelModel>().ReverseMap();

            CreateMap<ImovelRequest, ImovelModel>()
                .ForMember(x => x.IdEndereco, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ImovelPutRequest, ImovelModel>()
                .ForMember(x => x.IdIMovel, opt => opt.Ignore())
                .ForMember(x => x.IdProprietario, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ImovelSimplesResponse, ImovelModel>().ReverseMap();
            #endregion

            #region Locacao

            #endregion

        }
    }
}
