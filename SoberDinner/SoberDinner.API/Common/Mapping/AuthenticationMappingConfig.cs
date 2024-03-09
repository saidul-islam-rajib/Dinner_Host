using Mapster;
using SoberDinner.Application.Authentication.Commands.Register;
using SoberDinner.Application.Authentication.Common;
using SoberDinner.Application.Authentication.Queries.Login;
using SoberDinner.Contracts.Authentication;

namespace SoberDinner.API.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
