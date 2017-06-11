using System;
using System.ComponentModel.DataAnnotations;

namespace Unikreativ.Entities.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DateModified { get; set; }
    }
}