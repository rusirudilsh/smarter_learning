using Clean.Architecture.Domain.Common;

namespace Clean.Architecture.Domain.Entities
{
    public class LearnerResponse: BaseEntity
    {
        public new int Id { get; set; }
        public bool IsArchived { get; set; }

        public Learner? Learner { get; set; }
    }
}
