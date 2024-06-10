using AllegroConnector.Application.AllegroAuthorization;
using AllegroConnector.Application.AllegroAuthorization.Commands;
using AllegroConnector.Domain.OAuthToken;
using AutoMapper;
using FluentAssertions;
using FluentResults;
using Moq;

namespace AllegroManager.AllegroConnector.Application
{
    [TestFixture]
    public class AuthorizationTest
    {
        readonly Mock<IAllegroOAuthService> _allegroOAuthService;
        readonly Mock<IOAuthTokenRepository> _tokenRepository;
        readonly Mock<IMapper> _mapper;

        public AuthorizationTest()
        {
            _allegroOAuthService = new();
            _tokenRepository = new();
            _mapper = new();
        }

        [Test]
        public async Task Handle_Should_Return_SuccessfullyGetCodeMessage_When_Correct_Parameters()
        {
            _allegroOAuthService.Setup(x => x.GetCode())
                               .Returns(() => Task.FromResult(Result.Ok(new AuthDeviceOAuth())));
            var command = new GetCodeCommand();
            var commandHandler = new GetCodeCommandHandler(_allegroOAuthService.Object);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            result.IsSuccess.Should().BeTrue();
            result.Errors.Should().HaveCount(0);
        }

        [Test]
        public async Task Handle_Should_Return_FailedGetCodeMessage_When_Incorrect_Parameters()
        {
            _allegroOAuthService.Setup(x => x.GetCode())
                               .Returns(() =>Task.FromResult(Result.Fail<AuthDeviceOAuth>("Something went wrong")));

            var command = new GetCodeCommand();
            var commandHandler = new GetCodeCommandHandler(_allegroOAuthService.Object);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            result.IsSuccess.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors.Should().ContainEquivalentOf(new Error("Failed to get device code"));
        }

        [Test]
        public async Task Handle_Should_Return_SuccessfullyAuthorizedResponseMessage_When_Correct_Parameters()
        {
            _allegroOAuthService.Setup(x => x.GetAccessToken(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                                   .Returns((int param1, string param2, CancellationToken param3) =>
                                       Task.FromResult(Result.Ok(new AuthResponse())));
            _tokenRepository.Setup(x => x.AddAsync(It.IsAny<AllegroOAuthToken>())).Returns(Task.CompletedTask);
            _mapper.Setup(x => x.Map<AllegroOAuthToken>(It.IsAny<object>())).Returns(new AllegroOAuthToken());

            var command = new AuthorizeCommand(It.IsAny<int>(), It.IsAny<string>());
            var commandHandler = new AuthorizeCommandHandler(_tokenRepository.Object, _allegroOAuthService.Object, _mapper.Object);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            result.IsSuccess.Should().BeTrue();
            result.Errors.Should().HaveCount(0);
        }

        [Test]
        public async Task Handle_Should_Return_FailedAuthorizedResponseMessage_When_Api_Failed()
        {
            _allegroOAuthService.Setup(x => x.GetAccessToken(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                                   .Returns(() => Task.FromResult(Result.Fail<AuthResponse>("Not authorized")));


            _tokenRepository.Setup(x => x.AddAsync(It.IsAny<AllegroOAuthToken>())).Returns(Task.CompletedTask);
            _mapper.Setup(x => x.Map<AllegroOAuthToken>(It.IsAny<object>())).Returns(new AllegroOAuthToken());

            var command = new AuthorizeCommand(It.IsAny<int>(), It.IsAny<string>());
            var commandHandler = new AuthorizeCommandHandler(_tokenRepository.Object, _allegroOAuthService.Object, _mapper.Object);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            result.IsSuccess.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors.Should().ContainEquivalentOf(new AuthorizationError("Not authorized"));
        }
    }
}
