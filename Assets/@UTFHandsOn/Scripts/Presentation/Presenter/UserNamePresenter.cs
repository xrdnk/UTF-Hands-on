using Denity.UTFHandsOn.Domain.User;
using Denity.UTFHandsOn.Presentation.View;
using UnityEngine;

namespace Denity.UTFHandsOn.Presentation.Presenter
{
    public sealed class UserNamePresenter : MonoBehaviour
    {
        [SerializeField] UserNameView _userNameView = null;
        UserService _userService;

        void Awake()
        {
            _userService = new UserService();
        }

        void Start()
        {
            _userNameView.OnEnteredUserName += NotifyChangeName;
            _userService.OnNameChanged += DisplayUpdateNameResult;
        }

        void NotifyChangeName(string enterUserName)
        {
            _userService.ChangeName(enterUserName);
        }

        void DisplayUpdateNameResult(string userName, bool isSuccess)
        {
            if (isSuccess)
            {
                _userNameView.DisplayChangeNameSuccess(userName);
            }
            else
            {
                _userNameView.DisplayChangeNameFailure(userName);
            }
        }


    }
}