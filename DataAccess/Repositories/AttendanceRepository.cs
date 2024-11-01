using Core.Abstractions;
using Core.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AttendanceRepository : IAttendance
    {
        private readonly KpoDbContext context;

        public AttendanceRepository(KpoDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid> Create(Attendance attendance)
        {
            var attendanceEntity = new AttendanceEntity
            {
                Id = attendance.Id, 
                AccountingId = attendance.AccountingId,
                EmployeeId = attendance.EmployeeId,
                ArrivalCode = attendance.ArrivalCode,
                ArrivalTime = attendance.ArrivalTime,
                DepartureTime = attendance.DepartureTime
            };

            await context.Attendances.AddAsync(attendanceEntity); 
            await context.SaveChangesAsync();
            return attendanceEntity.Id; 
        }

        public async Task Delete(Guid id)
        {
            var attendance = await context.Attendances.FindAsync(id); 
            if (attendance != null)
            {
                context.Attendances.Remove(attendance); 
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Attendance>> GetAll()
        {
            var attendanceEntities = await context.Attendances.AsNoTracking().ToListAsync();

            var attendances = attendanceEntities
                .Select(a => Attendance.Create(
                    a.Id,
                    a.AccountingId,
                    a.EmployeeId,
                    a.ArrivalCode).Attendance).ToList();

            return attendances;
        }

        public async Task<Attendance> GetById(Guid id)
        {
            var a = await context.Attendances.FindAsync(id); 

            return Attendance.Create(a.Id, a.AccountingId, a.EmployeeId, a.ArrivalCode).Attendance;
        }

        public async Task Update(Attendance attendance)
        {
            var attendanceEntity = await context.Attendances.FindAsync(attendance.Id);

            if (attendanceEntity != null)
            {
                attendanceEntity.AccountingId = attendance.AccountingId;
                attendanceEntity.EmployeeId = attendance.EmployeeId;
                attendanceEntity.ArrivalCode = attendance.ArrivalCode;
                attendanceEntity.ArrivalTime = attendance.ArrivalTime;
                attendanceEntity.DepartureTime = attendance.DepartureTime;

                await context.SaveChangesAsync(); 
            }
        }
    }
}
