using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace H2StyleStore.Controllers
{
    public class H_Source_DetailsController : Controller
    {
        private AppDbContext _db;
        public H_Source_DetailsController(AppDbContext db)
        {
            _db = db;
        }

        // GET: H_Source_Details
        public ActionResult Index()
        {
            var data = _db.H_Source_Details.ToList();

            return View(data);
        }
    }
}