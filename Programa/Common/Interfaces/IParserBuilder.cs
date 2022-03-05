using System;
using Common.Interfaces;

namespace Common.Interfaces
{
    public interface IParserBuilder
    {
        public ISourceParser Build();
    }
}
