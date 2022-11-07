using MySql.Data.MySqlClient;
using System;

namespace ConsoleDB
{
    class Program
    {
        static string conStr = "server=localhost;user=root;password=;database=consoledb;port=3306";

        static void Main(string[] args)
        {
            DisplayOption();
        }
        public static void DisplayOption()
        {
            Console.WriteLine("\nEnter your option\n1: Add Data\n2: List Data\n3: Quit");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Console.Write("Enter full name (string) :\t");
                    string full_name = Console.ReadLine();
                    Console.Write("Enter Contact No (string) :\t");
                    string contact = Console.ReadLine();
                    Console.Write("Enter Email (string) :\t");
                    string email = Console.ReadLine();
                    var sql2 = "INSERT INTO address (id, full_name, contact_no, email) " +
                    $"VALUES (null, '{full_name}', '{contact}', '{email}')";
                    WriteToDatabase(sql2);
                    break;
                case 2:
                    var sql = "SELECT * FROM address";
                    ReadFromDatabase(sql);
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
        public static void ReadFromDatabase(string sql)
        {
            MySqlConnection conn = new MySqlConnection(conStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2] + " -- " + rdr[3]);
                }
                rdr.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            conn.Close();
            //Console.WriteLine("Connection Closed. Press any key to exit...");
            DisplayOption();
        }

        public static void WriteToDatabase(string sql)
        {
            MySqlConnection conn = new MySqlConnection(conStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Inserted successfully.");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            conn.Close();
            //Console.WriteLine("Connection Closed. Press any key to exit...");
            DisplayOption();
        }
    }


}
