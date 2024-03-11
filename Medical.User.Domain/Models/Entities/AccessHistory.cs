namespace Medical.User.Domain.Models.Entities
{
    public class AccessHistory
    {
        public Guid UserId { get; private set; }
        public DateTime Date { get; private set; } = DateTime.Now;
    }
}
