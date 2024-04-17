using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC3_M3UF5.CodeAC2
{
    public class QueryMethods
    {
        public static List<Region> SelectRegionByPopulation(List<Region> regions, int population)
        {
            var result = regions.Where(region => region.Population > population).ToList();

            return result;
        }

        public static List<(string Name, float Average)> AverageDomesticConsumption(List<Region> regions)
        {
            /*  
             * Per consum domestic mitjà per comarca, he entes que demana la mitjana de tots els consums 
             * domestics d'una mateixa comarca, durant els diferents anys. Per tant, he agrupat per comarca
             * i he utilitzat la funció Average per calcular la mitjana.
             */
            var linqQuery = from region in regions
                            group region by region.Name into regionGroup
                            select
                            (
                                Name: regionGroup.Key,
                                Average: (float)regionGroup.Average(region => region.DomesticConsum)
                            );

            return linqQuery.ToList();
        }

        public static List<Region> SelectRegionByHigherConsumCapita(List<Region> regions)
        {
            /* 
             * Com que no s'ha indicat un limit de regions a mostrar, he decidit ordenarles de manera
             * descendent, d'aquesta manera els que tenen major consum estaran al principi. 
             */
            var descOrder = regions.OrderByDescending(region => region.ConsumCapita).ToList();

            return descOrder;
        }

        public static List<Region> SelectRegionByLowerConsumCapita(List<Region> regions)
        {
            /*
             * Lo mateix que el cas anterior pero aquesta de forma ascendent, mostrant els que menys 
             * consum tenen al principi.
             */
            var ascOrder = regions.OrderBy(region => region.ConsumCapita).ToList();

            return ascOrder;
        }

        public static List<Region> SelectRegionByNameOrCode(List<Region> regions, string filter)
        {
            //Jo he entes que amb només contenir el filtre, ja es mostraria, i que no ha de ser exactament igual.

            var linqQuery = from region in regions
                            where region.Name.Contains(filter.ToUpper()) || region.Code.ToString().Contains(filter)
                            select region;

            return linqQuery.ToList();
        }



        //NOUS FUNCIONS PER L'AC3:

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