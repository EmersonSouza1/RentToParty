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
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PessoaResponse, PessoaModel>()
                  .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PessoaResponse, PessoaRequest>().ReverseMap();

        }
    }
}
