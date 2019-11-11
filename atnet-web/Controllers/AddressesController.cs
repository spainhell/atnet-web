using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atnet_web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace atnet_web.Controllers
{
    public class AddressesController : Controller
    {
        private AddressBook _abook;
        public AddressesController()
        {
            _abook = AddressBook.GetInstance();
        }
        // GET: Addresses
        public ActionResult Index()
        {
            return View(_abook.GetAddresses());
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int id)
        {
            ViewData["id"] = id;
            return View(_abook.GetAddresses()[id]);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            Address newAddress = new Address();
            return View(newAddress);
        }

        // POST: Addresses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public ActionResult Create(Address address)
        {
            try
            {
                _abook.AddAddress(address);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(address);
            }
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_abook.GetAddresses()[id]);
        }

        // POST: Addresses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Address address)
        {
            try
            {
                _abook.EditAddress(address, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_abook.GetAddresses()[id]);
        }

        // POST: Addresses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Address address)
        {
            try
            {
                _abook.DeleteAddress(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}