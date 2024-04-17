using Microsoft.Extensions.Configuration;
using Npgsql;
using AC4_M3UF5.DTOs;

namespace AC4_M3UF5.Persistence.Utils
{
    public class NpgsqlUtils
    {
        /*public static string OpenConnection()
        {
            // Carregar la cadena de connexió a la base de dades des de l'arxiu de configuració
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(@"\dao\dao\appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return config.GetConnectionString("MyPostgresConn");
        }*/

        public static RegionDTO GetContact(NpgsqlDataReader reader)
        {
            RegionDTO region = new RegionDTO
            {
                Year = reader.GetInt32(0),
                Code = reader.GetInt32(1),
                Name = reader.GetString(2),
                Population = reader.GetInt32(3),
                DomesticConsum = reader.GetInt32(4),
                EconomyConsum = reader.GetInt32(5),
                TotalConsum = reader.GetInt32(6),
                ConsumCapita = reader.GetFloat(7)
            };
            return region;
        }
    }
}
