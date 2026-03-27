using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using actividad01.Data;
using actividad01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace actividad01.Controllers
{
    public class MantenimientoController: Controller
    {
        private readonly AppDbContext _db;
        public MantenimientoController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Mantenimiento> mantenimientos = await _db.Mantenimientos.ToListAsync();
            return View(mantenimientos);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(Mantenimiento mantenimiento)
        {
            Mantenimiento? result = await _db.Mantenimientos.FirstOrDefaultAsync(x => x.Id == mantenimiento.Id);
            if (!ModelState.IsValid) return View(mantenimiento);
            if (result != null) {
                // ModelState.AddModelError("NoControl", "El número de control ya existe");
                return View(result);
            };

            await _db.Mantenimientos.AddAsync(mantenimiento);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            Mantenimiento? mantenimiento = await _db.Mantenimientos.FirstOrDefaultAsync(x => x.Id == int.Parse(id));
            if (mantenimiento == null) return NotFound();

            return View(mantenimiento);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Mantenimiento mantenimiento)
        {
            if (!ModelState.IsValid) return View(mantenimiento);
            Mantenimiento? result = await _db.Mantenimientos.FirstOrDefaultAsync(x => x.Id == mantenimiento.Id);
            if (result == null) return View(result);

            result.Diagnostico = mantenimiento.Diagnostico;
            result.Precio = mantenimiento.Precio;
            result.Tecnico = mantenimiento.Tecnico;
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Destroy(string id)
        {
            Mantenimiento? mantenimiento = await _db.Mantenimientos.FirstOrDefaultAsync(x => x.Id == int.Parse(id));
            if (mantenimiento == null) return NotFound();

            return View(mantenimiento);
        }

        [HttpPost]
        public async Task<IActionResult> DestroyAction(string id)
        {
            Mantenimiento? result = await _db.Mantenimientos.FirstOrDefaultAsync(x => x.Id == int.Parse(id));
            if (result == null) return NotFound();

            _db.Mantenimientos.Remove(result);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
    }
}