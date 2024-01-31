using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.StockType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper.StockTypes
{
    public class StockTypeProfile:Profile
    {
        public StockTypeProfile()
        {
            CreateMap<StockTypeDto, StockType>().ReverseMap();
        }
    }
}
