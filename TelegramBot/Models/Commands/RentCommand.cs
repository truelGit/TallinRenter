using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using WebApplication1.Models.Commands;
using Telegram.Bot.Types;

namespace TelegramBot.Models.Commands
{
	public class RentCommand : Command
	{
		public override string Name => @"rent";

		public override bool Contains(Message message)
		{
			if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
				return false;

			return message.Text.Contains(this.Name);
		}

		public override async Task Execute(Message message, TelegramBotClient client)
		{
			var chatId = message.Chat.Id;
			var messageText = message.Text;

			await client.SendTextMessageAsync(chatId, RentHelper.EvaluateMessage(messageText), Telegram.Bot.Types.Enums.ParseMode.Default);
		}
	}
}
