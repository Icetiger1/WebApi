using Domain.Model;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiClassLibrary;
using WebApi.Controllers;

namespace WebApi.Controllers
{
    public class UserContactController : CustomBaseController
    {
        private readonly DataContext dataContext;

        public UserContactController(
            IDateTimeServiceProvider dateTimeProvider, 
            DataContext dataContext) 
            : base(dateTimeProvider)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IEnumerable<UserContact>> Get()
        {
            return await dataContext.Contacts.ToListAsync();
        }

        [HttpGet("start={start}&end={end}")]
        public async Task<IEnumerable<UserContact>> Get(int start = 0, int end = 2)
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

        [HttpGet]
        public async Task<UserContact> Get(Guid id)
        {
            return await dataContext.Contacts.FindAsync(id);
        }

        [HttpPost]
        public async Task<bool> Append(UserContact userContact)
        {
            await dataContext.Contacts.AddAsync(userContact);

            return await dataContext.SaveChangesAsync() > 0;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Remove(Guid id)
        {
            var userContact = await dataContext.Contacts.FindAsync(id);
            dataContext.Contacts.Remove(userContact);
            return await dataContext.SaveChangesAsync() > 0;
        }

        [HttpPut]
        public async Task<bool> Update(Guid Id, UserContact updateUserContact)
        {
            var userContact = await dataContext.Contacts.FindAsync(Id);
            userContact.FirsName = updateUserContact.FirsName;
            userContact.LastName = updateUserContact.LastName;
            userContact.Telephone = updateUserContact.Telephone;
            userContact.Description = updateUserContact.Description;
            userContact.TimeCreated = updateUserContact.TimeCreated;

            //dataContext.Contacts.Update(updateUserContact);
            return await dataContext.SaveChangesAsync() > 0;
        }
    }
}
