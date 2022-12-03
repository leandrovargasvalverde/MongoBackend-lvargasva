using Microsoft.AspNetCore.Mvc;
using MongoBackend.DatabaseHelper;
using MongoBackend.Models;
using MongoDB.Bson;
using System.Diagnostics;
namespace MongoBackend.Controllers
{
    public class HomeController : Controller
    {
        private IUserCollection db = new UserCollection();



        //GET
        public ActionResult Index()
        {
            var user = db.GetAllUsers();
            return View(user);
        }  
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet("{id1}/edit")]
        public ActionResult Edit(string id1)
        {
            var user = db.GetUserById(id1);

            return View(user);
        }
        [HttpGet("{id2}/delete")]
        public ActionResult Delete(string id2)
        {
            var user = db.GetUserById2(id2);

            return View(user);
        }
        //POST

        /*public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var user = new User()
                {
                    name = collection["name"],
                    email = collection["email"],
                    phone = int.Parse(collection["phone"]),
                    address = collection["address"],
                    dateIn = DateTime.Parse(collection["DateIn"])
                };
                db.InsertUser(user);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
        [HttpPost]
        public IActionResult SaveUser(string txtName,
                                    string txtLastName,
                                    string txtPhone,
                                    string txtEmail,
                                    string txtAddress)
        {
            Database.insertUser(new Models.User()
            {
                name = txtName,
                email = txtEmail,
                phone = Convert.ToInt32(txtPhone),
                address = txtAddress,
                dateIn = DateTime.Now
            });

            return RedirectToAction("Index", "Home");
        }
            [HttpPost("{id1}/edit")]
        public ActionResult Edit(string id1, IFormCollection collection)
        {
            try
            {
                var user = new User()
                {
                    _id = new ObjectId(id1),
                    name = collection["name"],
                    email = collection["email"],
                    phone = int.Parse(collection["phone"]),
                    address = collection["address"],
                    dateIn = DateTime.Parse(collection["DateIn"])
                };
                db.UpdateUser(user);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost("{id2}/delete")]
        public ActionResult Delete(string id2, IFormCollection collection)
        {
            try
            {
                db.DeleteUser(id2);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}