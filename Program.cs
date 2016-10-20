using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

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
        
        string address = Console.ReadLine();
        IJSONAPI api = new MashapeAPI();
        // NutritionItem n = api.GetData<NutritionItem>("some url here");
        // Console.WriteLine(JsonConvert.SerializeObject(data));
    }
}
