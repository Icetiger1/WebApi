using Domain.Model;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApiClassLibrary;

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
        public async Task<IEnumerable<UserContact>> Get(UserContact userContact)
        {
            return await dataContext.Contacts.Take(10).ToListAsync();
        }

        [HttpGet("start={start}&end={end}")]
        public async Task<IEnumerable<UserContact>> Get(int start = 0, int end = 2)
        {
            Range range = new Range(start, end);
            var result = await dataContext.Contacts.Take(range).ToListAsync();

            return result;
        }

        [HttpGet]
        public async Task<UserContact> Get(Guid id)
        {
            var userContact = await dataContext.Contacts.FindAsync(id);
            return userContact;
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
            userContact.TimeCerated = updateUserContact.TimeCerated;

            //dataContext.Contacts.Update(updateUserContact);
            return await dataContext.SaveChangesAsync() > 0;
        }
    }
}
