using DataAccess.Model;
using DataAccess.SQLDataAccessL;
using System.Data.SqlClient;

namespace DataAccess.SQLDataAccess;
public class WebsiteDataAccess : IWebsiteDataAccess
{
    private readonly string _conString;

    public WebsiteDataAccess()
    {
        _conString = @"Data Source =.\SQLEXPRESS; Initial Catalog = WeatherApp; Integrated Security = True";
    }

    public int CreateWebsite(Website website)
    {
        using SqlConnection sqlConnection = new SqlConnection(_conString);

        string QueryStringCreateWebsite = "";


        sqlConnection.Open();

        SqlCommand sqlCommand = new SqlCommand();


        return 1;
    }

    public IEnumerable<Website> GetAllWebsites()
    {
        using SqlConnection sqlConnection = new SqlConnection(_conString);

        string queryGetAllWebsites = "SELECT * FROM Website";
        SqlCommand sqlCommand = new SqlCommand(queryGetAllWebsites, sqlConnection);
        


        

        List<Website> websitesList = new List<Website>();

        try
        {
            sqlConnection.Open();
        }
        catch (Exception)
        {

            throw new Exception("Connection not establisthed");
        }
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        try
        {
            while (sqlDataReader.Read())
            {
                Website website = new Website()
                {
                    Id = (int)sqlDataReader["Id"],
                    City = (string)sqlDataReader["City"],
                    Url = (string)sqlDataReader["URL"]
                };
                websitesList.Add(website);
                
            }
            return websitesList;
        }
        catch (Exception)
        {
           throw new Exception("Could not read any lines");
        }

    }

    public Website GetWebsiteById(int id)
    {
        throw new NotImplementedException();
    }

    public Website UpdateWebsite(Website website)
    {
        throw new NotImplementedException();
    }
}
