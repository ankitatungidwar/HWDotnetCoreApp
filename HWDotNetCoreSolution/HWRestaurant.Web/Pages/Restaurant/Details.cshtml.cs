﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HWRestaurant.Core;
using HWRestaurant.Data;
using Microsoft.Extensions.Configuration;

namespace HWRestaurant.Web.Pages.Restaurant
{
    public class DetailsModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        public HWRestaurant.Core.Restaurant Restaurant { get; set; }
        public string Details { get; set; }

        public DetailsModel(IConfiguration config,IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public ActionResult OnGet(int restaurantId)
        {
            Details = config["Details"];
            /*Restaurant = new HWRestaurant.Core.Restaurant();
            Restaurant.Id = restaurantId;*/
            Restaurant = restaurantData.GetById(restaurantId);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}