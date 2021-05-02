using System;
using System.Collections.Generic;
using Bogus;
using DataSeederWithFakes.Models;

// https://github.com/bchavez/Bogus

namespace DataSeederWithFakes
{
    public enum Gender
    {
        M, F
    }

    class Program
    {
        
        private static readonly int nrOfFakeEmployees = 100;
        private static readonly int minNrOfFakeReviewsPerEmployees = 2; 
        private static readonly int maxNrOfFakeReviewsPerEmployees = 15; 
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*Employee emp1 = new Employee()
            {
                achternaam = "Molema",
                geboortedatum = new DateTime(1990, 2 , 3),
                geslacht = "M",
                mail = "martin.molema@nhlstenden.com",
                voornaam = "Martin",
                personeelsNr = "123456"
            };
            DBFactory.CreateNewEmployee(emp1);*/

            DateTime startdate = new DateTime(1960, 1, 1);
            DateTime endDate = new DateTime(2000, 12, 31);
            long persNrStart = DBFactory.GetLastEmployeeNr() + 1000;
            
            var testUsers = new Faker<Employee>()
                    .RuleFor(em => em.geslacht, f => f.PickRandom<Gender>().ToString())
                    .RuleFor(em => em.achternaam, (f, u) => f.Name.LastName())
                    .RuleFor(em => em.voornaam, (f, u) => f.Name.FirstName())
                    .RuleFor(em => em.mail, (f, u) => f.Internet.Email())
                    .RuleFor(em => em.geboortedatum, (f, u) => f.Date.Between(startdate, endDate))
                    .FinishWith((f, em) => { em.personeelsNr = (persNrStart++).ToString();})
                ;
            List<Employee> employees = testUsers.Generate(nrOfFakeEmployees);

            Random random = new Random();
            foreach (Employee employee in employees)
            {
                DBFactory.CreateNewEmployee(employee);

                Faker<Review> fakeReviews = new Faker<Review>()
                    .RuleFor(rev => rev.review, f => f.Rant.Review())
                    .FinishWith((f, rev) =>
                    {
                        rev.fk_idEmployee = employee.id;
                    });
                int nrOfReviews = random.Next(minNrOfFakeReviewsPerEmployees, maxNrOfFakeReviewsPerEmployees) ;
                List<Review> reviews = fakeReviews.Generate(nrOfReviews);
                foreach (Review review in reviews)
                {
                    DBFactory.createReview(review);
                }
            }
            Console.WriteLine("Done!");
            
        }
    }
}