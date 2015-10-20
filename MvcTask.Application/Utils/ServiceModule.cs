namespace MvcTask.Application.Utils
{
    using MvcTask.Domain.Abstract.UnitOfWork;
    using MvcTask.Infrastructure.Concrete.UnitOfWork;
    using MvcTask.Infrastructure.Context.Abstract;
    using MvcTask.Infrastructure.Context.Concrete;

    using Ninject.Modules;

    public class ServiceModule : NinjectModule
    {
        private readonly string connectionString;
        public ServiceModule(string connection)
        {
            this.connectionString = connection;
        }
        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<EfUnitOfWork>().WithConstructorArgument(this.connectionString);
            this.Bind<IContext>().To<EfContext>().WithConstructorArgument(this.connectionString);
        }
    }
}
