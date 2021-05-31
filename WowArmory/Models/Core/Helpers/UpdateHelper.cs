using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Factory;

namespace WowArmory.Models.Core.Helpers
{
    public static class UpdateHelper
    {
        public static void AddToView(this Controller controller, PageHelper helper)
        {
            controller.ViewBag.Start = helper.Start;
            controller.ViewBag.End = helper.End;

            controller.ViewBag.Page = helper.Page;
            controller.ViewBag.Pages = helper.Pages;
            controller.ViewBag.NumberOfItems = helper.NumberOfItems;
        }
    }
}
