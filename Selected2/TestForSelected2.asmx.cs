using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace Selected2
{
    /// <summary>
    /// Summary description for TestForSelected2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TestForSelected2 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public void GetData( string q , int page)
        {
            int pageSize = 20;
            Rootobject rootobject = new Rootobject();
            List<Result> results = new List<Result>();
            for (int i = 0; i < 100; i++)
            {
                results.Add(new Result { id = i, text = i.ToString() });
            }
            rootobject.results = results.Skip(page-1 * pageSize).Take(pageSize).ToList();
            rootobject.total_count = 100;
            var js = new JavaScriptSerializer();

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
            HttpContext.Current.Response.Write(js.Serialize(rootobject));
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
    }

    public class Rootobject
    {
        public List<Result> results { get; set; }
        public int total_count { get; set; }
    }


    public class Result
    {
        public int id { get; set; }
        public string text { get; set; }
    }

}
