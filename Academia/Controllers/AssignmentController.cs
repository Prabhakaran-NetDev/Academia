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
    public class AssignmentController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<Assignment> Obj = new List<Assignment>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_Assignments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new Assignment
                        {
                            AssignmentID = Convert.ToInt32(sdr[0]),
                            CourseID = Convert.ToInt32(sdr[1]),
                            Title = sdr[2].ToString(),
                            Description = sdr[3].ToString(),
                            DueDate = Convert.ToDateTime(sdr[4]),
                            MaxPoints = Convert.ToInt32(sdr[5])
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
                Assignment Obj = new Assignment();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Assignments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AssignmentID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Assignment
                        {
                            AssignmentID = Convert.ToInt32(sdr[0]),
                            CourseID = Convert.ToInt32(sdr[1]),
                            Title = sdr[2].ToString(),
                            Description = sdr[3].ToString(),
                            DueDate = Convert.ToDateTime(sdr[4]),
                            MaxPoints = Convert.ToInt32(sdr[5])
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
        public ActionResult Create(Assignment Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Assignments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AssignmentID", Obj.AssignmentID);
                    SqlCmd.Parameters.AddWithValue("@CourseID", Obj.CourseID);
                    SqlCmd.Parameters.AddWithValue("@Title", Obj.Title);
                    SqlCmd.Parameters.AddWithValue("@Description", Obj.Description);
                    SqlCmd.Parameters.AddWithValue("@DueDate", Obj.DueDate);
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
                Assignment Obj = new Assignment();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Assignments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AssignmentID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Assignment
                        {
                            AssignmentID = Convert.ToInt32(sdr[0]),
                            CourseID = Convert.ToInt32(sdr[1]),
                            Title = sdr[2].ToString(),
                            Description = sdr[3].ToString(),
                            DueDate = Convert.ToDateTime(sdr[4]),
                            MaxPoints = Convert.ToInt32(sdr[5])
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
        public ActionResult Edit(int id, Assignment Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Assignments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AssignmentID", Obj.AssignmentID);
                    SqlCmd.Parameters.AddWithValue("@CourseID", Obj.CourseID);
                    SqlCmd.Parameters.AddWithValue("@Title", Obj.Title);
                    SqlCmd.Parameters.AddWithValue("@Description", Obj.Description);
                    SqlCmd.Parameters.AddWithValue("@DueDate", Obj.DueDate);
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
                Assignment Obj = new Assignment();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Assignments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AssignmentID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Assignment
                        {
                            AssignmentID = Convert.ToInt32(sdr[0]),
                            CourseID = Convert.ToInt32(sdr[1]),
                            Title = sdr[2].ToString(),
                            Description = sdr[3].ToString(),
                            DueDate = Convert.ToDateTime(sdr[4]),
                            MaxPoints = Convert.ToInt32(sdr[5])
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
        public ActionResult Delete(int id, Assignment Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_Assignments", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AssignmentID", id);

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
