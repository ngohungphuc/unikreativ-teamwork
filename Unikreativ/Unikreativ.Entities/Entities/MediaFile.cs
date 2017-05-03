namespace Unikreativ.Entities.Entities
{
    public class MediaFile
    {
        public string FileName { get; set; }

        public string UploadDate { get; set; }

        //nav properties
        public string UserUpload { get; set; }

        public string TaskId { get; set; }
    }
}