using firstPrjAspCore.Models;
using firstPrjAspCore.Models.RepositorIes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstPrjAspCore.Controllers
{
    public class EtudiantController : Controller
    {
        private readonly ISchool<Etudiant> etudiantsRepo;

        public EtudiantController(ISchool<Etudiant> EtudiantsRepo)
        {
            etudiantsRepo = EtudiantsRepo;
        }

        // GET: EtudiantController
        public ActionResult Index()
        {
            var allEtu = etudiantsRepo.List();
            return View(allEtu);
        }

        // GET: EtudiantController/Details/5
        public ActionResult Details(int id)
        {
            var detailEtud = etudiantsRepo.find(id);
            return View(detailEtud);
        }

        // GET: EtudiantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EtudiantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Etudiant Etudiant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    etudiantsRepo.Add(Etudiant);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "you have problem");
                return View(); 
            }
            
        }

        // GET: EtudiantController/Edit/5
        public ActionResult Edit(int id)
        {
            var detailEtud = etudiantsRepo.find(id);
            return View(detailEtud);
        }

        // POST: EtudiantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Etudiant Etudiant)
        {
            try
            {
                etudiantsRepo.Update(id , Etudiant);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EtudiantController/Delete/5
        public ActionResult Delete(int id)
        {
            var itemRemove = etudiantsRepo.find(id);
            return View(itemRemove);
        }

        // POST: EtudiantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Etudiant etudiant)
        {
            try
            {
                etudiantsRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
