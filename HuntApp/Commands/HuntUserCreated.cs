using System;

namespace UserApi.Commands
{
    public record HuntUserCreated(Guid Id, string Name, string Email, string PhoneNumber);
    
}
