using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Xml.Linq;
using System.Text;
using System.Diagnostics;

public class Program
{
    
    public static void Main(string[] args)
    
    {
        prompt().Wait();
    }
    
    public static async Task prompt()
    {
        Console.WriteLine(@"
        Hey! Listen!
        
        --------
        
        Enter a food or beverage to get caloric info:


        ");
        string term = Console.ReadLine();
        IJSONAPI mashapi = new MashapeAPI();
        var apiKey = "8H6stHhT25mshXH1okEaCywiRiCUp1DYIsxjsnyespJHYCy7ca";        
        Nutrition n = await mashapi.GetData<Nutrition>(term,apiKey);
        
        //Directory.CreateDirectory("csv");
        
        if(term == "" || term == "n") {
            Environment.Exit(0);
        } else if (n.hits.Count() > 0){
            string item = n.hits.ElementAt(0).fields.item_name;
            double? calories = n.hits.ElementAt(0).fields.nf_calories ?? 0;
            double? fatGrams = n.hits.ElementAt(0).fields.nf_total_fat ?? 0;            
            Console.WriteLine("Item: "+item+" Calories: "+calories+" Fat Grams: "+fatGrams+" grams");
            string stickem = ("Item: "+item+" Calories: "+calories+" Fat Grams: "+fatGrams+" grams");
            Console.WriteLine(stickem);
            string x = @"csv/nutrix.csv";
            
            StreamWriter file2 = new StreamWriter(@"nutrix.csv", true);
            file2.WriteLine(stickem);
            file2.Close();
            
            if (!File.Exists(stickem))
            {File.WriteAllText(x, stickem.ToString());}
            else
            {File.AppendAllText(x,stickem.ToString());}

            prompt().Wait();

        }

    }
}           
            //File.WriteAllText(@"csv/nutrix.csv", csvcontent.ToString()); //csvcontent.ToString()
            
            
        
        
        // public void WriteData2File(string filename){
        // string x = "csv/nutrix.csv";

        // if (!File.Exists(filename))
        // {File.WriteAllText(x, filename.ToString());}
        // else
        // {File.AppendAllText(x,filename.ToString());}

      
        // }    
        

    



        //Console.WriteLine(mashapi.ToJSON(n));  

        // IJSONAPI googapi = new GoogleAPI();   
        // Google g = await googapi.GetData<Google>("tacos", "APIKEY"); 
        // Console.WriteLine(googapi.ToJSON(g));

