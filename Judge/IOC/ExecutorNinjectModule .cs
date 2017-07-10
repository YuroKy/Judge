using Ninject.Modules;


namespace Judge.IOC
{
    class ExecutorNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IExecutor>().To<Executor>();

        }
    }
}
