using System;

namespace Denity.UTFHandsOn.Domain.User
{
    public interface IUserService
    {
        void ChangeName(string newName);
        Action<string, bool> OnNameChanged { get; set; }
    }
}