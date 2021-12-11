using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPT_project.Models;
using System.Web.Script.Serialization; 
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Http;
using System.Data;

namespace IPT_project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //string Json = System.IO.File.ReadAllText("D:\\semester_7\\IPT\\IPT_project\\PythonScrapping\\data.json");
            //JavaScriptSerializer ser = new JavaScriptSerializer();
            //var carlist = ser.Deserialize<List<CarDetail.Rootobject>>(Json);
            List<carCard> cars = new List<carCard>();
            int i = 0;
            string connString = "Server = localhost;Database = master;Trusted_Connection=True";

            
            //Console.WriteLine("Openning Connection ...");
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    i = 0;
                    conn.Open();

                    //Console.WriteLine("Connection successful!");

                    SqlCommand command;
                    SqlDataReader reader;
                    DataTable dt = new DataTable();
                    string sql;
                    sql = "select * from IPT_CourseProject.dbo.AdsData";
                    using (command = new SqlCommand(sql, conn))
                    {
                        i = 0;
                        using (reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        foreach (DataRow dr in dt.Rows)
                        {
                            object[] items = dr.ItemArray;
                            if (items[0].ToString() != string.Empty)
                            {
                                cars[0].ad_id = items[0].ToString();
                            }
                        }
                        
                    }

                    }
                }
            //Console.WriteLine(cars);
            ViewBag.i = i;
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Detail(string carID)
        {
            ViewBag.id = carID;

            return View();
        }
    }
}