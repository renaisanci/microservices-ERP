﻿using DBCorp.Common.Core.Handler;
using DBCorp.Common.Core.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace DBCorp.CRM.API.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        private readonly NotifiyHandler _messageHandler;

        protected BaseController(INotificationHandler<Notifications> notification)
        {
            _messageHandler = (NotifiyHandler)notification;
        }

        protected IActionResult CreatedHasNotification(string route, object result = null)
        {
            if (!HasNotifications())
            {
                if (result != null)
                    return Created(route, new
                    {
                        success = true,
                        data = result
                    });

                return Created(route, new
                {
                    success = true
                });
            }

            return NoticationsEntity();
        }

        protected bool HasNotifications()
        {
            return _messageHandler.HasNotifications();
        }

        protected IActionResult NoticationsEntity()
        {
            var notifications =
                _messageHandler.GetNotifications();

            if (notifications.Any())
            {
                return BadRequest(new ApiResponse(HttpStatusCode.BadRequest.ToString(), notifications.ToList()));
            }

            return BadRequest(new ApiResponse(HttpStatusCode.BadRequest.ToString(), notifications.ToList()));
        }
    }
}
