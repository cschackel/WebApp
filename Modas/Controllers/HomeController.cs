using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modas.Models;

namespace Modas.Controllers
{
    public class HomeController : Controller
    {
        private readonly int PageSize = 20;
        private IEventRepository repository;
        public HomeController(IEventRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(int page = 1)
        {
            EventPaginationViewModel vm = new EventPaginationViewModel();
            vm.TotalResults = repository.Events.Count();
            vm.MaxPage = (int)Math.Ceiling(((Double)vm.TotalResults/ 20));
            if(page > vm.MaxPage)
            {
                page = vm.MaxPage;
            }
            
            vm.CurrentMinResult = (((page - 1) * 20) + 1) <= vm.TotalResults ? ((page - 1) * 20) + 1 : vm.TotalResults;
            vm.CurrentMaxResult = (((page - 1) * 20) + 20)<=vm.TotalResults? ((page - 1) * 20) + 20 :vm.TotalResults;
            vm.CurrentPage = page;
            vm.Events = repository.Events.Include(e => e.Location)
.OrderBy(e => e.TimeStamp)
.Skip((page - 1) * PageSize)
.Take(PageSize);
            return View(vm);
        }

        //public ViewResult Index() => View(repository.Events.Include(e => e.Location).OrderBy(e => e.TimeStamp));
    }

    
}