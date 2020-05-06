using MyWcfService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyWcfService
{
    public class PersonelBusiness : IPersonelService
    {

        public void Ekle(Employee emp)
        {
            using (masterEntities ctx = new masterEntities())
            {
                ctx.Employees.Add(emp);
                ctx.SaveChanges();
            }
        }

        public void Guncelle(Employee emp)
        {
            using (masterEntities ctx = new masterEntities())
            {
                var employee = ctx.Employees.Where(x => x.EmployeeID == emp.EmployeeID).FirstOrDefault();
                if (employee != null)
                {
                    employee.FirstName = emp.FirstName;
                    employee.LastName = emp.LastName;
                }
                ctx.SaveChanges();
            }
        }

        public void Sil(Employee emp)
        {
            using (masterEntities ctx = new masterEntities())
            {
                var employee = ctx.Employees.Where(x => x.EmployeeID == emp.EmployeeID).FirstOrDefault();
                if (employee != null)
                {
                    ctx.Employees.Remove(employee);
                    ctx.SaveChanges();
                }
            }
        }

        public List<Employee> Ara(Employee emp)
        {
            using (masterEntities ctx = new masterEntities())
            {
                var employeeList = ctx.Employees.Where(x => x.FirstName.Contains(emp.FirstName) && x.LastName.Contains(emp.LastName)).ToList();
                return employeeList;
            }
        }

        public List<Employee> getPersonelList()
        {
            using (masterEntities ctx = new masterEntities())
            {
                var personelList = ctx.Employees.ToList(); ;
                return personelList;
            }
        }
    }
}
