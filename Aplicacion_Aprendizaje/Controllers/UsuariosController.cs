using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion_Aprendizaje.iUnitOfWork;
using Aplicacion_Aprendizaje.Models;
using Aplicacion_Aprendizaje.Models.ViewModels;

namespace Aplicacion_Aprendizaje.Controllers
{
    public class UsuariosController : Controller
    {
        //
        // GET: /Usuarios/

        public ActionResult Index()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var newuser= new UsuariosViewModel();
                newuser.edad = 10;
                newuser.nombre = "Pepe";
var newestado= new EstadosViewModel();
                newestado.descripcion = "JAJA";
                unitOfWork.RepoEstados.Add(newestado);
                unitOfWork.Commit();
                newuser.estado = newestado.id;
                unitOfWork.RepoUsuarios.Add(newuser);
                unitOfWork.Commit();
                var users = unitOfWork.RepoUsuarios.Get().ToList();

                return View(users);

            }
          
        }
    

        //
        // GET: /Usuarios/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Usuarios/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Usuarios/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Usuarios/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Usuarios/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Usuarios/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Usuarios/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
