# TestSolution
Solution for Test Problem (c#)
DESCRIPTION
There is a company; the company can have staff members. Staff members are characterized by their name, date when they joined the company, and base salary (to keep it simple, consider this value to be equal for all staff member types by default.)
There are 3 types of staff members: Employee, Manager, Sales. Any staff member can have a supervisor. Any staff member except for Employee can have subordinates.
Employee salary - base salary plus 3% for each year they have worked with the company, but not more than 30% of the base salary.
Manager salary - base salary plus 5% for each year they have worked with the company (but not more than 40% of the base salary), plus 0.5% of salaries of their first level subordinates.
Sales salary - base salary plus 1% for each year they have worked with the company (but not more than 35% of the base salary) plus 0.3% of salaries of their subordinates of any level.
Staff members (except Employee) can have any number of subordinates of any type.
REQUIREMENTS
Create a class library that describes this model, and implement an algorithm that calculates salary of any staff member at an arbitrary time (as well as calculate the sum of salaries of all staff members of the company).
The system must be verified by unit-tests (100% code coverage is not necessary, but the tests should demonstrate that the business logic works correctly).
In addition, prepare a brief description of the solution for the test assignment, including description of its architecture, its advantages and drawbacks (what can be changed or improved in the solution to make it ready for real-world usage.)
A DBMS is not necessary; the data model is transient. 
