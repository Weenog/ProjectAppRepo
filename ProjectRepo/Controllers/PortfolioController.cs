
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Database;
using PortfolioApp.Domain;
using PortfolioApp.Models;


namespace PortfolioApp.Controllers
{
    public class PortfolioController : Controller
    {

        private readonly PortfolioDb _projectDb;



        public PortfolioController(PortfolioDb portfolioDb)

        {

            _projectDb = portfolioDb;

        }



        public async Task<IActionResult> Index()

        {

            List<PortfolioListViewModel> vmList = new List<PortfolioListViewModel>();

            var portfolios = await _projectDb.Portfolio.Include(x => x.Status).Include(x => x.PortfolioTags).ThenInclude(x => x.Tag).ToListAsync();

            foreach (var portfolio in portfolios)

            {

                PortfolioListViewModel vm = new PortfolioListViewModel()

                {

                    Id = portfolio.Id,

                    CompletionDate = portfolio.CompletionDate,

                    Status = portfolio.Status.Description,

                    Tags = portfolio.PortfolioTags.Select(x => x.Tag.Description).ToList(),

                    PhotoUrl = portfolio.PhotoUrl,

                    Title = portfolio.Title

                };

                vmList.Add(vm);

            }



            return View(vmList);

        }

        public async Task<IActionResult> Detail(int id)

        {

            Portfolio portfolio = await _projectDb.Portfolio.Include(x => x.Status).Include(x => x.PortfolioTags).ThenInclude(x => x.Tag).FirstOrDefaultAsync(x => x.Id == id);

            PortfolioDetailViewModel vm = new PortfolioDetailViewModel()

            {

                Title = portfolio.Title,

                CompletionDate = portfolio.CompletionDate,

                Status = portfolio.Status.Description,

                Tags = portfolio.PortfolioTags.Select(x => x.Tag.Description).ToList(),

                PhotoUrl = portfolio.PhotoUrl,

                Description = portfolio.Description

            };

            return View(vm);

        }



    }

}