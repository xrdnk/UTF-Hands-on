using System;
using Denity.UTFHandsOn.Domain.User;
using UnityEngine;
using UnityEngine.UI;

namespace Denity.UTFHandsOn.Presentation.View
{
    public sealed class UserNameView : MonoBehaviour, IUserNameView
    {
        [SerializeField] Text _resultText;
        [SerializeField] Button _button;
        [SerializeField] InputField _inputField;
        [SerializeField] Text _nameLabel;

        public Action<string> OnEnteredUserName { get; set; }

        void Start()
        {
            _nameLabel.text = PlayerPrefs.GetString(UserNameConst.USER_NAME_KEY);
            _button.onClick
                .AddListener(() => OnEnteredUserName.Invoke(_inputField.text));
        }

        public void DisplayChangeNameSuccess(string newName)
        {
            _resultText.text = $"<color=green>[{newName}]に変更しました！</color>";
            _nameLabel.text = newName;
        }

        public void DisplayChangeNameFailure(string invalidName)
        {
            _resultText.text = $"<color=red>[{invalidName}には変更できません！]</color>";
        }
    }
}