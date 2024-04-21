
using AC4_M3UF5.DTOs;
using AC4_M3UF5.Persistence.DAO;
using AC4_M3UF5.Persistence.Utils;
using Npgsql;

namespace AC4_M3UF5.Persistence.Mapping
{
    public class RegionDAO : IRegionDAO
    {
        private readonly string connectionString;
        public RegionDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateRegionDB()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(),"..\\..\\..\\Codes\\region.sql");
            string sql = File.ReadAllText(path);

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public RegionDTO GetRegionByCodeAndYear(int code, int year)
        {
            RegionDTO region = null;

            using (NpgsqlConnection connection = new NpgsqlConnection(NpgsqlUtils.OpenConnection()))
            {
                string query = "SELECT * FROM \"region\" WHERE Code = @code AND Year = @year";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@code", code);
                command.Parameters.AddWithValue("@year", year);
                connection.Open();

                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // ORM: [--,--,--] -----> RegionDTO
                    region = NpgsqlUtils.GetRegion(reader);
                }
            }

            return region;
        }

        public void InsertRegion(RegionDTO region)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "INSERT INTO \"region\" VALUES (@year, @code, @name, @population, @domesticconsum, @economyconsum, @totalconsum, @consumcapita)";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                command.Parameters.AddWithValue("@year", region.Year);
                command.Parameters.AddWithValue("@code", region.Code);
                command.Parameters.AddWithValue("@name", region.Name ?? string.Empty);
                command.Parameters.AddWithValue("@population", region.Population);
                command.Parameters.AddWithValue("@domesticconsum", region.DomesticConsum);
                command.Parameters.AddWithValue("@economyconsum", region.EconomyConsum);
                command.Parameters.AddWithValue("@totalconsum", region.TotalConsum);
                command.Parameters.AddWithValue("@consumcapita", region.ConsumCapita);

                connection.Open();
                command.ExecuteNonQuery();
            }
            
        }

        public IEnumerable<RegionDTO> GetAllRegions()
        {
            List<RegionDTO> regions = new List<RegionDTO>();
            
            using (NpgsqlConnection connection = new NpgsqlConnection(NpgsqlUtils.OpenConnection()))
            {
                string query = "SELECT * FROM \"region\"";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                connection.Open();

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // ORM: [--,--,--] -----> RegionDTO
                    RegionDTO region = NpgsqlUtils.GetRegion(reader);
                    regions.Add(region);
                }
            }

            return regions;
        }
    }
}
