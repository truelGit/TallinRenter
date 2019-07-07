using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using WebApplication1.Models.Commands;

namespace TelegramBot.Models.Commands
{
	public class EchoCommand : Command
	{
		public override string Name => @"/echo";

		public override bool Contains(Message message)
		{
			if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
				return false;

			return message.Text.Contains(this.Name);
		}

		public override async Task Execute(Message message, TelegramBotClient client)
		{
			var chatId = message.Chat.Id;
			var chatMessage = message.Text;
			await client.SendTextMessageAsync(chatId, chatMessage, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
		}
	}
}
