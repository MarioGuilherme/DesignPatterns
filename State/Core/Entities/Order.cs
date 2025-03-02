using State.Core.Enums;

namespace State.Core.Entities;

public class Order(List<Guid> items) {
    public OrderStatus Status { get; set; } = OrderStatus.Started;
    public List<Guid> Items { get; set; } = items;

    public void Add(Guid item) {
        if (this.Status == OrderStatus.Started || this.Status == OrderStatus.Preparing) {
            this.Items.Add(item);
        } else {
            throw new InvalidOperationException("Invalid operation.");
        }
    }

    public void StartPreparing() {
        if (this.Status == OrderStatus.Started) {
            this.Status = OrderStatus.Preparing;
        } else {
            throw new InvalidOperationException("Invalid operation.");
        }
    }

    public void StartDelivery() {
        if (this.Status == OrderStatus.Preparing) {
            this.Status = OrderStatus.OnWayToDeliver;
        } else {
            throw new InvalidOperationException("Invalid operation.");
        }
    }

    public void Complete() {
        if (this.Status == OrderStatus.OnWayToDeliver) {
            this.Status = OrderStatus.Completed;
        } else {
            throw new InvalidOperationException("Invalid operation.");
        }
    }
}