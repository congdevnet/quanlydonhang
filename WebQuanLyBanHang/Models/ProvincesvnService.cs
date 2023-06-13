using System.Xml;
using System.Xml.Serialization;

namespace WebQuanLyBanHang.Models
{
    public static class ProvincesvnService
    {
        public static List<Provincescs> LoadXml(string path,string namefile)
        {
            List<Provincescs> provincescs = new List<Provincescs>();

            XmlDocument doc = new XmlDocument();
            doc.Load(string.Concat(path,namefile));

            var data = doc.DocumentElement.SelectNodes("/DonViHanhChinhVietNam/DVHC");

            foreach (XmlNode xmlNode in data)
            {
                Provincescs _provincescs = new Provincescs();
                _provincescs.MaDVHC = int.Parse(xmlNode.SelectSingleNode("MaDVHC").InnerText);
                _provincescs.Ten = xmlNode.SelectSingleNode("Ten").InnerText;
                _provincescs.Cap = xmlNode.SelectSingleNode("Cap").InnerText;
                _provincescs.CapTren = 0;

                if (_provincescs.Cap != "TINH")
                {
                    _provincescs.CapTren = int.Parse(
                        xmlNode.SelectSingleNode("CapTren").InnerText);
                }

                provincescs.Add(_provincescs);
            }
            return provincescs;
        }
    }
}
