using System.Security.Cryptography.X509Certificates;

namespace Core.Models
{
    public class Employee
    {
        public const int MAX_LENGTH = 50;
        private Employee(string name, string lastName, string position)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            Position = position;
        }
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string LastName { get; } = string.Empty;
        public string Position { get; } = string.Empty;

        static public (Employee Employee, string Error) Create(string name, string lastName, string position)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName))
            {
                error = "Имя или Фамилия не могут быть пустыми.";
            }
            else if (name.Length > MAX_LENGTH || lastName.Length > MAX_LENGTH || position.Length > MAX_LENGTH)
            {
                error = $"Максимальная длинна поля {MAX_LENGTH} символов";
            }

            var employee = new Employee(name, lastName, position);

            return (employee,error);
        }
    }
}
