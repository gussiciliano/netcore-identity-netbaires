using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using netcore_identity_netbaires.Models;

namespace netcore_identity_netbaires.Controllers
{
    [Route("authorization")]
    public class AuthorizationDemoController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("admin")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminOnly()
        {
            ViewData["Title"] = "Admins";
            ViewData["Message"] = "Sólo administradores pueden ver esta página";
            ViewData["Image"] = "https://vignette.wikia.nocookie.net/creepypasta/images/4/4c/Name-tag-admin-1000.png";
            return View("AccessPage");
        }

        [Route("user")]
        [Authorize]
        public IActionResult RegisteredUserOnly()
        {
            ViewData["Title"] = "Usuarios";
            ViewData["Message"] = "Sólo usuarios registrados pueden ver esta página";
            ViewData["Image"] = "https://openclipart.org/download/211821/matt-icons_preferences-desktop-personal.svg";
            return View("AccessPage");
        }

        [Route("everyone")]
        public IActionResult Everyone()
        {
            ViewData["Title"] = "Todos";
            ViewData["Message"] = "Todos  pueden ver esta página";
            ViewData["Image"] = "http://www.clker.com/cliparts/i/B/G/z/w/B/everyone-the-same-all-unique.svg";
            return View("AccessPage");
        }

        [Route("atleast21")]
        [Authorize(Policy = "AtLeast21")]
        public IActionResult AtLeast21()
        {
            ViewData["Title"] = "Mayores de 21";
            ViewData["Message"] = "Mayores de 21 pueden ver esta página";
            ViewData["Image"] = "https://openclipart.org/download/211821/matt-icons_preferences-desktop-personal.svg";
            return View("AccessPage");
        }
    }
}
