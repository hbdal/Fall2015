using Fall2015.Models;
using Fall2015.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fall2015.ViewModel;

namespace Fall2015.Controllers
{
    public class StudentsController : Controller
    {
        //StudentsRepository studentsRepository = new StudentsRepository();

        private readonly IStudentsRepository studentsRepository;
        private readonly ICompetenciesHeadersRepository competenciesHeadersRepository;

        public StudentsController(IStudentsRepository studentsRepository, ICompetenciesHeadersRepository competenciesHeadersRepository)
        {
            this.studentsRepository = studentsRepository;
            this.competenciesHeadersRepository = competenciesHeadersRepository;
        }

        public ActionResult Index()
        {
            StudentIndexViewModel sivm = new StudentIndexViewModel
            {
                Students = studentsRepository.All.ToList(),
                CompetencyHeaders = competenciesHeadersRepository.All.ToList()
            };

            return View(sivm);
        }

        [HttpGet]
        public ActionResult Edit(int studentId)
        {
            //look up a student in the db
            Student student = studentsRepository.Find(studentId);
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student, HttpPostedFileBase image)
        {
            //save to db.
            if (ModelState.IsValid)
            {
                studentsRepository.InsertOrUpdate(student, image);
                return RedirectToAction("Index");
            }
            else
            {
                return View(student);
            }
        }

        [HttpGet]
        public ActionResult Delete(int studentId)
        {
            //look up a student in the db
            Student student = studentsRepository.Find(studentId);
            return View(student);
        }
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            //save to db.
            if (ModelState.IsValid)
            {
                int id = student.StudentId;
                studentsRepository.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                return View(student);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateEditStudentViewModel vm = new CreateEditStudentViewModel
            {
                Student = new Student(),
                CompetencyHeaders = competenciesHeadersRepository.AllIncluding(a => a.Competencies).ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(Student student, HttpPostedFileBase image, IEnumerable<int> compIds)
        {
            //save to db.
            if (ModelState.IsValid)
            {
                studentsRepository.InsertOrUpdate(student, image);
                return View("Thanks");
            }
            else
            {
                return View();
            }
        }



        public String WannaPlayDad()
        {
            return "No!";
        }

        public ActionResult WannaPlayDad2()
        {
            ViewBag.Dad = "Hi there sonny";
            return View();
        }
    }
}
















