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
    public class FeedbackController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<Feedback> Obj = new List<Feedback>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_Feedback", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new Feedback
                        {
                            FeedbackID = Convert.ToInt32(sdr[0]),
                            CourseID= Convert.ToInt32(sdr[1]),
                            UserID = Convert.ToInt32(sdr[2]),
                            Rating = Convert.ToInt32(sdr[3]),
                            Comment = sdr[4].ToString(),
                            FeedbackDate = Convert.ToDateTime(sdr[5])
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
                Feedback Obj = new Feedback();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Feedback", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@FeedbackID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Feedback
                        {
                            FeedbackID = Convert.ToInt32(sdr[0]),
                            CourseID = Convert.ToInt32(sdr[1]),
                            UserID = Convert.ToInt32(sdr[2]),
                            Rating = Convert.ToInt32(sdr[3]),
                            Comment = sdr[4].ToString(),
                            FeedbackDate = Convert.ToDateTime(sdr[5])
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
        public ActionResult Create(Feedback Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Feedback", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@FeedbackID", Obj.FeedbackID);
                    SqlCmd.Parameters.AddWithValue("@CourseID)", Obj.CourseID);
                    SqlCmd.Parameters.AddWithValue("@UserID", Obj.UserID);
                    SqlCmd.Parameters.AddWithValue("@Rating", Obj.Rating);
                    SqlCmd.Parameters.AddWithValue("@Comment", Obj.Comment);
                    SqlCmd.Parameters.AddWithValue("@FeedbackDate", Obj.FeedbackDate);

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
                Feedback Obj = new Feedback();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Feedback", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@FeedbackID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Feedback
                        {
                            FeedbackID = Convert.ToInt32(sdr[0]),
                            CourseID = Convert.ToInt32(sdr[1]),
                            UserID = Convert.ToInt32(sdr[2]),
                            Rating = Convert.ToInt32(sdr[3]),
                            Comment = sdr[4].ToString(),
                            FeedbackDate = Convert.ToDateTime(sdr[5])
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
        public ActionResult Edit(int id, Feedback Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Feedback", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@FeedbackID", Obj.FeedbackID);
                    SqlCmd.Parameters.AddWithValue("@CourseID)", Obj.CourseID);
                    SqlCmd.Parameters.AddWithValue("@UserID", Obj.UserID);
                    SqlCmd.Parameters.AddWithValue("@Rating", Obj.Rating);
                    SqlCmd.Parameters.AddWithValue("@Comment", Obj.Comment);
                    SqlCmd.Parameters.AddWithValue("@FeedbackDate", Obj.FeedbackDate);

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
                Feedback Obj = new Feedback();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Feedback", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@FeedbackID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Feedback
                        {
                            FeedbackID = Convert.ToInt32(sdr[0]),
                            CourseID = Convert.ToInt32(sdr[1]),
                            UserID = Convert.ToInt32(sdr[2]),
                            Rating = Convert.ToInt32(sdr[3]),
                            Comment = sdr[4].ToString(),
                            FeedbackDate = Convert.ToDateTime(sdr[5])
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
        public ActionResult Delete(int id, Feedback Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_Feedback", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@FeedbackID", id);

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
