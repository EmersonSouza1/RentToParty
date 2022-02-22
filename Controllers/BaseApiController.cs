using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace RentToParty.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected const string _version = "webapi/v1";




        public BaseApiController(IMapper mapper)
        {

            _mapper = mapper;
        }
    }
}
