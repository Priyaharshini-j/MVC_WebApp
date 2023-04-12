using Microsoft.Data.SqlClient;
using System;

namespace MVC_WebApp.Models
{
    
public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public int Age{ get; set;}
        public DateTime DoB { get; set;}
        public string Email { get; set; }

    }


}
