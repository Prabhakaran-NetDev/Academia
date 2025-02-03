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
    public class EnrollmentController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<Enrollment> Obj = new List<Enrollment>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_Enrollments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new Enrollment
                        {
                            EnrollmentID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            CourseID = Convert.ToInt32(sdr[2]),
                            EnrollmentDate = Convert.ToDateTime(sdr[3]),
                            Status = sdr[4].ToString()
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
                Enrollment Obj = new Enrollment();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Enrollments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@EnrollmentID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Enrollment
                        {
                            EnrollmentID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            CourseID = Convert.ToInt32(sdr[2]),
                            EnrollmentDate = Convert.ToDateTime(sdr[3]),
                            Status = sdr[4].ToString()
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
        public ActionResult Create(Enrollment Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Enrollments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@EnrollmentID", Obj.EnrollmentID);
                    SqlCmd.Parameters.AddWithValue("@UserID", Obj.UserID);
                    SqlCmd.Parameters.AddWithValue("@CourseID", Obj.CourseID);
                    SqlCmd.Parameters.AddWithValue("@EnrollmentDate", Obj.EnrollmentDate);
                    SqlCmd.Parameters.AddWithValue("@Status", Obj.Status);

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
                Enrollment Obj = new Enrollment();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Enrollments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@EnrollmentID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Enrollment
                        {
                            EnrollmentID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            CourseID = Convert.ToInt32(sdr[2]),
                            EnrollmentDate = Convert.ToDateTime(sdr[3]),
                            Status = sdr[4].ToString()
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
        public ActionResult Edit(int id, Enrollment Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Enrollments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@EnrollmentID", Obj.EnrollmentID);
                    SqlCmd.Parameters.AddWithValue("@UserID", Obj.UserID);
                    SqlCmd.Parameters.AddWithValue("@CourseID", Obj.CourseID);
                    SqlCmd.Parameters.AddWithValue("@EnrollmentDate", Obj.EnrollmentDate);
                    SqlCmd.Parameters.AddWithValue("@Status", Obj.Status);

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
                Enrollment Obj = new Enrollment();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Enrollments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@EnrollmentID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Enrollment
                        {
                            EnrollmentID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            CourseID = Convert.ToInt32(sdr[2]),
                            EnrollmentDate = Convert.ToDateTime(sdr[3]),
                            Status = sdr[4].ToString()
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
        public ActionResult Delete(int id, Enrollment Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_Enrollments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@EnrollmentID", id);

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
