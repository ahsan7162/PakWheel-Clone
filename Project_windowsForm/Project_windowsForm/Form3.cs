using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace Project_windowsForm
{
    public partial class Form3 : Form
    {
        public static dynamic globalJsonObject;
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
        public Form3()
        {
            InitializeComponent();
            string baseURL = "https://toyotawebsitescrapper20211213153031.azurewebsites.net/api/GetLivePricesToyota";
            string urlToInvoke = string.Format("{0}", baseURL);
            dynamic jsonObject = Task.Run(async () => await Run1(urlToInvoke)).Result;
            DataTable dtdata = new DataTable();
            dtdata.Columns.Add("Name");
            dtdata.Columns.Add("Starting From (Price)");
            dtdata.Columns.Add("URL");

            foreach ( var item in jsonObject)
            {
                DataRow row = dtdata.NewRow();
                row[0] = item.name;
                row[1] = item.price;
                row[2] = item.url;
                dtdata.Rows.Add(row);
            }
            dataGridView1.DataSource = dtdata;
            dataGridView1.Columns[2].Width = 400;
            dataGridView1.Columns[1].Width = 200;
        }
    }
}
