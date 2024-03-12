namespace Medical.User.Domain.Common.Models
{
    public interface ICommonInputModel<TEntity>
        where TEntity : class
    {
        TEntity ToEntity();
    }
}
