using AutoMapper;
using BluDataSoftware.Application.Interfaces;
using BluDataSoftware.Domain.Entities;
using BluDataSoftware.UII.Models.FornecedorFisico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BluDataSoftware.UII.Controllers
{
    public class FornecedorFisicoController : Controller
    {
        private readonly IAppFisico _appFisico;
        private readonly IAppEmpresa _appEmpresa;

        public FornecedorFisicoController(IAppFisico appFisico, IAppEmpresa appEmpresa)
        {
            _appFisico = appFisico;
            _appEmpresa = appEmpresa;
        }

        // GET: FornecedorFisico
        public ActionResult Index(string sortOrder)
        {
            var fisicoIndex = Mapper.Map<IEnumerable<FornecedorFisico>, IEnumerable<FornecedorFisicoViewModel>>(_appFisico.GetAll());

            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CpfSortParm = string.IsNullOrEmpty(sortOrder) ? "cpf_desc" : "";
            switch (sortOrder)
            {
                case "name_desc":
                    fisicoIndex = Mapper.Map<IEnumerable<FornecedorFisico>, IEnumerable<FornecedorFisicoViewModel>>(_appFisico.GetAll()).OrderBy(x=> x.Nome);
                    break;
                case "cpf_desc":
                    fisicoIndex = Mapper.Map<IEnumerable<FornecedorFisico>, IEnumerable<FornecedorFisicoViewModel>>(_appFisico.GetAll()).OrderBy(x => x.Cpf);
                    break;
                default:
                    fisicoIndex = Mapper.Map<IEnumerable<FornecedorFisico>, IEnumerable<FornecedorFisicoViewModel>>(_appFisico.GetAll()).OrderByDescending(x => x.EmpresaId) ;
                    break;

            }
            return View(fisicoIndex);
        }

        // GET: FornecedorFisico/Details/5
        public ActionResult Details(int id)
        {
            var fornecedorDetails = Mapper.Map<FornecedorFisico, FornecedorFisicoViewModel>(_appFisico.GetById(id));
            return View(fornecedorDetails);
        }

        // GET: FornecedorFisico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FornecedorFisico/Create
        [HttpPost]
        public ActionResult Create(FornecedorFisicoViewModel fornecedorFisico)
        {
            try
            {
                var fornecedorCreate = Mapper.Map<FornecedorFisicoViewModel, FornecedorFisico>(fornecedorFisico);
                if (fornecedorCreate.Nome == null)
                {
                    ModelState.AddModelError(string.Empty, "Verifique se o nome está nulo");
                    return View(fornecedorFisico);
                }
                else
                
                _appFisico.Add(fornecedorCreate);
                _appFisico.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(fornecedorFisico);
            }
        }

        //GET: FornecedorFisico/AddEmpresa/5
        public ActionResult AddEmpresa(int id)
        {
            ViewBag.EmpresaId = new SelectList(_appEmpresa.GetAll().ToList().OrderBy(x => x.NomeFantasia), "EmpresaId", "NomeFantasia");
            var fornecedorAddEmpresa = Mapper.Map<FornecedorFisico, FornecedorFisicoViewModel>(_appFisico.GetById(id));
            return View(fornecedorAddEmpresa);
        }

        [HttpPost, ActionName("AddEmpresa")]
        public ActionResult AddEmpresa(int id, FornecedorFisicoViewModel fornecedorFisico)
        {
            ViewBag.EmpresaId = new SelectList(_appEmpresa.GetAll().ToList().OrderBy(x => x.NomeFantasia), "EmpresaId", "NomeFantasia");
            var fornecedorAddEmpresa = Mapper.Map<FornecedorFisicoViewModel, FornecedorFisico>(fornecedorFisico);
            var fornecedorBanco = _appFisico.GetById(id);
          

            if (fornecedorAddEmpresa.EmpresaId == null)
            {
                ModelState.AddModelError("", "Por favor, escolha uma empresa!");
                return View(fornecedorFisico);
            }
            else
                fornecedorBanco.AddEmpresaId(fornecedorFisico.EmpresaId);
            var empresa = _appEmpresa.GetAll().Where(x => x.EmpresaId == fornecedorBanco.EmpresaId).FirstOrDefault();
            if (empresa.Uf.Contains("Paraná") && (DateTime.Now.Year - fornecedorBanco.DataNascimento.Year ) < 18)
            {
                ModelState.AddModelError("", "Não é possível cadastrar uma empresa do Paraná para um fornecedor pessoa física menor de 18 anos!");
                return View(fornecedorFisico);

            }
            _appFisico.SaveChanges();
            return RedirectToAction("Index");
           
        }

        // GET: FornecedorFisico/Edit/5
        public ActionResult Edit(int id)
        {
            var fornecedorEdit = Mapper.Map<FornecedorFisico, FornecedorFisicoViewModel>(_appFisico.GetById(id));
            return View(fornecedorEdit);
        }

        // POST: FornecedorFisico/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FornecedorFisicoViewModel fornecedorView)
        {
            try
            {
                var fornecedorEdit = Mapper.Map<FornecedorFisicoViewModel, FornecedorFisico>(fornecedorView);
                _appFisico.Edit(fornecedorEdit);
                _appFisico.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(fornecedorView);
            }
        }

        // GET: FornecedorFisico/Delete/5
        public ActionResult Delete(int id)
        {
            var fornecedorId = Mapper.Map<FornecedorFisico, FornecedorFisicoViewModel>(_appFisico.GetById(id));
            return View(fornecedorId);
        }

        // POST: FornecedorFisico/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteOk(int id, FornecedorFisicoViewModel fornecedorFisico)
        {
            try
            {
                _appFisico.Delete(id);
                _appFisico.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(fornecedorFisico);
            }
        }
    }
}
