using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Security.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Security.Controllers
{
    public class CalculateController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "作業一";
            return View();
        }

        public IActionResult Calculate(string textAreaNumber)
        {
            CalculateModel model = new CalculateModel();

            if (string.IsNullOrEmpty(textAreaNumber))   //沒有輸入
            {
                model.Message = "請輸入數字";
                return Json(model);
            }
            
            textAreaNumber = textAreaNumber.Trim();
            var stringArray = textAreaNumber.Split( new char[0] , StringSplitOptions.RemoveEmptyEntries );  //切空白
            double[] inputNumbers = new double[stringArray.Length];
            
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                Console.WriteLine(stringArray[i]);
                if (!Double.TryParse(stringArray[i] , out inputNumbers[i])) //轉成Double
                {
                    model.Message = "錯誤，請輸入實數"; //不符合格式
                    return Json(model);
                }
            }

            model.Add(inputNumbers);    //加入Model

            return Json(model);
        }
    }
}
