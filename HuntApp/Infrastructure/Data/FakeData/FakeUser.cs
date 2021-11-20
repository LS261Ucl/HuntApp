using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using UserApi.Entities;

namespace UserApi.Infrastructure.Data.FakeData
{
    public class FakeUser
    {
        public  static void SeedData(UserContext context)
        {
            var UserFaker = new Faker<User>()               
                .RuleFor(x => x.Name, x => x.Person.FullName)
                .RuleFor(x => x.Email, x => x.Person.Email)
                .RuleFor(x => x.PhoneNumber, x => x.Phone.Locale);

            var userFake = JsonSerializer.Serialize(UserFaker.Generate());

            
         
        }

  
        

    }
}
