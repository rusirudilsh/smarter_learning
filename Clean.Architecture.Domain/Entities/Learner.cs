using Clean.Architecture.Domain.Common;

namespace Clean.Architecture.Domain.Entities
{
    public class Learner : BaseEntity
    {
        public new int Id { get; set; }
        public required string Name { get; set; }
    }
}