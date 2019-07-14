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

			if (messageText.Contains(Constants.KvarplataKeyword))
			{
				await client.SendTextMessageAsync(chatId, "Делаю расчет", Telegram.Bot.Types.Enums.ParseMode.Default);
				var kvarplata = GetValue(messageText, Constants.KvarplataKeyword);
				var electricity = GetValue(messageText, Constants.ElectricityKeyword);
				var gas = GetValue(messageText, Constants.GasKeyword);
				var total = 22000 + kvarplata + electricity + gas;
				var text = string.Format("Привет, расчет 22 000 аренда + кварплата {0} + электричество {1} + газ {2} = {3}", kvarplata, electricity, gas, total);
				await client.SendTextMessageAsync(chatId, text, Telegram.Bot.Types.Enums.ParseMode.Default);
			}
			else
				await client.SendTextMessageAsync(chatId, "Привет задай значение кварплата", Telegram.Bot.Types.Enums.ParseMode.Default);
		}

		public static decimal GetValue(string text, string keyWord)
		{
			decimal value = 0;

			try
			{
				var rightPartFromKeyWord = text.Split(keyWord)[1].Trim();

				if(!string.IsNullOrWhiteSpace(rightPartFromKeyWord))
				{
					value = decimal.Parse(rightPartFromKeyWord.Split(' ')[0].Trim());
				}
			}
			catch(Exception ex)
			{

			}

			return value;
		}
	}
}
