namespace Unikreativ.Helper.Confirm
{
    public class MessageContent
    {
        public string[] Recipients { get; set; }

        public string[] CcRecipients { get; set; }

        public string[] BccRecipients { get; set; }

        public string Subject { get; set; }
        public string PlainContent { get; set; }

        public string HtmlContent { get; set; }
    }
}