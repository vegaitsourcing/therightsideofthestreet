using PravaStranaUlice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PravaStranaUlice.Web.ViewModels
{
    public class HeaderViewModel
    {
        public HeaderViewModel(Settings settings, Home home)
        {
            Settings = settings;
            HomeUrl = home.Url;
        }

        public Settings Settings { get; }
        public string HomeUrl { get; }
    }
}