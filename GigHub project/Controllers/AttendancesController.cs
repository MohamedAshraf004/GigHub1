using GigHub.Dtos;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto Dto)
        {
            var userId = User.Identity.GetUserId();
            var exist = _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == Dto.GigId);
            if (exist)
                return BadRequest("The attendance is already exists");
            var attendance = new Attendance
            {
                GigId = Dto.GigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }

    }
}
