using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Collections.Generic;

namespace WorldPollution.Model
{
    class ContinentPollutionDataService
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        private static IDbConnection db = new SqlConnection(connectionString);

        public List<ContinentPollution> GetContinentPollution(int continentID)
        {
            string sql = "select * from ContinentPollution where ContinentId = @continentID order by Year";

            return (List<ContinentPollution>)db.Query<ContinentPollution>(sql, new { continentID });
        }

        public void UpdateContinentPollution(ContinentPollution continentPollution)
        {
            string sql = "update ContinentPollution set Pollution = @Pollution, Year = @Year, ContinentId = @ContinentId where Id = @Id";

            db.Execute(sql, new { continentPollution.Pollution, continentPollution.Year, continentPollution.ContinentId, continentPollution.ID});
        }

        public void InsertContinentPollution(ContinentPollution continentPollution)
        {
            string sql = "insert into ContinentPollution values (@ContinentId,@Year,@Pollution)";

            db.Execute(sql, new { continentPollution.ContinentId,continentPollution.Year,continentPollution.Pollution });
        }

        public void DeleteContinentPollution(ContinentPollution continentPollution)
        {
            string sql = "Delete ContinentPollution where Id = @Id";

            db.Execute(sql, new { continentPollution.ID });
        }


    }
}
