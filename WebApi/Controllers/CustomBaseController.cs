using Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomBaseController : Controller
    {
        protected readonly IDateTimeServiceProvider dateTimeProvider;

        public CustomBaseController(IDateTimeServiceProvider dateTimeProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
        }

    }
}
