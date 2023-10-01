using DataAccess;
using Webscraper;

namespace ConsoleApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        await GetWebscraper.YrNoWebscrape();


        GuessingGame game = new GuessingGame();

        //game.Game();
    }
}
