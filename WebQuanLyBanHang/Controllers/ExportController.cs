using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;using System.Data;

namespace WebQuanLyBanHang.Controllers{	public class ExportController : BaseController	{		private IWebHostEnvironment _webHostEnvironment;		public ExportController(IWebHostEnvironment webHostEnvironment)		{			this._webHostEnvironment = webHostEnvironment;			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);		}		[HttpGet]		[Route("bao-cao")]		public IActionResult Index()		{			return View();		}		[HttpGet]		[Route("in-bao-cao")]		public IActionResult Print()		{			DataTable dataTable = new DataTable();			dataTable = getdatatable();			string minetype = "";			int extension = 1;			var path = $"{this._webHostEnvironment.WebRootPath}\\Report\\baocao.rdlc";			Dictionary<string, string> parameters = new Dictionary<string, string>();			parameters.Add("prm", "RDLC REPORT");			LocalReport localReport = new LocalReport(path);			localReport.AddDataSource("datademo", dataTable);			var result = localReport.Execute(RenderType.Pdf,extension,parameters,minetype);			return File(result.MainStream, "application/pdf");		}
		[HttpGet]
		[Route("xuat-ban-ex")]
        public IActionResult Export()
        {
            var dt = new DataTable();
            dt = getdatatable();
            string mimetype = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Report\\baocao.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("prm", "RDLC report (Set as parameter)");
            LocalReport lr = new LocalReport(path);
            lr.AddDataSource("datademo", dt);

            var result = lr.Execute(RenderType.Excel, extension, parameters, mimetype);
            return File(result.MainStream, "application/msexcel", "Export.xls");
        }
        [HttpGet]
        [Route("xuat-ban-wd")]
        public IActionResult ExportWd()
        {
            var dt = new DataTable();
            dt = getdatatable();
            string mimetype = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Report\\baocao.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("prm", "RDLC report (Set as parameter)");
            LocalReport lr = new LocalReport(path);
            lr.AddDataSource("datademo", dt);

            var result = lr.Execute(RenderType.Word, extension, parameters, mimetype);
            return File(result.MainStream, "application/msexcel", "Export.docx");
        }
        private DataTable getdatatable()
        {
            var dataTable = new DataTable();
			dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("DiaChi");
            dataTable.Columns.Add("Sex");

			DataRow row;
			for (int i = 0; i < 50; i++)
			{
				row = dataTable.NewRow();
				row["Id"] = i;
				row["Name"] = "Name" + i.ToString();
                row["DiaChi"] = "DiaChi" + i.ToString();
                row["Sex"] = "DiaChi" + i.ToString();

				dataTable.Rows.Add(row);
            }

			return dataTable;
        }
    }}