namespace Unikreativ.Entities.Entities
{
    public class MediaFile : BaseEntity
    {
        public string FileName { get; set; }

        public string UploadDate { get; set; }

        public User User { get; set; }

        public TasksRequest TasksRequest { get; set; }
    }
}