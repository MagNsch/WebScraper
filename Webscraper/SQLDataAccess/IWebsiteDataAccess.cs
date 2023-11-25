using DataAccess.Model;

namespace DataAccess.SQLDataAccessL;

public interface IWebsiteDataAccess
{
    public IEnumerable<Website> GetAllWebsites();
    public Website GetWebsiteById(int id);
    public int CreateWebsite(Website website);
    public Website UpdateWebsite(Website website);
}
