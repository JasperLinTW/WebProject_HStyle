using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services.Interfaces;
using H2StyleStore.Models.Services;
using H2StyleStore.Models.ViewModels;
using System.Web.Security;
using H2StyleStore.Models.Infrastructures.ExtensionMethods;

namespace H2StyleStore.Controllers
{
	public class EmployeesController : Controller
    {
        private AppDbContext db = new AppDbContext();
		private IEmployeeRepository repository;
		private EmployeeService service;

		public EmployeesController()   //不知道幹嘛用
		{
			repository = new EmployeeRepository();
			service = new EmployeeService(repository);

		}

		// GET: Employees
		
		public ActionResult Index()
        {
			List<int> list= new List<int> { 1,2 }; //代表 資料庫1跟2都能進去
			bool isAuthenticated = new AuthrizeHelper().IsAuthenticated(list);
			if(isAuthenticated == false)   //用來判斷權限
			{
				return RedirectToAction("Index", "home");
			}

			var employees = db.Employees.Include(e => e.PermissionsE);
			return View(employees.ToList());

		}

	//	var roles = FormsAuthentication.Decrypt(System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;  //抓出cookie  跟  roles比較

	//		if (int.Parse(roles) >= 3)   //用來判斷權限
 //           {
	//			var employees = db.Employees.Include(e => e.PermissionsE);
	//			return View(employees.ToList());
	//}
 //           return RedirectToAction("Index","home");  //如果沒有就轉跳這個頁面


	// GET: Members/Register
	public ActionResult Register_Employees()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register_Employees(Register_EmployeesVM model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var service = new EmployeeService(repository);

			(bool IsSuccess, string ErrorMessage) response =
				service.CreateNewMember(model.ToRequest_EmployeesVMDto());

			if (response.IsSuccess)
			{
				// 建檔成功 redirect to confirm page
				return View("RegisterConfirm_E");                   //註冊成功就跳到這邊
			}
			else
			{
				ModelState.AddModelError(string.Empty, response.ErrorMessage);
				return View(model);
			}
		}


		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(Login_EmployeesVM model)   //12-26 2:05s Create LoginVM
		{
			// var service = new MemberService(repository);
			(bool IsSuccess, string ErrorMessage) response =
				service.Login(model.Account, model.Password);

			if (response.IsSuccess)
			{
				// 記住登入成功的會員
				var rememberMe = false;

                //這邊先找出來 
				string returnUrl = ProcessLogin(model.Account, rememberMe, out HttpCookie cookie); //然後這邊丟進去

				Response.Cookies.Add(cookie);

				return Redirect(returnUrl);
			}

			ModelState.AddModelError(string.Empty, response.ErrorMessage);

			return this.View(model);
		}
		public ActionResult Logout()
		{
			Session.Abandon();
			FormsAuthentication.SignOut();
			return Redirect("/Employees/Login");
		}
		// GET: Employees/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.Permission_id = new SelectList(db.PermissionsEs, "PermissionM_id", "Level");
            return View();
        }

        // POST: Employees/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_id,Account,Title,Permission_id,EncryptedPassword")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Permission_id = new SelectList(db.PermissionsEs, "PermissionM_id", "Level", employee.Permission_id);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Permission_id = new SelectList(db.PermissionsEs, "PermissionM_id", "Level", employee.Permission_id);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditEmployeeVM newEmployee)
        {
            if (ModelState.IsValid)
            {
				Employee employee = db.Employees.Find(newEmployee.Employee_id);
				employee.Title = newEmployee.Title;
				employee.Account = newEmployee.Account;
				employee.Permission_id = newEmployee.Permission_id;
			

               // db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Permission_id = new SelectList(db.PermissionsEs, "PermissionM_id", "Level", newEmployee.Permission_id);
            return View(newEmployee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

		private string ProcessLogin(string account, bool rememberMe, out HttpCookie cookie)
		{
			var member = repository.GetByAccount(account);
			
			int? Permission_id = member.Permission_id;
			string roles = Permission_id.ToString(); //丟權限表  
		    //string roles = String.Empty; // 在本範例, 沒有用到角色權限,所以存入空白    

			// 建立一張認證票
			FormsAuthenticationTicket ticket =
				new FormsAuthenticationTicket(
					1,          // 版本別, 沒特別用處
					account,
					DateTime.Now,   // 發行日
					DateTime.Now.AddMinutes(30), // 到期時間30分鐘 
					rememberMe,     // 是否續存
					roles,          // userdata
					"/" // cookie位置
				);

			// 將它加密
			string value = FormsAuthentication.Encrypt(ticket);

			// 存入cookie
			cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value);

			// 取得return url
			string url = FormsAuthentication.GetRedirectUrl(account, true); //第二個引數沒有用處

			return url;
		}
	}
}
