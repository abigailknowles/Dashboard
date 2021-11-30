using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PatientWarningApp.Api.Controllers;
using PatientWarningApp.Api.PractitionerAccount.Interfaces;
using PatientWarningApp.Api.PractitionerAccount.Models;

namespace PatientWarningApp.Tests.PractitionerAccountTests
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
            var service = new Mock<IPractitionerAccountService>();
            service.Setup(o => o.ReadByUsernameAndPassword(It.IsAny<PractitionerAccountModel>())).Returns(new PractitionerAccountModel() { Id=1, Username = "username", Password = "password" });
            var accountModel = new PractitionerAccountModel() { Username = "username", Password = "password" };
            _loginController = new LoginController(service.Object);
            //Act
            var result = _loginController.Login(accountModel);

            //Assert
             Assert.IsInstanceOf<ActionResult<PractitionerAccountModel>>(result);

        }
    }
}

    
