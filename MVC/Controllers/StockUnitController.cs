using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Controllers
{
    public class StockUnitController : Controller
    {
        IStockUnitService _stockUnitService;
        IStockTypeService _stockTypeService;
        StockContext c = new StockContext();

        public StockUnitController(IStockUnitService stockUnitService,IStockTypeService stockTypeService)
        {
            _stockUnitService = stockUnitService;
            _stockTypeService = stockTypeService;
            
        }

        [HttpGet("StockUnit/getall")]
        public IActionResult GetAll()
        {

            var result = _stockUnitService.GetAll();
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


        [HttpGet]
        public IActionResult GetAllWithStockTypeNonDeleted()
        {

            var result = _stockUnitService.GetAll();
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
