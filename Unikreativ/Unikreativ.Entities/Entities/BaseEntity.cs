using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Unikreativ.Entities.Entities
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }

        public DateTime DateModified { get; set; }
    }
}