using Builder.Infrastructure.Payments.Models;

namespace Builder.Infrastructure.Payments;

public class PaymentSlipService : IPaymentService {
    public object Process() {
        // As infos poderiam vir por parâmetros
        //PaymentSlipModel paymentSlip = new(
        //    "12312.23214521-1.232152131", "12324124", DateTime.Now, DateTime.Now.AddDays(3), 1234.0m,
        //    new Payer("Pagador", "123.567.899-10", "Rua do Pagador"),
        //    new Receiver("Recebedor", "987.654.321-01", "Rua do Recebedor")
        //);

        PaymentSlipBuilder builder = new();

        PaymentSlipModel paymentSlipWithBuilder = builder
            .Start()
            .WithPayer(new Payer("Pagador", "123.567.899-10", "Rua do Pagador"))
            .WithReceiver(new Receiver("Recebedor", "987.654.321-01", "Rua do Recebedor"))
            .WithPaymentDocument("12312.23214521-1.232152131", "12324124", 1234.0m)
            .WithDates(DateTime.Now, DateTime.Now.AddDays(3))
            .Build();

        return "Dados do Boleto";
    }
}