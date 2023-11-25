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
            MainView mainView = new MainView();
            
            try
            {
                Website website = new Website
                {
                    City = textBoxCityName.Text,
                    Id = Convert.ToInt32(TextboxId.Text),
                    Url = textBoxURL.Text
                };

                if (!website.Url.StartsWith("https://www.yr.no/"))
                {
                    throw new ArgumentException("Website does not start with yr.no");
                }

                mainView.AddWebsiteToList(website);
                mainView.Show();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error trying to convert input from textfields, Id must be a number");
            }
            catch
            {
                MessageBox.Show("website must start with: https://www.yr.no/");
            }
            finally
            {
                textBoxCityName.Text = string.Empty;
                textBoxURL.Text = string.Empty;
                TextboxId.Text = string.Empty;
            }
        }
    }
}
