﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	[Route("api/message/update")]
	public class MessageController : Controller
	{
		// GET api/values
		[HttpGet]
		public string Get()
		{
			return "Method GET unuvalable";
		}

		// POST api/values
		[HttpPost]
		public async Task<OkResult> Post([FromBody]Update update)
		{
			if (update == null) return Ok();

			var commands = Bot.Commands;
			var message = update.Message;
			var botClient = await Bot.GetBotClientAsync();

			foreach (var command in commands)
			{
				if (command.Contains(message))
				{
					await command.Execute(message, botClient);
					break;
				}
			}
			return Ok();
		}
	}
}
