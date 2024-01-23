using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public  static class Messages
    {
        public static string ProductAdded = "Ürün başarıyla eklendi";
        public static string ProductDeleted = "Ürün başarıyla silindi";
        public static string ProductUpdated = "Ürün başarıyla güncellendi";

        public static string StockTypeAdded = "Stok tipi başarıyla eklendi";
        public static string StockTypeDeleted = "Stok tipi başarıyla silindi";
        public static string StockTypeUpdated = "Stok tipi başarıyla güncellendi";

        public static string StockAdded = "Stok başarıyla eklendi";
        public static string StockDeleted = "Stok başarıyla silindi";
        public static string StockUpdated = "Stok başarıyla güncellendi";


        public static string StockListAdded = "Stok başarıyla eklendi";
        public static string StockListDeleted = "Stok başarıyla silindi";
        public static string StockListUpdated = "Stok başarıyla güncellendi";
        public static string StockListTypeListed = "Stok operasyonları listelendi.";
        

        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductListed = "Ürünler listelendi.";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExist = "Bu isimde bir ürün zaten var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string StockTypeListed = "Stok tipleri listelendi";
    }
}
