using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Collections.Generic;

namespace WorldPollution.Model
{
    public class ContinentDataService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        private static IDbConnection db = new SqlConnection(connectionString);

        public List<Continent> GetContinenten()
        {
            string sql = "select * from Continent order by Name";

            return (List<Continent>)db.Query<Continent>(sql);
        }

        public void UpdateContinent(Continent continent)
        {
            string sql = "update Continent set name = @name where id = @id";

            db.Execute(sql, new { continent.Name, continent.ID });
        }

        public void InsertContinent(Continent continent)
        {
            string sql = "insert into Continent values (@name)";

            db.Execute(sql, new { continent.Name });
        }

        public void DeleteContinent(Continent continent)
        {
            string sql = "Delete Continent where id = @id";

            db.Execute(sql, new { continent.ID });
        }

        public bool FindDoubleContinent(Continent continent)
        {
            string sql = "Select * from Continent where Name = @Name";

            List<Continent> continents = new List<Continent>();

            continents = (List<Continent>)db.Query<Continent>(sql, new { continent.Name });

            if (continents.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
