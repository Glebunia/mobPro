using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml.Linq;

namespace webServiceHelloWorld
{
    /// <summary>
    /// Summary description for helloworldWebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class helloworldWebService1 : System.Web.Services.WebService
    {

        [WebMethod(Description = "Get Emps"), ScriptMethod(UseHttpGet = true)]
        public void GetEmp()//change
        {
            var file = Path.Combine(HttpRuntime.AppDomainAppPath, "Emps.xml");
            var doc = XDocument.Load(file);
            var elements = doc.Root.Elements();
            var Emps = new List<Emps>();//The books is empty at the start
                                        //change

            foreach (var e in elements)
            {
                var Emp = new Emps()
                {
                    Id = int.Parse(e.Attribute("Id").Value),
                    Name = e.Element("Name").Value,
                    Department = Departments.FirstOrDefault(
                        c => c.Id == Int32.Parse(e.Element("Department").Value)),
                    Phone = int.Parse(e.Attribute("Phone").Value),
                    Street = e.Element("Street").Value,
                    City = e.Element("City").Value,
                    State = e.Element("State").Value,
                    Zip = int.Parse(e.Attribute("Zip").Value),
                    Country = e.Element("Country").Value,
                };
                Emps.Add(Emp);

            }

            Context.Response.Write(
              new JavaScriptSerializer().Serialize(Emps));

        }

        [WebMethod(Description = "Add Emps"), ScriptMethod(UseHttpGet = true)]
        public void AddEmp(string name, string department, string phone, string street, string city, string state, string zip, string country)//added new 
        {
            var file = Path.Combine(HttpRuntime.AppDomainAppPath, "Emps.xml");
            var doc = XDocument.Load(file);
            var root = doc.Root;

            int id = 0;
            if (root.Elements("Emp").Any())
            {
                id = doc.Descendants("Emp").Max(p => (int)p.Attribute("Id")) + 1;
            }

            var Emp = new XElement("Emp");
            Emp.Add(new XAttribute("Id", id)); // add an attribute
            Emp.Add(new XElement("Name", name));
            Emp.Add(new XElement("Department", department));
            Emp.Add(new XElement("Phone", phone));
            Emp.Add(new XElement("Street", street));
            Emp.Add(new XElement("City", city));
            Emp.Add(new XElement("State", state));
            Emp.Add(new XElement("Zip", zip));
            Emp.Add(new XElement("Country", country));



            root.Add(Emp);
            doc.Save(file);
            Context.Response.StatusCode = 201;

        }

        [WebMethod(Description = "Delete Emp"), ScriptMethod(UseHttpGet = true)]
        public void DeleteEmp(int id)
        {
            var file = Path.Combine(HttpRuntime.AppDomainAppPath, "Emps.xml");
            var doc = XDocument.Load(file);
            var Emp =
                doc.Root.Elements().FirstOrDefault(b => int.Parse(b.Attribute("Id").Value) == id);

            if (Emp != null)
            {
                Emp.Remove();
                doc.Save(file);
                Context.Response.StatusCode = 202;
            }
        }


        [WebMethod(Description = "Get Books"), ScriptMethod(UseHttpGet = true)]
        public void UpdateEmp(int id, string name, string department, string phone, string street, string city, string state, string zip, string country)//added new
        {
            var file = Path.Combine(HttpRuntime.AppDomainAppPath, "Emps.xml");
            var doc = XDocument.Load(file);
            var Emp =
                doc.Root.Elements().FirstOrDefault(b => int.Parse(b.Attribute("Id").Value) == id);
            if (Emp != null)
            {
                Emp.Element("Name").SetValue(name);
                Emp.Element("Department").SetValue(department);
                Emp.Element("Phone").SetValue(phone);
                Emp.Element("Street").SetValue(street);
                Emp.Element("City").SetValue(city);
                Emp.Element("State").SetValue(state);
                Emp.Element("Zip").SetValue(zip);
                Emp.Element("Country").SetValue(country);
                doc.Save(file);
                Context.Response.StatusCode = 202;
            }
        }


        [WebMethod(Description = "Get Departments"), ScriptMethod(UseHttpGet = true)]
        public void GetDepartments()
        {
            Context.Response.Write(
                new JavaScriptSerializer().Serialize(Departments)
                );

        }


        public List<Department> Departments
        {
            get
            {
                var elements =
                    XDocument.Load(Path.Combine(HttpRuntime.AppDomainAppPath,
                    "Departments.xml")).Root.Elements();

                var categories = new List<Department>();
                foreach (XElement element in elements)
                {
                    Department categoryObj =
                        new Department
                        {
                            Id = int.Parse(element.Attribute("Id").Value),
                            Name = element.Element("Name").Value,
                        };
                    categories.Add(categoryObj);
                }

                return categories;

            }
        }



    }
}
