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
    public class CompetencyHeadersController : Controller
    {
        //CompetenciesHeadersRepository competenciesHeadersRepository = new CompetenciesHeadersRepository();

        private readonly ICompetenciesHeadersRepository competenciesHeadersRepository;

        public CompetencyHeadersController(ICompetenciesHeadersRepository competenciesHeadersRepository)
        {
            this.competenciesHeadersRepository = competenciesHeadersRepository;
        }

        public ActionResult Index()
        {
            return View(competenciesHeadersRepository.All.ToList());
        }

        [HttpGet]
        public ActionResult Edit(int competencyHeaderId)
        {
            //look up a student in the db
            CompetencyHeader competencyHeader = competenciesHeadersRepository.Find(competencyHeaderId);
            return View(competencyHeader);
        }
        [HttpPost]
        public ActionResult Edit(CompetencyHeader competencyHeader)
        {
            //save to db.
            if (ModelState.IsValid)
            {
                competenciesHeadersRepository.InsertOrUpdate(competencyHeader);
                return RedirectToAction("Index");
            }
            else
            {
                return View(competencyHeader);
            }
        }

        [HttpGet]
        public ActionResult Delete(int competencyHeaderId)
        {
            //look up a student in the db
            CompetencyHeader competencyHeader = competenciesHeadersRepository.Find(competencyHeaderId);
            return View(competencyHeader);
        }
        [HttpPost]
        public ActionResult Delete(CompetencyHeader competencyHeader)
        {
            //save to db.
            if (ModelState.IsValid)
            {
                int id = competencyHeader.CompetencyHeaderId;
                competenciesHeadersRepository.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                return View(competencyHeader);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CompetencyHeader competencyHeader)
        {
            //save to db.
            if (ModelState.IsValid)
            {
                competenciesHeadersRepository.InsertOrUpdate(competencyHeader);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
