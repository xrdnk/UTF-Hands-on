using Denity.UTFHandsOn.Domain.User;
using NUnit.Framework;

namespace Denity.UTFHandsOn.Test
{
    [TestFixture]
    public class UserNameValidatorTest
    {
        [Test]
        public void 名前はアルファベットのみにする()
        {
            Assert.That(UserNameValidator.Validate("Denik"), Is.True);
        }

        [TestCase("a", TestName = "境界値テスト【下限】")]
        [TestCase("zzzzzzzzzz", TestName = "境界値テスト【上限】")]
        public void 名前の文字数は1から10文字にする(string testcase)
        {
            Assert.That(UserNameValidator.Validate(testcase), Is.True);
        }

        [TestCase("", TestName = "境界値テスト【0文字】")]
        [TestCase("zzzzzzzzzzz", TestName = "境界値テスト【11文字】")]
        public void UserNameValidator_Validate_名前の文字数は1から10文字以外許容しない(string invalidName)
        {
            Assert.That(UserNameValidator.Validate(invalidName), Is.False);
        }

        [TestCase("a b")]
        [TestCase("a_b")]
        [TestCase("aあb")]
        [TestCase("＠！＃")]
        public void UserNameValidator_Validate_名前はアルファベット以外は許容しない(string invalidName)
        {
            Assert.That(UserNameValidator.Validate(invalidName), Is.False);
        }
    }
}