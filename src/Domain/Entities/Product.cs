using Domain.Bases;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public DateTime ManufacturingDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public Guid ProviderId { get; private set; }

        [ForeignKey("ProviderId")]
        public Provider Provider { get; private set; }
                        
        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
