using Visitor.Infrastructure.Notifications.Visitors;

namespace Visitor.Infrastructure.Notifications;

public class SmsMessage(string from, string to, string content) : IMarketingMessage {
    public string From { get; private set; } = from;

    public string To { get; private set; } = to;

    public string Content { get; private set; } = content;

    public void Accept(INotificationVisitor visitor) {
        visitor.Visit(this);
    }
}