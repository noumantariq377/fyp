using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testappli.Models;


namespace testappli.Controllers
{
    public class HomeController : Controller
    {
         //database_access_layer.db dblayer = new database_acces_layer.db();
        database_access_layer.db dblayer = new database_access_layer.db();

        // View for Add record

        public ActionResult Index()
        {

            return View();

        }

        // View for Display record

        public ActionResult Show_data()
        {

            return View();

        }

        // View for Update record

        public ActionResult update_data(int id)
        {

            return View();

        }

        //Add record

        public JsonResult Add_record(Student rs)
        {

            string res = string.Empty;

            try
            {

                dblayer.Add_record(rs);

                res = "Inserted";

            }

            catch (Exception)
            {

                res = "failed";

            }

            return Json(res, JsonRequestBehavior.AllowGet);



        }

        // Display all records

        public JsonResult Get_data()
        {

            DataSet ds = dblayer.get_record();

            List<Student> listrs = new List<Student>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                listrs.Add(new Student
                {

                    sid = Convert.ToInt32(dr["sid"]),

                    std_name = dr["std_name"].ToString(),

                    f_name = dr["f_name"].ToString(),

                    Department = dr["Department"].ToString(),

                    semester = dr["semester"].ToString(),

                    roll_no = dr["roll_no"].ToString(),

                    cnic = dr["cnic"].ToString(),

                    mob_no = dr["mob_no"].ToString(),

                    google_id = dr["google_id"].ToString(),

                    passworrd = dr["passworrd"].ToString(),

                    studentregisterationtime = dr["studentregisterationtime"].ToString()

                });

            }

            return Json(listrs, JsonRequestBehavior.AllowGet);

        }

        // Display records by id

        public JsonResult Get_databyid(int id)
        {

            DataSet ds = dblayer.get_recordbyid(id);

            List<Student> listrs = new List<Student>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                listrs.Add(new Student

                {

                  sid = Convert.ToInt32(dr["sid"]),

                    std_name = dr["std_name"].ToString(),

                    f_name = dr["f_name"].ToString(),

                    Department = dr["Department"].ToString(),

                    semester = dr["semester"].ToString(),

                    roll_no = dr["roll_no"].ToString(),

                    cnic = dr["cnic"].ToString(),

                    mob_no = dr["mob_no"].ToString(),

                    google_id = dr["google_id"].ToString(),

                    passworrd = dr["passworrd"].ToString(),

                    studentregisterationtime = dr["studentregisterationtime"].ToString()

                });

            }

            return Json(listrs, JsonRequestBehavior.AllowGet);

        }

        // Update records

        public JsonResult update_record(Student rs)
        {

            string res = string.Empty;

            try
            {

                dblayer.update_record(rs);

                res = "Updated";

            }

            catch (Exception)
            {

                res = "failed";

            }

            return Json(res, JsonRequestBehavior.AllowGet);



        }

        // Delete record

        public JsonResult delete_record(int id)
        {

            string res = string.Empty;

            try
            {

                dblayer.deletedata(id);

                res = "data deleted";

            }

            catch (Exception)
            {

                res = "failed";

            }

            return Json(res, JsonRequestBehavior.AllowGet);



        }

    }
}