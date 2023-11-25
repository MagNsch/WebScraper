using HtmlAgilityPack;

namespace Webscraper;

public class GetWebscraper
{

    //Does not work -
    private static async Task<HtmlDocument> Htmlpackage(string url)
    {
        var httpClient = new HttpClient();

        var html = await httpClient.GetStringAsync(url);

        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);

        return htmlDocument;
    }


    public static async Task YrNoWebscrape()
    {
        Console.WriteLine("1. Torshavn");
        Console.WriteLine("2. Aalborg");
        Console.WriteLine("3. København");
        Console.WriteLine("4. Skælskør");
        Console.Write("Vælg et tal: ");

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
        var getHighestTemperature = htmlDocument.DocumentNode.Descendants("span").Where(node =>
                node.GetAttributeValue("class", "")
                    .Split(' ')
                    .Contains("temperature") &&
                node.GetAttributeValue("class", "").Contains("min-max-temperature__max") &&
                (node.GetAttributeValue("class", "").Contains("temperature--warm") ||
                 node.GetAttributeValue("class", "").Contains("temperature--cold"))
            ).ToList();

        var getLowestTemperature = htmlDocument.DocumentNode.Descendants("span").Where(node => node.GetAttributeValue("class", "").Contains("temperature min-max-temperature__min temperature--warm")).ToList();
        var getCity = htmlDocument.DocumentNode.Descendants("h1").Where(node => node.GetAttributeValue("class", "page-header__location").Contains(""));

        var getWindyWeather = htmlDocument.DocumentNode.Descendants("span").Where(node => node.GetAttributeValue("class", "").Contains("wind daily-weather-list-item__wind-value"))
        .Select(node => node.InnerText.Trim())
        .Select(value =>
        {
            int index = value.IndexOf("0");
            if (index >= 0) { return value.Remove(index, 1); } // Fjern den første forekomst af "0"
            return value;
        }).DefaultIfEmpty("null").ToList();

        var getIfItsRaining = htmlDocument.DocumentNode.Descendants("span")
        .Where(node => node.GetAttributeValue("class", "daily-weather-list-item__precipitation").Contains("Precipitation-module__main-sU6qN"))
        .Select(node => node.InnerText.Trim())
        .DefaultIfEmpty("0")
        .ToList();


        var getCityInfo = htmlDocument.DocumentNode.Descendants("span").Where(node => node.GetAttributeValue("class", "").Contains("page-header__location-details"));


        //Starts printing

        Console.WriteLine();

        foreach (var item in getCity) { Console.WriteLine(item.InnerText.Trim()); Console.WriteLine(); }

        foreach (var item in getCityInfo) { Console.WriteLine(item.InnerText.Trim()); Console.WriteLine(); }


        if (getDate.Count == getHighestTemperature.Count && getLowestTemperature.Count == getDate.Count && getWindyWeather.Count == getDate.Count)
        {
            for (int i = 0; i < getDate.Count; i++)
            {
                string getAllDataFromWebsiteAndPrint = $"{getDate[i].InnerText.Trim().PadRight(20)} " +
                $"Højeste Temperatur i dag: {getHighestTemperature[i].InnerText.Trim().PadRight(5)} " +
                $"Laveste temperatur i dag: {getLowestTemperature[i].InnerText.Trim().PadRight(5)} " +
                $"Blæser i dag: {getWindyWeather[i].PadLeft(2)}" + "    " +
                $"Regn i dag: {getIfItsRaining[i].PadLeft(10)}";

                Console.Out.WriteLine(getAllDataFromWebsiteAndPrint);

            }
        }
    }

    //Does not work - 
}