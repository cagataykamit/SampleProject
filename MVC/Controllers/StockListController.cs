using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;

namespace MVC.Controllers
{
    public class StockListController : Controller
    {
        IStockListService _stockListService;
        IStockUnitService _stockUnitService;
        IStockTypeService _stockTypeService;
        IStockClassService _stockClassService;

        public StockListController(IStockListService StockListService, IStockUnitService stockUnitService, IStockTypeService stockTypeService, IStockClassService stockClassService)
        {
            _stockListService = StockListService;
            _stockUnitService = stockUnitService;
            _stockTypeService = stockTypeService;
            _stockClassService = stockClassService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var viewModel = new StockListViewModel();

            var result = _stockListService.GetAllForTable();
            if (result.Success)
            {
                viewModel.ListStockList = result.Data;
                viewModel.StockTypeItems = new List<SelectListItem>();
                viewModel.StockClassItems = new List<SelectListItem>();
                viewModel.StockUnitItems = new List<SelectListItem>();
                


                var stockTypeItems = _stockTypeService.GetAllStockTypesSelectList();
                var stockUnitItems = _stockUnitService.GetAllStockUnitSelectList();
                var stockClassItems = _stockClassService.GetAllStockClassSelectList();



                foreach (var item in stockTypeItems)
                {
                    viewModel.StockTypeItems.Add(new SelectListItem { Value = item.Value, Text = item.Text });
                }
                foreach (var item in stockUnitItems)
                {
                    viewModel.StockUnitItems.Add(new SelectListItem { Value = item.Value, Text = item.Text });
                }
                foreach (var item in stockClassItems)
                {
                    viewModel.StockClassItems.Add(new SelectListItem { Value = item.Value, Text = item.Text });
                }
               
                //return Ok(result);
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
        public IActionResult Add(StockList StockList)
        {
            var result = _stockListService.Add(StockList);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        public IActionResult Update()
        {

            return PartialView("_UpdateStockListPartialView");
        }

        [HttpPost]
        public IActionResult Update(StockList stockList)
        {
            var result = _stockListService.Update(stockList);
            if (result.Success)
            {
                return RedirectToAction("GetAll", new { message = result.Message });
            }
            else
            {
                return PartialView("_UpdateStockListPartialView", stockList);
            }
        }

    }
}
