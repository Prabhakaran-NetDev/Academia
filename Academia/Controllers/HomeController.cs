using Academia.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace Academia.Controllers
{
    public class HomeController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        public ActionResult Index()
        {
            List<Courses> Obj = new List<Courses>();
            using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
            {
                DbCon.Open();
                SqlCommand SqlCmd = new SqlCommand("sp_fetch_Courses", DbCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = SqlCmd.ExecuteReader();

                while (sdr.Read())
                {
                    Obj.Add(new Courses
                    {
                        CourseID = Convert.ToInt32(sdr[0]),
                        Title = sdr[1].ToString(),
                        Description = sdr[2].ToString(),
                        InstructorID = Convert.ToInt32(sdr[3]),
                        Price = Convert.ToDecimal(sdr[4]),
                        DurationWeeks = Convert.ToInt32(sdr[5]),
                        StartDate = Convert.ToDateTime(sdr[6]),
                        EndDate = Convert.ToDateTime(sdr[7]),
                        Category = sdr[8].ToString()
                    });
                }
                DbCon.Close();
            }
            if (Session["UserRole"] == null)
            {
                return View("Index", Obj);
            }
            else if (Session["UserRole"].ToString() == "admin")
            {
                return RedirectToAction("../Users/Index");
            }
            else if (Session["UserRole"].ToString() == "manager")
            {
                return RedirectToAction("../Users/Index");
            }
            else if (Session["UserRole"].ToString() == "staff")
            {
                return RedirectToAction("../Users/Index");
            }
            else
            {
                return View(Obj);
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Detailed description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Detailed contact page.";

            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}