﻿using DataAccess.Model;
using HtmlAgilityPack;
using System.Runtime;

namespace DataAccess;

public class WebscraperDataAccess : IWebscraperDataAccess
{
    public Task<int> CreateWebsite(Website website)
    {
        throw new NotImplementedException();
    }

    public async Task<HtmlDocument> Htmlpackage(Website website)
    {
        var httpClient = new HttpClient();

        var html = await httpClient.GetStringAsync(website.Url);

        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);

        return htmlDocument;
    }

    public Task<string> Scrapesite(HtmlDocument htmlDocument)
    {
        var getDate = htmlDocument.DocumentNode.Descendants("h3").Where(node => node.GetAttributeValue("class", "").Contains("daily-weather-list-item__date-heading")).ToList();
        var getHighestTemperature = htmlDocument.DocumentNode.Descendants("span").Where(node => node.GetAttributeValue("class", "").Contains("temperature min-max-temperature__max temperature--warm")).ToList();
        var getLowestTemperature = htmlDocument.DocumentNode.Descendants("span").Where(node => node.GetAttributeValue("class", "").Contains("temperature min-max-temperature__min temperature--warm")).ToList();
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

        var allDataList = new List<string>();
        for (int i = 0; i < getDate.Count; i++)
        {
            string dateText = $"{getDate[i].InnerText.Trim()}".PadRight(18);
            string maxTempText = $"Højeste Temperatur i dag: {getHighestTemperature[i].InnerText.Trim()}".PadRight(30);
            string minTempText = $"Laveste temperatur i dag: {getLowestTemperature[i].InnerText.Trim()}".PadRight(30);
            string windyText = $"Blæser i dag: {getWindyWeather[i]}".PadRight(20);
            string rainText = $"Regn i dag: {getIfItsRaining[i]}".PadRight(30);

            string getAllDataFromWebsiteAndPrint = $"{dateText}{maxTempText}{minTempText}{windyText}{rainText}";
            allDataList.Add(getAllDataFromWebsiteAndPrint);
        }

        string allDataAsString = string.Join(Environment.NewLine, allDataList);
        return Task.FromResult(allDataAsString);
    }


    public Task<string> ScrapeCity(HtmlDocument htmlDocument)
    {
        var allDataList = new List<string>();
        var getCity = htmlDocument.DocumentNode.Descendants("h1").Where(node => node.GetAttributeValue("class", "page-header__location").Contains(""));
        foreach (var item in getCity)
        {
            string city = item.InnerText.Trim();
            allDataList.Add(city);
            string allDataAsString = string.Join(Environment.NewLine, allDataList);
            return Task.FromResult(allDataAsString);
            
        }
        return Task.FromResult(string.Empty);
    }

    public Task<string> ScrapeCityInfo(HtmlDocument htmlDocument)
    {
        var allDataList = new List<string>();
        var getCityInfo = htmlDocument.DocumentNode.Descendants("span").Where(node => node.GetAttributeValue("class", "").Contains("page-header__location-details"));
        if (getCityInfo != null)
        {
            foreach (var item in getCityInfo)
            {
                string cityInfo = item.InnerText.Trim();
                allDataList.Add(cityInfo);
                string allDataAsString = string.Join(Environment.NewLine, allDataList);
                return Task.FromResult(allDataAsString);
            }
        }
        return Task.FromResult(string.Empty);
    }
}
