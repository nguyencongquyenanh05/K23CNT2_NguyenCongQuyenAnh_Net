using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ncqa_lab08.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ncqa_lab08.Controllers
{
    public class ncqaAccountController : Controller
    {
        private static List<ncqaAccount> ncqaListAccount = new List<ncqaAccount>()
        {
            new ncqaAccount
            {
                ncqaId = 230022113,
                ncqaFullName = "Nguyễn Công Quyền Anh",
                ncqaEmail = "quyenanhxz@gmail.com",
                ncqaPhone = "0369464826",
                ncqaAddress = "Lớp K23CNT2",
                ncqaAvatar = "quyenanhj.jpg",
                ncqaBirthday = new DateTime(2005, 11, 23),
                ncqaGender = "Nam",
                ncqaPassword = "0369464826",
                ncqaFacebook = "https://www.facebook.com/nguyen.cong.quyen.anh.2024"
            },
            new ncqaAccount
            {
                ncqaId = 2,
                ncqaFullName = "Trần Thị B",
                ncqaEmail = "tranthib@example.com",
                ncqaPhone = "0987654321",
                ncqaAddress = "456 Đường B, Quận 3, TP.HCM",
                ncqaAvatar = "avatar2.jpg",
                ncqaBirthday = new DateTime(1992, 8, 15),
                ncqaGender = "Nữ",
                ncqaPassword = "password2",
                ncqaFacebook = "https://facebook.com/tranthib"
            },
            new ncqaAccount
            {
                ncqaId = 3,
                ncqaFullName = "Lê Văn C",
                ncqaEmail = "levanc@example.com",
                ncqaPhone = "0911222333",
                ncqaAddress = "789 Đường C, Quận 5, TP.HCM",
                ncqaAvatar = "avatar3.jpg",
                ncqaBirthday = new DateTime(1988, 12, 1),
                ncqaGender = "Nam",
                ncqaPassword = "password3",
                ncqaFacebook = "https://facebook.com/levanc"
            },
            new ncqaAccount
            {
                ncqaId = 4,
                ncqaFullName = "Phạm Thị D",
                ncqaEmail = "phamthid@example.com",
                ncqaPhone = "0909876543",
                ncqaAddress = "321 Đường D, Quận 7, TP.HCM",
                ncqaAvatar = "avatar4.jpg",
                ncqaBirthday = new DateTime(1995, 3, 10),
                ncqaGender = "Nữ",
                ncqaPassword = "password4",
                ncqaFacebook = "https://facebook.com/phamthid"
            },
            new ncqaAccount
            {
                ncqaId = 5,
                ncqaFullName = "Hoàng Văn E",
                ncqaEmail = "hoangvane@example.com",
                ncqaPhone = "0933444555",
                ncqaAddress = "654 Đường E, Quận 10, TP.HCM",
                ncqaAvatar = "avatar5.jpg",
                ncqaBirthday = new DateTime(1991, 7, 22),
                ncqaGender = "Nam",
                ncqaPassword = "password5",
                ncqaFacebook = "https://facebook.com/hoangvane"
            }
        };

        // GET: ncqaAccount
        public ActionResult ncqaIndex()
        {
            var ncqaModel = new ncqaAccount();
            return View(ncqaModel);
        }

        // GET: ncqaAccount/Details/5
        public ActionResult Details(int id)
        {
            var account = ncqaListAccount.FirstOrDefault(a => a.ncqaId == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // GET: ncqaAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ncqaAccount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ncqaAccount model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Đảm bảo không trùng mã
                    if (!ncqaListAccount.Any(a => a.ncqaId == model.ncqaId))
                    {
                        ncqaListAccount.Add(model);
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("ncqaId", "Mã tài khoản đã tồn tại.");
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: ncqaAccount/Edit/5
        public ActionResult Edit(int id)
        {
            var account = ncqaListAccount.FirstOrDefault(a => a.ncqaId == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: ncqaAccount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ncqaAccount model)
        {
            try
            {
                var account = ncqaListAccount.FirstOrDefault(a => a.ncqaId == id);
                if (account == null)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    // Cập nhật thông tin tài khoản
                    account.ncqaFullName = model.ncqaFullName;
                    account.ncqaEmail = model.ncqaEmail;
                    account.ncqaPhone = model.ncqaPhone;
                    account.ncqaAddress = model.ncqaAddress;
                    account.ncqaAvatar = model.ncqaAvatar;
                    account.ncqaBirthday = model.ncqaBirthday;
                    account.ncqaGender = model.ncqaGender;
                    account.ncqaPassword = model.ncqaPassword;
                    account.ncqaFacebook = model.ncqaFacebook;
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: ncqaAccount/Delete/5
        public ActionResult Delete(int id)
        {
            var account = ncqaListAccount.FirstOrDefault(a => a.ncqaId == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: ncqaAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var account = ncqaListAccount.FirstOrDefault(a => a.ncqaId == id);
            if (account != null)
            {
                ncqaListAccount.Remove(account);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}