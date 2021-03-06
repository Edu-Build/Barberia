﻿using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class UsersController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerUsers user;


        public UsersController()
        {
            /*Instanciando el objeto dentro del contructor*/
            user = new ManagerUsers();
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult UserList()
        {

            return Json(new { data = user.allUsers() }, JsonRequestBehavior.AllowGet);

        }

        /*Action JsonResult que con un condional Case evaluara que metodo se ejecutara dependiendo de la Peticion del cliente*/
        public JsonResult Users(string id, UsersModel item)
        {
            switch (Request.HttpMethod)
            {
                case "PUT":
                    return Json(user.updateUser(item));
                case "GET":
                    return Json(user.returnUser(id.ToString()), JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(user.deleteUser(id.ToString()));
            }

            return Json(new { Error = true, Message = "Operacion HTTP desconocida" });
        }
    }
}