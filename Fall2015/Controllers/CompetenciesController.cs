using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fall2015.Models;
using Fall2015.Repositories;

namespace Fall2015.Controllers
{
    public class CompetenciesController : Controller
    {
        //CompetenciesRepository competenciesRepository = new CompetenciesRepository();
        //CompetenciesHeadersRepository competenciesHeadersRepository = new CompetenciesHeadersRepository();
        private readonly ICompetenciesRepository competenciesRepository;
        private readonly ICompetenciesHeadersRepository competenciesHeadersRepository;

        public CompetenciesController(ICompetenciesRepository competenciesRepository, ICompetenciesHeadersRepository competenciesHeadersRepository)
        {
            this.competenciesRepository = competenciesRepository;
            this.competenciesHeadersRepository = competenciesHeadersRepository;
        }

        public ActionResult Index()
        {
            return View(competenciesRepository.All.ToList());
        }

        [HttpGet]
        public ActionResult Edit(int competencyId)
        {
            //look up a competency in the db
            //Competency competency= competenciesRepository.Find(competencyId);
            ViewBag.CompetencyHeaderId = new SelectList(competenciesHeadersRepository.All, "CompetencyHeaderId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Competency competency)
        {
            //save to db.
            if (ModelState.IsValid)
            {
                competenciesRepository.InsertOrUpdate(competency);
                return RedirectToAction("Index");
            }
            else
            {
                return View(competency);
            }
        }

        [HttpGet]
        public ActionResult Delete(int competencyId)
        {
            //look up a student in the db
            Competency competency = competenciesRepository.Find(competencyId);
            return View(competency);
        }
        [HttpPost]
        public ActionResult Delete(Competency competency)
        {
            //save to db.
            if (ModelState.IsValid)
            {
                int id = competency.CompetencyId;
                competenciesRepository.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                return View(competency);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CompetencyHeaderId = new SelectList(competenciesHeadersRepository.All, "CompetencyHeaderId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Competency competency)
        {
            //save to db.
            if (ModelState.IsValid)
            {
                competenciesRepository.InsertOrUpdate(competency);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
