using Visitor.Infrastructure.Notifications.Visitors;

namespace Visitor.Infrastructure.Notifications;

public class NotificationService {
    public void Notify(List<IMarketingMessage> messages) {
        INotificationVisitor visitor = new NotificationVisitor(); // Obtido via DI

        foreach (IMarketingMessage message in messages)
            message.Accept(visitor);
    }
}