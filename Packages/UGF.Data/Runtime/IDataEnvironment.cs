using System;
using UGF.Instance.Runtime;

namespace UGF.Data.Runtime
{
    public interface IDataEnvironment : IInstanceCollection<Guid, IData>
    {
    }
}