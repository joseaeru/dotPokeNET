using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public abstract class EntityBase
    {
        public char Status { get; set; } = 'A';

        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.MinValue;
        public DateTimeOffset? DateUpdated { get; set; } = DateTimeOffset.MinValue;
        public DateTimeOffset? DateDeleted { get; set; } = DateTimeOffset.MinValue;
    }
}
