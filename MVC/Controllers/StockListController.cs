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

        [HttpGet("StockList/getall")]
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

        [HttpGet("StockList/getallstocksbystocktype")]
        public IActionResult GetAll(int idStockType)
        {

            IDataResult<List<StockSelectListDto>> result = _stockUnitService.GetAllStockUnitByStockType(idStockType);
            if (result.Success)
            {
                //return Ok(result);
                return View(result.Data);
            }
            else
            {
                return BadRequest(result);
            }

        }


        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("add")]
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

        //[HttpGet("getbyid")]
        //public IActionResult GetById(int id)
        //{
        //    var result = _StockListService.GetById(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

    }
}
