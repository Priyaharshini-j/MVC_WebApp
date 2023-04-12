using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVC_WebApp.Models;

namespace MVC_WebApp.Controllers
{
    public class StudentController : Controller
    {
        //in order o view the page on student controller we have to give the name of IActionResult with file name
        public IActionResult Student()
        {

            return View();
        }

        public IConfiguration Configuration {
            get; set;
        }
        IConfiguration configuration;
        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public StudentModel student = new StudentModel();
        public List<StudentModel> students = new List<StudentModel>();
        public IActionResult Index() {

           // String CONN_STRING = "Data Source=LocalHost;Encrypt=False;Initial Catalog=Practice;Integrated Security=True;";
            string connString = configuration.GetConnectionString("StudentDB");
            SqlConnection connect = new SqlConnection(connString);
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandText = "SELECT * from StudentDB;";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                StudentModel student= new StudentModel();
                student.Id = reader.GetInt32(0);
                student.Name = reader.GetString(1);
                student.Dept = reader.GetString(2);
                student.Age = reader.GetInt32(3);
                student.DoB = reader.GetDateTime(4);
                student.Email = reader.GetString(5);


                //we fetch the details of one book and store it in a list with properties of BooksFetch class
                students.Add(student);
               
            }

            ViewBag.students = students;

            return View();
        }
    }
}
