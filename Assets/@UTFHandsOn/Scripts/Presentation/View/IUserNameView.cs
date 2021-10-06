using System;

namespace Denity.UTFHandsOn.Presentation.View
{
    public interface IUserNameView
    {
        Action<string> OnEnteredUserName { get; set; }
        void DisplayChangeNameSuccess(string newName);
        void DisplayChangeNameFailure(string invalidName);
    }
}