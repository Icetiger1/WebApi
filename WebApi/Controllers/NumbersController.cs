using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using WebApiClassLibrary;

namespace WebApi.Controllers
{
    public class NumbersController : CustomBaseController
    {
        protected readonly IDateTimeServiceProvider dateTimeProvider;

        public NumbersController(IDateTimeServiceProvider dateTimeProvider) : base(dateTimeProvider) 
        {
        }

        [HttpGet("gettimeutcnow")]
        public string Get() => base.dateTimeProvider.GetDateTime();

        [HttpGet]
        [Route("get")]
        public IEnumerable<int> Get2() => new int[] { 1, 2, 3 };

    }
}
