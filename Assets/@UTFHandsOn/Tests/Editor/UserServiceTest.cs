using Denity.UTFHandsOn.Domain.User;
using NUnit.Framework;
using UnityEngine;

namespace Denity.UTFHandsOn.Test
{
    [TestFixture]
    public class UserServiceTest
    {
        UserService _userService;

        [SetUp]
        public void SetUp()
        {
            _userService = new UserService();
        }

        [TearDown]
        public void TearDown()
        {
            PlayerPrefs.DeleteKey(UserNameConst.USER_NAME_KEY);
        }

        [Test]
        public void UserService_ChangeName_バリデーションが通った時に名前が保存される()
        {
            // setup
            var validName = "testName";

            // exercise
            _userService.ChangeName(validName);

            // verify
            Assert.That(PlayerPrefs.GetString(UserNameConst.USER_NAME_KEY), Is.EqualTo("testName"));
        }

        [Test]
        public void UserService_ChangeName_バリデーションが通った時に成功したことを通知する()
        {
            // setup
            var validName = "testName";
            (string, bool) actual = (string.Empty, false);
            _userService.OnNameChanged += (s, b) => actual = (s, b);

            // exercise
            _userService.ChangeName(validName);

            // verify
            Assert.That(actual, Is.EqualTo(("testName", true)));
        }

        [Test]
        public void UserService_ChangeName_バリデーションが通らなかった時に名前は保存されない()
        {
            // setup
            var invalidName = "あいうえお";

            // exercise
            _userService.ChangeName(invalidName);

            // verify
            Assert.That(PlayerPrefs.GetString(UserNameConst.USER_NAME_KEY), Is.Not.EqualTo("あいうえお"));
        }

        [Test]
        public void UserService_ChangeName_バリデーションが通らなかった時に失敗したことを通知する()
        {
            // setup
            var invalidName = "あいうえお";
            (string, bool) actual = (string.Empty, false);
            _userService.OnNameChanged += (s, b) => actual = (s, b);

            // exercise
            _userService.ChangeName(invalidName);

            // verify
            Assert.That(actual, Is.EqualTo(("あいうえお", false)));
        }
    }
}