using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class DateTimeService : IDateTimeServiceProvider
    {
        public string GetDateTime()
        {
            return DateTime.UtcNow.ToString();
        }
    }
}
