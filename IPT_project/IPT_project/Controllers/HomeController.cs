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
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace IPT_project.Controllers
{
    public class HomeController : Controller
    {
        public static dynamic globalJsonObject;
        public ActionResult Index(string brand_name)
        {
            if(brand_name == null)
            {
                //string Json = System.IO.File.ReadAllText("D:\\semester_7\\IPT\\IPT_project\\PythonScrapping\\data.json");
                //JavaScriptSerializer ser = new JavaScriptSerializer();
                //var carlist = ser.Deserialize<List<CarDetail.Rootobject>>(Json);
                List<carCard> cars = new List<carCard>();

                var dataSource = "DESKTOP-D0VQCM8\\MSSQLSERVERDEV";
                var database = "IPT_CourseProject";
                var username = "sa";
                var password = "owais123";

                string connString = @"Data Source=" + dataSource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

                /*string connString = "Server = localhost;Database = master;Trusted_Connection=True";*/

                SqlConnection conn = new SqlConnection(connString);
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");

                SqlCommand command;
                SqlDataReader reader;
                string sql;
                sql = "select * from IPT_CourseProject.dbo.AdsData";
                command = new SqlCommand(sql, conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine(reader.GetValue(0)+" "+ reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3) + " " + reader.GetValue(4) + " " + reader.GetValue(5) + " " + reader.GetValue(6) + " " + reader.GetValue(7) + " " + reader.GetValue(8) + " " + reader.GetValue(9) + " " + reader.GetValue(10) + " " + reader.GetValue(11) + " " + reader.GetValue(12) + " ");
                    cars.Add(new carCard { ad_id = reader.GetValue(0).ToString(), brand_name = reader.GetValue(1).ToString(), item_condition = reader.GetValue(2).ToString(), model_year = reader.GetValue(3).ToString(), manufacturer = reader.GetValue(4).ToString(), fuel_type = reader.GetValue(5).ToString(), transmission = reader.GetValue(6).ToString(), engine_capacity = reader.GetValue(7).ToString(), description = reader.GetValue(8).ToString(), engine_milegage = reader.GetValue(9).ToString(), image_url = reader.GetValue(11).ToString(), price = reader.GetValue(12).ToString() });

                }
                //Console.WriteLine(cars);
                return View(cars);
            }
            else
            {
                List<carCard> cars = new List<carCard>();
                string connString = "Server = localhost;Database = master;Trusted_Connection=True";

                SqlConnection conn = new SqlConnection(connString);
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");

                SqlCommand command;
                SqlDataReader reader;
                string sql;
                sql = "select * from IPT_CourseProject.dbo.AdsData";
                if (brand_name != null)
                {
                    sql = sql + " where brand_name = @brand_name";
                }
                Console.WriteLine(sql);
                command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("brand_name", brand_name);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine(reader.GetValue(0)+" "+ reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3) + " " + reader.GetValue(4) + " " + reader.GetValue(5) + " " + reader.GetValue(6) + " " + reader.GetValue(7) + " " + reader.GetValue(8) + " " + reader.GetValue(9) + " " + reader.GetValue(10) + " " + reader.GetValue(11) + " " + reader.GetValue(12) + " ");
                    cars.Add(new carCard { ad_id = reader.GetValue(0).ToString(), brand_name = reader.GetValue(1).ToString(), item_condition = reader.GetValue(2).ToString(), model_year = reader.GetValue(3).ToString(), manufacturer = reader.GetValue(4).ToString(), fuel_type = reader.GetValue(5).ToString(), transmission = reader.GetValue(6).ToString(), engine_capacity = reader.GetValue(7).ToString(), description = reader.GetValue(8).ToString(), engine_milegage = reader.GetValue(9).ToString(), image_url = reader.GetValue(11).ToString(), price = reader.GetValue(12).ToString() });

                }
                //Console.WriteLine(cars);
                return View(cars);
            }

           
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
        public static async Task<dynamic> Run(string url)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string responseString = await response.Content.ReadAsStringAsync();
            globalJsonObject = JsonConvert.DeserializeObject(responseString);
            return globalJsonObject;
            /*return jsonObject;*/
            /*Console.WriteLine($"{jsonObject["imageUrls"]}");
            Console.WriteLine($"{jsonObject["carFeatures"]}");
            Console.WriteLine($"{jsonObject["descriptionText"]}");*/


        }
        public ActionResult Detail(string carID)
        {
            if (carID != null)
            {
                ViewBag.id = carID;

                carCard car = new carCard();
                var dataSource = "DESKTOP-D0VQCM8\\MSSQLSERVERDEV";
                var database = "IPT_CourseProject";
                var username = "sa";
                var password = "owais123";

                string connString = @"Data Source=" + dataSource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

                /*string connString = "Server = localhost;Database = master;Trusted_Connection=True";*/

                SqlConnection conn = new SqlConnection(connString);

                
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
                SqlCommand command;
                SqlDataReader reader;
                string sql;
                sql = "select * from dbo.AdsData where ad_id = @ad_id";
                command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("ad_id", carID);
                reader = command.ExecuteReader();
                string details_url = string.Empty;
                while (reader.Read())
                {
                    //car(new carC { ad_id = reader.GetValue(0).ToString(), brand_name = reader.GetValue(1).ToString(), item_condition = reader.GetValue(2).ToString(), model_year = reader.GetValue(3).ToString(), manufacturer = reader.GetValue(4).ToString(), fuel_type = reader.GetValue(5).ToString(), transmission = reader.GetValue(6).ToString(), engine_capacity = reader.GetValue(7).ToString(), description = reader.GetValue(8).ToString(), engine_milegage = reader.GetValue(9).ToString(), image_url = reader.GetValue(11).ToString(), price = reader.GetValue(12).ToString() });
                    car.ad_id = reader.GetValue(0).ToString();
                    car.brand_name = reader.GetValue(1).ToString();
                    car.item_condition = reader.GetValue(2).ToString();
                    car.model_year = reader.GetValue(3).ToString();
                    car.manufacturer = reader.GetValue(4).ToString();
                    car.fuel_type = reader.GetValue(5).ToString();
                    car.transmission = reader.GetValue(6).ToString();
                    car.engine_capacity = reader.GetValue(7).ToString();
                    car.description = reader.GetValue(8).ToString();
                    car.engine_milegage = reader.GetValue(9).ToString();
                    car.image_url = reader.GetValue(11).ToString();
                    car.price = reader.GetValue(12).ToString();
                    details_url = reader.GetValue(10).ToString();
                    break;
                }





                /*string nameToSend = de;*/
                string baseURL = "http://localhost:7071/api/ScrapDetails";
                string urlToInvoke = string.Format("{0}?adUrl={1}", baseURL, details_url);
                dynamic jsonObject = Task.Run(async() => await Run(urlToInvoke)).Result;

                

                
                ViewBag.jsonImages = jsonObject["imageUrls"];
                


                ViewBag.car = car;
                ViewBag.sellerComment = jsonObject["descriptionText"];

                ViewBag.carFeatures = jsonObject["carFeatures"];

                return View();
            }
            else
            {
                ViewBag.car = null;
                return View();
            }
            
        }
    }
}