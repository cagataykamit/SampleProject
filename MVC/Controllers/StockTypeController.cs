using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Web.Razor.Parser.SyntaxTree;

namespace MVC.Controllers
{
    public class StockTypeController : Controller
    {
        IStockTypeService _stockTypeService;
        public StockTypeController(IStockTypeService stockTypeService)
        {
            _stockTypeService = stockTypeService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var viewModel = new StockTypeViewModel();


            var result = _stockTypeService.GetAll();
            if (result.Success)
            {
                viewModel.LstStock = result.Data;
                return View(viewModel);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(StockType RequestModel)
        {
            var result = _stockTypeService.Add(RequestModel);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet]
        public IActionResult Update()
        {
            
            return PartialView("_UpdateStockTypePartialView");
        }

        [HttpPost]
        public IActionResult Update(StockType stockType)
        {
            var result = _stockTypeService.Update(stockType);
            if (result.Success)
            {
                return RedirectToAction("GetAll", new { message = result.Message });
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet]
        public IActionResult Delete(StockType stockType)
        {
            var result = _stockTypeService.Delete(stockType);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
