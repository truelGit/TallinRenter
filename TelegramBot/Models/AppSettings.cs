using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public static class AppSettings
	{
		public static string Url { get; set; } = "https://webapplication120190706115457.azurewebsites.net:443/{0}";
		//https://telegrambotapp.azurewebsites.net:443/{0}
		public static string Name { get; set; } = "TallinRenterBot";
		public static string Key { get; set; } = "745956783:AAHxGgCHQJbCGc2PumKK1vv8Oy8SCgSQEPc";
	}
}
