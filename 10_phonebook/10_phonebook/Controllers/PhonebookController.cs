using _10_phonebook.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace _10_phonebook.Controllers
{
    public class PhonebookController : Controller
    {
        private string connStr = "server=localhost;user=root;password=;port=3306;database=phonebook";
        public IActionResult Index()
        {
            List<PhonebookModel> phoneBookList = new List<PhonebookModel>();

            MySqlConnection conn = new MySqlConnection(connStr);
            var query = "SELECT * FROM phonebook";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                PhonebookModel phoneData = new PhonebookModel();
                phoneData.Id = Convert.ToInt32(rdr["id"]);
                phoneData.Name = rdr["name"].ToString();
                phoneData.Number = rdr["number"].ToString();
                phoneData.Email = rdr["email"].ToString();
                phoneBookList.Add(phoneData);
            }
            conn.Close();
            return View(phoneBookList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PhonebookModel toAddData)
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            var query = "INSERT INTO phonebook (name, number,email) VALUES (@name, @number,@email)";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@name", toAddData.Name);
            cmd.Parameters.AddWithValue("@number", toAddData.Number);
            cmd.Parameters.AddWithValue("@email", toAddData.Email);

            conn.Open();
            if (ModelState.IsValid)
            {
                cmd.ExecuteNonQuery();
            }
           
            conn.Close();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            MySqlConnection conn = new MySqlConnection(connStr);

            var query = "SELECT * FROM phonebook WHERE ID=@id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();

            PhonebookModel phoneData = new PhonebookModel();
            while (rdr.Read())
            {
                phoneData.Id = Convert.ToInt32(rdr["id"]);
                phoneData.Name = rdr["name"].ToString();
                phoneData.Number = rdr["number"].ToString();
                phoneData.Email = rdr["email"].ToString();
            }
            conn.Close();

            if (phoneData == null)
            {
                return NotFound();
            }

            return View(phoneData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PhonebookModel updatedData)
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            var query = "UPDATE phonebook SET name=@name, number=@number, email=@email WHERE id=@id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", updatedData.Id);
            cmd.Parameters.AddWithValue("@name", updatedData.Name);
            cmd.Parameters.AddWithValue("@number", updatedData.Number);
            cmd.Parameters.AddWithValue("@email", updatedData.Email);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            var query = "DELETE FROM phonebook WHERE id=@id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();

            return RedirectToAction("Index");
        }
    }
}


