using DataAccess.Model;

namespace WebscraperUI
{
    public partial class CreateCity : Form
    {
        public CreateCity()
        {
            InitializeComponent();
        }

        private void CreateCityButton_Click(object sender, EventArgs e)
        {
            Website website = new Website
            {
                City = textBoxCityName.Text,
                Id = Convert.ToInt32(TextboxId.Text),
                Url = textBoxURL.Text
            };
            MainView mainView = new MainView();
            mainView.AddWebsiteToList(website);
            mainView.Show();

        }
    }
}
