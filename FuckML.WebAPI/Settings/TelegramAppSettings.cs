namespace FuckML.WebAPI.Settings
{
    public class TelegramAppSettings
    {
        public TelegramBotClientSettings BotClient { get; set; } = new();
    }
    public class TelegramBotClientSettings
    {
        public string Token = "";
        public string Username = "";
    }
}
