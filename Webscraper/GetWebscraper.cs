using HtmlAgilityPack;

namespace Webscraper;

public class GetWebscraper
{

    private static async Task<HtmlDocument> Htmlpackage(string url)
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(url);
        var html = await httpClient.GetStringAsync(url);

        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);
        return htmlDocument;
    }


    public static async Task YrNoWebscrape()
    {

        Console.WriteLine("Vælg et tal:");
        Console.WriteLine("1. Torshavn");
        Console.WriteLine("2. Aalborg");
        Console.WriteLine("3. København");
        Console.WriteLine("4. Skælskør");

        string urlToScrape = "";
        int city = Convert.ToInt32(Console.ReadLine());

        switch (city)
        {
            case 1:
                urlToScrape = "https://www.yr.no/nb/v%C3%A6rvarsel/daglig-tabell/2-2611396/F%C3%A6r%C3%B8yene/Streymoyar%20S%C3%BDsla/T%C3%B3rshavn/T%C3%B3rshavn";
                break;
            case 2:
                urlToScrape = "https://www.yr.no/nb/v%C3%A6rvarsel/daglig-tabell/2-2624886/Danmark/Nordjylland/%C3%85lborg/Aalborg";
                break;
            case 3:
                urlToScrape = "https://www.yr.no/nb/v%C3%A6rvarsel/daglig-tabell/2-2618425/Danmark/Region%20Hovedstaden/K%C3%B8benhavn/K%C3%B8benhavn";
                break;
            case 4:
                urlToScrape = "https://www.yr.no/nb/v%C3%A6rvarsel/daglig-tabell/2-2613694/Danmark/Region%20Sj%C3%A6lland/Slagelse/Sk%C3%A6lsk%C3%B8r";
                break;
            case 5:
                break;
            default:
                Console.WriteLine("Ugyldig website valgt.");
                return;
        }

        HtmlDocument htmlDocument = await Htmlpackage(urlToScrape);

        await Scrapesite(htmlDocument);

    }

    private static async Task Scrapesite(HtmlDocument htmlDocument)
    {
        var getDate = htmlDocument.DocumentNode.Descendants("h3").Where(node => node.GetAttributeValue("class", "").Contains("daily-weather-list-item__date-heading")).ToList();
        var getTemperature = htmlDocument.DocumentNode.Descendants("span").Where(node => node.GetAttributeValue("class", "").Contains("temperature min-max-temperature__max temperature--warm")).ToList();
        var getCity = htmlDocument.DocumentNode.Descendants("h1").Where(node => node.GetAttributeValue("class", "page-header__location").Contains(""));
        var getCityInfo = htmlDocument.DocumentNode.Descendants("span").Where(node => node.GetAttributeValue("class", "").Contains("page-header__location-details"));

        foreach (var item in getCity) { await Console.Out.WriteLineAsync(item.InnerText.Trim()); await Console.Out.WriteLineAsync(); }

        foreach (var item in getCityInfo) { await Console.Out.WriteLineAsync(item.InnerText.Trim()); await Console.Out.WriteLineAsync(); }

        if (getDate.Count == getTemperature.Count)
        {
            for (int i = 0; i < getDate.Count; i++)
            {
                Console.WriteLine(getDate[i].InnerText.Trim() + " Temperatur: " + getTemperature[i].InnerText.Trim());
            }
        }
    }
}