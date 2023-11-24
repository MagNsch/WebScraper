using DataAccess;
using DataAccess.Model;

namespace WebscraperUI;

public partial class MainView : Form
{
    static List<Website> websites = new List<Website>();
    IWebscraperDataAccess _webScraperDataAccess = new WebscraperDataAccess();
    public MainView()
    {
        InitializeComponent();
        List<Website> list = new List<Website>();
        CreateWebsites();
    }

    private void CreateWebsites()
    {

        Website website = new Website() { Id = 1, City = "Skælskør", Url = "https://www.yr.no/nb/v%C3%A6rvarsel/daglig-tabell/2-2613694/Danmark/Region%20Sj%C3%A6lland/Slagelse/Sk%C3%A6lsk%C3%B8r" };
        Website website2 = new Website() { Id = 2, City = "Aalborg", Url = "https://www.yr.no/nb/v%C3%A6rvarsel/daglig-tabell/2-2624886/Danmark/Nordjylland/%C3%85lborg/Aalborg" };

        websites.Add(website);
        websites.Add(website2);

        Websites_List.Items.Clear();

        foreach (var item in websites)
        {
            Websites_List.Items.Add(item);
        }
    }

    private async void ListBox_websites_SelectedIndexChanged(object sender, EventArgs e)
    {
        await SelectItem();
    }

    private async Task SelectItem()
    {
        int selectedIndex = Websites_List.SelectedIndex;

        if (selectedIndex != -1)
        {

            Website website = (Website)Websites_List.SelectedItem;
            var htmldoc = await _webScraperDataAccess.Htmlpackage(website);
            string city = await _webScraperDataAccess.ScrapeCity(htmldoc);
            string cityInfo = await _webScraperDataAccess.ScrapeCityInfo(htmldoc);
            string cityWeather = await _webScraperDataAccess.Scrapesite(htmldoc);
            CityLabel.Text = city;
            CityInfo.Text = cityInfo;
            Weather_label.Text = cityWeather;
        }



    }
}