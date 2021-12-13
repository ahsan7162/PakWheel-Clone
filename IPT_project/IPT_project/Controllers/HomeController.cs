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
        public ActionResult Index(string brand_name,string price)
        {
            if(brand_name == null  && price == null)
            {
                //string Json = System.IO.File.ReadAllText("D:\\semester_7\\IPT\\IPT_project\\PythonScrapping\\data.json");
                //JavaScriptSerializer ser = new JavaScriptSerializer();
                //var carlist = ser.Deserialize<List<CarDetail.Rootobject>>(Json);
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
                if (brand_name != null && brand_name != "")
                {
                    sql = sql + " where brand_name = @brand_name";
                }
                if (price != null && price != "")
                {
                    if (price == "1")
                        sql = sql + " order by price DESC";
                    if (price == "2")
                        sql = sql + " order by price ASC";
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
            dynamic jsonObject = JsonConvert.DeserializeObject(responseString);
            return jsonObject;
            Console.WriteLine($"{jsonObject["imageUrls"]}");
            Console.WriteLine($"{jsonObject["carFeatures"]}");
            Console.WriteLine($"{jsonObject["descriptionText"]}");


        }
        public ActionResult Detail(string carID)
        {
            if (carID != null)
            {
                ViewBag.id = carID;

                carCard car = new carCard();
                string connString = "Server = localhost;Database = master;Trusted_Connection=True";

                SqlConnection conn = new SqlConnection(connString);
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
                SqlCommand command;
                SqlDataReader reader;
                string sql;
                sql = "select * from IPT_CourseProject.dbo.AdsData where ad_id = @ad_id";
                command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("ad_id", carID);
                reader = command.ExecuteReader();
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
                    break;
                }





                //string nameToSend = "https://www.pakwheels.com/used-cars/suzuki-mehran-1997-for-sale-in-toba-tek-singh-5701434";
                //string baseURL = "https://pakwheelsaddetailsscrapper20211211160440.azurewebsites.net/api/ScrapDetails";
                //string urlToInvoke = string.Format("{0}?adUrl={1}", baseURL, nameToSend);
                //var jsonObject = Run(urlToInvoke);
                //ViewBag.json = jsonObject["imageUrls"];
                ViewBag.car = car;
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