using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using PillaniConnect.Models.App_Code;

namespace PilaniConnect.Models
{
    public class Cls_Registration : DataEntity
    {
        public int lineid { get; set; }
        public string ReegUuid { get; set; }
        public List<Cls_Registration> _List { get; set; }

        public List<Cls_Registration> _DetailsList { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }
        public string Industry { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public string Emailid { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int TotalUsers { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string description { get; set; }
        public string postedby { get; set; }
        public string photo { get; set; }
        public List<SelectListItem> DesignationDDL { get; set; }
        public List<SelectListItem> IndustryDDL { get; set; }
        public List<SelectListItem> CountryDDL { get; set; }
        public List<SelectListItem> StateDDL { get; set; }
        public List<SelectListItem> CityDDL { get; set; }

        public DataTable Get_Registered_Members()
        {
            return ExecuteDataSetFN("fn_get_registered_user").Tables[0];
        }
        public DataTable Register_user(Cls_Registration obj)
        {
            return ExecuteDataTableFN("fn_post_user", obj.Name, obj.Designation, obj.Industry, obj.Company, obj.Contact1, obj.Contact2, obj.Emailid, obj.Address, obj.City, obj.State, obj.Country, obj.Pincode, obj.description, obj.photo, obj.postedby);
        }
        public DataTable Update_Registered_user(Cls_Registration obj)
        {

            return ExecuteDataTableFN("fn_update_registered_user", obj.lineid, obj.Name, obj.Designation, obj.Industry, obj.Company, obj.Contact1, obj.Contact2, obj.Emailid, obj.Address, obj.Country, obj.State, obj.City, obj.Pincode, obj.description, obj.postedby, obj.photo);
        }
        public DataTable Get_designation_DD()
        {
            return ExecuteDataSetFN("Fn_Get_designation_DD").Tables[0];
        }
        public DataTable Get_Industry_DD()
        {
            return ExecuteDataSetFN("Fn_Get_Industry_DD").Tables[0];
        }
        public DataTable Get_Country_DD()
        {
            return ExecuteDataSetFN("fn_get_country_dd").Tables[0];
        }
        public DataTable Get_State_DD()
        {
            return ExecuteDataSetFN("fn_get_state_dd").Tables[0];
        }
        public DataTable Get_City_DD()
        {
            return ExecuteDataSetFN("fn_get_city_dd").Tables[0];
        }
        public DataTable Get_State_By_Country(string Country)
        {
            return ExecuteDataSetFN("Fn_Get_State_By_Country", Country).Tables[0];
        }
        public DataTable Get_City_By_State(string State)
        {
            return ExecuteDataSetFN("Fn_Get_City_By_State", State).Tables[0];
        }

        public DataTable Get_Registered_Members_Details(string sessionid)
        {
            return ExecuteDataSetFN("Fn_Get_User_Deatils", sessionid).Tables[0];
        }
    }
}