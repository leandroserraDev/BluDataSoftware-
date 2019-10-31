[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BluDataSoftware.UII.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BluDataSoftware.UII.App_Start.NinjectWebCommon), "Stop")]

namespace BluDataSoftware.UII.App_Start
{
    using System;
    using System.Web;
    using BluData.Application.Services;
    using BluDataSoftware.Application.Interfaces;
    using BluDataSoftware.Domain.Interfaces.Repositories;
    using BluDataSoftware.Domain.Interfaces.Services;
    using BluDataSoftware.Domain.Services;
    using BluDataSoftware.InfraStructure.Repositories;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IEmpresaRepository>().To<EmpresaRepository>();
            kernel.Bind<IFornecedorFisicoRepository>().To<FornecedorFisicoRepository>();
            kernel.Bind<IFornecedorJuridicoRepository>().To<FornecedorJuridicoRepository>();

            kernel.Bind<IServiceEmpresa>().To<ServiceEmpresa>();
            kernel.Bind<IServiceFornecedorFisico>().To<ServiceFornecedorFisico>();
            kernel.Bind<IServiceFornecedorJuridico>().To<ServiceFornecedorJuridico>();


            kernel.Bind<IAppEmpresa>().To<AppEmpresa>();
            kernel.Bind<IAppFisico>().To<AppFisico>();
            kernel.Bind<IAppJuridico>().To<AppJuridico>();
        }        
    }
}
