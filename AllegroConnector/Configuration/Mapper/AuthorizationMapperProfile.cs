using AllegroConnector.Application.AllegroAuthorization;
using AllegroConnector.Domain.OAuthToken;
using AutoMapper;

namespace AllegroConnector.Infrastructure.Configuration.Mapper
{
    public class AuthorizationMapperProfile : Profile
    {
        public AuthorizationMapperProfile()
        {
            CreateMap<AuthResponse, AllegroOAuthToken>()
                  .ForMember(dest => dest.AccessToken, opt => opt.MapFrom(src => src.access_token))
                  .ForMember(dest => dest.TokenType, opt => opt.MapFrom(src => src.token_type))
                  .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.refresh_token))
                  .ForMember(dest => dest.ExpiresIn, opt => opt.MapFrom(src => src.expires_in))
                  .ForMember(dest => dest.Scope, opt => opt.MapFrom(src => src.scope))
                  .ForMember(dest => dest.Jti, opt => opt.MapFrom(src => src.jti))
                  .ForMember(dest => dest.DateTimeStamp, opt => opt.MapFrom(src => src.DateTimeStamp))
                  .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
