using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using BluDataSoftware.Application.Interfaces;
using BluDataSoftware.Domain.Entities;
using BluDataSoftware.UII.Models.Empresa;

namespace BluDataSoftware.UII.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IAppEmpresa _appEmpresa;

        public EmpresaController(IAppEmpresa appEmpresa)
        {
            _appEmpresa = appEmpresa;
        }

        // GET: Empresa
        public ActionResult Index()
        {
            var empresaView = Mapper.Map<IEnumerable<Empresa>, IEnumerable<EmpresaIndexViewModel>>(_appEmpresa.GetAll());
            return View(empresaView);
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int id)
        {
            
            var empresaDetails = Mapper.Map<Empresa, EmpresaIndexViewModel>(_appEmpresa.GetById(id));
            if (empresaDetails == null)
            {
                ModelState.AddModelError("", "Não existe empresa com esse ID");
                return RedirectToAction("Index");
            }
            return View(empresaDetails);
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( EmpresaIndexViewModel empresa)
        {
            if (ModelState.IsValid)
            {
                var empresaCreate = Mapper.Map<EmpresaIndexViewModel, Empresa>(empresa);
                _appEmpresa.Add(empresaCreate);
                _appEmpresa.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(int id)
        {

            var empresaEdit = Mapper.Map<Empresa, EmpresaIndexViewModel>(_appEmpresa.GetById(id));
            if (empresaEdit == null)
            {
                ModelState.AddModelError("", "empresa não encontrada");
                return RedirectToAction("Index");
            }
            return View(empresaEdit);
        }

        // POST: Empresa/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( EmpresaIndexViewModel empresa)
        {
            if (ModelState.IsValid)
            {
                var empresaEdit = Mapper.Map<EmpresaIndexViewModel, Empresa>(empresa);
                _appEmpresa.Edit(empresaEdit);
                _appEmpresa.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
           
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(int id)
        {

            var empresaDelete = Mapper.Map<Empresa, EmpresaIndexViewModel>(_appEmpresa.GetById(id));
            if (empresaDelete == null)
            {
                ModelState.AddModelError("", "Empresa não existe");
                return RedirectToAction("Index");
            }
            return View(empresaDelete);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var empresaView = Mapper.Map<Empresa, EmpresaIndexViewModel>(_appEmpresa.GetById(id));
            _appEmpresa.Delete(id);
            try
            {
                _appEmpresa.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                if(ex.InnerException != null && ex.InnerException.InnerException !=null 
                    && ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    ModelState.AddModelError("", "Não é possível deletar essa empresa porque existe um fornecedor que depende dela.\n Por favor, delete primeiro o fornecedor para depois deletar a empresa");
                    return View(empresaView);
                }
                ModelState.AddModelError("", ex.Message);
                return View(empresaView);
            }
        }
 
      
    }
}
