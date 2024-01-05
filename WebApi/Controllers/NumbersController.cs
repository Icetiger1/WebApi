using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using WebApiClassLibrary;

namespace WebApi.Controllers
{
    public class NumbersController : CustomBaseController
    {
        public NumbersController(IDateTimeServiceProvider dateTimeProvider)
            : base(dateTimeProvider)
        {
        }

        [HttpGet("GetTimeUtcNow")]
        public string Get() => base.dateTimeProvider.GetDateTime();

        [HttpGet(Name = "GetNumbers")]
        public IEnumerable<int> Get2() => new int[] { 1, 2, 3 };
        
    }
}
