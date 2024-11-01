using Core.Models;
using Core.Abstractions;

namespace Application.Services
{
    
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendance attendanceRepository;

        public AttendanceService(IAttendance attendanceRepository)
        {
            this.attendanceRepository = attendanceRepository;
        }

        public async Task<Guid> CreateAttendance(Attendance attendance)
        {
            return await attendanceRepository.Create(attendance);
        }

        public async Task DeleteAttendance(Guid id)
        {
            await attendanceRepository.Delete(id);
        }

        public async Task<List<Attendance>> GetAllAttendances()
        {
            return await attendanceRepository.GetAll();
        }

        public async Task<Attendance> GetAttendanceById(Guid id)
        {
            return await attendanceRepository.GetById(id);
        }

        public async Task UpdateAttendance(Attendance attendance)
        {
            await attendanceRepository.Update(attendance);
        }
    }
}
