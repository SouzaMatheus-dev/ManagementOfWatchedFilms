namespace ManagementOfWatchedFilms.Domain.Entity
{
    public interface IEntity
    {
        Guid Id { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? ModifiedAt { get; set; }
        bool IsDeleted { get; set; }
    }
}