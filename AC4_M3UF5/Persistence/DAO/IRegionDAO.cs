using AC4_M3UF5.DTOs;

namespace AC4_M3UF5.Persistence.DAO
{
    public interface IRegionDAO
    {
        IEnumerable<RegionDTO> GetRegionByCode(int code);
        void InsertRegion(RegionDTO region);
    }
}
