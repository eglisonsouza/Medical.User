using Medical.User.Application.Models.BaseModels;

namespace Medical.User.Application.Models.ViewModels
{
    public class TokenViewModel : UserBaseModel
    {
        public string Token { get; set; }
        public string RefressToken { get; set; }
    }
}
