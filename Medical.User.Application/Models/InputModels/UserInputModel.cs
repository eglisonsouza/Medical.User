using Medical.User.Application.Models.BaseModels;

namespace Medical.User.Application.Models.InputModels
{
    public sealed class UserInputModel : UserBaseModel
    {
        public string Password { get; set; }

    }
}
