using NUnit.Framework;

namespace Common.UnitTests
{
    public class StringExtsTests
    {
        [Theory]
        #region Valid Email Test Cases
        [TestCase(arg1: "david.jones@proseware.com", arg2: true)]
        [TestCase(arg1: "d.j@server1.proseware.com", arg2: true)]
        [TestCase(arg1: "jones@ms1.proseware.com", arg2: true)]
        [TestCase(arg1: "j@proseware.com9", arg2: true)]
        [TestCase(arg1: "js#internal@proseware.com", arg2: true)]
        [TestCase(arg1: "j_9@[129.126.118.1]", arg2: true)]
        [TestCase(arg1: "js@proseware.com9", arg2: true)]
        [TestCase(arg1: "j.s@server1.proseware.com", arg2: true)]
        [TestCase(arg1: "\"j\"s\"\"@proseware.com", arg2: true)]
        [TestCase(arg1: "js@contoso.中国", arg2: true)]
        #endregion
        #region Invalid Email Test Cases
        [TestCase(arg1: "", arg2: false)]
        [TestCase(arg1: " ", arg2: false)]
        [TestCase(arg1: @"\", arg2: false)]
        [TestCase(arg1: "j.@server1.proseware.com", arg2: false)]
        [TestCase(arg1: "j..s@proseware.com", arg2: false)]
        [TestCase(arg1: "js*@proseware.com", arg2: false)]
        [TestCase(arg1: "js@proseware..com", arg2: false)]
        #endregion
        public void VerifyEmailFormat(string email, bool isEmailValid)
        {
            // Act
            bool result = email.IsEmailValid();

            // Assert
            Assert.AreEqual(isEmailValid, result);
        }
    }
}