using System;
using UGF.Instance.Runtime;
using UGF.Instance.Runtime.Collections;

namespace UGF.Data.Runtime
{
    public class DataEnvironment : InstanceCollectionGuid<IData>
    {
        public DataEnvironment(IInstanceIdentifierGenerator<Guid> generator = null) : base(generator)
        {
        }

        protected override Guid OnGenerateIdentifier()
        {
            return base.OnGenerateIdentifier();
        }

        public override Guid Add(IData instance)
        {
            return base.Add(instance);
        }

        public override bool Remove(Guid identifier)
        {
            return base.Remove(identifier);
        }
    }
}