using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Collections.Generic;

namespace WorldPollution.Model
{
    class CountryDataService
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        private static IDbConnection db = new SqlConnection(connectionString);

        public List<Country> GetCountries()
        {
            string sql = "select * from Country";

            return (List<Country>)db.Query<Country>(sql);
        }

        public void UpdateCountry(Country country)
        {
            string sql = "update Country set Name = @Name, ContinentId = @ContinentId, CountryCode = @CountryCode, Population = @Population, Area = @Area, Industry = @Industry, Agriculture = @Agriculture, PopDensity = @PopDensity, Literacy= @Literacy where Id = @Id";

            db.Execute(sql, new { country.Name, country.ContinentId, country.CountryCode, country.Population, country.Area, country.Industry, country.Agriculture, country.PopDensity, country.Literacy, country.ID });
        }

        public void InsertCountry(Country country)
        {
            string sql = "insert into Country values (@Name, @ContinentId, @CountryCode, @Population, @Area, @Industry, @Agriculture, @PopDensity, @Literacy)";

            db.Execute(sql, new { country.Name, country.ContinentId, country.CountryCode, country.Population, country.Area, country.Industry, country.Agriculture, country.PopDensity, country.Literacy });
        }

        public void DeleteCountry(Country country)
        {
            string sql = "Delete Country where Id = @Id";

            db.Execute(sql, new { country.ID });
        }

        public bool FindDoubleCountry(Country country)
        {
            string sql = "Select * from Country where Name = @Name";

            List<Country> countries = new List<Country>();

            countries = (List<Country>)db.Query<Country>(sql, new { country.Name });

            if (countries.Count == 0) {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
