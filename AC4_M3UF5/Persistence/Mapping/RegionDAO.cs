using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AC4_M3UF5.DTOs;
using AC4_M3UF5.Persistence.DAO;

namespace AC4_M3UF5.Persistence.Mapping
{
    public class RegionDAO : IRegionDAO
    {
        private readonly string connectionString;
        public RegionDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<RegionDTO> GetRegionByCode(int code)
        {
            throw new NotImplementedException();
        }

        public void InsertRegion(RegionDTO region)
        {
            throw new NotImplementedException();
        }
    }
}
