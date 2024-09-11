using Clean.Architecture.Domain.Common;

namespace Clean.Architecture.Domain.Entities
{
    public class FailoverEntry : BaseEntity
    {
        public new int Id { get; set; }
        public DateTime DateTime { get; set; }
    }
}
