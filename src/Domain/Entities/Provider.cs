using Domain.Bases;

namespace Domain.Entities
{
    public class Provider : BaseEntity
    {
        public string Description { get; private set; }
        public string Cnpj { get; private set; }

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
