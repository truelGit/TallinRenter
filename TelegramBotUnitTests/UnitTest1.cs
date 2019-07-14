using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelegramBot.Models.Commands;
using TelegramBot.Models;

namespace TelegramBotUnitTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void CheckKvarplata()
		{
			var kvartPlataValue = 1;
			string messageText = $"rent kvarplata {kvartPlataValue}";

			var value = RentCommand.GetValue(messageText, Constants.KvarplataKeyword);

			Assert.AreEqual(value, kvartPlataValue);
		}


		[TestMethod]
		public void CheckElectricity()
		{
			var electricityValue = 2;
			string messageText = $"rent electricity {electricityValue}";

			var value = RentCommand.GetValue(messageText, Constants.ElectricityKeyword);

			Assert.AreEqual(value, electricityValue);
		}

		[TestMethod]
		public void CheckGas()
		{
			var gasValue = 3;
			string messageText = $"rent gas {gasValue}";

			var value = RentCommand.GetValue(messageText, Constants.GasKeyword);

			Assert.AreEqual(value, gasValue);
		}

		[TestMethod]
		public void CheckKvarplataElectricityAndGas()
		{
			var kvartPlataValue = 1;
			var electricityValue = 2;
			var gasValue = 3;
			string messageText = $"rent kvarplata {kvartPlataValue} electricity {electricityValue} gas {gasValue}";

			var kvartPlataEvaluatedValue = RentCommand.GetValue(messageText, Constants.KvarplataKeyword);
			var electricityEvaluatedValue = RentCommand.GetValue(messageText, Constants.ElectricityKeyword);
			var gasEvaluatedValue = RentCommand.GetValue(messageText, Constants.GasKeyword);

			Assert.AreEqual(kvartPlataEvaluatedValue, kvartPlataValue);
			Assert.AreEqual(electricityEvaluatedValue, electricityValue);
			Assert.AreEqual(gasEvaluatedValue, gasValue);
		}
	}
}
