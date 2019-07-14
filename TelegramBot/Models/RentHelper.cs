using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramBot.Models
{
	public static class RentHelper
	{
		public static string GetPreviuosMonth()
		{
			return DateTime.Now.AddMonths(-1).ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("ru-RU"));
		}

		public static string EvaluateMessage(string messageText)
		{
			var keyWords = new[]
			{
				Constants.KvarplataKeyword,
				Constants.ElectricityKeyword,
				Constants.GasKeyword
			};

			if (keyWords.Any(k => messageText.Contains(k)))
			{
				var kvarplata = GetValue(messageText, Constants.KvarplataKeyword);
				var electricity = GetValue(messageText, Constants.ElectricityKeyword);
				var gas = GetValue(messageText, Constants.GasKeyword);
				var total = Constants.RentPrice + kvarplata + electricity + gas;

				return $"Привет, расчет за {GetPreviuosMonth()} : аренда {Constants.RentPrice} + кварплата {kvarplata} + электричество {electricity} + газ {gas} = {total}";
			}
			else
				return "Привет, пример правильной комманды rent kvarplata 11 electricity 2 gas 4";
		}

		public static decimal GetValue(string text, string keyWord)
		{
			decimal value = 0;

			try
			{
				var rightPartFromKeyWord = text.Split(keyWord)[1].Trim();

				if (!string.IsNullOrWhiteSpace(rightPartFromKeyWord))
				{
					value = decimal.Parse(rightPartFromKeyWord.Split(' ')[0].Trim());
				}
			}
			catch (Exception ex)
			{

			}

			return value;
		}
	}
}
