using System;
using UnityEngine;

namespace Denity.UTFHandsOn.Domain.User
{
    public sealed class UserService : IUserService
    {
        public Action<string, bool> OnNameChanged { get; set; }

        public void ChangeName(string newName)
        {
            if (UserNameValidator.Validate(newName))
            {
                PlayerPrefs.SetString(UserNameConst.USER_NAME_KEY, newName);
                OnNameChanged?.Invoke(newName, true);
            }
            else
            {
                OnNameChanged?.Invoke(newName, false);
            }
        }
    }
}