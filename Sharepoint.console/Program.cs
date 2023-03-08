using Microsoft.Identity.Client;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Sharepoint.console
{
    internal class Program
    {
        static void Main(string[] args)
        {

           

             
            ClientContext clientContext = new
                ClientContext("https://{your-tranent}.sharepoint.com/sites/ExalerCo.Ltd");


            SecureString theSecureString = new NetworkCredential("", "password").SecurePassword;
            clientContext.Credentials =  new SharePointOnlineCredentials("xxx@xxx.com", theSecureString);
          
            // Get the SharePoint web  
            Web web = clientContext.Web;

            // Get the SharePoint list collection for the web  
            ListCollection listColl = web.Lists;

            // Retrieve the list collection properties  
            clientContext.Load(listColl);

            // Execute the query to the server.  
            clientContext.ExecuteQuery();

            // Loop through all the list  
            foreach (List list in listColl)
            {
                // Display the list title and ID  
                Console.WriteLine("List Name: " + list.Title + "; ID: " + list.Id);
            }
            Console.ReadLine();
        }

        
    }
}
