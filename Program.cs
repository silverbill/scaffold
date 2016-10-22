using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Xml.Linq;

public class Program
{
    
    public static void Main(string[] args)
    {
        prompt().Wait();
    }
    StringWriter csvContent = new StringWriter();
    csvConte
    public static async Task prompt()
    {
        Console.WriteLine(@"
        Hey! Listen!
        
        --------
        
        Enter a food or beverage to get caloric info:


        ");
        string filePath = @"/Users/bryansory/code/scaffold/nutrionix.csv";  
        string term = Console.ReadLine();
        IJSONAPI mashapi = new MashapeAPI();
        var apiKey = "8H6stHhT25mshXH1okEaCywiRiCUp1DYIsxjsnyespJHYCy7ca";        
        Nutrition n = await mashapi.GetData<Nutrition>(term,apiKey);
        
        if(term == "" || term == "n") {
            Environment.Exit(0);
        } else if (n.hits.Count() > 0){
            string item = n.hits.ElementAt(0).fields.item_name;
            double? calories = n.hits.ElementAt(0).fields.nf_calories ?? 0;
            double? fatGrams = n.hits.ElementAt(0).fields.nf_total_fat ?? 0;
              //csv1: add path
            
            Console.WriteLine("Item: "+item+" Calories: "+calories+" Fat Grams: "+fatGrams+" grams");
            prompt().Wait();
        }    
        

        //Console.WriteLine(mashapi.ToJSON(n));  

        // IJSONAPI googapi = new GoogleAPI();   
        // Google g = await googapi.GetData<Google>("tacos", "APIKEY"); 
        // Console.WriteLine(googapi.ToJSON(g));
    }
}
