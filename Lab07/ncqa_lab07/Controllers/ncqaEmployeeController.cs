using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ncqa_lab07.Models;

namespace ncqa_lab07.Controllers
{
    public class ncqaEmployHomeController : Controller
    {
        // Mock Data:
        private static List<ncqaEmployee> ncqaListEmployee = new List<ncqaEmployee>
        {
            new ncqaEmployee { ncqaId = 1, ncqaName = "Nguyễn Công Quyền Anh", ncqaBirthDay = new DateTime(2005, 11, 23), ncqaEmail = "quyenanhxz@gmail.com", ncqaPhone = "0901111111", ncqaSalary = 15000000, ncqaStatus = true },
            new ncqaEmployee { ncqaId = 2, ncqaName = "Trần Thị B", ncqaBirthDay = new DateTime(1992, 2, 2), ncqaEmail = "b@ex.com", ncqaPhone = "0902222222", ncqaSalary = 16000000, ncqaStatus = true },
            new ncqaEmployee { ncqaId = 3, ncqaName = "Lê Văn C", ncqaBirthDay = new DateTime(1994, 3, 3), ncqaEmail = "c@ex.com", ncqaPhone = "0903333333", ncqaSalary = 17000000, ncqaStatus = false },
            new ncqaEmployee { ncqaId = 4, ncqaName = "Phạm Thị D", ncqaBirthDay = new DateTime(1996, 4, 4), ncqaEmail = "d@ex.com", ncqaPhone = "0904444444", ncqaSalary = 18000000, ncqaStatus = true },
            new ncqaEmployee { ncqaId = 5, ncqaName = "Đỗ Văn E", ncqaBirthDay = new DateTime(1998, 5, 5), ncqaEmail = "e@ex.com", ncqaPhone = "0905555555", ncqaSalary = 19000000, ncqaStatus = false },
        };

        public ActionResult ncqaIndex()
        {
            return View(ncqaListEmployee);
        }

        public ActionResult Details(int id)
        {
            var emp = ncqaListEmployee.FirstOrDefault(e => e.ncqaId == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ncqaEmployee newEmp)
        {
            try
            {
                newEmp.ncqaId = ncqaListEmployee.Max(e => e.ncqaId) + 1;
                ncqaListEmployee.Add(newEmp);
                return RedirectToAction(nameof(ncqaIndex));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var emp = ncqaListEmployee.FirstOrDefault(e => e.ncqaId == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ncqaEmployee updatedEmp)
        {
            try
            {
                var emp = ncqaListEmployee.FirstOrDefault(e => e.ncqaId == id);
                if (emp == null) return NotFound();

                emp.ncqaName = updatedEmp.ncqaName;
                emp.ncqaBirthDay = updatedEmp.ncqaBirthDay;
                emp.ncqaEmail = updatedEmp.ncqaEmail;
                emp.ncqaPhone = updatedEmp.ncqaPhone;
                emp.ncqaSalary = updatedEmp.ncqaSalary;
                emp.ncqaStatus = updatedEmp.ncqaStatus;

                return RedirectToAction(nameof(ncqaIndex));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var emp = ncqaListEmployee.FirstOrDefault(e => e.ncqaId == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var emp = ncqaListEmployee.FirstOrDefault(e => e.ncqaId == id);
                if (emp != null)
                {
                    ncqaListEmployee.Remove(emp);
                }
                return RedirectToAction(nameof(ncqaIndex));
            }
            catch
            {
                return View();
            }
        }
    }
}
