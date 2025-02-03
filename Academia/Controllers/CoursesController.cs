using Academia.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academia.Controllers
{
    public class CoursesController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
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
                return View(Obj);
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // GET 
        public ActionResult Details(int id)
        {
            try
            {
                Courses Obj = new Courses();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Courses", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@CourseID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Courses
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
                        };
                    }
                    DbCon.Close();
                }
                return View(Obj);
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Create(Courses Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Courses", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@CourseID", Obj.CourseID);
                    SqlCmd.Parameters.AddWithValue("@Title", Obj.Title);
                    SqlCmd.Parameters.AddWithValue("@Description", Obj.Description);
                    SqlCmd.Parameters.AddWithValue("@InstructorID", Obj.InstructorID);
                    SqlCmd.Parameters.AddWithValue("@Price", Obj.Price);
                    SqlCmd.Parameters.AddWithValue("@DurationWeeks", Obj.DurationWeeks);
                    SqlCmd.Parameters.AddWithValue("@StartDate", Obj.StartDate);
                    SqlCmd.Parameters.AddWithValue("@EndDate", Obj.EndDate);
                    SqlCmd.Parameters.AddWithValue("@Category", Obj.Category);

                    SqlCmd.ExecuteNonQuery();
                    DbCon.Close();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // GET
        public ActionResult Edit(int id)
        {
            try
            {
                Courses Obj = new Courses();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Courses", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@CourseID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Courses
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
                        };
                    }
                    DbCon.Close();
                }
                return View(Obj);
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // POST
        [HttpPost]
        public ActionResult Edit(int id, Courses Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Courses", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@CourseID", Obj.CourseID);
                    SqlCmd.Parameters.AddWithValue("@Title", Obj.Title);
                    SqlCmd.Parameters.AddWithValue("@Description", Obj.Description);
                    SqlCmd.Parameters.AddWithValue("@InstructorID", Obj.InstructorID);
                    SqlCmd.Parameters.AddWithValue("@Price", Obj.Price);
                    SqlCmd.Parameters.AddWithValue("@DurationWeeks", Obj.DurationWeeks);
                    SqlCmd.Parameters.AddWithValue("@StartDate", Obj.StartDate);
                    SqlCmd.Parameters.AddWithValue("@EndDate", Obj.EndDate);
                    SqlCmd.Parameters.AddWithValue("@Category", Obj.Category);

                    SqlCmd.ExecuteNonQuery();
                    DbCon.Close();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // GET
        public ActionResult Delete(int id)
        {
            try
            {
                Courses Obj = new Courses();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Courses", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@CourseID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Courses
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
                        };
                    }
                    DbCon.Close();
                }
                return View(Obj);
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // POST
        [HttpPost]
        public ActionResult Delete(int id, Courses Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_Courses", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@CourseID", id);

                    SqlCmd.ExecuteNonQuery();
                    DbCon.Close();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }
    }
}
