namespace OurResumeIR.Application.Static
{
    public static class UserPanelMessage
    {
        public  const string Blog = "مقاله";
        public  const string AboutMe = "درباره من";
        public  const string Document = "مدرک";
        public  const string History = "تجربه";
        public  const string MySkill = "مهارت های من";
        public  const string Skill = "مهارت";
        public  const string Skill_Level = "سطح مهارت";
        private static readonly Dictionary<MessageType, string> Messages = new()
        {
            { MessageType.DeleteError, "{0} با شکست مواجه شد!" },
            { MessageType.DeleteSuccess, "{0} با موفقیت حذف شد!" },
            { MessageType.EditError, "ویرایش {0} ناموفق بود!" },
            { MessageType.EditSuccess, "{0} با موفقیت ویرایش شد!" },
            { MessageType.AddError, "ثبت {0} با شکست مواجه شد!" },
            { MessageType.AddSuccess, "{0} با موفقیت اضافه شد!" }
        };
        public static string GetMessage(string entityName, MessageType messageType)
        {
            string template = Messages.TryGetValue(messageType, out var message) ? message : "پیام نامعتبر!";
            return string.Format(template, entityName);
        }
        public enum MessageType
        {
            DeleteError,
            DeleteSuccess,
            EditError,
            EditSuccess,
            AddError,
            AddSuccess
        }
    }
}
