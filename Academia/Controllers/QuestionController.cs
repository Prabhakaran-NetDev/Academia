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
    public class QuestionController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<Question> Obj = new List<Question>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_Questions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new Question
                        {
                            QuestionID = Convert.ToInt32(sdr[0]),
                            AssessmentID = Convert.ToInt32(sdr[1]),
                            QuestionText = sdr[2].ToString(),
                            QuestionType = sdr[3].ToString(),
                            Points = Convert.ToInt32(sdr[4])
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
                Question Obj = new Question();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Questions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@QuestionID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Question
                        {
                            QuestionID = Convert.ToInt32(sdr[0]),
                            AssessmentID = Convert.ToInt32(sdr[1]),
                            QuestionText = sdr[2].ToString(),
                            QuestionType = sdr[3].ToString(),
                            Points = Convert.ToInt32(sdr[4])
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
        public ActionResult Create(Question Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Questions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@QuestionID", Obj.QuestionID);
                    SqlCmd.Parameters.AddWithValue("@AssessmentID", Obj.AssessmentID);
                    SqlCmd.Parameters.AddWithValue("@QuestionText", Obj.QuestionText);
                    SqlCmd.Parameters.AddWithValue("@QuestionType", Obj.QuestionType);
                    SqlCmd.Parameters.AddWithValue("@Points", Obj.Points);

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
                Question Obj = new Question();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Questions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@QuestionID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Question
                        {
                            QuestionID = Convert.ToInt32(sdr[0]),
                            AssessmentID = Convert.ToInt32(sdr[1]),
                            QuestionText = sdr[2].ToString(),
                            QuestionType = sdr[3].ToString(),
                            Points = Convert.ToInt32(sdr[4])
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
        public ActionResult Edit(int id, Question Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Questions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@QuestionID", Obj.QuestionID);
                    SqlCmd.Parameters.AddWithValue("@AssessmentID", Obj.AssessmentID);
                    SqlCmd.Parameters.AddWithValue("@QuestionText", Obj.QuestionText);
                    SqlCmd.Parameters.AddWithValue("@QuestionType", Obj.QuestionType);
                    SqlCmd.Parameters.AddWithValue("@Points", Obj.Points);

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
                Question Obj = new Question();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Questions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@QuestionID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Question
                        {
                            QuestionID = Convert.ToInt32(sdr[0]),
                            AssessmentID = Convert.ToInt32(sdr[1]),
                            QuestionText = sdr[2].ToString(),
                            QuestionType = sdr[3].ToString(),
                            Points = Convert.ToInt32(sdr[4])
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
        public ActionResult Delete(int id, Question Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_Questions", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@QuestionID", id);

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
