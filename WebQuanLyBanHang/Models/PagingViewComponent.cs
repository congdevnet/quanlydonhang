using Microsoft.AspNetCore.Mvc;
using WebQuanLyBanHang.Data.Entity;

namespace WebQuanLyBanHang.Models
{
    public class PagingViewComponent: ViewComponent
    {
         dynamic model;
         public PagingViewComponent()
         {
           
         }
        public IViewComponentResult Invoke()
        {
            this.model = model;
            return View(model);
        }
    }
}
