using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Api.TelegramBot;

namespace WebAPIClient
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
        	Bot bot = new Bot("5557152628:AAFnBaIo0MSXeae8KCa02lr_a7nLXX7NioU");

            var rep = await bot.GetUpdates();
            // var res = await bot.GetMe();
            // Console.WriteLine(res.first_name);
            // Console.WriteLine("@"+res.username);
            // Console.WriteLine(res.Id);
            
            // foreach(var up in rep)
            // {
            // 	Console.WriteLine($"{up.Message.from.first_name} -> {up.Message.text}");
            // }
            // // Console.WriteLine(rep.Ok);
            
            await bot.SendMessage(chat_id:1305481132, text:"<b>teste</b>", parse_mode:"html");
            await bot.Run();
        }
    }
}