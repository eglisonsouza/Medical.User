using Medical.User.Application.Models.BaseModels;

namespace Medical.User.Application.Models.ViewModels
{
    public sealed class UserViewModel : UserBaseModel
    {
        public Guid Id { get; set; }
    }
}
