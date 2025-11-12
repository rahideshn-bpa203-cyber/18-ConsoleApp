using Academy_Presentation.Controllers;
using Academy_Presentation.Helpers;


namespace Academy_Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Helper.PrintConsole(ConsoleColor.DarkMagenta, "Loading....");
            Thread.Sleep(20);
            GroupController groupController = new GroupController();
            StudentController studentController = new StudentController();

            Helper.PrintConsole(ConsoleColor.Blue, "Select one");
            Helper.PrintConsole(ConsoleColor.Blue, "  1 - Create Group,\n  2 - Delete Group,\n  3 - Get Group By Id,\n  4- Get All Groups,\n  5 - Get All Groups By Teacher,\n  6 - Get All Group By Room,\n  7 - Update Group\n  8 - Create Student,\n  9 - Get Student By ID,\n  10 - Delete Student,\n  11 - Update Student,\n  12 - Search Students by Age,\n  13 - Search Students by Group Id,\n  14 - Get Group by Group Name,\n  15 - Search Students by name or surname.");

            while (true)
            {
                string option = Console.ReadLine() ?? string.Empty;
                int selectOption;
                bool isOptionSelected = int.TryParse(option, out selectOption);

                if (isOptionSelected)
                {
                    switch (selectOption)
                    {
                        case 1:
                            groupController.Create();
                            break;
                        case 2:
                            groupController.Delete();

                            break;
                        case 3:
                            groupController.GetByID();
                            break;
                        case 4:
                            groupController.GetAll();
                            break;
                        case 5:
                            groupController.GetAllByTeacher();
                            break;
                        case 6:
                            groupController.GetAllByRoom();
                            break;
                        case 7:
                            groupController.Update();
                            break;
                        case 8:
                            studentController.Create();
                            break;
                        case 9:
                            studentController.GetById();
                            break;
                        case 10:
                            studentController.Delete();
                            break;
                        case 11:
                            studentController.Update();
                            break;
                        case 12:
                            studentController.StudentsByAge();
                            break;
                        case 13:
                            studentController.StudentsByGroupID();
                            break;
                        case 14:
                            groupController.GetAllByName();
                            break;
                        case 15:
                            studentController.StudentsbyNameOrSurname();
                            break;

                    }


                }
            }
        }
    }
}
