using System;
namespace Inheritance
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Family> familyList = new List<Family>();
            familyList.Add(new Family_Member(id: 1, firstname: "Hishan", lastname: "Shrestha", role: "Son"));
            familyList.Add(new Family_Member(id: 1, firstname: "Hari", lastname: "Shrestha", role: "Father"));
            familyList.Add(new Family_Member(id: 1, firstname: "Gyanu", lastname: "Shrestha", role: "Mother"));
            foreach (Family_Member family_Member in familyList)
            {
                family_Member.display();
            }
        }
    }

    public class Family
    {
        public int Id { get; set; } = 0;
        public string LastName { get; set; } = "";

        public Family(int id, string lastname)
        {
            Id = id;
            LastName = lastname;

        }
        public void display()
        {
            Console.WriteLine("This is from parent class");
            Console.WriteLine($"Id={Id}\t Last Name={LastName}{Environment.NewLine}");
        }
    }
    public class Family_Member : Family
    {
        public string FirstName { get; set; } = "";
        public string Role { get; set; } = "";
        public Family_Member(int id, string lastname, string firstname, string role) : base(id, lastname)
        {
            FirstName = firstname;
            Role = role;
        }
        public new void display()
        {
            base.display();
            Console.WriteLine("\nThis is from Child Class");
            Console.WriteLine($"FirstName:{FirstName}\trole={Role}\n");
        }
    }
}