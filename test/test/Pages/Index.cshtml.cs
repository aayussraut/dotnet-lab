using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string WelcomeMessage { get; set; }
        

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //WelcomeMessage="Hi";

        }
        public IActionResult OnPost(string name,string password)
        {
            var conStr = "server=localhost;user=root;password=;database=validation;port=3306";
            MySqlConnection con = new MySqlConnection(conStr);
            var sql = "select count(*) from users where name=@name and password=@password";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@password", password);
            
            try
            {
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count==1)
                {
                    return RedirectToPage("Privacy");
                }
                ViewData["unsucess"]="Login Failed.Please check your username and password";
                WelcomeMessage="Hi";
                return Page();

            }
            catch(Exception ex)
            {
                return Page();
            }
            //WelcomeMessage=name;
            ////return RedirectToPage("Index");
            //return RedirectToPage("Privacy");
        }

    }
}
