namespace AutofacACTNARS
{
  using Autofac;
  using Autofac.Features.ResolveAnything;

  public class Foo<T>
  {
  }

  public class Bar1
  {
  }

  public abstract class Bar2
  {
  }

  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = new ContainerBuilder();

      builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

      var container = builder.Build();

      var thisWorks = container.Resolve<Foo<Bar1>>(); // OK, Bar1 is not abstract
      var thisDoesnt = container.Resolve<Foo<Bar2>>(); // Throws, Bar2 is abstract, but there is no code that would use it
    }
  }
}
