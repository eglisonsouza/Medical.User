using Medical.User.Application.Models.BaseModels;
using System.Diagnostics.CodeAnalysis;

namespace Medical.User.Application.Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public sealed class UserViewModel : UserBaseModel
    {
        public Guid Id { get; set; }
    }
}
