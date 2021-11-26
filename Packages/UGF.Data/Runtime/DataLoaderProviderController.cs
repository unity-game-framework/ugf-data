using System;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Data.Runtime
{
    public class DataLoaderProviderController : ControllerDescribed<DataLoaderProviderControllerDescription>
    {
        public IProvider<string, IDataLoader> Provider { get; }
        public IContext Context { get; }

        public DataLoaderProviderController(DataLoaderProviderControllerDescription description, IApplication application) : this(description, application, new Provider<string, IDataLoader>(), new Context { application })
        {
        }

        public DataLoaderProviderController(DataLoaderProviderControllerDescription description, IApplication application, IProvider<string, IDataLoader> provider, IContext context) : base(description, application)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach ((string key, IBuilder<IApplication, IDataLoader> value) in Description.Loaders)
            {
                IDataLoader loader = value.Build(Application);

                Provider.Add(key, loader);
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            Provider.Clear();
        }
    }
}
