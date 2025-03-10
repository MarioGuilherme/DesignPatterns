﻿using Visitor.Infrastructure.Notifications.Visitors;

namespace Visitor.Infrastructure.Notifications;

public interface IMarketingMessage {
    void Accept(INotificationVisitor visitor);
    string From { get; }
    string To { get; }
    string Content { get; }
}