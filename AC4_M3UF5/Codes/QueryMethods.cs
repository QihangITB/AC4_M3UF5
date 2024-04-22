
namespace AC4_M3UF5.Codes
{
    public class QueryMethods
    {
        private static int OldestYear(List<Region> regions)
        {
            //Aquesta funció retorna l'any més antic de la llista de regions.
            return regions.Min(region => region.Year);
        }

        public static object[] ListOfYears(List<Region> regions)
        {
            List<object> years = new List<object>();
            for (int i = OldestYear(regions); i <= 2050; i++)
            {
                years.Add(i);
            }
            return years.ToArray();
        }

        public static List<Region> GroupRegionByCode(List<Region> regions, int code)
        {
            var linqQuery = from region in regions
                            where region.Code == code
                            select region;

            return linqQuery.ToList();
           
        }

        public static bool IsPopulationHigherThan20000(int population)
        {
            return population > 20000;
        }

        public static double AverageDomesticConsum(int population, int domesticNetwork)
        {
            return Math.Round((double)domesticNetwork/population,2);
        }

        public static bool IsHighestConsumCapita(List<Region> regionList, float consumCapita)
        {
            List<Region> descOrder = regionList.OrderByDescending(r => r.ConsumCapita).ToList();
            return descOrder[0].ConsumCapita == consumCapita;
        }

        public static bool IsLowestConsumCapita(List<Region> regionList, float consumCapita)
        {
            List<Region> ascOrder = regionList.OrderBy(r => r.ConsumCapita).ToList();
            return ascOrder[0].ConsumCapita == consumCapita;
        }
    }
}