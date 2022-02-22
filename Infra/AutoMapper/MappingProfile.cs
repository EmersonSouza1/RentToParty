using AutoMapper;
using RentToParty.Models;
using RentToParty.Request;

namespace RentToParty.Infra.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PessoaInfo, PessoaRequest>();

            CreateMap<PessoaRequest, PessoaInfo>();
        }
    }
}
