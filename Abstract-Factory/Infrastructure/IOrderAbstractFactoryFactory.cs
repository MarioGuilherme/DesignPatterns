namespace AbstractFactory.Infrastructure;

public interface IOrderAbstractFactoryFactory {
    IOrderAbstractFactory GetAbstractFactory(bool isInternational);
}

public class OrderAbstractFactoryFactory(
    InternationalOrderAbstractFactory internationalOrderAbstractFactory,
    NationalOrderAbstractFactory nationalOrderAbstractFactory
) : IOrderAbstractFactoryFactory {
    public IOrderAbstractFactory GetAbstractFactory(bool isInternational) =>
        isInternational ? internationalOrderAbstractFactory : nationalOrderAbstractFactory;
}