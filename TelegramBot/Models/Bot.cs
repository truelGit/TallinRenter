﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.Models.Commands;
using WebApplication1.Models.Commands;

namespace WebApplication1.Models
{
	public class Bot
	{
		private static TelegramBotClient botClient;
		private static List<Command> commandsList;

		public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

		public static async Task<TelegramBotClient> GetBotClientAsync()
		{
			if (botClient != null)
			{
				return botClient;
			}

			commandsList = new List<Command>();
			commandsList.Add(new StartCommand());
			commandsList.Add(new EchoCommand());
			commandsList.Add(new TimeCommand());
			commandsList.Add(new RentCommand());

			botClient = new TelegramBotClient(AppSettings.Key);
			string hook = string.Format(AppSettings.Url, "api/message/update");
			await botClient.SetWebhookAsync(hook);
			return botClient;
		}
	}
}
