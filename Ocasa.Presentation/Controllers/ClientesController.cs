using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ocasa.Entities;
using Ocasa.Presentation.Repositories;
using Ocasa.Presentation.ViewModels;
using System.Linq;

namespace Ocasa.Presentation.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClientRepository clientRepository;

        public ClientesController(IClientRepository ClientRepository)
        {
            clientRepository = ClientRepository;
        }

        public IActionResult Index()
        {
            return View((clientRepository.GetAllClientes().Select(x => new ClienteVM(x))).ToList());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteVM model)
        {
            var client = BuildClient(model);

            if (ModelState.IsValid)
            {
                clientRepository.InsertClient(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var client = new ClienteVM(clientRepository.GetClienteByID(id));

            if (client == null)
                return NotFound();

            return View(client);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClienteVM model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var client = BuildClient(model);

                    clientRepository.UpdateClient(client);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!clientRepository.ClienteExists(model.IdCliente))
                        return NotFound();

                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        private Cliente BuildClient(ClienteVM model)
            => new Cliente
            {
                IdCliente = model.IdCliente,
                RazonSocial = model.RazonSocial,
                Direccion = model.Direccion
            };

    }
}
