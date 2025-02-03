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
    public class SubmissionController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<Submission> Obj = new List<Submission>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_Submissions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new Submission
                        {
                            SubmissionID = Convert.ToInt32(sdr[0]),
                            AssignmentID = Convert.ToInt32(sdr[1]),
                            UserID = Convert.ToInt32(sdr[2]),
                            SubmissionDate = Convert.ToDateTime(sdr[3]),
                            Content = sdr[4].ToString(),
                            Grade = Convert.ToInt32(sdr[5])
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
                Submission Obj = new Submission();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Submissions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@SubmissionID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Submission
                        {
                            SubmissionID = Convert.ToInt32(sdr[0]),
                            AssignmentID = Convert.ToInt32(sdr[1]),
                            UserID = Convert.ToInt32(sdr[2]),
                            SubmissionDate = Convert.ToDateTime(sdr[3]),
                            Content = sdr[4].ToString(),
                            Grade = Convert.ToInt32(sdr[5])
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
        public ActionResult Create(Submission Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Submissions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@SubmissionID", Obj.SubmissionID);
                    SqlCmd.Parameters.AddWithValue("@AssignmentID", Obj.AssignmentID);
                    SqlCmd.Parameters.AddWithValue("@UserID", Obj.UserID);
                    SqlCmd.Parameters.AddWithValue("@SubmissionDate", Obj.SubmissionDate);
                    SqlCmd.Parameters.AddWithValue("@Content", Obj.Content);
                    SqlCmd.Parameters.AddWithValue("@Grade", Obj.Grade);

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
                Submission Obj = new Submission();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Submissions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@SubmissionID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Submission
                        {
                            SubmissionID = Convert.ToInt32(sdr[0]),
                            AssignmentID = Convert.ToInt32(sdr[1]),
                            UserID = Convert.ToInt32(sdr[2]),
                            SubmissionDate = Convert.ToDateTime(sdr[3]),
                            Content = sdr[4].ToString(),
                            Grade = Convert.ToInt32(sdr[5])
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
        public ActionResult Edit(int id, Submission Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Submissions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@SubmissionID", Obj.SubmissionID);
                    SqlCmd.Parameters.AddWithValue("@AssignmentID", Obj.AssignmentID);
                    SqlCmd.Parameters.AddWithValue("@UserID", Obj.UserID);
                    SqlCmd.Parameters.AddWithValue("@SubmissionDate", Obj.SubmissionDate);
                    SqlCmd.Parameters.AddWithValue("@Content", Obj.Content);
                    SqlCmd.Parameters.AddWithValue("@Grade", Obj.Grade);

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
                Submission Obj = new Submission();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Submissions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@SubmissionID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Submission
                        {
                            SubmissionID = Convert.ToInt32(sdr[0]),
                            AssignmentID = Convert.ToInt32(sdr[1]),
                            UserID = Convert.ToInt32(sdr[2]),
                            SubmissionDate = Convert.ToDateTime(sdr[3]),
                            Content = sdr[4].ToString(),
                            Grade = Convert.ToInt32(sdr[5])
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
        public ActionResult Delete(int id, Submission Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_Submissions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@SubmissionID", id);

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
