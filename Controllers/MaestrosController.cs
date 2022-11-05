using BackEnd_BD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackEnd_BD.Controllers
{
    public class MaestrosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
              

                return View(dbAlumnos.Alumnos.ToList());

            }


        }

        public ActionResult Details(int id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                Maestros maestros = dbAlumnos.Maestros.Find(id);
                if (maestros == null)
                {
                    return HttpNotFound();
                }

                return View(maestros);
            }
        }

        public ActionResult Edit(int id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                return View(dbAlumnos.Maestros.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Edit(Maestros maes)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                dbAlumnos.Entry(maes).State = EntityState.Modified;
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                return View(dbAlumnos.Maestros.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Delete(Maestros maes, int id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                Maestros al = dbAlumnos.Maestros.Where((x) => x.Id == id).FirstOrDefault();
                dbAlumnos.Maestros.Remove(al);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Maestros maes)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                //Insert into
                dbAlumnos.Maestros.Add(maes);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
