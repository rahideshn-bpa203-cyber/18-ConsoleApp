using Academy_Presentation.Controller;
using Academy_Presentation.Helpers;
using System;
using System.Text.RegularExpressions;

namespace Academy_Presentation
{
    internal class Program
    {

        static void Main(string[] args)
        {
            GroupService groupService = new();
            GroupController groupController = new();
            //StudentService studentService = new();
            //StudentController studentController = new();


            Helper.PrintConsole(ConsoleColor.Blue, "Select one option");
            Helper.PrintConsole(ConsoleColor.Cyan, "1 - Create Group,\n2 - Update group,\n3 - Delete Group, \n4 - Get group  by id,\n5 - Get all groups  by teacher , \n6 - Get all groups by room, \n7 - Get all groups,\n8 - Create Student , \n9 - Update Student   , \n10- Get student  by id, \n11 - Delete student,\n12 - Get students   by age, \n13 - Get all students  by group id , \n14- Search method for groups by name, \n15 - Search method for students by name or surname.\r\n");

            while (true)
            {
            selectOption: string selectOption = Console.ReadLine();
                int selectTrueOption;
                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);
                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {

                        case (int)Menus.CreateGroup:
                            groupController.Create();
                            break;
                        case (int)Menus.Updategroup:
                            groupController.UpdateGroup();
                            break;
                        case (int)Menus.DeleteGroup:
                            groupController.Delete();
                            break;

                        case (int)Menus.Getgroupbyid:
                            groupController.GetById();
                            break;
                        case (int)Menus.Getallgroupsbyteacher:
                            groupController.GetByTeacher();
                            break;
                        case (int)Menus.Getallgroupsbyroom:
                            groupController.GetByRoom();
                            break;
                        case (int)Menus.Getallgroups:
                            groupController.GetAll();
                            break;

                        //case (int)Menus.CreateStudent:
                        //    studentController.Create();
                        //    break;

                        //case (int)Menus.UpdateStudent:
                        //    studentController.UpdateStudent();
                        //    break;

                        //case (int)Menus.Getstudentbyid:
                        //    studentController.GetById();
                        //    break;

                        //case (int)Menus.Deletestudent:
                        //    studentController.Delete();
                        //    break;

                        //case (int)Menus.Getstudentsbyage:
                        //    studentController.GetByAge();
                        //    break;

                        //case (int)Menus.Getallstudentsbygroupid:
                        //    studentController.GetByGroupId();
                        //    break;

                        //case (int)Menus.Searchgroupsbyname:
                        //    studentController.Search();
                        //    break;

                        //case (int)Menus.Searchstudentsbyname:
                        //    studentController.Search();
                        //    break;



                        default:
                            Helper.PrintConsole(ConsoleColor.Red, "unknown option, please try again!");
                            break;
                    }
                }
                else
                {

                    Helper.PrintConsole(ConsoleColor.Red, "Error: select correct option");
                    goto selectOption;
                }
            }
        }
    }


    }
}
