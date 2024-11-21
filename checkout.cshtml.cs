using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace SellKoiWeb.Pages
{
    public class CheckoutModel : PageModel
    {
        // ??c t? thu?c t�nh ?? bind d? li?u t? form
        [BindProperty]
        public string FishId { get; set; }

        [BindProperty]
        public string BuyerName { get; set; }

        [BindProperty]
        public string BuyerEmail { get; set; }

        [BindProperty]
        public string Address { get; set; }

        // Bi?n ?? l?u th�ng b�o th�nh c�ng
        public string SuccessMessage { get; set; }

        // D? li?u m?u cho danh s�ch c� Koi (c� th? thay th? b?ng d? li?u th?c t? t? c? s? d? li?u)
        public List<dynamic> KoiFishList { get; set; }

        // Bi?n ?? l?u th�ng tin c� ???c ch?n
        public dynamic SelectedFish { get; set; }

        public void OnGet()
        {
            // D? li?u m?u danh s�ch c� Koi
            KoiFishList = new List<dynamic>
            {
                new { Id = "001", Name = "C� 001", Price = "5,000,000 VND", Rating = "9/10", Image = "/images/images (2).jpg" },
                new { Id = "002", Name = "C� 002", Price = "5,250,000 VND", Rating = "9.5/10", Image = "/images/koi3.jpg" },
                new { Id = "003", Name = "C� 003", Price = "5,500,000 VND", Rating = "9.5/10", Image = "/images/Untitled.jpg" },
                new { Id = "004", Name = "C� 004", Price = "5,750,000 VND", Rating = "9/10", Image = "/images/koi3.jpg" },
                new { Id = "005", Name = "C� 005", Price = "6,000,000 VND", Rating = "8.5/10", Image = "/images/koi5.jpg" },
                new { Id = "020", Name = "C� 020", Price = "10,000,000 VND", Rating = "10/10", Image = "/images/koi2.jpg" }
            };

            // L?y fish_id t? query string ?? t�m th�ng tin c� ???c ch?n
            string fishId = Request.Query["fish_id"];
            SelectedFish = KoiFishList.FirstOrDefault(fish => fish.Id == fishId);
        }

        // X? l� khi ng??i d�ng g?i form thanh to�n
        public IActionResult OnPost()
        {
            // Ki?m tra c�c tr??ng th�ng tin nh?p v�o
            if (string.IsNullOrEmpty(FishId) || string.IsNullOrEmpty(BuyerName) || string.IsNullOrEmpty(BuyerEmail) || string.IsNullOrEmpty(Address))
            {
                TempData["ErrorMessage"] = "Vui l�ng ?i?n ??y ?? th�ng tin!";
                return RedirectToPage(); // Tr? l?i trang Checkout n?u c� l?i
            }

            // X? l� logic thanh to�n ho?c l?u th�ng tin v�o c? s? d? li?u (n?u c�)
            TempData["SuccessMessage"] = "??t h�ng th�nh c�ng!"; // L?u th�ng b�o th�nh c�ng v�o TempData
            return RedirectToPage("Success"); // Chuy?n h??ng t?i trang th�nh c�ng
            
            return RedirectToPage("/");
        }
    }
}
