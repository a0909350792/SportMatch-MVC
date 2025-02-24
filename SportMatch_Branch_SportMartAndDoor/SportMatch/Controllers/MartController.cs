using Microsoft.AspNetCore.Mvc;

namespace SportMatch.Controllers
{
    public class MartController : Controller
    {
        public class Product
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public int Discount { get; set; }
            public string Image { get; set; }
        }

        public class Category
        {
            public int CategoryID { get; set; }
            public string ParentCategory { get; set; }
            public string ChildCategory1 { get; set; }
            public string ChildCategory2 { get; set; }
            public string ChildCategoryID1 { get; set; }
            public string ChildCategoryID2 { get; set; }
        }

        public IActionResult Mart()
        {
            var _Products = new List<Product>
            {
                new Product { Name = "商品 1", Price = 199, Discount = -20, Image = "/image/icon.jpg" },
                new Product { Name = "商品 2", Price = 299, Discount = -10, Image = "/image/icon.jpg" },
                new Product { Name = "商品 3", Price = 399, Discount = -5, Image = "/image/icon.jpg" },
                new Product { Name = "商品 4", Price = 499, Discount = 0, Image = "/image/icon.jpg" },
                new Product { Name = "商品 5", Price = 199, Discount = -20, Image = "/image/icon.jpg" },
                new Product { Name = "商品 6", Price = 299, Discount = -10, Image = "/image/icon.jpg" },
                new Product { Name = "商品 7", Price = 399, Discount = -5, Image = "/image/icon.jpg" },
                new Product { Name = "商品 8", Price = 499, Discount = 0, Image = "/image/icon.jpg" }
            };
            ViewBag.ForProducts = _Products;

            var _Category = new List<Category>
            {
                new Category { CategoryID = 1, ParentCategory = "父分類 1", ChildCategoryID1 = "ChildCategory1", ChildCategoryID2 = "ChildCategory2", ChildCategory1 = "子分類1", ChildCategory2 = "子分類2" },
                new Category { CategoryID = 2, ParentCategory = "父分類 2", ChildCategoryID1 = "ChildCategory3", ChildCategoryID2 = "ChildCategory4", ChildCategory1 = "子分類3", ChildCategory2 = "子分類4" }
            };
            ViewBag.ForCategory = _Category;

            return View();
        }

        public IActionResult Checkout()
        {
            var _Products = new List<Product>
            {
                new Product { Name = "商品 1", Price = 199, Discount = -20, Image = "/image/icon.jpg" },
                new Product { Name = "商品 2", Price = 299, Discount = -10, Image = "/image/icon.jpg" },
                new Product { Name = "商品 3", Price = 399, Discount = -5, Image = "/image/icon.jpg" },
                new Product { Name = "商品 4", Price = 499, Discount = 0, Image = "/image/icon.jpg" },
            };
            ViewBag.ForProducts = _Products;

            return View();
        }

        public IActionResult Bill()
        {
            var _Products = new List<Product>
            {
                new Product { Name = "商品 1", Price = 199, Discount = -20, Image = "/image/icon.jpg" },
                new Product { Name = "商品 2", Price = 299, Discount = -10, Image = "/image/icon.jpg" },
                new Product { Name = "商品 3", Price = 399, Discount = -5, Image = "/image/icon.jpg" },
                new Product { Name = "商品 4", Price = 499, Discount = 0, Image = "/image/icon.jpg" },
            };
            ViewBag.ForProducts = _Products;

            return View();
        }
    }
}
