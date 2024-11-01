﻿using System.Security.Cryptography.X509Certificates;

namespace Core.Models
{
    public class Employee
    {
        public const int MAX_LENGTH = 50;
        private Employee(Guid id, string login, string password,string name, string lastName, string position)
        {
            Id = id;
            Login = login;
            Password = password;
            Name = name;
            LastName = lastName;
            Position = position;
        }
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string LastName { get; } = string.Empty;
        public string Position { get; } = string.Empty;
        public string Login { get; } = string.Empty;
        public string Password { get; } = string.Empty;

        static public (Employee Employee, string Error) Create(Guid id, string login, string password,string name, string lastName, string position)
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

            var employee = new Employee(id, login, password, name, lastName, position);

            return (employee,error);
        }
    }
}
