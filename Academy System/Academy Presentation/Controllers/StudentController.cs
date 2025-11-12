using Academy_Presentation.Helpers;
using Domain.Entities;
using Repository.Repositories.Implementations;
using Service.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Academy_Presentation.Controllers
{
    public class StudentController
    {
        StudentService _studentService = new StudentService();
        public void Create()
        {
        GroupID: Helper.PrintConsole(ConsoleColor.Blue, "Enter Group ID:");
            string selcetedID = Console.ReadLine();
            int groupId;
            bool IsGroupID = int.TryParse(selcetedID, out groupId);
            if (IsGroupID)
            {
            Name: Helper.PrintConsole(ConsoleColor.Blue, "Enter Student name:");
                string studentName = Console.ReadLine();
                if (string.IsNullOrEmpty(studentName) || studentName.Any(char.IsDigit))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group name can not be empty or number");
                    goto Name;

                }

            Surname: Helper.PrintConsole(ConsoleColor.Blue, "Enter Student surname:");
                string studentSurname = Console.ReadLine();
                if (string.IsNullOrEmpty(studentSurname) || studentSurname.Any(char.IsDigit))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group name can not be empty or number");
                    goto Surname;

                }

            AGE: Helper.PrintConsole(ConsoleColor.Blue, "Enter Student age:");
                string addedAge = Console.ReadLine();
                int age;
                bool isAge = int.TryParse(addedAge, out age);
                if (age >= 0)
                {
                    if (isAge)
                    {
                        studentName = char.ToUpper(studentName[0]) + studentName.Substring(1).ToLower();
                        studentSurname = char.ToUpper(studentSurname[0]) + studentSurname.Substring(1).ToLower();

                        Students student = new Students { Name = studentName, Surname = studentSurname, Age = age };
                        var result = _studentService.Create(groupId, student);

                        if (result != null)
                        {
                            Helper.PrintConsole(ConsoleColor.Green, $"ID: {student.Id},Name: {studentName},Surname: {studentSurname},Age: {age},Group: {result.Group.Name}");

                        }
                        else
                        {
                            Helper.PrintConsole(ConsoleColor.Red, "Group NOT FOUND");
                            return;
                        }
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Add correct age type");
                        goto AGE;
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Age can't be negative");
                    goto AGE;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct Group ID type");
                goto GroupID;
            }
        }
        public void GetById()
        {
        StudentID: Helper.PrintConsole(ConsoleColor.Blue, "Enter Student ID:");
            string studentID = Console.ReadLine();
            int id;
            bool isID = int.TryParse(studentID, out id);
            if (isID)
            {
                var result = _studentService.GetById(id);
                if (result != null)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"ID: {result.Id},Name: {result.Name},Surname: {result.Surname},Age: {result.Age},Group: {result.Group.Name}");

                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Invalid ID!");
                    Helper.PrintConsole(ConsoleColor.Yellow, "Create new Student ");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Incorrect ID type, try again.");
                goto StudentID;
            }

        }
        public void Delete()
        {
        StudentID: Helper.PrintConsole(ConsoleColor.Blue, "Enter Student ID");
            string deleteID = Console.ReadLine();
            int id;
            bool isID = int.TryParse(deleteID, out id);
            if (isID)
            {
                if (id > 0)
                {
                    _studentService.Delete(id);

                    Helper.PrintConsole(ConsoleColor.DarkGreen, "All done,you can continue.");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Warning! ID can't be zero or negative,please try again");
                    goto StudentID;

                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid ID type");
                goto StudentID;
            }
        }

        public void Update()
        {
        StudentID: Helper.PrintConsole(ConsoleColor.Blue, "Enter Student ID");
            string updateID = Console.ReadLine();
            if (updateID is null)
            {
                Helper.PrintConsole(ConsoleColor.Yellow, "Update operation cancelled.");
                return;
            }
            int id;
            bool isID = int.TryParse(updateID, out id);
            if (isID)
            {
                var findbyid = _studentService.GetById(id);
                if (findbyid != null)
                {
                    Helper.PrintConsole(ConsoleColor.Blue, "Enter new Student Nama:");
                    string newstudentName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newstudentName)) newstudentName = findbyid.Name;
                    Helper.PrintConsole(ConsoleColor.Blue, "Enter new Student Surname:");
                    string newstudentSurname = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newstudentSurname)) newstudentSurname = findbyid.Surname;

                    AGE: Helper.PrintConsole(ConsoleColor.Blue, "Enter new Student Age:");
                    string addedAge = Console.ReadLine();

                    int newage;

                    if (string.IsNullOrWhiteSpace(addedAge))
                    {
                        newage = findbyid.Age;
                    }
                    else if (!int.TryParse(addedAge, out newage) || newage <= 0)
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Invalid age type");
                        goto AGE;
                    }

                GroupID: Helper.PrintConsole(ConsoleColor.Blue, "Enter new Student Group ID ");
                    string addedGroupID = Console.ReadLine();
                    int newGroupID;

                    if (string.IsNullOrEmpty(addedGroupID))
                    {
                        newGroupID = findbyid.Group.Id;
                    }
                    else if (!int.TryParse(addedGroupID, out newGroupID) || newGroupID < 0)
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Invalid Group ID type");
                        goto GroupID;
                    }

                    var groupRepo = new GroupRepository();
                    var newGroup = groupRepo.Get(g => g.Id == newGroupID);

                    if (newGroup == null)
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Group not found. Please enter Group ID.");
                        goto GroupID;
                    }

                    Students students = new Students
                    { Name = newstudentName, Surname = newstudentSurname, Age = newage, Group = newGroup };
                    var result = _studentService.Update(id, students);
                    if (result != null)
                    {
                        Helper.PrintConsole(ConsoleColor.Green, $"ID: {result.Id},Name: {result.Name},Surname: {result.Surname},Age: {result.Age},Group: {result.Group.Name}");
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Not Group ID  try again.");
                        return;
                    }

                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Not Found ID  try again.");
                    return;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid ID type");
                goto StudentID;
            }

        }

        public void StudentsByAge()
        {
        StudentID: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter student age");
            string addedAge = Console.ReadLine();
            int age;
            bool isAge = int.TryParse(addedAge, out age);
            if (isAge)
            {
                var students = _studentService.StudentsbyAge(age);
                if (students != null)
                {
                    foreach (var result in students)
                    {

                        Helper.PrintConsole(ConsoleColor.Green, $"ID: {result.Id},Name: {result.Name},Surname: {result.Surname},Age: {result.Age},Group: {result.Group.Name}");

                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Not Found Age try again.");
                    return;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid ID type");
                goto StudentID;
            }





        }

        public void StudentsByGroupID()
        {

        StudentID: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter Group ID");
            string addedID = Console.ReadLine();
            int id;
            bool isID = int.TryParse(addedID, out id);
            if (isID)
            {
                var students = _studentService.StudentsbyGroupID(id);
                if (students.Count > 0)
                {
                    foreach (var result in students)
                    {

                        Helper.PrintConsole(ConsoleColor.Green, $"ID: {result.Id},Name: {result.Name},Surname: {result.Surname},Age: {result.Age},Group: {result.Group.Name}");

                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Not Found Age , try again.");
                    return;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid ID type");
                goto StudentID;
            }
        }


        public void StudentsbyNameOrSurname()
        {
        Student: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter Student Name or Surname");
            string nameOrSurname = Console.ReadLine();
            if (!string.IsNullOrEmpty(nameOrSurname))
            {
                var results = _studentService.StudentsbyNameOrSurname(nameOrSurname);
                if (results != null)
                {
                    foreach (var result in results)
                    {
                        Helper.PrintConsole(ConsoleColor.Green, $"ID: {result.Id},Name: {result.Name},Surname: {result.Surname},Age: {result.Age},Group: {result.Group.Name}");

                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Not Found Student try again.");
                    return;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Name or Surname can not be empty");
                goto Student;
            }

        }
    }


}

