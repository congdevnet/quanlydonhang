namespace WebQuanLyBanHang.Models
{
    public interface IProvincesService
    {
        List<Provincescs> GetAll();
        List<Provincescs> GetCity();
        List<Provincescs> GetDistrict();
        List<Provincescs> GetWard();
        List<Provincescs> GetDistrict(int city);
        List<Provincescs> GetWard(int district);
        string GetProvincescs(string address, int? city,
            int? district, int? ward);
    }
}
