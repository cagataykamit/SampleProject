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
        public static string StockTypeListed = "Stok tipleri listelendi";

        public static string StockUnitAdded = "Stok başarıyla eklendi";
        public static string StockUnitDeleted = "Stok başarıyla silindi";
        public static string StockUnitUpdated = "Stok başarıyla güncellendi";


        public static string StockListAdded = "Stok başarıyla eklendi";
        public static string StockListDeleted = "Stok başarıyla silindi";
        public static string StockListUpdated = "Stok başarıyla güncellendi";
        public static string StockListTypeListed = "Stok operasyonları listelendi.";

        public static string QuantityUnitAdded = "Stok başarıyla eklendi";
        public static string QuantityUnitDeleted = "Stok başarıyla silindi";
        public static string QuantityUnitUpdated = "Stok başarıyla güncellendi";
        public static string QuantityUnitListed = "Stok operasyonları listelendi.";

        public static string CurrencyTypeAdded = "Para birimi başarıyla eklendi";
        public static string CurrencyTypeDeleted = "Para birimi başarıyla silindi";
        public static string CurrencyTypeUpdated = "Para birimi başarıyla güncellendi";
        public static string CurrencyTypeListed = "Para birimi operasyonları listelendi.";


        public static string StockClassAdded = "Stok sınıfı başarıyla eklendi";
        public static string StockClassDeleted = "Stok sınıfı başarıyla silindi";
        public static string StockClassUpdated = "Stok sınıfı başarıyla güncellendi";
        public static string StockClassListed = "Stok sınıfı operasyonları listelendi.";


        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductListed = "Ürünler listelendi.";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExist = "Bu isimde bir ürün zaten var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string StockUnitInStockListNotDelete = "Silmek istediğiniz bu stok birimi bir stok listesinde bulunuyor bu sebeple silme işlemi yapamazsınız.";
        
    }
}
