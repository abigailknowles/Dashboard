using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using PaitentWarning.Web.Controllers;
using Moq;
using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;

namespace PatientWarningApp.Tests.DataTests
{
    public class LoginControllerTests
    {
        private LoginController _loginController;

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void GivenUsername_And_Password_Returns_ValidatedEntity()
        {
            //Arrange
            var practionerAccountService = new Mock<IPractitionerAccountService>();
            practionerAccountService.Setup(o => o.ReadByUsernameAndPassword(It.IsAny<PractitionerAccountModel>())).Returns(new PractitionerAccountModel() { Id=1, Username = "username", Password = "password" });
            var accountModel = new PractitionerAccountModel() { Username = "username", Password = "password" };
            _loginController = new LoginController(practionerAccountService.Object);
            //Act
            var result = _loginController.Login(accountModel);

            //Assert
             Assert.IsInstanceOf<ActionResult<PractitionerAccountModel>>(result);

        }
    }
}

    
