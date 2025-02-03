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
    public class CategoryController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<Category> Obj = new List<Category>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_Categories", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new Category
                        {
                            CategoryID = Convert.ToInt32(sdr[0]),
                            Name = sdr[1].ToString(),
                            Description = sdr[2].ToString()
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
                Category Obj = new Category();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Categories", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@CategoryID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Category
                        {
                            CategoryID = Convert.ToInt32(sdr[0]),
                            Name = sdr[1].ToString(),
                            Description = sdr[2].ToString()
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
        public ActionResult Create(Category Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Categories", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@CategoryID", Obj.CategoryID);
                    SqlCmd.Parameters.AddWithValue("@Name", Obj.Name);
                    SqlCmd.Parameters.AddWithValue("@Description", Obj.Description);

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
                Category Obj = new Category();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Categories", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@CategoryID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Category
                        {
                            CategoryID = Convert.ToInt32(sdr[0]),
                            Name = sdr[1].ToString(),
                            Description = sdr[2].ToString()
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
        public ActionResult Edit(int id, Category Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Categories", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@CategoryID", Obj.CategoryID);
                    SqlCmd.Parameters.AddWithValue("@Name", Obj.Name);
                    SqlCmd.Parameters.AddWithValue("@Description", Obj.Description);

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
                Category Obj = new Category();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Categories", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@CategoryID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Category
                        {
                            CategoryID = Convert.ToInt32(sdr[0]),
                            Name = sdr[1].ToString(),
                            Description = sdr[2].ToString()
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
        public ActionResult Delete(int id, Category Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_Categories", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@CategoryID", id);

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
