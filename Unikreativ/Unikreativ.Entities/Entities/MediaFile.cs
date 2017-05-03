namespace Unikreativ.Entities.Entities
{
    public class MediaFile
    {
        public string FileName { get; set; }
        public string UploadDate { get; set; }

        //nav properties
        public string UserId { get; set; }

        public string TaskId { get; set; }
    }
}