using System;

namespace Service.Storage.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Сущность для  связывания двух сущностей в отношении многие ко многим
    /// </summary>
    public class ProblemTag : EntityModel
    {
        public Guid ProblemId { get; set; }

        public Problem Problem { get; set; }

        public Guid TagId { get; set; }

        public Tag Tag { get; set; }
    }
}