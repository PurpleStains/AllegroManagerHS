using AllegroConnector.Application.AllegroAuthorization;
using AllegroConnector.Application.AllegroAuthorization.Commands;
using FluentAssertions;
using FluentResults;
using Moq;

namespace AllegroManager.AllegroConnector.Application
{
    [TestFixture]
    public class AuthorizationTest
    {
        readonly Mock<IAllegroOAuthService> _allegroOAuthService;

        public AuthorizationTest()
        {
            _allegroOAuthService = new();
        }

        [Test]
        public async Task Handle_Should_Return_SuccessfullyGetCodeMessage_When_Correct_Parameters()
        {
            _allegroOAuthService.Setup(x => x.GetCode())
                               .Returns(() =>
                                   Task.FromResult(Result.Ok(new AuthDeviceOAuth())));
            var command = new GetCodeCommand();
            var commandHandler = new GetCodeCommandHandler(_allegroOAuthService.Object);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            result.IsSuccess.Should().BeTrue();
            result.Errors.Should().HaveCount(0);
        }

        //[Test]
        //public async Task Handle_Should_Return_SuccessfullyAuthorizedResponseMessage_When_Correct_Parameters()
        //{
        //    _allegroOAuthService.Setup(x => x.GetAccessToken(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
        //                           .Returns((int param1, string param2, CancellationToken param3) =>
        //                               Task.FromResult(Result.Ok(new AuthResponse())));
        //    var command = new AuthorizeCommand();
        //    var commandHandler = new AuthorizeCommandHandler(_allegroOAuthService.Object);

        //    var result = await commandHandler.Handle(command, CancellationToken.None);

        //    result.IsSuccess.Should().BeTrue();
        //    result.Errors.Should().HaveCount(0);
        //}
    }
}
