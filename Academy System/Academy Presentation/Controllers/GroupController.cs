using Academy_Presentation.Helpers;
using Domain.Entities;
using Service.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Academy_Presentation.Controllers
{
    public class GroupController
    {
        private GroupService _groupService = new GroupService();
        public void Create()
        {
        Name: Helper.PrintConsole(ConsoleColor.Blue, "Add group Name");
            string groupName = Console.ReadLine();
            if (string.IsNullOrEmpty(groupName)|| (groupName.Length >30))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group name is usually empty");
                goto Name;
            }

        Teacher: Helper.PrintConsole(ConsoleColor.Blue, "Add group Teacher");
            string groupTeacher = Console.ReadLine();
            if (string.IsNullOrEmpty(groupTeacher) || groupTeacher.Any(char.IsDigit) ||(groupName.Length<3))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group Teacher is usually empty");
                goto Teacher;
            }
        Room: Helper.PrintConsole(ConsoleColor.Blue, "Add group Room");
            string groupRoom = Console.ReadLine();
            if (string.IsNullOrEmpty(groupRoom))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group Room is usually empty");
                goto Room;
            }
            groupTeacher = char.ToUpper(groupTeacher[0]) + groupTeacher.Substring(1).ToLower();
            Groups group = new Groups { Name = groupName, Teacher = groupTeacher, Room = groupRoom };
            var result = _groupService.Create(group);
            Helper.PrintConsole(ConsoleColor.Green, $"Group ID: {group.Id},Group name: {groupName},Teacher: {groupTeacher},Group Room: {groupRoom} ");
        }
        public void Delete()
        {
        GroupId: Helper.PrintConsole(ConsoleColor.Blue, "Add group Id");
            string groupId = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
                if (id > 0)
                {
                    _groupService.Delete(id);
                    Helper.PrintConsole(ConsoleColor.DarkBlue, "Deleted");

                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Id cannot be negative.");
                    goto GroupId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid ID");
                goto GroupId;
            }
        }
        public void GetByID()
        {
        GroupId: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id");
            string groupID = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupID, out id);
            if (isGroupId)
            {
                Groups groups = _groupService.GetById(id);
                if (groups != null)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Group ID: {groupID}, Group name: {groups.Name}, Teacher: {groups.Teacher}, Group Room: {groups.Room} ");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Invalid ID!");
                    Helper.PrintConsole(ConsoleColor.Yellow, "There is no group.");
                }

            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid ID type");
                goto GroupId;
            }

        }
        public void GetAll()
        {
            List<Groups> groups = _groupService.GetAll();
            if (groups.Count > 0)
            {
                foreach (var group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Group ID: {group.Id},Group name: {group.Name},Teacher: {group.Teacher},Group Room: {group.Room} ");

                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Warning!");

                Helper.PrintConsole(ConsoleColor.Yellow, "It's empty");
            }
        }
        public void GetAllByTeacher()
        {


            Helper.PrintConsole(ConsoleColor.Blue, "Search Teacher name:");
            string searchTeacher = Console.ReadLine();

            List<Groups> groups = _groupService.SearchName(searchTeacher);
            if (groups.Count > 0)
            {
                foreach (var group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Group ID: {group.Id}, Group name: {group.Name}, Teacher: {group.Teacher}, Group Room: {group.Room} ");

                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid name, please try again.");
                Helper.PrintConsole(ConsoleColor.Yellow, "There is no group.");


            }

        }
        public void GetAllByRoom()
        {
            Helper.PrintConsole(ConsoleColor.Blue, "Search Room name:");
            string searchRoom = Console.ReadLine();

            List<Groups> groups = _groupService.SearchRoom(searchRoom);
            if (groups.Count > 0)
            {
                foreach (var group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Group ID: {group.Id}, Group name: {group.Name}, Teacher: {group.Teacher}, Group Room: {group.Room} ");

                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid room, please try again.");
                Helper.PrintConsole(ConsoleColor.Yellow, "There is no group.");




            }
        }
        public void GetAllByRooms()
        {
            Helper.PrintConsole(ConsoleColor.Blue, "Search via Room name:");
            string searchRoom = Console.ReadLine();

            List<Groups> groups = _groupService.SearchRoom(searchRoom);
            if (groups.Count > 0)
            {
                foreach (var group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Group ID: {group.Id}, Group name: {group.Name}, Teacher: {group.Teacher}, Group Room: {group.Room} ");

                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid room or doesn't exists any groups, please try again.");
                Helper.PrintConsole(ConsoleColor.Yellow, "Create new Group");



            }
        }
        public void Update()
        {
        GroupID: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id");
            string groupId = Console.ReadLine();
            if (string.IsNullOrEmpty(groupId))
            {
                Helper.PrintConsole(ConsoleColor.Yellow, "Update operation cancelled.");
                return;
            }

            int id;
            bool isGroupID = int.TryParse(groupId, out id);
            if (isGroupID)
            {
                var findGroup = _groupService.GetById(id);

                if (findGroup != null)
                {
                    Helper.PrintConsole(ConsoleColor.Blue, "Add new Group name or skip ");
                    string newGroupName = Console.ReadLine();
                    if (newGroupName is null)
                    {
                        newGroupName = findGroup.Name;
                    }

                    Helper.PrintConsole(ConsoleColor.Blue, "Add new Teacher or skip");
                    string newTeacher = Console.ReadLine();
                    if (newTeacher is null)
                    {
                        newTeacher = findGroup.Teacher;
                    }

                    Helper.PrintConsole(ConsoleColor.Blue, "Add new Room or skip");
                    string newRoom = Console.ReadLine();
                    if (newRoom is null)
                    {
                        newRoom = findGroup.Room;
                    }

                    Groups groups = new Groups { Name = newGroupName, Teacher = newTeacher, Room = newRoom };

                    var updateGroups = _groupService.Update(id, groups);

                    if (updateGroups == null) { Helper.PrintConsole(ConsoleColor.Red, "Group not Updated"); goto GroupID; }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Green, $"Group ID: {id}, Group name: {groups.Name}, Teacher: {groups.Teacher}, Group Room: {groups.Room} ");
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Not Found ID ");
                    Helper.PrintConsole(ConsoleColor.Yellow, "Create new Group");

                    return;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid ID type, try again.");
                goto GroupID;
            }

        }
        public void GetAllByName()
        {


            Helper.PrintConsole(ConsoleColor.Blue, "Search via Group name:");
            string searchName = Console.ReadLine();

            Groups groups = _groupService.GetByName(searchName);
            if (groups != null)
            {

                Helper.PrintConsole(ConsoleColor.Green, $"Group ID: {groups.Id}, Group name: {groups.Name}, Teacher: {groups.Teacher}, Group Room: {groups.Room} ");


            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid name or doesn't exists any groups, please try again.");
                Helper.PrintConsole(ConsoleColor.Yellow, "Create new Group[1] or try again[14] ");


            }

        }
    }
}
