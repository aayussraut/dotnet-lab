namespace EnumClass
{
    public class Staff
    {
        public int id { get; set; } = 0;
        public string f_name { get; set; } = "";
        public string m_name { get; set; } = "";
        public string l_name { get; set; } = "";
        public string gender { get; set; } = "";
        public int age { get; set; } = 0;
        public designation desig { get; set; } = designation.NormalStaff;

        public enum designation
        {
            CEO,
            Manager,
            BranchManager,
            Accountant,
            HR,
            NormalStaff
        }
        public Staff(int iid, string sf_name, string sm_name, string sl_name, string sgender, int iage, designation d)
        {
            id=iid;
            f_name=sf_name;
            m_name=sm_name;
            l_name=sl_name;
            gender=sgender;
            age=iage;
            desig=d;

        }
        public string getInfo()
        {
            string full_detail = "";
            full_detail+=$"id: {id}{Environment.NewLine}";
            full_detail+="Fullname: "+f_name +" "+(m_name.Trim().Length>0 ? m_name+" " : "")+" "+l_name+Environment.NewLine;
            full_detail+="Gender: "+gender+Environment.NewLine;
            full_detail+="Age: "+age+Environment.NewLine;
            full_detail+="Post: "+desig+Environment.NewLine;
            return full_detail;
        }
    }

    class program
    {
        public static void Main()
        {
            List<Staff> staff_details = new List<Staff>()
            {
                new Staff(1,"Aayush","","Raut","Male",22,Staff.designation.CEO),
                new Staff(2,"Amresh","Kumar","Chaudhary","Male",22,Staff.designation.BranchManager),
                new Staff(3,"Kriti","","Shrestha","Female",22,Staff.designation.NormalStaff),
                new Staff(4,"Karishma","","Chapagain","Female",29,Staff.designation.Manager),
                new Staff(5,"Prasmit","","Neupane","Male",25,Staff.designation.HR)
            };
            var aa = from s in staff_details where s.gender=="Female" orderby s.desig ascending select s ;
            foreach (var a in aa)
            {
                Console.WriteLine(a.getInfo());
            }
        }
    }
}