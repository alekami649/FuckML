using FuckML.ImageSearchers;
using FuckML.Searchers;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FuckML.WebAPI.Controllers
{
    [ApiController]
    public class TelegrambotController : ControllerBase
    {
        static TelegramBotClient botClient { get; set; }
        static QuickSearcher quickSearcher { get; set; }
        static QuickImageSearcher quickImageSearcher { get; set; }
        static object _lock { get; set; }

        static TelegrambotController()
        {
            botClient = new(System.IO.File.ReadAllText("token.cfg"));

            quickSearcher = new();
            quickImageSearcher = new(false);

            _lock = new();
        }

        [HttpPost]
        [Route("telegram/process")]
        public async Task<IActionResult> ProcessUpdate([FromBody] Update update)
        {
            try
            {
                if (update.Type == UpdateType.Message && update.Message != null)
                {
                    if (update.Message.Type == MessageType.Text && update.Message.Text != null)
                    {
                        if (quickSearcher.ContainsObscene(update.Message.Text.ToLowerInvariant()))
                        {
                            await botClient.DeleteMessageAsync(update.Message.Chat.Id, update.Message.MessageId);
                        }
                    }
                    else if (update.Message.Type == MessageType.Sticker && update.Message.Sticker != null)
                    {
                        var fileInfo = await botClient.GetFileAsync(update.Message.Sticker.FileId);
                        var stream = new MemoryStream();
                        await botClient.DownloadFileAsync(fileInfo.FilePath ?? "", stream);
                        if (quickImageSearcher.ContainsObsense(stream.ToArray()))
                        {
                            await botClient.DeleteMessageAsync(update.Message.Chat.Id, update.Message.MessageId);
                        }
                    }
                }
                else if (update.Type == UpdateType.EditedMessage && update.EditedMessage != null)
                {
                    if (update.EditedMessage.Type == MessageType.Text && update.EditedMessage.Text != null)
                    {
                        if (quickSearcher.ContainsObscene(update.EditedMessage.Text.ToLowerInvariant()))
                        {
                            await botClient.DeleteMessageAsync(update.EditedMessage.Chat.Id, update.EditedMessage.MessageId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lock (_lock)
                {
                    var textForEx = DateTime.UtcNow.AddHours(7).ToString("dd'.'MM'.'yyyy' 'ss':'mm':'HH") + " | " + ex.GetType().ToString() + Environment.NewLine + ex.Message + Environment.NewLine;
                    System.IO.File.AppendAllText("errors.log", textForEx);
                }
            }
            return Ok();
        }
    }
}
