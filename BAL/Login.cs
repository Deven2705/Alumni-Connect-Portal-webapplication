using AlumniConnect.DAL;
using AlumniConnect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace AlumniConnect.BAL
{
    public class Login
    {
        public static LoginModel ValidateLogin(LoginModel login)
        {
            login.dbAction = "VALIDATE";
            //login.mobile = login.loginId;

            login = OTPOp.ValidateLogin(login);

            login.mobile = login.loginId;

            return login;
        }

        //Get IP address
        public static string GetIPAddress()
        {
            string ipAddress = string.Empty;

            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ipAddress = Convert.ToString(IP);
                }
            }
            return ipAddress;
        }
    }
}