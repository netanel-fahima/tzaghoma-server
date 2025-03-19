using System;
using System.Data;
using System.Data.SqlClient;

public static class GeneralService
{
	
    public static void  logger(string subject ,string strLog)
    {
        string format = "yyyy-MM-dd HH:mm:ss";
        try
        {
            DBService.ExecuteStatement("insert into log values('" + subject +"','" + strLog +"','"+ DateTime.Now.ToString(format) + "')");

        }
        catch
        { 
        }
        
    }

    public  static void setSesionData(string userMail  )
    {//Context.User.Identity.GetUserName()
       /* if (Session[""] is null )
        
        string res = DBService.getResult("select syn_id from users where user_role='GABAI' and user_mail = " + userMail);
        if (res.Length > 0)
        { 
        
        }
       */
    }



        

 
    
}



