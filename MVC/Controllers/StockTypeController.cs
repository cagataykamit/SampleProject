using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

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
            //return PartialView("_StockTypeAddPartial");
        }

        [HttpPost]
        public IActionResult Add(StockType RequestModel)
        {
            var result = _stockTypeService.Add(RequestModel);
            if (result.Success)
            {
                return RedirectToAction("GetAll",new { message = result.Message});
            }
            else
            {
                return BadRequest(result);
            }
        }

        //[HttpGet("getbyid")]
        //public IActionResult GetById(int id)
        //{
        //    var result = _stockTypeService.GetById(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

    }
}
