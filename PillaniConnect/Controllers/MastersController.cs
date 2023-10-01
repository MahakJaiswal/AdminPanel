using Microsoft.AspNetCore.Mvc;
using PilaniConnect.Models;

using PillaniConnect.Models;
using System.Data;

namespace PillaniConnect.Controllers
{
    public class MastersController : Controller
    {
        public IActionResult Designation()
        {
            Cls_Masters _obj = new Cls_Masters();
            _obj._DesList = new List<Cls_Masters>();
            DataTable dt = _obj.Get_Designations();
            _obj._DesList = BindDesignation(dt);
            return View(_obj);
        }
        public List<Cls_Masters> BindDesignation(DataTable dt)
        {
            List<Cls_Masters> lst = new List<Cls_Masters>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    
                    lst.Add(new Cls_Masters()
                    {
                        //LineId = Convert.ToInt32(dr["LineID"].ToString()),
                        lineid = Convert.ToInt32(dr["lineid"].ToString()),
                        designation = dr["designationname"].ToString(),
                        postedby = dr["accounttype"].ToString(),
                        posteddatetime = dr["posteddatetime"].ToString(),
                    });
                }
            }
            return lst;
        }
        [HttpPost]
        public IActionResult Designation(Cls_Masters _obj, Microsoft.AspNetCore.Http.IFormFile postedFile, IFormCollection form, string save, string Upload, string Update, string status, string Confirm)
        {

            List<Cls_Masters> _uploadList = new List<Cls_Masters>();
            if (ModelState.IsValid)
            {
                _obj.postedby = HttpContext.Session.GetString("SysAccountUUid");


                if (!string.IsNullOrEmpty(save))
                {

                    // _obj.SysVisitorCardId = '0';
                    DataTable dtSave = _obj.Post_Designation(_obj);
                    if (dtSave != null && dtSave.Rows.Count > 0)
                    {
                        ViewBag.Message = dtSave.Rows[0][0].ToString();
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = "An error occurred.";
                        ModelState.Clear();
                    }
                }
                
                DataTable dt = _obj.Get_Designations();
                _obj._DesList = BindDesignation(dt);

            }

            return View(_obj);
        }
        public IActionResult AddDesignation()
        {
            Cls_Masters obj = new Cls_Masters();
            return PartialView(obj);
        }
        public IActionResult Industry()
        {
            Cls_Masters _obj = new Cls_Masters();
            _obj._IndustryList = new List<Cls_Masters>();
            DataTable dt = _obj.Get_Industry();
            _obj._IndustryList = BindIndustry(dt);
            return View(_obj);
        }
        [HttpPost]
        public IActionResult Industry(Cls_Masters _obj, Microsoft.AspNetCore.Http.IFormFile postedFile, IFormCollection form, string save, string Upload, string Update, string status, string Confirm)
        {

            List<Cls_Masters> _uploadList = new List<Cls_Masters>();
            if (ModelState.IsValid)
            {
                _obj.postedby = HttpContext.Session.GetString("SysAccountUUid");


                if (!string.IsNullOrEmpty(save))
                {

                    // _obj.SysVisitorCardId = '0';
                    DataTable dtSave = _obj.Post_Industry(_obj);
                    if (dtSave != null && dtSave.Rows.Count > 0)
                    {
                        ViewBag.Message = dtSave.Rows[0][0].ToString();
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = "An error occurred.";
                        ModelState.Clear();
                    }
                }

                DataTable dt = _obj.Get_Industry();
                _obj._IndustryList = BindIndustry(dt);

            }

            return View(_obj);
        }
        public IActionResult AddIndustry()
        {
            Cls_Masters obj = new Cls_Masters();
            return PartialView(obj);
        }
        public List<Cls_Masters> BindIndustry(DataTable dt)
        {
            List<Cls_Masters> lst = new List<Cls_Masters>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    
                    lst.Add(new Cls_Masters()
                    {
                        //LineId = Convert.ToInt32(dr["LineID"].ToString()),
                        lineid = Convert.ToInt32(dr["lineid"].ToString()),
                        industry = dr["industryname"].ToString(),
                        postedby = dr["accounttype"].ToString(),
                        posteddatetime = dr["posteddatetime"].ToString(),
                    });
                }
            }
            return lst;
        }
    }
}