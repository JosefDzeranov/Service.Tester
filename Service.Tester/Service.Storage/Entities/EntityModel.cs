using System;

namespace Service.Storage.Entities
{
    /// <summary>
    /// Общий класс для всех сущностей базы данных
    /// </summary>
    public abstract class EntityModel
    {
        /// <summary>
        /// У всех сущностей есть УИд в качестве первичного ключа с автогенерированием 
        /// </summary>
        public Guid Id { get; set; }
    }
}
