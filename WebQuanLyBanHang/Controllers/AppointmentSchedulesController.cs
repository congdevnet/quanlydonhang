using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebQuanLyBanHang.Models;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Controllers
{
    public class AppointmentSchedulesController : BaseController
    {
        private readonly IAppointmentScheduleService _appointmentScheduleService;

        public AppointmentSchedulesController(IAppointmentScheduleService appointmentScheduleService)
        {
            _appointmentScheduleService = appointmentScheduleService;
        }
        [HttpGet]
        [Route("lich-hen")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Table(Pageding pageding)
        {
            PagedingMKT pagedingMKT = new PagedingMKT()
            {
                KeyWord = pageding.KeyWord,
                PageNum = pageding.PageNum,
                PageSize = pageding.PageSize,
                UserId = Guid.Parse(HttpContext.Request.Cookies[ConstSession.UserId]),
            };
            var data = await _appointmentScheduleService.GetAll(pagedingMKT);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AppointmentScheduleVM model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            else
            {
                model.AppointmentDate = DateTime.ParseExact(model.DateAppointments, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);
                await _appointmentScheduleService.Add(model);
                return Ok();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] AppointmentScheduleVM model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            else
            {
                model.AppointmentDate = DateTime.ParseExact(model.DateAppointments, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);
                await _appointmentScheduleService.Update(model);
                return Ok();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetModel(int id)
        {
            var data = await _appointmentScheduleService.Get(id);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _appointmentScheduleService.Delete(id);
            return Ok();
        }
    }
}