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
            decimal BaseSalary = 200M;
            DateTime DateJoined = new DateTime(2013, 1, 1);
            decimal EхpectedSalary = 236M;

            //act
            Employee e = new Employee("Employee", BaseSalary, DateJoined);
            decimal ActualSalary = e.Salary;
            // assert
            if (e.ErrorMessage != "") { 
                Assert.Fail(e.ErrorMessage);
            }
            else {
                Assert.AreEqual(EхpectedSalary, ActualSalary);
            }            
            
        }
        [TestMethod]
        public void TestEmployeeLongWorkSalary()
        {
            // arrange
            decimal BaseSalary = 200M;
            DateTime DateJoined = new DateTime(2003, 1, 1);
            decimal EхpectedSalary = 260M;

            //act

            Employee e = new Employee("Employee long work", BaseSalary, DateJoined);
            decimal ActualSalary = e.Salary;

            // assert
            if (e.ErrorMessage != "")
            {
                Assert.Fail(e.ErrorMessage);
            }
            else
            {
                Assert.AreEqual(EхpectedSalary, ActualSalary);
            }            
        }
        [TestMethod]
        public void TestManagerSalaryWithoutSubordinates()
        {
            // arrange
            decimal BaseSalary = 300M;
            DateTime DateJoined = new DateTime(2014, 1, 1);
            decimal EхpectedSalary = 375M;

            //act

            Manager m = new Manager("Manager Without Subordinates", BaseSalary, DateJoined);
            decimal ActualSalary = m.Salary;

            // assert
            if (m.ErrorMessage != "")
            {
                Assert.Fail(m.ErrorMessage);
            }
            else
            {
                Assert.AreEqual(EхpectedSalary, ActualSalary);
            }            
        }
        [TestMethod]
        public void TestManagerLongWorkSalaryWitoutSubordinates()
        {
            // arrange
            decimal BaseSalary = 300M;
            DateTime DateJoined = new DateTime(2004, 1, 1);
            decimal EхpectedSalary = 420M;

            //act

            Manager m = new Manager("Manager long work", BaseSalary, DateJoined);
            decimal ActualSalary = m.Salary;

            // assert
            if (m.ErrorMessage != "")
            {
                Assert.Fail(m.ErrorMessage);
            }
            else
            {
                Assert.AreEqual(EхpectedSalary, ActualSalary);
            }            
        }
        [TestMethod]
        public void TestManagerSalaryWithSubordinates()
        {
            // arrange
            string TestErrorMessage="";
            decimal BaseSalaryManager = 300M;
            decimal BaseSalaryEmployee1 = 100M;
            decimal BaseSalaryEmployee2 = 160M;
            DateTime DateJoined = new DateTime(2014, 1, 1);
            decimal EхpectedSalaryManager = 376.3M;

            //act

            Manager m = new Manager("Manager with Subordinates", BaseSalaryManager, DateJoined);
            Employee e1 = new Employee("Employee 1", BaseSalaryEmployee1, DateJoined);
            e1.Supervisor = m;
            Employee e2 = new Employee("Employee 2", BaseSalaryEmployee2, DateJoined);
            e2.Supervisor = m;
            
            decimal ActualSalaryManager = m.Salary;

            // assert
            TestErrorMessage = m.ErrorMessage + e1.ErrorMessage + e2.ErrorMessage;
            if (TestErrorMessage != "") { 
                Assert.Fail(TestErrorMessage); 
            }else{   
                Assert.AreEqual(EхpectedSalaryManager, ActualSalaryManager);
            }            
        }
        [TestMethod]        
        public void TestSalesSalaryWithoutSubordinates()
        {
            // arrange
            decimal BaseSalary = 400M;
            DateTime DateJoined = new DateTime(2015, 1, 1);
            decimal EхpectedSalary = 416M;

            //act

            Sales s = new Sales("Sales Without Subordinates", BaseSalary, DateJoined);
            
            decimal ActualSalary = s.Salary;

            // assert
            if (s.ErrorMessage != "") { 
                Assert.Fail(s.ErrorMessage);
            }
            else { 
                Assert.AreEqual(EхpectedSalary, ActualSalary);
            }
        }        
        [TestMethod]
        public void TestSalesLongWorkSalaryWitoutSubordinates()
        {
            // arrange
            decimal BaseSalary = 400M;
            DateTime DateJoined = new DateTime(1975, 1, 1);
            decimal EхpectedSalary = 540M;

            //act

            Sales s = new Sales("Sales Long Work", BaseSalary, DateJoined);
            decimal ActualSalary = s.Salary;

            // assert
            if (s.ErrorMessage != "") { 
                Assert.Fail(s.ErrorMessage);
            }
            else { 
                Assert.AreEqual(EхpectedSalary, ActualSalary);
            }
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
            string TestErrorMessage ="";
            Manager m = new Manager("Manager", BaseSalaryManager, DateJoined);
            Employee e1 = new Employee("Employee 1", BaseSalaryEmployee1, DateJoined);
            e1.Supervisor = m;
            Employee e2 = new Employee("Employee 2", BaseSalaryEmployee2, DateJoined);
            e2.Supervisor = m;
            decimal EхpectedSalary = 417.68M;

            //act

            Sales s = new Sales("Sales", BaseSalary, DateJoined);
            m.Supervisor = s;
            decimal ActualSalary = s.Salary;

            // assert
            TestErrorMessage = m.ErrorMessage + e1.ErrorMessage + e2.ErrorMessage+s.ErrorMessage;
            if (TestErrorMessage != "") {
                Assert.Fail(TestErrorMessage);
            }
            else
            {
                Assert.AreEqual(EхpectedSalary, ActualSalary);
            }
            
        }
    }    
}
