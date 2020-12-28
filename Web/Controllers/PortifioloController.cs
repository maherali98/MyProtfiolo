using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructre.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Web.ViewModel;

namespace Web.Controllers
{
    public class PortifioloController : Controller
    {
        private readonly IUnitOfWork<PortifioloItem> portifioloItem;
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment host;

        public PortifioloController(IUnitOfWork<PortifioloItem> portifioloItem,
            DataContext dataContext,
            IWebHostEnvironment host)
        {
            this.portifioloItem = portifioloItem;
            _dataContext = dataContext;
            this.host = host;
        }
        // GET: PortifioloController
        public ActionResult Index()
        {
            List<PortifioloItem> portifiolo = portifioloItem.Entity.GetAll().ToList();
            return View(portifiolo);
        }



        // GET: PortifioloController/Details/5
        public ActionResult Details(Guid id)
        {
            PortifioloItem portifiolo = portifioloItem.Entity.GetById(id);

            return View(portifiolo);
        }

        // GET: PortifioloController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortifioloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PortifioloViewModel portifiolo)
        {

            if (ModelState.IsValid)
            {
                if (portifiolo.File != null)
                {
                    string Upload = Path.Combine(host.WebRootPath, @"img\portfolio");
                    string FullPath = Path.Combine(Upload, portifiolo.File.FileName);
                    portifiolo.File.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                PortifioloItem item = new PortifioloItem
                {
                    Id = Guid.NewGuid(),
                    ProjectName = portifiolo.ProjectName,
                    Description = portifiolo.Description,
                    ImgUrl = portifiolo.File.FileName
                };

                portifioloItem.Entity.Insert(item);
                _dataContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }


            return View(portifiolo);
        }

        // GET: PortifioloController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PortifioloController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PortifioloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PortifioloController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
