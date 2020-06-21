using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soccer.Web.Data;
using Soccer.Web.Data.Entities;
using Soccer.Web.Helpers;
using Soccer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Soccer.Web.Controllers
{
    public class TournamentsController:Controller
    {
        private readonly DataContex _dataContex;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;
        public TournamentsController(DataContex dataContex, IImageHelper imageHelper,IConverterHelper converterHelper)
        {
            _dataContex = dataContex;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dataContex
                .Tournaments
                .Include(t => t.Groups)
                .OrderBy(t=> t.StartDate)
                .ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TournamentViewModel model)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;

                if(model.LogoFile!= null)
                {
                    path = await _imageHelper.UploadImageAsync(model.LogoFile, "Tournaments");
                }

                TournamentEntity tournament = _converterHelper.ToTournamentEntity(model, path, true);
                _dataContex.Add(tournament);
                await _dataContex.SaveChangesAsync();

                RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }

            TournamentEntity tournamentEntity = await _dataContex.Tournaments.FindAsync(id);

            if(tournamentEntity == null)
            {
                return NotFound();
            }

            TournamentViewModel model = _converterHelper.ToTournamentViewModel(tournamentEntity);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TournamentViewModel model)
        {
            if (ModelState.IsValid)
            {
                string path = model.LogoPath;

                if (model.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.LogoFile, "Tournaments");
                }

                TournamentEntity tournamentEntity = _converterHelper.ToTournamentEntity(model, path, false);
                _dataContex.Update(tournamentEntity);
                await _dataContex.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TournamentEntity tournamentEntity = await _dataContex.Tournaments
                .FirstOrDefaultAsync(m => m.Id == id);

            if(tournamentEntity == null)
            {
                return NotFound();
            }

            _dataContex.Tournaments.Remove(tournamentEntity);
            await _dataContex.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
;       }

        public async Task<IActionResult> Details(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }

            TournamentEntity tournamentEntity = await _dataContex.Tournaments
                .Include(t => t.Groups)
                .ThenInclude(t => t.Matches)
                .ThenInclude(t => t.Local)
                .Include(t => t.Groups)
                .ThenInclude(t => t.Matches)
                .ThenInclude(t => t.Visitor)
                .Include(t => t.Groups)
                .ThenInclude(t => t.GroupDetails)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tournamentEntity == null)
            {
                return NotFound();
            }

            return View(tournamentEntity);
        }
    }
}
