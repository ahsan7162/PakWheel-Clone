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
        public static DataTable dataTable = new DataTable();
        public static DataTable temp = new DataTable();
        public ActionResult Index(string brand_name, string price, string transmission,string max_year , string min_year ,string fuel, string car_name)
        {
            //if((max_year!=null && max_year!="0") &&(min_year!=null && min_year != "0")){
            //    if (int.Parse(min_year) > int.Parse(max_year))
            //    {
            //        ViewBag.error = "min year cannot be greater then max year";
            //        List<carCard> cars = new List<carCard>();
            //        string connString = "Server = localhost;Database = master;Trusted_Connection=True";

            //        SqlConnection conn = new SqlConnection(connString);
            //        Console.WriteLine("Openning Connection ...");

            //        //open connection
            //        conn.Open();

            //        Console.WriteLine("Connection successful!");

            //        SqlCommand command;
            //        SqlDataReader reader;
            //        string sql;
            //        sql = "select * from IPT_CourseProject.dbo.AdsData";
            //        command = new SqlCommand(sql, conn);
            //        reader = command.ExecuteReader();
            //        while (reader.Read())
            //        { 
            //            cars.Add(new carCard { ad_id = reader.GetValue(0).ToString(), brand_name = reader.GetValue(1).ToString(), item_condition = reader.GetValue(2).ToString(), model_year = reader.GetValue(3).ToString(), manufacturer = reader.GetValue(4).ToString(), fuel_type = reader.GetValue(5).ToString(), transmission = reader.GetValue(6).ToString(), engine_capacity = reader.GetValue(7).ToString(), description = reader.GetValue(8).ToString(), engine_milegage = reader.GetValue(9).ToString(), image_url = reader.GetValue(11).ToString(), price = reader.GetValue(12).ToString() });

            //        }
            //        return View(cars);

            //    }
            //}
            if(car_name==null /*&& brand_name == null  && (price == "0" || price == null) && (transmission == "0" || transmission == null) && (max_year == "0" || max_year == null) && (min_year == "0" || min_year == null) && (fuel == "0" || fuel == null)*/)
            {
                ViewBag.error = "";
                //string Json = System.IO.File.ReadAllText("D:\\semester_7\\IPT\\IPT_project\\PythonScrapping\\data.json");
                //JavaScriptSerializer ser = new JavaScriptSerializer();
                //var carlist = ser.Deserialize<List<CarDetail.Rootobject>>(Json);
                List<carCard> cars = new List<carCard>();

                //var dataSource = "DESKTOP-D0VQCM8\\MSSQLSERVERDEV";
                //var database = "IPT_CourseProject";
                //var username = "sa";
                //var password = "owais123";

                //string connString = @"Data Source=" + dataSource + ";Initial Catalog="
                //        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

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
                if(/*brand_name != "" || transmission !="0" || min_year =="0" || max_year == "0" || fuel != "0" ||*/ car_name != "")
                {
                    sql = sql + " where car_name LIKE '%" + @brand_name + "%'";
                }
                //if (brand_name != null && brand_name != "")
                //{
                //    sql = sql + " brand_name LIKE '%"+@brand_name+"%'";
                //}
                //if(transmission != null && transmission != "" && transmission !="0")
                //{
                //    if(brand_name != "")
                //    {
                //        sql = sql + " AND transmission = @transmission";
                //    }
                //    else
                //    {
                //        sql = sql + " transmission = @transmission";
                //    }
                //}
                //if(min_year != null && min_year != "" && max_year != null && max_year != "")
                //{
                //    if(brand_name != "" || transmission != "0")
                //    {
                //        sql = sql + " AND model_year >= @min_year AND model_year <= @max_year";
                //    }
                //    else
                //    {

                //        sql = sql + " model_year >= @min_year AND model_year <= @max_year";
                //    }
                //}
                //if (fuel !="0")
                //{
                //    if (brand_name != "" || transmission != "0" || min_year!="" || max_year !="")
                //    {
                //        sql = sql + " AND fuel_type = @fuel";
                //    }
                //    else
                //    {
                //        sql = sql + " fuel_type = @fuel";
                //    }
                //}

                //if (car_name != null && car_name != "")
                //{
                //    if(brand_name != "" || transmission != "0" || min_year != "" || max_year != "" || fuel != "0"){
                //        sql = sql + " AND description LIKE '%" + @car_name + "%'";
                //    }
                //    else
                //    {
                //        sql = sql + "description LIKE '%" + @car_name + "%'";
                //    }
                //}

                //    if (price != null && price != "")
                //{
                //    if (price == "1")
                //        sql = sql + " order by price DESC";
                //    if (price == "2")
                //        sql = sql + " order by price ASC";
                //}
                Console.WriteLine(sql);
                command = new SqlCommand(sql, conn);
                //command.Parameters.AddWithValue("brand_name", brand_name);
                command.Parameters.AddWithValue("car_name", car_name);
                //if(min_year == "0")
                //{
                //    command.Parameters.AddWithValue("min_year", "2000");
                //}
                //else
                //{
                //    command.Parameters.AddWithValue("min_year", min_year);
                //}
                //if(max_year == "0")
                //{
                //    command.Parameters.AddWithValue("max_year", "2022");
                //}
                //else
                //{
                //    command.Parameters.AddWithValue("max_year", max_year);
                //}
                //if(transmission == "1")
                //{
                //    command.Parameters.AddWithValue("transmission", "Manual");
                //}
                //if (transmission == "2")
                //{
                //    command.Parameters.AddWithValue("transmission", "Automatic");
                //}
                //command.Parameters.AddWithValue("fuel", fuel);

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
                //var dataSource = "DESKTOP-D0VQCM8\\MSSQLSERVERDEV";
                //var database = "IPT_CourseProject";
                //var username = "sa";
                //var password = "owais123";

                //string connString = @"Data Source=" + dataSource + ";Initial Catalog="
                //        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

                string connString = "server = localhost;database = master;trusted_connection=true";

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
                string baseURL = "https://pakwheelsaddetailsscrapper20211211160440.azurewebsites.net/api/ScrapDetails";
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

        public static async Task<dynamic> Run1(string url)
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
        public ActionResult Live_price()
        {
            string baseURL = "https://toyotawebsitescrapper20211213153031.azurewebsites.net/api/GetLivePricesToyota";
            string urlToInvoke = string.Format("{0}", baseURL);
            dynamic jsonObject = Task.Run(async () => await Run1(urlToInvoke)).Result;
            ViewBag.json = jsonObject;
            return View();
        }

        public ActionResult Search(string car_name ,string price, string transmission, string min_year, string max_year, string fuel)
        {
            ViewBag.trans = "0";
            ViewBag.fuel = "0";
            ViewBag.min_year = "0";
            ViewBag.max_year = "0";
            ViewBag.price = "0";


            if (car_name != null)
            {
                ViewBag.error = "";
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


                sql = "select * from IPT_CourseProject.dbo.AdsData where description LIKE '%" + @car_name + "%'";
                command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("car_name", car_name);
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dataTable);
                Console.WriteLine(dataTable);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cars.Add(new carCard { ad_id = reader.GetValue(0).ToString(), brand_name = reader.GetValue(1).ToString(), item_condition = reader.GetValue(2).ToString(), model_year = reader.GetValue(3).ToString(), manufacturer = reader.GetValue(4).ToString(), fuel_type = reader.GetValue(5).ToString(), transmission = reader.GetValue(6).ToString(), engine_capacity = reader.GetValue(7).ToString(), description = reader.GetValue(8).ToString(), engine_milegage = reader.GetValue(9).ToString(), image_url = reader.GetValue(11).ToString(), price = reader.GetValue(12).ToString() });

                }
                temp = dataTable;
                return View(cars);
            }
            else
            {
                dataTable = temp;
                ViewBag.error = "";
                
                if(transmission!=null || transmission != "0")
                {
                    if(transmission == "1")
                    {
                        ViewBag.trans = "1";
                        dataTable = dataTable.Select("transmission = 'manual'").CopyToDataTable();
                    }
                    if (transmission == "2")
                    {
                        ViewBag.trans = "2";
                        dataTable = dataTable.Select("transmission = 'automatic'").CopyToDataTable();
                    }
                }

                if(fuel != null || fuel != "0")
                {
                    if (fuel == "petrol")
                    {
                        ViewBag.fuel = "petrol";
                        dataTable = dataTable.Select("fuel_type = 'petrol'").CopyToDataTable();
                    }

                    if (fuel == "diesel")
                    {
                        ViewBag.fuel = "diesel";
                        dataTable = dataTable.Select("fuel_type = 'diesel'").CopyToDataTable();
                    }
                    if (fuel == "LPG")
                    {
                        ViewBag.fuel = "LPG";
                        dataTable = dataTable.Select("fuel_type = 'petrol'").CopyToDataTable();
                    }
                    if (fuel == "CNG")
                    {
                        ViewBag.fuel = "CNG";
                        dataTable = dataTable.Select("fuel_type = 'CNG'").CopyToDataTable();
                    }
                    if (fuel == "Electric")
                    {
                        ViewBag.fuel = "Electric";
                        dataTable = dataTable.Select("fuel_type = 'Electric'").CopyToDataTable();
                    }
                    if (fuel == "Hybrid")
                    {
                        ViewBag.fuel = "Hybrid";
                        dataTable = dataTable.Select("fuel_type = 'Hybrid'").CopyToDataTable();
                    }
                }
                if((min_year!=null) && (max_year!=null))
                {
                    ViewBag.min_year = min_year;
                    ViewBag.min_year = max_year;
                    if (int.Parse(min_year) > int.Parse(max_year))
                    {
                        
                        ViewBag.error = "min year cannot be greater then max year";
                    }
                    else
                    {
                        if(max_year == "0")
                        {
                            max_year = "2022";
                        }
                        if(min_year == "0")
                        {
                            min_year = "2000";
                        }
                        dataTable = dataTable.Select("model_year >= '" + min_year + "' AND model_year <= '" + max_year + "'").CopyToDataTable();
                    }
                }

                if (price != null || price != "0")
                {
                    if (price == "1")
                    {
                        ViewBag.price = "1";
                        //dataTable.DefaultView.Sort = "price desc";
                        //dataTable = dataTable.DefaultView.ToTable();

                        dataTable = dataTable.Select("", "price DESC").CopyToDataTable();
                        Console.WriteLine(dataTable);
                    }
                    if (price == "2")
                    {
                        ViewBag.price = "2";
                        //dataTable.DefaultView.Sort = "price asc";
                        //dataTable = dataTable.DefaultView.ToTable();
                        dataTable = dataTable.Select("", "price ASC").CopyToDataTable();
                    }
                }

                List<carCard> cars = new List<carCard>();
                cars = (from DataRow dr in dataTable.Rows
                               select new carCard()
                               {
                                    ad_id = dr["ad_id"].ToString(),
                                    brand_name = dr["brand_name"].ToString(),
                                    item_condition = dr["item_condition"].ToString(),
                                    model_year = dr["model_year"].ToString(),
                                    manufacturer = dr["manufacturer"].ToString(),
                                    fuel_type = dr["fuel_type"].ToString(),
                                    transmission = dr["transmission"].ToString(),
                                    engine_capacity = dr["engine_capacity"].ToString(),
                                    description = dr["description"].ToString(),
                                    engine_milegage = dr["engine_mileage"].ToString(),
                                    image_url = dr["image_url"].ToString(),
                                    price = dr["price"].ToString()
                               }).ToList();
                return View(cars);
            }

            
        }

    }
}