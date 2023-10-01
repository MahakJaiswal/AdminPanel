using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PillaniConnect.Models.App_Code
{
    public class Common
    {
        //UAT
        //public string pgConnection = "Server=103.47.216.115;User Id=portal;Pwd=Convex@12345678;Database=OPRMCDBUAT";
        //public string pgConnection = "Server=10.0.3.88;User Id=portal;Pwd=Convex@12345678;Database=OPRMCDBUAT";

        //Prod
        public string pgConnection = "Server=localhost;User Id=postgres;Pwd=1234;Database=PilaniConnect";
        //public string pgConnection = "Server=192.168.1.250;User Id=aaryan;Pwd=aaryan#@1234;Database=GForceDB";

        private string[] _ParaName;

        #region ParaNameArray()
        public void ParaNameArray(params string[] paraname)
        {
            _ParaName = paraname;
        }
        #endregion

        #region Set_SelectSP
        public void Set_SelectSP(string SPName, object[] ParaArray, NpgsqlCommand cmd)
        {
            cmd.CommandTimeout = 1200;
            for (int i = 0; i < ParaArray.Length; i++)
            {
                cmd.Parameters.AddWithValue(_ParaName.GetValue(i).ToString(), ParaArray.GetValue(i));
            }
        }
        #endregion

        public List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public T GetItem<T>(DataRow dr)
        {

            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            try
            {
                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        //Convert.ChangeType(dr[column.ColumnName], pro.PropertyType);
                        if (pro.Name.ToLower() == column.ColumnName.ToLower())
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        else
                            continue;
                    }
                }
            }
            catch (Exception ex) { }
            return obj;
        }

        public void SendEmail(string ToAddress, string Subject, string Body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");

                mail.From = new MailAddress("helpdesk@rodicconsultants.com");
                mail.To.Add(ToAddress);
                mail.Subject = Subject;

                mail.IsBodyHtml = true;
                string htmlBody;

                htmlBody = Body;

                mail.Body = htmlBody;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("helpdesk@rodicconsultants.com", "Welcome2rodic@789");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
