using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task;
namespace TaskTest
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void TestEmployeeSalary()
        {
            // arrange
            string Name = "Employee 1";
            decimal BaseSalary = 200M;
            DateTime DateJoined = new DateTime(2013, 1, 1);
            decimal EхpectedSalary = 236M;
            //act
            Employee e = new Employee(Name, BaseSalary, DateJoined);
            decimal ActualSalary = e.Salary;
            // assert
            Assert.AreEqual(EхpectedSalary, ActualSalary);
        }
        [TestMethod]
        public void TestEmployeeLongWorkSalary()
        {
            // arrange
            string Name = "Employee long work";
            decimal BaseSalary = 200M;
            DateTime DateJoined = new DateTime(2003, 1, 1);
            decimal EхpectedSalary = 260M;
            //act
            Employee e = new Employee(Name, BaseSalary, DateJoined);
            decimal ActualSalary = e.Salary;
            // assert
            Assert.AreEqual(EхpectedSalary, ActualSalary);
        }
        [TestMethod]
        public void TestManagerSalaryWithoutSubordinates()
        {
            // arrange
            string Name = "Manager Without Subordinates";
            decimal BaseSalary = 300M;
            DateTime DateJoined = new DateTime(2014, 1, 1);
            decimal EхpectedSalary = 375M;
            //act
            Manager m = new Manager(Name, BaseSalary, DateJoined);
            decimal ActualSalary = m.Salary;
            // assert
            Assert.AreEqual(EхpectedSalary, ActualSalary);
        }
        [TestMethod]
        public void TestManagerLongWorkSalaryWitoutSubordinates()
        {
            // arrange
            string Name = "Manager long work";
            decimal BaseSalary = 300M;
            DateTime DateJoined = new DateTime(2004, 1, 1);
            decimal EхpectedSalary = 420M;
            //act
            Manager m = new Manager(Name, BaseSalary, DateJoined);
            decimal ActualSalary = m.Salary;
            // assert
            Assert.AreEqual(EхpectedSalary, ActualSalary);
        }
        [TestMethod]
        public void TestManagerSalaryWithSubordinates()
        {
            // arrange
            string Name = "Manager with Subordinates";
            decimal BaseSalaryManager = 300M;
            decimal BaseSalaryEmployee1 = 100M;
            decimal BaseSalaryEmployee2 = 160M;
            DateTime DateJoined = new DateTime(2014, 1, 1);
            decimal EхpectedSalaryManager = 376.3M;
            //act
            Manager m = new Manager(Name, BaseSalaryManager, DateJoined);
            Employee e1 = new Employee(Name, BaseSalaryEmployee1, DateJoined);
            e1.Supervisor = m;
            Employee e2 = new Employee(Name, BaseSalaryEmployee2, DateJoined);
            e2.Supervisor = m;
            decimal ActualSalaryManager = m.Salary;
            // assert
            Assert.AreEqual(EхpectedSalaryManager, ActualSalaryManager);
        }
        [TestMethod]
        public void TestSalesSalaryWithoutSubordinates()
        {
            // arrange
            string Name = "Sales Without Subordinates";
            decimal BaseSalary = 400M;
            DateTime DateJoined = new DateTime(2015, 1, 1);
            decimal EхpectedSalary = 416M;
            //act
            Sales s = new Sales(Name, BaseSalary, DateJoined);
            decimal ActualSalary = s.Salary;
            // assert
            Assert.AreEqual(EхpectedSalary, ActualSalary);
        }
        [TestMethod]
        public void TestSalesLongWorkSalaryWitoutSubordinates()
        {
            // arrange
            string Name = "Sales Long Work";
            decimal BaseSalary = 400M;
            DateTime DateJoined = new DateTime(1975, 1, 1);
            decimal EхpectedSalary = 540M;
            //act
            Sales s = new Sales(Name, BaseSalary, DateJoined);
            decimal ActualSalary = s.Salary;
            // assert
            Assert.AreEqual(EхpectedSalary, ActualSalary);
        }
        [TestMethod]
        public void TestSalesSalaryWithSubordinates()
        {
            // arrange
            decimal BaseSalaryManager = 300M;
            decimal BaseSalaryEmployee1 = 100M;
            decimal BaseSalaryEmployee2 = 160M;
            decimal BaseSalary = 400M;
            DateTime DateJoined = new DateTime(2015, 1, 1);
            string Name = "Sales With Subordinates";
            Manager m = new Manager(Name, BaseSalaryManager, DateJoined);
            Employee e1 = new Employee(Name, BaseSalaryEmployee1, DateJoined);
            e1.Supervisor = m;
            Employee e2 = new Employee(Name, BaseSalaryEmployee2, DateJoined);
            e2.Supervisor = m;
            decimal EхpectedSalary = 417.68M;
            //act
            Sales s = new Sales(Name, BaseSalary, DateJoined);
            m.Supervisor = s;
            decimal ActualSalary = s.Salary;
            // assert
            Assert.AreEqual(EхpectedSalary, ActualSalary);
        }
    }
}

