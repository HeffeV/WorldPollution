using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Collections.Generic;

namespace WorldPollution.Model
{
    class CountryPollutionDataService
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        private static IDbConnection db = new SqlConnection(connectionString);

        public List<CountryPollution> GetCountryPollution(int countryID)
        {
            string sql = "select * from CountryPollution where Countryid = @countryID order by Year";

            return (List<CountryPollution>)db.Query<CountryPollution>(sql, new { countryID });
        }

        public void UpdateCountryPollution(CountryPollution countryPollution)
        {
            if(countryPollution.ID != 0)
            {
                string sql = "update CountryPollution set Pollution = @Pollution, Year = @Year, CountryId = @CountryId where Id = @Id";

                db.Execute(sql, new { countryPollution.Pollution, countryPollution.Year, countryPollution.CountryId, countryPollution.ID });
            }
        }

        public void InsertCountryPollution(CountryPollution countryPollution)
        {
            string sql = "insert into CountryPollution values (@CountryId,@Year,@Pollution)";

            db.Execute(sql, new { countryPollution.CountryId,countryPollution.Year, countryPollution.Pollution });
        }

        public void DeleteCountryPollution(CountryPollution countryPollution)
        {
            string sql = "Delete CountryPollution where Id = @Id";

            db.Execute(sql, new { countryPollution.ID });
        }
    }
}
