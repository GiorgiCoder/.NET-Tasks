using Microsoft.EntityFrameworkCore;
using SweeftStage2Tasks.ReadCountriesTask8;
using SweeftStage2Tasks.TeachingEFCoreTask7.Data;
using SweeftStage2Tasks.TeachingEFCoreTask7.Repositories;
using System.Diagnostics;

namespace SweeftStage2Tasks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FirstFiveTasks tasks = new FirstFiveTasks();

            // Tasks 1-5: in FirstFiveTasks.cs
            Console.WriteLine($"Task 1: {tasks.IsPalindrome("zabaz")}\n"); // True
            Console.WriteLine($"Task 2: {tasks.MinSplit(261)}\n"); // 7
            Console.WriteLine($"Task 3: {tasks.NotContains([1, 2, 4, 5, 3, 7, 8])}\n"); // 6
            Console.WriteLine($"Task 4: {tasks.IsProperly(")(()(())(()))()")}\n"); // False
            Console.WriteLine($"Task 5: {tasks.CountVariants(39)}\n");

            // Task 6: in TeacherStudent.sql

            // Task 7: in TeachingEFCoreTask7/Repositories/TeacherRepository (can't be tested since
            // it requires DBContext which doesn't exist in the current project.
            // I made the MVC project and connected it to the server to test if everything works.
            // It did. I can add that project to the repository as well if needed.

            //Task 8: in ReadCountriesTask8/ReadCountries.cs
            ReadCountries readCountries = new ReadCountries();
            readCountries.ReadAndWrite("https://restcountries.com/v3.1/all");

            //Task 9: in NeoTheChosenOne.cs
            //NeoTheChosenOne neo = new NeoTheChosenOne();
            //neo.RunTask9().GetAwaiter().GetResult();
        }
    }
}
