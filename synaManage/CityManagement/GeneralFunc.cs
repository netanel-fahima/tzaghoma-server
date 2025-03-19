using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net.Sockets;
using System.IO;
using System.Data;

namespace WebApplicationLUACH.Controllers
{
    public static class GeneralFunc
    {

        //מעדכן SQL DB
        public static void UpdateDB(string connectionString, string sqlQuery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    //write LOG
                    //SEND EMAIL
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //מחזיק האם בשדה מסויים בטבלה יש ערך
        public static bool FieldHasValue(DataRow row, string fieldName)
        {
            object fieldValue = row[fieldName];
            return fieldValue != null && fieldValue != DBNull.Value;
        }

        //מקבל שאילתה ומחזיר טבלה ממסד הנתונים
        public static DataTable GetDataTableFromSQL(string connectionString, string sqlQuery)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //מחזיר את שמות הקבצים בתיקיה בלי הכתובת המלאה
        public static string[] GetFolderFiles(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);

            Array.Sort(files);

            return files;
        }

     
        public static void SendEmail(string senderAddress, string recipientAddress, string subject, string messageText)
        {
            MailMessage message = new MailMessage(senderAddress, recipientAddress);
            //message.Bcc.Add
            message.IsBodyHtml = true;
            message.Subject = subject;
            message.Body = messageText;

            SmtpClient smtpClient = new SmtpClient("10.151.2.3", 25);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.Credentials = new NetworkCredential(senderAddress, senderPassword);
            smtpClient.EnableSsl = false;
            smtpClient.UseDefaultCredentials = false;

            // Send the email
            smtpClient.Send(message);
        }

        //בודק האם שם קובץ כבר קיים בתיקיה ומחזיר שם יחודי
        public static string GetFileWithUniqueName(string fileName, string folderPath)
        {
            string filePath = Path.Combine(folderPath, fileName);
            string uniqueFileName = fileName;

            // Check if the file already exists
            if (File.Exists(filePath))
            {
                int counter = 1;

                // Increment the counter until a unique file name is found
                do
                {
                    string counterSuffix = "_" + counter.ToString();
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                    string fileExtension = Path.GetExtension(fileName);

                    uniqueFileName = fileNameWithoutExtension + counterSuffix + fileExtension;
                    filePath = Path.Combine(folderPath, uniqueFileName);
                    counter++;
                }
                while (File.Exists(filePath));
            }
            return uniqueFileName;
        }
    }
}