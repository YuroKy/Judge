using Judge.Checkers;
using Ninject.Modules;

namespace Judge.IOC
{
    class CheckerNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IChecker>().To<StringChecker>();
        }
    }
}
