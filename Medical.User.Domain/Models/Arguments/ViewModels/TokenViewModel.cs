using Medical.User.Domain.Models.Arguments.BaseModels;

namespace Medical.User.Domain.Models.Arguments.ViewModels
{
    public class TokenViewModel : UserBaseModel
    {
        public string Token { get; set; }
        public string RefressToken { get; set; }
    }
}
