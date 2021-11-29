using System;

namespace TraningSessionApi.Commands
{
    public record HuntUserCreated(Guid Id, string Name, string Email, string PhoneNumber);
}
