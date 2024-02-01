using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.StockType;
using Entities.DTOs.StockUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.AutoMapper.StockUnitProfile
{
    public class StockUnitProfile:Profile
    {
        public StockUnitProfile()
        {
            CreateMap<StockUnitDto, StockUnit>().ReverseMap();
        }
    }
}
