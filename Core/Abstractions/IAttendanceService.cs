using Core.Models;

namespace Core.Abstractions
{
    public interface IAttendanceService
    {
        Task<Guid> CreateAttendance(Attendance attendance);
        Task DeleteAttendance(Guid id);
        Task<List<Attendance>> GetAllAttendances();
        Task<Attendance> GetAttendanceById(Guid id);
        Task UpdateAttendance(Attendance attendance);
    }

}
