using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Front.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Front.Controllers
{
    public class ArticlesController : Controller
    {
        // POST: Articles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Article article)
        {
            try
            {
                //Article artilce = new Article();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:64861/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //var jsonObj = JsonConvert.SerializeObject(article);

                    var response = await client.PostAsJsonAsync<Article>("Articles", article);

                    if (response.IsSuccessStatusCode)
                    {
                        return Redirect("index");
                    }
                    else
                    {
                        //return BadRequest();
                        return Redirect("index");
                    }

                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {

            List<Article> artilces = new List<Article>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64861/");
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/articles");
                if (response.IsSuccessStatusCode)
                {
                    return View(await response.Content.ReadAsAsync<IEnumerable<Article>>());
                }
                else
                {
                    //return BadRequest();
                    return View(new List<Article>());
                }

            }
        }

        // GET: Articles/Details/guid
        //http://localhost:25273/Articles/Details/387ecbbf-90e0-4b72-8768-52c583fc715b
        public async Task<IActionResult> Details(Guid id)
        {
            Article artilces = new Article();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64861/");
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/articles/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<Article>(jsonString);

                    return View(model);
                }
                else
                {
                    //return BadRequest();
                    return View(new ErrorViewModel());
                }

            }
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            return View();
        }


        // GET: Articles/Edit/5
        //http://localhost:64861/api/articles/Edit/387ecbbf-90e0-4b72-8768-52c583fc715b
        public async Task<IActionResult> Edit(Guid id)
        {           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64861/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/articles/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return View(await response.Content.ReadAsAsync<Article>());
                }
                else
                {
                    //return BadRequest();
                    return View(new Article());
                }

            }            
        }

        // POST: Articles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Article article)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:64861/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //var jsonObj = JsonConvert.SerializeObject(article);

                    var response = await client.PutAsJsonAsync<Article>("Articles/" + id, article);

                    if (response.IsSuccessStatusCode)
                    {
                        return Redirect("index");
                    }
                    else
                    {
                        //return BadRequest();
                        return View(new ErrorViewModel());
                    }

                }


            }
            catch
            {
                return View();
            }
        }

        // GET: Articles/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id, Article article)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64861/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/articles/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return View(await response.Content.ReadAsAsync<Article>());
                }
                else
                {
                    //return BadRequest();
                    return View(new Article());
                }

            }
        }

        // POST:
        //http://localhost:25273/Articles/Delete/387ecbbf-90e0-4b72-8768-52c583fc715b
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:64861/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.DeleteAsync("api/articles/" + id);
                    if (response.IsSuccessStatusCode)
                    {

                        return Redirect("Index");
                    }
                    else
                    {
                        //return BadRequest();
                        return View(new ErrorViewModel());
                    }

                }


            }
            catch
            {
                return View();
            }
        }
    }

}

