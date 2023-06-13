namespace WebQuanLyBanHang.Models
{
    public class ProvincesService : IProvincesService
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public ProvincesService(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public List<Provincescs> GetAll()
        {
            return ProvincesvnService.LoadXml(this._environment.WebRootPath, @"/dvhc_data.xml");
        }

        public List<Provincescs> GetCity()
        {
            List<Provincescs> provincescs = new List<Provincescs>();
            var data = GetAll();
            provincescs = data.Where(x => x.CapTren == 0).ToList();
            return provincescs;
        }

        public List<Provincescs> GetDistrict(int city)
        {
            List<Provincescs> provincescs = new List<Provincescs>();
            var data = GetAll();
            provincescs = data.Where(x => x.CapTren == city && x.Cap == "HUYEN").ToList();
            return provincescs;
        }

        public List<Provincescs> GetDistrict()
        {
            List<Provincescs> provincescs = new List<Provincescs>();
            var data = GetAll();
            provincescs = data.Where(x => x.Cap == "HUYEN").ToList();
            return provincescs;
        }

        public string GetProvincescs(string address,int? city, int? district, int? ward)
        {
            var data = GetAll();
            string namecity = data.FirstOrDefault(x => x.MaDVHC == city).Ten;
            string namedistrict = data.FirstOrDefault(x => x.MaDVHC == district).Ten;
            string nameward = data.FirstOrDefault(x => x.MaDVHC == ward).Ten;

            return address+" ,"+ nameward + " - "
                + namedistrict +" - "+ namecity;
        }

        public List<Provincescs> GetWard(int district)
        {
            List<Provincescs> provincescs = new List<Provincescs>();
            var data = GetAll();
            provincescs = data.Where(x => x.CapTren == district && x.Cap == "XA").ToList();
            return provincescs;
        }

        public List<Provincescs> GetWard()
        {
            List<Provincescs> provincescs = new List<Provincescs>();
            var data = GetAll();
            provincescs = data.Where(x=>x.Cap == "XA").ToList();
            return provincescs;
        }
    }
}