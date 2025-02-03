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
    public class AssessmentController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<Assessment> Obj = new List<Assessment>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_Assessments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new Assessment
                        {
                            AssessmentID = Convert.ToInt32(sdr[0]),
                            CourseID = Convert.ToInt32(sdr[1]),
                            Title = sdr[2].ToString(),
                            Description = sdr[3].ToString(),
                            MaxPoints = Convert.ToInt32(sdr[4])
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
                Assessment Obj = new Assessment();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Assessments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AssessmentID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Assessment
                        {
                            AssessmentID = Convert.ToInt32(sdr[0]),
                            CourseID = Convert.ToInt32(sdr[1]),
                            Title = sdr[2].ToString(),
                            Description = sdr[3].ToString(),
                            MaxPoints = Convert.ToInt32(sdr[4])
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
        public ActionResult Create(Assessment Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Assessments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AssessmentID", Obj.AssessmentID);
                    SqlCmd.Parameters.AddWithValue("@CourseID", Obj.CourseID);
                    SqlCmd.Parameters.AddWithValue("@Title", Obj.Title);
                    SqlCmd.Parameters.AddWithValue("@Description", Obj.Description);
                    SqlCmd.Parameters.AddWithValue("@MaxPoints", Obj.MaxPoints);

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
                Assessment Obj = new Assessment();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Assessments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AssessmentID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Assessment
                        {
                            AssessmentID = Convert.ToInt32(sdr[0]),
                            CourseID = Convert.ToInt32(sdr[1]),
                            Title = sdr[2].ToString(),
                            Description = sdr[3].ToString(),
                            MaxPoints = Convert.ToInt32(sdr[4])
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
        public ActionResult Edit(int id, Assessment Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Assessments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AssessmentID", Obj.AssessmentID);
                    SqlCmd.Parameters.AddWithValue("@CourseID", Obj.CourseID);
                    SqlCmd.Parameters.AddWithValue("@Title", Obj.Title);
                    SqlCmd.Parameters.AddWithValue("@Description", Obj.Description);
                    SqlCmd.Parameters.AddWithValue("@MaxPoints", Obj.MaxPoints);

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
                Assessment Obj = new Assessment();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Assessments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AssessmentID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Assessment
                        {
                            AssessmentID = Convert.ToInt32(sdr[0]),
                            CourseID = Convert.ToInt32(sdr[1]),
                            Title = sdr[2].ToString(),
                            Description = sdr[3].ToString(),
                            MaxPoints = Convert.ToInt32(sdr[4])
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
        public ActionResult Delete(int id, Assessment Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_ Assessment", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AssessmentID", id);

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
