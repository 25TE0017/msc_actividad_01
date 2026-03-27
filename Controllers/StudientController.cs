using System.Diagnostics;
using actividad01.Data;
using actividad01.Interface;
using actividad01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace actividad01.Controllers;

public class StudientController: Controller
{
    private readonly IAlumnoDireccion _IAlumno;
    private readonly AppDbContext _context;

    public StudientController(AppDbContext context, IAlumnoDireccion alumnoService)
    {
        _context = context;
        _IAlumno = alumnoService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(Login login)
    {
        if (!ModelState.IsValid) return View(login);

        String access = "No";
        if (login.Usuario != "25TE0017P") return RedirectToAction("Index");

        ViewData["access"] = access;
        ViewData["username"] = login.Usuario;
        ViewData["password"] = login.Password;

        return RedirectToAction("Register");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(AlumnoDireccionViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);
        _IAlumno.CrearRegistro(viewModel);
        return RedirectToAction("Consultar");
    }

    [HttpGet]
    public async Task<IActionResult> Consultar()
    {
        try
        {            
            if (!await _context.Database.CanConnectAsync()) return View();
            
            var resultado = await _context.Database.ExecuteSqlRawAsync("SELECT 1");            
            List<AlumnoDireccionViewModel> alumnos = _IAlumno.ConsultarRegistros();
            
            return View(alumnos);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return View();
        }
    }

    [HttpGet]
    public async Task<IActionResult> Consultar2()
    {
        // List<AlumnoDireccionViewModel> alumnos = _IAlumno.ConsultarRegistros();
        // return View(_IAlumno.ConsultarRegistros());
        try
        {
            Console.WriteLine("OK");
            // 1. Verificar conectividad básica
            if (!await _context.Database.CanConnectAsync())
            {
                return View();
            }
            Console.WriteLine("OK");

            // 2. Verificar que la base de datos existe y responde
            var resultado = await _context.Database.ExecuteSqlRawAsync("SELECT 1");
            Console.WriteLine(resultado);
            
            return View(_IAlumno.ConsultarRegistros());
        }
        catch (Exception ex)
        {
            return View();
        }
    }

    [HttpGet]
    public IActionResult Eliminar(string NoControl)
    {
        // Alumno a1 = new Alumno{NoControl = "25TE001", Nombre = "A1"};
        // Alumno a2 = new Alumno{NoControl = "25TE002", Nombre = "A2"};
        // Alumno a3 = new Alumno{NoControl = "25TE003", Nombre = "A3"};

        // Direcciones d1 = new Direcciones{Calle = "Av. puerto", CP = 10001};
        // Direcciones d2 = new Direcciones{Calle = "Av. muelle", CP = 10002};
        // Direcciones d3 = new Direcciones{Calle = "Av. abismo", CP = 10003};

        // AlumnoDireccionViewModel r1 = new AlumnoDireccionViewModel{Alumno = a1, Direccion = d1};
        // AlumnoDireccionViewModel r2 = new AlumnoDireccionViewModel{Alumno = a2, Direccion = d2};
        // AlumnoDireccionViewModel r3 = new AlumnoDireccionViewModel{Alumno = a3, Direccion = d3};
        // List<AlumnoDireccionViewModel> alumnos = new List<AlumnoDireccionViewModel>{r1, r2, r3};

        // List<AlumnoDireccionViewModel> alumnos = _IAlumno.ConsultarRegistros();

        return RedirectToAction("Consultar");
    }
}

// 1.- Que es la injección de dependencia
// 2.- Scope, Singleton, Transient
// 3.- Como resuelvo, el problema planteado con el sistema de inyección de dependencias
// 4.- Mostrar todos los registros en la vista consultar
// Instalar SQL Server...
