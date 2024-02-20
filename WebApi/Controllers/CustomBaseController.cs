using Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        protected readonly IDateTimeServiceProvider dateTimeProvider;

        public CustomBaseController(IDateTimeServiceProvider dateTimeProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
        }

    }
}
