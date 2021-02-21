using DBCorp.Common.Core.Handler;
using DBCorp.Common.Core.Interface;
using DBCorp.Common.Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DBCorp.Common.Core.Implementation
{
    public class Notify : INotify
    {
        private readonly NotifiyHandler _messageHandler;

        public Notify(INotificationHandler<Notifications> notification)
        {
            _messageHandler = (NotifiyHandler)notification;
        }

        public Notify Invoke()
        {
            return this;
        }

        public bool IsValid()
        {
            return !_messageHandler.HasNotifications();
        }

        public void NewNotification(string key, string message)
        {
            _messageHandler.Handle(new Notifications(key, message), default(CancellationToken));
        }
    }
}
