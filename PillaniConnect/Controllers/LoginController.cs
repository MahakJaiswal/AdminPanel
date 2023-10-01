using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PillaniConnect.Models;
//using System.Net.Mail;
using MailKit.Net.Smtp;
using System.Data;

namespace PillaniConnect.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            Cls_Login person = new Cls_Login();
            person.Message = "";
            return View(person);
        }

        [HttpPost]
        public IActionResult Login(Cls_Login person)
        {
            try
            {
                Cls_Login _Login = new Cls_Login();
                var validate = _Login.ValidateUserAccount(person.UserName, person.Password);

                if (validate.Rows.Count > 0)
                {

                    HttpContext.Session.SetString("FullName", validate.Rows[0]["FullName"].ToString());
                    HttpContext.Session.SetString("SysAccountUUid", validate.Rows[0]["SysAccountUUid"].ToString());
                    HttpContext.Session.SetString("Accounttype", validate.Rows[0]["Accounttype"].ToString());
                    HttpContext.Session.SetString("Email", validate.Rows[0]["Email"].ToString());
                    HttpContext.Session.SetString("SysUserUUid", validate.Rows[0]["SysUserUUid"].ToString());


                    ViewBag.Message = "Login Successfully.";
                    return RedirectToAction("RegisteredMembers", "Registration");
                }
                else
                {
                    ViewBag.Message = "Invalid username or password!! Please try again.";
                    return View(person);
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = "An Error Occurred!!";
                return View(person);
            }
        }

        public ActionResult Logout()
        {
            Cls_Login _obj = new Cls_Login();
            return View("login", _obj);
        }

        public ActionResult ForgetPassword()
        {
            Cls_Login _obj = new Cls_Login();
            return View("ForgetPassword", _obj);
        }

        [HttpPost]

        public ActionResult ForgetPassword(Cls_Login obj, string UserName, string Save)
        {
            Cls_Login _obj = new Cls_Login();

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Save))
                {
                    var validate = _obj.FogetPassword(obj);

                    if (validate.Rows.Count > 0)
                    {
                        try
                        {
                            MimeMessage message = new MimeMessage();
                            MailboxAddress from = new MailboxAddress("Sender Name", "sanjeev.mishra2@gmail.com");
                            MailboxAddress to = new MailboxAddress("Recipient Name", UserName);

                            message.From.Add(from);
                            message.To.Add(to);
                            message.Subject = "Account Recovery";

                            BodyBuilder bodyBuilder = new BodyBuilder();
                            bodyBuilder.HtmlBody = "<p>Hi " + validate.Rows[0]["email"].ToString() + "</p> <p></p>" + "<p>We've received your request for a password to use with your pilani connect account.</p> <p></p> " + "<p>Your account password is: " + validate.Rows[0]["Password"].ToString() + "<p></p> <p>If you didn't request this code, you can safely ignore this email. Someone else might have typed your email address by mistake.</p><p></p><p>Thanks,</p>";

                            message.Body = bodyBuilder.ToMessageBody();

                            using (var client = new SmtpClient())
                            {
                                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                                client.Authenticate("sanjeev.mishra2@gmail.com", "reyfgpxqmuqskdoh");

                                //client.Authenticate("aparnasandilya11@gmail.com", "CHHOTI1234");

                                client.Send(message);
                                client.Disconnect(true);
                            }

                            ViewBag.Message = "Mail Sent Successfully.";
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                return View("ForgetPassword", _obj);
            }
            return View("ForgetPassword", _obj);
        }

        public IActionResult ChangePassword()
        {
            Cls_Login _obj = new Cls_Login();
            return View(_obj);
        }

        [HttpPost]
        public IActionResult ChangePassword(Cls_Login obj, string ChangePassword)
        {
            Cls_Login _obj = new Cls_Login();
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(ChangePassword))
                {

                    DataTable dtSave = obj.ChangePassword(obj);
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

                return View("ChangePassword", _obj);
            }

            return View("Login", _obj);
        }

    }
}
