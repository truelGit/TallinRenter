﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using WebApplication1.Models.Commands;

namespace TelegramBot.Models.Commands
{
	public class TimeCommand : Command
	{
		public override string Name => @"time";

		public override bool Contains(Message message)
		{
			if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
				return false;

			return message.Text.Contains(this.Name);
		}

		public override async Task Execute(Message message, TelegramBotClient client)
		{
			var chatId = message.Chat.Id;
			await client.SendTextMessageAsync(chatId, DateTime.Now.ToString(), parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
		}
	}
}
