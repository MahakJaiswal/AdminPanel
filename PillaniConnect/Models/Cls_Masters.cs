using PillaniConnect.Models.App_Code;
using System.Data;

namespace PillaniConnect.Models
{
    public class Cls_Masters : DataEntity
    {
        public List<Cls_Masters> _DesList { get; set; }
        public List<Cls_Masters> _IndustryList { get; set; }

        public int lineid { get; set; }
        public string designation { get; set; }
        public string industry { get; set; }
        public string postedby { get; set; }
        public string posteddatetime { get; set; }

        public DataTable Get_Designations()
        {
            return ExecuteDataSetFN("fn_get_designation").Tables[0];
        }
        public DataTable Get_Industry()
        {
            return ExecuteDataSetFN("fn_get_industry").Tables[0];
        }
        public DataTable Post_Designation(Cls_Masters obj)
        {
            return ExecuteDataTableFN("fn_post_designation", obj.designation, obj.postedby);
        }
        public DataTable Post_Industry(Cls_Masters obj)
        {
            return ExecuteDataTableFN("fn_post_industry", obj.industry, obj.postedby);
        }
    }
}