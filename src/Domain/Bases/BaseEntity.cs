using System;

namespace Domain.Bases
{
    public abstract class BaseEntity : BaseValidator
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; protected set; }
        public DateTime? DeletedAt { get; protected set; }

        protected BaseEntity()
        {

        }

    }
}
