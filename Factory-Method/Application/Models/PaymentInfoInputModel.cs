using FactoryMethod.Core.Enums;

namespace FactoryMethod.Application.Models;

public class PaymentInfoInputModel {
    public PaymentMethod PaymentMethod { get; set; }
    public string CardNumber { get; set; }
    public string FullName { get; set; }
    public string ExpirationDate { get; set; }
    public string Cvv { get; set; }
}