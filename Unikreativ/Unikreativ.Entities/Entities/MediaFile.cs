using System;
using System.ComponentModel.DataAnnotations;

namespace Unikreativ.Entities.Entities
{
    public class MediaFile : BaseEntity
    {
        public string FileName { get; set; }

        public string UploadDate { get; set; }

        /// <summary>
        /// user upload Id
        /// </summary>
        public string UserId { get; set; }

        public User User { get; set; }
        public string TaskRequestId { get; set; }
        public TasksRequest TasksRequest { get; set; }
    }
}