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
			const string kvarplataKeyword = "kvarplata";
			var chatId = message.Chat.Id;
			//

			if (message.Text.Contains(kvarplataKeyword))
			{
				await client.SendTextMessageAsync(chatId, "Делаю расчет", Telegram.Bot.Types.Enums.ParseMode.Default);
				var price = message.Text.Split(kvarplataKeyword);
				var kvarplata = decimal.Parse(price[1]);
				var total = 22000 + kvarplata;
				var text = string.Format("Привет, расчет 22 000 аренда + кварплата {0} = {1}", kvarplata, total);
				await client.SendTextMessageAsync(chatId, text, Telegram.Bot.Types.Enums.ParseMode.Default);
			}
			else
				await client.SendTextMessageAsync(chatId, "Привет задай значение кварплата", Telegram.Bot.Types.Enums.ParseMode.Default);
		}
	}
}
