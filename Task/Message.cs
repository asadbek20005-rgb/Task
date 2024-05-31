namespace Task
{
    public struct Message
    {
        public String FromUser  { get; set; }
        public string ToUser { get; set; }
        public string Text { get; set; }

        public Message(String fromUser, string toUser, string text)
        {
            FromUser = fromUser;
            ToUser = toUser;
            Text = text;
        }
    }
}
