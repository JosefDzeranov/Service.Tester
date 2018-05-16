using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}
