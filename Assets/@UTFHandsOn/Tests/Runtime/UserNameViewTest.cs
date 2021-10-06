using System.Collections;
using Denity.UTFHandsOn.Domain.User;
using Denity.UTFHandsOn.Presentation.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityUITest;

namespace Denity.UTFHandsOn.Test
{
    [TestFixture]
    public class UserNameViewTest : UITest
    {
        [SetUp]
        public void SetUp()
        {
            PlayerPrefs.SetString(UserNameConst.USER_NAME_KEY, "test");
        }

        [TearDown]
        public void TearDown()
        {
            PlayerPrefs.DeleteKey(UserNameConst.USER_NAME_KEY);
        }

        [UnityTest]
        public IEnumerator 初回起動時にテキストにUSER_NAME_KEYの値が設定されている()
        {
            yield return LoadScene("S01_MVP");

            yield return WaitFor(new ObjectAppeared<UserNameView>());

            yield return AssertLabel("Label_UserName", "test");
        }

        [UnityTest]
        public IEnumerator 名前入力時にボタンを押すと入力した名前が出力される()
        {
            // setup
            string actual = null;
            string expected = "samplename";

            yield return LoadScene("S01_MVP");

            yield return WaitFor(new ObjectAppeared<UserNameView>());
            var userNameView = Object.FindObjectOfType<UserNameView>();

            yield return WaitFor(new ObjectAppeared<InputField>());
            var inputField = Object.FindObjectOfType<InputField>();
            inputField.text = "samplename";

            yield return AssertLabel("InputField_EnterName/Text", "sampename");

            userNameView.OnEnteredUserName += s => actual = s;

            yield return Press("Button_Update");

            // verify
            Assert.That(actual, Is.EqualTo(expected));
        }

        [UnityTest]
        public IEnumerator 名前変更が成功した時に入力時の名前と成功結果を表示する()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator 名前変更が失敗した時に失敗結果を表示する()
        {
            yield return null;
        }
    }
}