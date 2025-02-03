using Academia.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Academia.Controllers
{
    public class AnswerController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<Answer> Obj = new List<Answer>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_Answers", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new Answer
                        {
                            AnswerID = Convert.ToInt32(sdr[0]),
                            QuestionID = Convert.ToInt32(sdr[1]),
                            AnswerText = sdr[2].ToString(),
                            IsCorrect = Convert.ToBoolean(sdr[3])
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
                Answer Obj = new Answer();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Answers", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AnswerID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Answer
                        {
                            AnswerID = Convert.ToInt32(sdr[0]),
                            QuestionID = Convert.ToInt32(sdr[1]),
                            AnswerText = sdr[2].ToString(),
                            IsCorrect = Convert.ToBoolean(sdr[3])
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
        public ActionResult Create(Answer Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Answers", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AnswerID", Obj.AnswerID);
                    SqlCmd.Parameters.AddWithValue("@QuestionID", Obj.QuestionID);
                    SqlCmd.Parameters.AddWithValue("@AnswerText", Obj.AnswerText);
                    SqlCmd.Parameters.AddWithValue("@IsCorrect", Obj.IsCorrect);

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
                Answer Obj = new Answer();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Answers", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AnswerID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Answer
                        {
                            AnswerID = Convert.ToInt32(sdr[0]),
                            QuestionID = Convert.ToInt32(sdr[1]),
                            AnswerText = sdr[2].ToString(),
                            IsCorrect = Convert.ToBoolean(sdr[3])
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
        public ActionResult Edit(int id, Answer Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Answers", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AnswerID", Obj.AnswerID);
                    SqlCmd.Parameters.AddWithValue("@QuestionID", Obj.QuestionID);
                    SqlCmd.Parameters.AddWithValue("@AnswerText", Obj.AnswerText);
                    SqlCmd.Parameters.AddWithValue("@IsCorrect", Obj.IsCorrect);

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
                Answer Obj = new Answer();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Answers", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AnswerID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Answer
                        {
                            AnswerID = Convert.ToInt32(sdr[0]),
                            QuestionID = Convert.ToInt32(sdr[1]),
                            AnswerText = sdr[2].ToString(),
                            IsCorrect = Convert.ToBoolean(sdr[3])
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
        public ActionResult Delete(int id, Answer Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_Answers", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@AnswerID", id);

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
