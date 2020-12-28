using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.Page;
using Web.ViewModel;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<PortifioloItem> portifioloItem;

        public HomeController(IUnitOfWork<Owner> Owner,
            IUnitOfWork<PortifioloItem> PortifioloItem)
        {
            _owner = Owner;
            portifioloItem = PortifioloItem;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                owner = _owner.Entity.GetAll().First(),
                portifioloItems = portifioloItem.Entity.GetAll().ToList()
            };

            return  View(homeViewModel);
        }
        
    }
}
