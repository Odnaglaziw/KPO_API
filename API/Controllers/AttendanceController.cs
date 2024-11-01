using API.Contracts;
using Core.Abstractions;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/attendances")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AttendanceResponse>>> GetAttendances()
        {
            var attendances = await attendanceService.GetAllAttendances();
            var response = attendances.Select(a => new AttendanceResponse(a.Id,a.AccountingId, a.EmployeeId,a.ArrivalCode, a.ArrivalTime, a.DepartureTime));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAttendance([FromBody] AttendanceRequest request)
        {
            var attendanceId = Guid.NewGuid();
            var (attendance, error) = Attendance.Create(attendanceId, request.AccountingId,request.EmployeeId, request.ArrivalCode);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await attendanceService.CreateAttendance(attendance);
            return Ok(attendanceId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateAttendance(Guid id, [FromBody] AttendanceRequest request)
        {
            var attendance = Attendance.Create(id, request.AccountingId, request.EmployeeId, request.ArrivalCode).Attendance;
            await attendanceService.UpdateAttendance(attendance);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAttendance(Guid id)
        {
            await attendanceService.DeleteAttendance(id);
            return Ok();
        }
    }
}
