using DataAccess;
using DataAccess.Model;
using DataAccess.SQLDataAccess;
using DataAccess.SQLDataAccessL;

namespace WebscraperUI;

public partial class MainView : Form
{
    static List<Website> websites = new List<Website>();

    IWebsiteDataAccess _websiteDataAccess = new WebsiteDataAccess();
    IWebscraperDataAccess _webScraperDataAccess = new WebscraperDataAccess();
    public MainView()
    {
        InitializeComponent();
        CreateWebsites();

    }
    public void AddWebsiteToList(Website website)
    {
        websites.Add(website);

        Websites_List.DataSource = websites;
    }

    private void CreateWebsites()
    {
        //Website website = new Website() { Id = 1, City = "Skælskør", Url = "https://www.yr.no/nb/v%C3%A6rvarsel/daglig-tabell/2-2613694/Danmark/Region%20Sj%C3%A6lland/Slagelse/Sk%C3%A6lsk%C3%B8r" };
        //Website website2 = new Website() { Id = 2, City = "Aalborg", Url = "https://www.yr.no/nb/v%C3%A6rvarsel/daglig-tabell/2-2624886/Danmark/Nordjylland/%C3%85lborg/Aalborg" };

        //if (!websites.Any(w => w.Id == website.Id))
        //{
        //    websites.Add(website);
        //}

        //// Samme kontrol for det andet websted
        //if (!websites.Any(w => w.Id == website2.Id))
        //{
        //    websites.Add(website2);
        //}

        //Websites_List.Items.Clear();
        var websites = _websiteDataAccess.GetAllWebsites();

        foreach (var item in websites)
        {
            Websites_List.Items.Add(item);
        }
        
        if (websites.Any())
        {
            Websites_List.SelectedIndex = 0;
        }
        else
        {
            Websites_List = null;
        }


        // Starter programmet med det første element, hvis listen ikke er tom
        //if (websites.Count > 0)
        //{
        //    Websites_List.SelectedIndex = 0;
        //}
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
            //string cityInfo = await _webScraperDataAccess.ScrapeCityInfo(htmldoc);
            string cityWeather = await _webScraperDataAccess.Scrapesite(htmldoc);
            CityLabel.Text = city;
            //CityInfo.Text = cityInfo;
            Weather_label.Text = cityWeather;
        }



    }

    private void ButtonCreate_Click(object sender, EventArgs e)
    {
        OpenViewCreate();
    }

    private void OpenViewCreate()
    {
        CreateCity createCity = new CreateCity();
        createCity.Show();
    }
}