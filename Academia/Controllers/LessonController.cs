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
    public class LessonController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<Lesson> Obj = new List<Lesson>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_Lessons", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new Lesson
                        {
                            LessonID = Convert.ToInt32(sdr[0]),
                            CourseID = Convert.ToInt32(sdr[1]),
                            Title = sdr[2].ToString(),
                            Content = sdr[3].ToString(),
                            VideoURL = sdr[4].ToString(),
                            OrderIndex = Convert.ToInt32(sdr[5])
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
                Lesson Obj = new Lesson();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Lessons", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@LessonID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Lesson
                        {
                            LessonID = Convert.ToInt32(sdr[0]),
                            CourseID = Convert.ToInt32(sdr[1]),
                            Title = sdr[2].ToString(),
                            Content = sdr[3].ToString(),
                            VideoURL = sdr[4].ToString(),
                            OrderIndex = Convert.ToInt32(sdr[5])
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
        public ActionResult Create(Lesson Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Lessons", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@LessonID", Obj.LessonID);
                    SqlCmd.Parameters.AddWithValue("@CourseID", Obj.CourseID);
                    SqlCmd.Parameters.AddWithValue("@Title", Obj.Title);
                    SqlCmd.Parameters.AddWithValue("@Content", Obj.Content);
                    SqlCmd.Parameters.AddWithValue("@VideoURL", Obj.VideoURL);
                    SqlCmd.Parameters.AddWithValue("@OrderIndex", Obj.OrderIndex);

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
                Lesson Obj = new Lesson();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Lessons", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@LessonID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Lesson
                        {
                            LessonID = Convert.ToInt32(sdr[0]),
                            CourseID = Convert.ToInt32(sdr[1]),
                            Title = sdr[2].ToString(),
                            Content = sdr[3].ToString(),
                            VideoURL = sdr[4].ToString(),
                            OrderIndex = Convert.ToInt32(sdr[5])
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
        public ActionResult Edit(int id, Lesson Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Lessons", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@LessonID", Obj.LessonID);
                    SqlCmd.Parameters.AddWithValue("@CourseID", Obj.CourseID);
                    SqlCmd.Parameters.AddWithValue("@Title", Obj.Title);
                    SqlCmd.Parameters.AddWithValue("@Content", Obj.Content);
                    SqlCmd.Parameters.AddWithValue("@VideoURL", Obj.VideoURL);
                    SqlCmd.Parameters.AddWithValue("@OrderIndex", Obj.OrderIndex);

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
                Lesson Obj = new Lesson();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Lessons", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@LessonID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Lesson
                        {
                            LessonID = Convert.ToInt32(sdr[0]),
                            CourseID = Convert.ToInt32(sdr[1]),
                            Title = sdr[2].ToString(),
                            Content = sdr[3].ToString(),
                            VideoURL = sdr[4].ToString(),
                            OrderIndex = Convert.ToInt32(sdr[5])
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
        public ActionResult Delete(int id, Lesson Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_Lessons", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@LessonID", id);

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
