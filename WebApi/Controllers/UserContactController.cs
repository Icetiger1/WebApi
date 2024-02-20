using Domain.Model;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiClassLibrary;
using WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserContactController : Controller
    {
        private readonly DataContext dataContext;

        public UserContactController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IEnumerable<UserContact>> GetAll()
        {
            return await dataContext.Contacts.ToListAsync();
        }

        [HttpGet("start={start}&end={end}")]
        public async Task<IEnumerable<UserContact>> GetRange(int start = 0, int end = 2)
        {
            var t = dataContext
                .Contacts
                .OrderBy(e => e.TimeCreated)
                .ToArray();

            List<UserContact> result = new();
            for (int i = start; i <= end; i++)
            {
                result.Add(t[i]);
            }

            return result;
        }

        [HttpGet("{id}")]
        public async Task<UserContact> GetOne(Guid id)
        {
            return await dataContext.Contacts.FindAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] UserContact userContact)
        {
            var contactExist = dataContext.Contacts.Any(e => e.FirsName == userContact.FirsName 
                                                            && e.LastName == userContact.LastName);
            if (contactExist == true)
            {
                return Ok(new { Message = "User Already Created" });

            }

            await dataContext.Contacts.AddAsync(userContact);
            await dataContext.SaveChangesAsync();
            return Ok(new { Message = "User Created" });
        }

        [HttpDelete("{id}")]
        public async Task<bool> Remove(Guid id)
        {
            var userContact = await dataContext.Contacts.FindAsync(id);
            dataContext.Contacts.Remove(userContact);
            return await dataContext.SaveChangesAsync() > 0;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserContact updateUserContact)
        {
            dataContext.Contacts.Update(updateUserContact);

            await dataContext.SaveChangesAsync();

            return Ok(new { Message = "User Updated" });
        }
    }
}
