using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using JournalSystemMVC.DataAccessLayer;
using JournalSystemMVC.Models;
using JournalSystemMVC.Models.ResidentData;
using JournalSystemMVC.Models.ViewModels;

namespace JournalSystemMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJournalRepository _journalRepository;
        private const int ENTRIES_PER_PAGE = 3;
        private readonly IList<JournalEntry> _entries; 

        public HomeController()
        {
            _journalRepository = new JournalRepository(new ApplicationDbContext());
            _entries = _journalRepository.GetJournalEntries().ToList();
        }

        public ActionResult Index()
        {
            var indexVm = new HomeIndexViewModel();
            indexVm.JournalEntries = _entries.Take(ENTRIES_PER_PAGE);
            indexVm.EntriesPerPage = ENTRIES_PER_PAGE;
            indexVm.PageNum = 1;
            return View(indexVm);
        }

        [OutputCache(Duration = 0, Location = OutputCacheLocation.Any, VaryByHeader = "Content-Type")]
        public ActionResult Entries(int page)
        {
            Response.Cache.SetOmitVaryStar(true);
            var entries = _entries.Skip((page - 1) * ENTRIES_PER_PAGE).Take(ENTRIES_PER_PAGE);
            var hasMore = page * ENTRIES_PER_PAGE < _entries.Count;

            if (ControllerContext.HttpContext.Request.ContentType == "application/json")
            {
                return Json(new
                {
                    entries = entries,
                    hasMore = hasMore
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var indexVm = new HomeIndexViewModel();
                indexVm.JournalEntries = _entries.Take(ENTRIES_PER_PAGE * page);
                indexVm.EntriesPerPage = ENTRIES_PER_PAGE;
                indexVm.PageNum = page;

                return View("Index", indexVm);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}