using PillaniConnect.Models.App_Code;
using System.Data;
using System.Security.Principal;

namespace PillaniConnect.Models
{
    public class Cls_Login : DataEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public string Message { get; set; }
        public string AccountId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Postedby { get; set; }

        public DataTable ValidateUserAccount(string userid, string password)
        {
            return ExecuteDataSetFN("fn_validate_masteruseraccount", userid, password).Tables[0];
        }
        public DataTable FogetPassword(Cls_Login _obj)
        {
            return ExecuteDataSetFN("fn_get_recovery_password", _obj.UserName).Tables[0];
        }

        public DataTable ChangePassword(Cls_Login _obj)
        {
            return ExecuteDataTableFN("fn_update_password", _obj.Postedby,  _obj.OldPassword, _obj.NewPassword);
        }

    }
}
