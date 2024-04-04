using Medical.User.Application.Models.InputModels;
using Smart.Essentials.Core.ResultDataModel;

namespace Medical.User.Application.Service
{
    public interface IUserProfileService
    {
        Task<ResultModel> AddAsync(UserInputModel model);
        Task<ResultModel> LoginAsync(LoginInputModel model);
        ResultModel Update(Guid id, UserInputModel model);
    }
}
