using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaWebsiteScrapper
{
    class ToyotaCars
    {
        public string url { get; set; }
        public string price { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string slogan { get; set; }

        public void Display()
        {
            Console.WriteLine("====================== Car Information ======================");
            Console.WriteLine($"** Name: {name} \n** Price: {price} \n** Slogan: {slogan} \n** Redirect Url: {url}\n** Image Url: {image}\n");
        }
    }
}
