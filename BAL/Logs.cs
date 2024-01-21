using AlumniConnect.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AlumniConnect.BAL
{
    public class Logs
    {
        public static void ErrorLogging(ErrorLogModel err)
        {
            try
            {
                DAL.ErrorLog.LogToDB(err);
            }
            catch (Exception ex) { }
        }
        public static string LogMySqlProc(MySqlCommand cmd)
        {
            string response = string.Empty;
            try
            {
                if (cmd != null)
                {
                    string req = string.Empty;
                    req = DateTime.Now + "    " + "\"" + Convert.ToString(cmd.CommandText) + "\"" + "    {";

                    for (int i = 0; i < cmd.Parameters.Count; i++)
                    {
                        req = req + "\"" + Convert.ToString(cmd.Parameters[i].ParameterName) + "\":" + "\"" + Convert.ToString(cmd.Parameters[i].Value) + "\",";

                    }

                    req = req.Substring(0, req.Length - 2);

                    req = req + "}";

                    //WriteLogToText(req);
                    response = req;
                }
            }
            catch { }

            return response;
        }

        public static void WriteLogToText(string data)
        {
            string fileName = @"D:\POC\svdmAng\Logs\" + DateTime.Now.ToString("ddMMyyyy") + ".txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    //File.Delete(fileName);
                    //using (FileStream fs = File.OpenRead(fileName))
                    //{
                    //    byte[] author = new UTF8Encoding(true).GetBytes(data);
                    //    fs.Write(author, 0, author.Length);
                    //}

                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        sw.WriteLine("\n");
                        sw.WriteLine(data);
                    }
                }
                else
                {
                    // Create a new file     
                    //using (FileStream fs = File.Create(fileName))
                    //{
                    //    // Add some text to file    
                    //    //Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                    //    //fs.Write(title, 0, title.Length);
                    //    byte[] author = new UTF8Encoding(true).GetBytes(data);
                    //    fs.Write(author, 0, author.Length);
                    //}

                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        sw.WriteLine("\n");
                        sw.WriteLine(data);
                    }
                }
                // Open the stream and read it back.    
                //using (StreamReader sr = File.OpenText(fileName))
                //{
                //    string s = "";
                //    while ((s = sr.ReadLine()) != null)
                //    {
                //        Console.WriteLine(s);
                //    }
                //}
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

        }
    }
}