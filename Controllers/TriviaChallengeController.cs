using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sharpen.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sharpen.Controllers
{

    public class TriviaChallengeController : Controller
    {
        //static HttpClient client = new HttpClient();
        //static async Task RunAsync()
        //{
        //    // Update port # in the following line.
        //    client.BaseAddress = new Uri("http://jservice.io/api/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));

        //    try
        //    {
        //        TriviaChallenge triviaChallenge = new TriviaChallenge;
        //        // Get the question object
        //        triviaChallenge = await GetProductAsync("random");
        //        //ShowProduct(product);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}

        //static async IAsyncEnumerable<TriviaChallenge> GetProductAsync()
        //{
        //    client.BaseAddress = new Uri("http://jservice.io/api/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));

            
            //TriviaChallenge triviaChallenge = null;
            //HttpResponseMessage response = await client.GetAsync("random");
            //if (response.IsSuccessStatusCode)
            //{
                //List<TriviaChallenge> respArr = await response.Content.ReadAsAsync<List<TriviaChallenge>>();
                //yield return respArr[0];
            //}
            
        //}

        // GET: /<controller>/

        public async Task<TriviaChallenge> Index()
        {
            Console.WriteLine("Hello");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://jservice.io/api/random");
            List<TriviaChallenge> respArr = await response.Content.ReadAsAsync<List<TriviaChallenge>>();
            TriviaChallenge triviaChallenge = respArr[0];
            //ViewData["Question"] = triviaChallenge.question;
            //ViewData["Category"] = triviaChallenge.category.title;
            return triviaChallenge;
        }
    }
}
