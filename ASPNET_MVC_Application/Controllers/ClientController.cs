using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

using ASPNET_MVC_Application.Models;
using Newtonsoft.Json;

namespace ASP.NET_MVC_Application.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client  
        public ActionResult Index()
        {
            // Load the data for the client  
            var clients = Client.GetClients();

            // Return the view.  
            return View(clients);
        }

        public ActionResult Create(String btn)
        {
            if (HttpContext.Request.RequestType == "POST")
            {
                if (Request.Form["btn"] == "ShowClients")
                {
                    Response.Redirect("~/Client/");
                    
                }
            }
            return View();

        }

        public ActionResult Update(int id)
        {
            if (HttpContext.Request.RequestType == "POST")
            {
                // Request is Post type; must be a submit  
                var name = Request.Form["name"];
                var address = Request.Form["address"];
                var trusted = Request.Form["trusted"];

                // Get all of the clients  
                var clints = Client.GetClients();

                foreach (Client client in clints)
                {
                    // Find the client  
                    if (client.ID == id)
                    {
                        // Client found, now update his properties and save it.  
                        client.Name = name;
                        client.Address = address;
                        client.Trusted = Convert.ToBoolean(trusted);
                        // Break through the loop  
                        break;
                    }
                }

                // Update the clients in the disk  
                System.IO.File.WriteAllText(Client.ClientFile, JsonConvert.SerializeObject(clints));

                // Add the details to the View  
                Response.Redirect("~/Client/Index?Message=Client_Updated");
            }


            // Create a model object.  
            var clnt = new Client();
            // Get the list of clients  
            var clients = Client.GetClients();
            // Search within the clients  
            foreach (Client client in clients)
            {
                // If the client's ID matches  
                if (client.ID == id)
                {
                    clnt = client;
                }
                // No need to further run the loop  
                break;
            }
            if (clnt == null)
            {
                // No client was found  
                ViewBag.Message = "No client was found.";
            }
            return View(clnt);
        }

        public ActionResult Delete(int id)
        {
            // Get the clients  
            var Clients = Client.GetClients();
            var deleted = false;
            // Delete the specific one.  
            foreach (Client client in Clients)
            {
                // Found the client  
                if (client.ID == id)
                {
                    // delete this client  
                    var index = Clients.IndexOf(client);
                    Clients.RemoveAt(index);

                    // Removed now save the data back.  
                    System.IO.File.WriteAllText(Client.ClientFile, JsonConvert.SerializeObject(Clients));
                    deleted = true;
                    break;
                }
            }

            // Add the process details to the ViewBag  
            if (deleted)
            {
                ViewBag.Message = "Client was deleted successfully.";
                Response.Redirect("~/Client");
            }
            else
            {
                ViewBag.Message = "There was an error while deleting the client.";
            }
            //Response.Redirect("~/ Client /");
            return View();
        }
        //public actionresult showclient()
        //{

        //}
    }
}