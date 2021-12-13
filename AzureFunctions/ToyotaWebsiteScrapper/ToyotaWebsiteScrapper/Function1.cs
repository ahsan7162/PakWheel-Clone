using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;

using HtmlAgilityPack;
namespace ToyotaWebsiteScrapper
{
    public static class Function1
    {
        [FunctionName("GetLivePricesToyota")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            HtmlWeb web = new HtmlWeb();

            string webUrl = "https://www.toyota-indus.com/";

            HtmlDocument doc = web.Load(webUrl);

            var carList = new List<ToyotaCars>();

            try
            {
                var DataRow = doc.DocumentNode.SelectSingleNode("//div[@class='row discover-range-cont']");


                try
                {
                    var a = DataRow.SelectSingleNode(".//div[@class='container']");
                    var b = a.SelectSingleNode(".//div[@class='eds-animate edsanimate-sis-hidden ']");
                    var c = b.SelectSingleNode(".//div[@id='lcs_logo_carousel_slider']");
                    var d = c.SelectNodes(".//div[@class='lcs_logo_container']");
                    /*Console.WriteLine($"Images Count: {d.Count}");*/
                    int i = 0;
                    foreach (var alpha in d)
                    {
                        // searching redirecting URL tag
                        var redirectUrl = alpha.SelectSingleNode(".//a");
                        /*Console.WriteLine($"{redirectUrl.GetAttributeValue("href","")}");*/


                        string url = string.Empty;      // variable to store redirect url
                        string price = string.Empty;    // variable to store price of car
                        string name = string.Empty;     // variable to store the name of the car
                        string image = string.Empty;    // variable to store the image url of the car
                        string slogan = string.Empty;   // variable to store the slogan of the car

                        if (redirectUrl.GetAttributeValue("href", "").Contains("https://toyota-indus.com"))
                        {
                            url = redirectUrl.GetAttributeValue("href", "");
                        }
                        else
                        {
                            url = "https://toyota-indus.com" + redirectUrl.GetAttributeValue("href", "");
                        }

                        // searching for image tag
                        var imageUrl = redirectUrl.SelectSingleNode(".//img");
                        image = imageUrl.GetAttributeValue("src", "");
                        /*Console.WriteLine($"{imageUrl.GetAttributeValue("src", "")}");*/

                        var e = alpha.SelectSingleNode(".//a[@target='_blank']");

                        var f = e.SelectSingleNode(".//div[@class='lcs_logo_title']");
                        string details = f.InnerText;


                        /*Console.WriteLine(details);*/
                        i++;
                        var information = details.Split(new string[] { "  " }, StringSplitOptions.None);

                        // splitting the information for necessary section
                        name = information[0];

                        /*Console.WriteLine($"{details}");*/
                        /*Console.WriteLine($"Name: {name}");*/

                        var g = f.SelectSingleNode(".//span");
                        /*Console.WriteLine($"Price: {g.InnerText}");*/
                        price = g.InnerText;

                        var h = f.SelectSingleNode(".//div[@class='slogan']");
                        /*Console.WriteLine($"Slogan: {h.InnerText}\n");*/
                        slogan = h.InnerText;


                        ToyotaCars obj = new ToyotaCars();

                        // setting urlattributes of object
                        obj.url = url;
                        obj.price = price;
                        obj.name = name;
                        obj.image = image;
                        obj.slogan = slogan;

                        /*obj.Display();*/

                        carList.Add(obj);

                        /*Console.WriteLine("Tag Found");*/
                    }
                    /*Console.WriteLine($"AdsCount: {i}");*/


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception Found while looking for carousel tag");
                }
            }
            catch (Exception ex)
            {
                // do nothing
            }


            // deserializing the list as json object


            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(carList, Formatting.Indented), Encoding.UTF8, "application/json")
            };
        }
    }
}
