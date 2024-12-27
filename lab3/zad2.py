import os
import json

komunikat = """Witaj w Employees System Project!
Dostępne operacje:
1 - Dodawanie nowych pracowników
2 - Wyświetlenie listy istniejących pracowników
3 - Usuwanie pracowników na podstawie przedziału wiekowego
4 - Aktualizacja wynagrodzeń pracowników według nazwiska
0 - Zakończ działanie systemu\n"""

class Employee(object):
    def __init__(self, name: str, age: int, salary: float):
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

    def updateEmployeeSalary(self, name: str, salary: float):
        employee = self.findEmployeeByName(name)
        if employee == None:
            return None
        oEmployee = employee
        employee.salary = salary
        return employee

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
                    salary = float(input("Podaj wynagrodzenie\n"))
                    emp = Employee(name,age,salary)
                    employeeManager.addEmployeeToList(emp)
                    dane_do_pliku(emp)
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
                    empList = employeeManager.removeEmployeeByAge(minAge, maxAge)
                    if len(empList) == 0:
                        print("Nie ma takich pracowników")
                    else:
                        print("Lista usunietych pracowników:")
                        for emp in empList:
                            print(emp.info())
                            usun_plik(emp)
                case 4:
                    os.system('cls')
                    name = input("Podaj imię i nazwisko pracownika\n")
                    salary = float(input("Podaj nowa kwotę wynagrodzenia\n"))
                    new = employeeManager.updateEmployeeSalary(name, salary)
                    if new == None:
                        print("Nie ma takiego pracownika")
                    else:
                        dane_do_pliku(new)
                        print(f"Nowe dane: {new.info()}")

        print("Zakończono działanie programu")


def logowanie():
    print("Witaj w Employees System Project!")
    login = input("Podaj login\n")
    haslo = input("Podaj haslo\n")
    if login == "admin" and haslo == "admin":
        return True
    else:
        return False

def ladowanie_plikow():
    list = []
    for x in os.listdir():
        if x.endswith(".json"):
            print(x)
            with open(x, 'r') as file:
                json_obj = json.load(file)
                emp = Employee(**json_obj)
                list.append(emp)
    return list
def dane_do_pliku(employee: Employee):
    file_name = employee.name
    file_name = file_name.replace(" ","")
    json_obj = json.dumps(employee.__dict__)
    with open(f"{file_name}.json", "w") as outfile:
        outfile.write(json_obj)

def usun_plik(employee: Employee):
    file_name = employee.name
    file_name = file_name.replace(" ", "")
    if os.path.exists(f"{file_name}.json"):
        os.remove(f"{file_name}.json")


def main():
    if logowanie():
        os.system('cls')
        list_emp = ladowanie_plikow()
        FrontendManager(list_emp)
    else:
        print("Nie prawidłowy login lub hasło!")

main()
