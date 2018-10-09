using System;

namespace Acme.Universe.Terraforming.Directives
{
    public abstract class Directive
    {
        protected Directive(int times)
        {
            if(times < 0)
                throw new ArgumentOutOfRangeException($"Unable to perform the directive {times} times. Must be a non-negative number.", nameof(times));
            Times = times;
        }

        public int Times { get; }
    }
}
