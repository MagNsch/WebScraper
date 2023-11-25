using DataAccess.Model;
using HtmlAgilityPack;

namespace DataAccess;

public interface IWebscraperDataAccess
{
    Task<HtmlDocument> Htmlpackage(Website website);
    Task<string> Scrapesite(HtmlDocument htmlDocument);
    Task<int> CreateWebsite(Website website);
    Task<string> ScrapeCity(HtmlDocument htmlDocument);
    //Task<string> ScrapeCityInfo(HtmlDocument htmlDocument);
}
