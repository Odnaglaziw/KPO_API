using Core.Models;

namespace Core.Abstractions
{
    public interface IAttendance
    {
        Task<Attendance> GetById(Guid id);
        Task<List<Attendance>> GetAll();
        Task<Guid> Create(Attendance attendance);
        Task Update(Attendance attendance);
        Task Delete(Guid id);
    }
}
