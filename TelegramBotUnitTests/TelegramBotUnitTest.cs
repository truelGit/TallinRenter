using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelegramBot.Models.Commands;
using TelegramBot.Models;

namespace TelegramBotUnitTests
{
	[TestClass]
	public class TelegramBotUnitTest
	{
		decimal kvartPlataValue = 1;
		decimal electricityValue = 2;
		decimal gasValue = 3;
		string messageText;

		public TelegramBotUnitTest()
		{
			messageText = $"rent kvarplata {kvartPlataValue} electricity {electricityValue} gas {gasValue}";
		}

		[TestMethod]
		public void CheckKvarplata()
		{
			string messageText = $"rent kvarplata {kvartPlataValue}";

			var value = RentHelper.GetValue(messageText, Constants.KvarplataKeyword);

			Assert.AreEqual(value, kvartPlataValue);
		}


		[TestMethod]
		public void CheckElectricity()
		{
			string messageText = $"rent electricity {electricityValue}";

			var value = RentHelper.GetValue(messageText, Constants.ElectricityKeyword);

			Assert.AreEqual(value, electricityValue);
		}

		[TestMethod]
		public void CheckGas()
		{
			string messageText = $"rent gas {gasValue}";

			var value = RentHelper.GetValue(messageText, Constants.GasKeyword);

			Assert.AreEqual(value, gasValue);
		}

		[TestMethod]
		public void CheckKvarplataElectricityAndGas()
		{
			var kvartPlataEvaluatedValue = RentHelper.GetValue(messageText, Constants.KvarplataKeyword);
			var electricityEvaluatedValue = RentHelper.GetValue(messageText, Constants.ElectricityKeyword);
			var gasEvaluatedValue = RentHelper.GetValue(messageText, Constants.GasKeyword);

			Assert.AreEqual(kvartPlataEvaluatedValue, kvartPlataValue);
			Assert.AreEqual(electricityEvaluatedValue, electricityValue);
			Assert.AreEqual(gasEvaluatedValue, gasValue);
		}

		[TestMethod]
		public void GenerateAnswerToUser()
		{
			string expectedAnswer = $"Привет, расчет за {RentHelper.GetPreviuosMonth()} : аренда 22000 + кварплата 1 + электричество 2 + газ 3 = 22006";

			var answer = RentHelper.EvaluateMessage(messageText);
			Assert.AreEqual(answer, expectedAnswer);
		}
	}
}
