using _8_database.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;


namespace _8_database.Controllers
{
    public class CollegeController : Controller
    {
        private string connStr = "server=localhost;user=root;password=;port=3306;database=college";
        public IActionResult Index()
        {
            List<CollegeModel> collegeList = new List<CollegeModel>();

            MySqlConnection conn = new MySqlConnection(connStr);
            var query = "SELECT * FROM college_table";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                CollegeModel collegeData = new CollegeModel();
                collegeData.Id = Convert.ToInt32(rdr["id"]);
                collegeData.Name = rdr["full_name"].ToString();
                collegeData.Number = rdr["contact_no"].ToString();
                collegeData.Email = rdr["email"].ToString();
                collegeList.Add(collegeData);
            }
            conn.Close();
            return View(collegeList);
        }
    }
}
