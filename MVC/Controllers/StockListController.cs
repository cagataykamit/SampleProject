using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class StockListController : Controller
    {
        IStockListService _stockListService;
        IStockUnitService _stockService;

        public StockListController(IStockListService StockListService, IStockUnitService stockService)
        {
            _stockListService = StockListService;
            _stockService = stockService;
        }

        [HttpGet("StockList/getall")]
        public IActionResult GetAll()
        {

            var result = _stockListService.GetAll();
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

        [HttpGet("StockList/getallstocksbystocktype")]
        public IActionResult GetAll(int idStockType)
        {

            IDataResult<List<StockSelectListDto>> result = _stockService.GetAllStocksByStockType(idStockType);
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
