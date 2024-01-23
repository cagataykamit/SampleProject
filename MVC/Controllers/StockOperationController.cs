using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class StockOperationController : Controller
    {
        IStockOperationService _StockOperationService;
        IStockService _stockService;

        public StockOperationController(IStockOperationService StockOperationService, IStockService stockService)
        {
            _StockOperationService = StockOperationService;
            _stockService = stockService;
        }

        [HttpGet("StockOperation/getall")]
        public IActionResult GetAll()
        {

            var result = _StockOperationService.GetAll();
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

        [HttpGet("StockOperation/getallstocksbystocktype")]
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
        public IActionResult Add(StockOperation StockOperation)
        {
            var result = _StockOperationService.Add(StockOperation);
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
        //    var result = _StockOperationService.GetById(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

    }
}
