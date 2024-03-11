namespace Medical.User.Domain.Common.Models
{
    public interface ICommonInputModel<in T, out O>
    {
        O ToEntity(T model);
    }
}
