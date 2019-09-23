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
        // GET: /<controller>/
        TriviaChallenge triviaChallenge;
        public async Task<TriviaChallenge> GetTrivia()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://jservice.io/api/random");
            List<TriviaChallenge> respArr = await response.Content.ReadAsAsync<List<TriviaChallenge>>();
            triviaChallenge = respArr[0];
            return triviaChallenge;
        }

            public async Task<IActionResult> Index(string xp)
        {
            await GetTrivia();
            ViewData["Question"] = triviaChallenge.question;
            ViewData["Value"] = triviaChallenge.value;
            ViewData["Category"] = triviaChallenge.category.title;
            ViewData["Answer"] = triviaChallenge.answer;
            ViewData["Xp"] = xp;
            return View();
        }

        

        public async Task<IActionResult> Answer(string playerAnswer, string answer, string value, string xp)
        {
            int IntXp = Int32.Parse(xp);
            string LcPlayerAns = playerAnswer.ToLower();
            string LcCorrectAns = answer.ToLower();
            if (LcCorrectAns.Contains(LcPlayerAns))
            {
                ViewData["Response"] = "You Got It!";
                IntXp += Int32.Parse(value);
            }
            else
            {
                ViewData["Response"] = "You missed!";
            }
            ViewData["PlayerAnswer"] = playerAnswer;
            ViewData["Answer"] = answer;
            ViewData["Xp"] = IntXp;
            return View();

        }
    }
}
