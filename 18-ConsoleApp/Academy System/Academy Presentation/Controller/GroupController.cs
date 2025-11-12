using Academy_Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Academy_Presentation.Controller
{
    internal class GroupController
    {
        GroupService _groupService = new();

        public void Create()
        {
            Helper.PrintConsole(ConsoleColor.Green, "Add Group Name:");
            string groupName = Console.ReadLine();

            Helper.PrintConsole(ConsoleColor.Green, "Add Group Teacher:");
            string groupTeacher = Console.ReadLine();


            Helper.PrintConsole(ConsoleColor.Green, "Add Group Room:");
            string groupRoom = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(groupName) || string.IsNullOrWhiteSpace(groupTeacher) || string.IsNullOrWhiteSpace(groupRoom))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Error: All fields must be filled!");
                return;
            }

            Group group = new Group { Name = groupName, Teacher = groupTeacher, Room = groupRoom };

            var groupResult = _groupService.Create(group);

            if (groupResult != null)
            {
                Helper.PrintConsole(ConsoleColor.Yellow, $" Group added successfully! \nId: {groupResult.Id}, \nGroupName: {groupResult.Name},\nGroupTeacher: {group.Teacher},\nGroupRoom: {group.Room}");
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Error: Could not add group");
            }
        }
 
        public void Update()
        {
        GroupId:
            Helper.PrintConsole(ConsoleColor.Blue, "Enter Group Id to update:");
            string idStr = Console.ReadLine();

            if (int.TryParse(idStr, out int id))
            {
                var group = _groupService.GetById(id);
                if (group == null)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group not found!");
                    goto GroupId;
                }

                Helper.PrintConsole(ConsoleColor.Blue, $"Current Name: {group.Name}. Enter new name (or press Enter to skip):");
                string newName = Console.ReadLine();

                Helper.PrintConsole(ConsoleColor.Blue, $"Current Teacher: {group.Teacher}. Enter new teacher (or press Enter to skip):");
                string newTeacher = Console.ReadLine();

                Helper.PrintConsole(ConsoleColor.Blue, $"Current Room: {group.Room}. Enter new room (or press Enter to skip):");
                string newRoom = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newName)) newName = group.Name;
                if (string.IsNullOrWhiteSpace(newTeacher)) newTeacher = group.Teacher;
                if (string.IsNullOrWhiteSpace(newRoom)) newRoom = group.Room;

                Group updatedGroup = new Group
                {
                    Name = newName,
                    Teacher = newTeacher,
                    Room = newRoom
                };

                var result = _groupService.Update(id, updatedGroup);

                if (result != null)
                {
                    Helper.PrintConsole(ConsoleColor.Green,
                        $"Group updated successfully! Id: {result.Id}, Name: {result.Name}, Teacher: {result.Teacher}, Room: {result.Room}");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Update failed!");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Enter a valid number!");
                goto GroupId;
            }

        } 
        public void Delete()
        {
            {
            GroupId: Helper.PrintConsole(ConsoleColor.Green, "Add Group Id:");
                string groupId = Console.ReadLine();

                int id;

                bool isGroupId = int.TryParse(groupId, out id);

                if (isGroupId)
                {
                    _groupService.Delete(id);
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Add correct GroupId type");
                    goto GroupId;
                }
            }
        }
        public void GetById()

        {
        GroupId: Helper.PrintConsole(ConsoleColor.Green, "Add Group Id:");
            string groupId = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
                Group group = _groupService.GetById(id);
                if (group != null)
                {
                    Helper.PrintConsole(ConsoleColor.Yellow, $" Group added successfully! \nId: {group.Id}, \nGroupName: {group.Name},\nGroupTeacher: {group.Teacher},\nGroupRoom: {group.Room}");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Error: Group not found!");
                    goto GroupId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct GroupId type!");
                goto GroupId;
            }
        }
        public void GetAll()
        {
            var groups = _groupService.GetAll();
            if (groups.Count > 0)
            {
                foreach (var group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Green,
                        $"Group Id: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "No groups found! Please create a group first.");
            }
        }

        }
        public void GetByTeacher()
        {
            Helper.PrintConsole(ConsoleColor.Blue, "Enter teacher name:");
            string teacherName = Console.ReadLine();

            var groups = _groupService.GetByTeacher(teacherName);

            if (groups!=null)
            {
                
                
                    Helper.PrintConsole(ConsoleColor.Green,
                        $"Group Id: {groups.Id}, Name: {groups.Name}, Teacher: {groups.Teacher}, Room: {groups.Room}");
                
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "No groups found for this teacher!");
            }
        }

        public void GetByRoom()
        {
      
            Helper.PrintConsole(ConsoleColor.Green, "Add Group Room:");
            string groupRoom = Console.ReadLine().Trim().ToUpper();

            var groups = _groupService.GetByRoom(groupRoom);

            if (groups != null)
            {
                Helper.PrintConsole(ConsoleColor.Green, $"Group Id: {groups.Id}, Name: {groups.Name}, Teacher: {groups.Teacher}, Room: {groups.Room}");
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "No groups found for this room!");
            }

        
        }
        public void Search()
        {
        SearchText: Helper.PrintConsole(ConsoleColor.Blue, "Add Group search text");

            string searchName = Console.ReadLine();
            List<Group>groups=_groupService.Search(searchName);
            if (groups.Count != 0)
            {
                foreach (var group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Cyan,$"Id: {group.Id}, GroupName: {group.Name}, GroupTeacher: {group.Teacher}, GroupRoom: {group.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Groups not found for search text!");
                goto SearchText;
            }
        }
    }

    }
}
