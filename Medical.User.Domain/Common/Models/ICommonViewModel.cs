namespace Medical.User.Domain.Common.Models
{
    public interface ICommonViewModel<in T, out O>
    {
        O FromEntity(T entity);
    }
}
