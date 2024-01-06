using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Raythose.DB;
using Raythose.Models;
using Rythose.Models;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Rythose.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext ctx;

        public UserController(ApplicationDbContext db)
        {
            this.ctx = db;
        }

        public IActionResult Index()
        {
            IEnumerable<User> objList = ctx.tbl_user.Where(u => u.UserId != 1).ToList();
            return View(objList);
        }


        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add_action(string Username, string Password, string StaffName, string adminPassword)
        {
            string UserType = "Staff";
            string hashedAdminPassword = GetMD5Hash(adminPassword);

            // Check if the hashedAdminPassword is similar to the Password of UserId=1
            var adminUser = ctx.tbl_user.FirstOrDefault(u => u.UserId == 1);
            if (adminUser != null && adminUser.Password == hashedAdminPassword)
            {
                string HashedUserPassword = GetMD5Hash(Password);

                var newUser = new User
                {
                    Username = Username,
                    Password = HashedUserPassword,
                    UserType = UserType,
                    StaffName = StaffName
                };

                ctx.tbl_user.Add(newUser);
                ctx.SaveChanges();

                HttpContext.Session.SetString("Success", "Successfully Created a Staff User");
                return RedirectToAction("Index");
            }
            else
            {
                HttpContext.Session.SetString("Error", "Need the Admin Password to create a Staff User");
                return RedirectToAction("Add");
            }
        }

        [HttpPost]
        public IActionResult Update(string Username, string Password, int UserId)
        {
            string HashedUserPassword = GetMD5Hash(Password);
            string sql1 = "UPDATE tbl_user SET Username = @username, Password= @password  WHERE UserId = @UserId";

            ctx.Database.ExecuteSqlRaw(sql1,
                new SqlParameter("@username", Username),
                new SqlParameter("@UserId", UserId),
                new SqlParameter("@password", HashedUserPassword)
            );

            ctx.SaveChanges();
            HttpContext.Session.SetString("Success", "User Data Updated Successfully");

            return RedirectToAction("Index");
        }


        public IActionResult Remove(int id)
        {
            var userToRemove = ctx.tbl_user.Find(id);

            if (userToRemove == null)
            {
                return NotFound();
            }

            ctx.tbl_user.Remove(userToRemove);

            ctx.SaveChanges();
            HttpContext.Session.SetString("Success", "User Successfully Removed");

            return RedirectToAction("Index");
        }


        // MD5 hashing function
        private string GetMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
