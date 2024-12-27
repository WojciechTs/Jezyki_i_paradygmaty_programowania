import os

komunikat = """Witaj w Employees System Project!
Dostępne operacje:
1 - Dodawanie nowych pracowników
2 - Wyświetlenie listy istniejących pracowników
3 - Usuwanie pracowników na podstawie przedziału wiekowego
4 - Aktualizacja wynagrodzeń pracowników według nazwiska
0 - Zakończ działanie systemu\n"""

class Employee(object):
    def __init__(self, name, age, salary):
        self.name = name
        self.age = age
        self.salary = salary

    def info(self):
        return f"Name: {self.name}, Age: {self.age}, Salary: {self.salary}"

class EmployeesManager:
    def __init__(self, employeeList: list=[]):
        self.employeeList = employeeList

    def addEmployeeToList(self, employee: Employee):
        self.employeeList.append(employee)

    def printAllEmployee(self):
        return self.employeeList

    def removeEmployeeByAge(self, minAge, maxAge):
        list = []
        for employee in self.employeeList:
            if employee.age >= minAge and employee.age <= maxAge:
                list.append(employee)
                self.employeeList.remove(employee)
        return list

    def findEmployeeByName(self, name):
        emmployee = [employee for employee in self.employeeList if employee.name == name]
        if len(emmployee) == 0:
            return None
        else:
            return emmployee[0]

    def updateEmployeeSalary(self, name, salary):
        employee = self.findEmployeeByName(name)
        if employee == None:
            return None, None
        oEmployee = employee
        employee.salary = salary
        return employee, oEmployee

class FrontendManager(Employee):
    def __init__(self, employeeList: list=[]):
        employeeManager = EmployeesManager(employeeList)
        global komunikat
        proccess = -1
        while proccess != 0:
            proccess = int(input(komunikat))
            match proccess:
                case 1:
                    os.system('cls')
                    name = input("Podaj imie i nazwisko\n")
                    age = int(input("Podaj wiek\n"))
                    salary = input("Podaj wynagrodzenie\n")
                    emp = Employee(name,age,salary)
                    employeeManager.addEmployeeToList(emp)
                    print(f"Dodano pracownika {emp.info()}")
                case 2:
                    os.system('cls')
                    emp = employeeManager.printAllEmployee()
                    if len(emp) == 0:
                        print("Nie ma pracowników")
                    else:
                        print("Lista pracowników:")
                        for e in emp:
                            print(e.info())
                case 3:
                    os.system('cls')
                    print("Podaj przedział:")
                    minAge = int(input("Pierwszy argument:\n"))
                    maxAge = int(input("Drugi argument:\n"))
                    emp = employeeManager.removeEmployeeByAge(minAge, maxAge)
                    if len(emp) == 0:
                        print("Nie ma takich pracowników")
                    else:
                        print("Lista usunietych pracowników:")
                        for e in emp:
                            print(e.info())
                case 4:
                    os.system('cls')
                    name = input("Podaj imię i nazwisko pracownika\n")
                    salary = input("Podaj nowe wynagrodzenie")
                    new, old = employeeManager.updateEmployeeSalary(name, salary)
                    if new == None:
                        print("Nie ma takiego pracownika")
                    else:
                        print(f"Stare dane: {old.info()}")
                        print(f"Nowe dane: {new.info()}")

        print("Zakończono działanie programu")





def main():
    FrontendManager()

main()
