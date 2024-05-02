using AutoMapper;
using Medical.User.Application.Models.InputModels;
using Medical.User.Application.Models.ViewModels;
using Medical.User.Domain.Models.Entities;
using Smart.Essentials.Security.Cryptography;
using System.Diagnostics.CodeAnalysis;

namespace Medical.User.Application.Models.Mappings
{
    [ExcludeFromCodeCoverage]
    public sealed class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<UserInputModel, UserProfile>()
                .ForMember(dst => dst.Username, map => map.MapFrom(src => src.Username))
                .ForMember(dst => dst.Password, map => map.MapFrom(src => src.Password.To256Hash()))
                .ForMember(dst => dst.UrlProfile, map => map.MapFrom(src => src.UrlProfile))
                .ForMember(dst => dst.Role, map => map.MapFrom(src => src.Role));

            CreateMap<LoginInputModel, UserProfile>()
                .ForMember(dst => dst.Username, map => map.MapFrom(src => src.Username))
                .ForMember(dst => dst.Password, map => map.MapFrom(src => src.Password.To256Hash()))
                .ForMember(dst => dst.Role, map => map.MapFrom(src => src.Role))
                .ReverseMap();

            CreateMap<UserProfile, UserViewModel>()
                .ForMember(dst => dst.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dst => dst.Username, map => map.MapFrom(src => src.Username))
                .ForMember(dst => dst.UrlProfile, map => map.MapFrom(src => src.UrlProfile))
                .ForMember(dst => dst.Role, map => map.MapFrom(src => src.Role))
                .ReverseMap();
        }
    }
}
