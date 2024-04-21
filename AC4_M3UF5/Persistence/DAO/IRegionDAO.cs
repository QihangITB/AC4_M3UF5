using AC4_M3UF5.DTOs;

namespace AC4_M3UF5.Persistence.DAO
{
    public interface IRegionDAO
    {
        void CreateRegionDB();
        RegionDTO GetRegionByCodeAndYear(int code, int year);
        IEnumerable<RegionDTO> GetAllRegions();
        void InsertRegion(RegionDTO region);
    }
}
