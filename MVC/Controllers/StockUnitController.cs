﻿using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;

namespace MVC.Controllers
{
    public class StockUnitController : Controller
    {
        IStockUnitService _stockUnitService;
        IStockTypeService _stockTypeService;
        IQuantityUnitService _quantityUnitService;
        ICurrencyTypeService _currencyTypeService;
        

        public StockUnitController(IStockUnitService stockUnitService,IStockTypeService stockTypeService,IQuantityUnitService quantityUnitService, ICurrencyTypeService currencyTypeService)
        {
            _stockUnitService = stockUnitService;
            _stockTypeService = stockTypeService;
            _quantityUnitService = quantityUnitService;
            _currencyTypeService = currencyTypeService;
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var viewModel = new StockUnitViewModel();


            var result = _stockUnitService.GetAllWithStockType();
            if (result.Success)
            {
                viewModel.ListStockUnit = result.Data;
                viewModel.StockTypeItems = new List<SelectListItem>();
                viewModel.QuantityUnitItems = new List<SelectListItem>();
                viewModel.CurrencyTypePurchaseItems = new List<SelectListItem>();
                viewModel.CurrencyTypeSaleItems = new List<SelectListItem>();


                var stockTypeItems = _stockTypeService.GetAllStockTypesSelectList();
                var quantityUnitItems = _quantityUnitService.GetAllQuantityUnitSelectList();
                var currencyTypePurchaseItems = _currencyTypeService.GetAllCurrencyTypeSelectList();
                var currencyTypeSaleItems = _currencyTypeService.GetAllCurrencyTypeSelectList();
                


                foreach (var item in stockTypeItems)
                {
                    viewModel.StockTypeItems.Add(new SelectListItem { Value = item.Value, Text = item.Text });
                }
                foreach (var item in quantityUnitItems)
                {
                    viewModel.QuantityUnitItems.Add(new SelectListItem { Value = item.Value, Text = item.Text });
                }
                foreach (var item in currencyTypePurchaseItems)
                {
                    viewModel.CurrencyTypePurchaseItems.Add(new SelectListItem { Value = item.Value, Text = item.Text });
                }
                foreach (var item in currencyTypeSaleItems)
                {
                    viewModel.CurrencyTypeSaleItems.Add(new SelectListItem { Value = item.Value, Text = item.Text });
                }
                //return Ok(result);
                return View(viewModel);
            }
            else
            {
                return BadRequest(result);
            }

        }


        //[HttpGet]
        //public IActionResult GetAllWithStockTypeNonDeleted()
        //{

        //    var result = _stockUnitService.GetAll();
        //    if (result.Success)
        //    {
        //        //return Ok(result);
        //        return View(result.Data);
        //    }
        //    else
        //    {
        //        return BadRequest(result);
        //    }

        //}


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(StockUnit stockUnit)
        {
            var result = _stockUnitService.Add(stockUnit);
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
        public IActionResult Delete(StockUnit stockUnit)
        {
            var result = _stockUnitService.Delete(stockUnit);
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
            
            return PartialView("_UpdateStockUnitPartialView");
        }

        [HttpPost]
        public IActionResult Update(StockUnit stockUnit)
        {
            var result = _stockUnitService.Update(stockUnit);
            if (result.Success)
            {
                return RedirectToAction("GetAll", new { message = result.Message });
            }
            else
            {
                return BadRequest(result);
            }
        }
        //[HttpGet]
        //public IActionResult AddStockType()
        //{
        //    // Veritabanından stok tiplerini alın
        //    List<StockType> stockTypes = _stockTypeService.GetAll();

        //    // SelectListItem listesini oluşturun
        //    List<SelectListItem> stockTypeList = stockTypes
        //        .Select(x => new SelectListItem
        //        {
        //            Text = x.Name,
        //            Value = x.st.ToString() // Varsa, StockType'un bir sayısal değeri varsa kullanın
        //        })
        //        .ToList();

        //    // ViewModel'i oluşturun ve SelectListItem listesini atayın
        //    var viewModel = new StockUnitViewModel
        //    {
        //        StockTypeList = stockTypeList
        //    };

        //    return View(viewModel);
        //}

        //[HttpPost]
        //public IActionResult AddStockType(StockUnit stockUnit)
        //{

        //}

        //[HttpGet("getbyid")]
        //public IActionResult GetById(int id)
        //{
        //    var result = _StockService.GetById(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

    }
}
