using System;

namespace Acme.MarsColonizer.Directives
{
    public abstract class Directive
    {
        protected Directive(int times)
        {
            if(times < 0)
                throw new ArgumentOutOfRangeException($"Unable to perform an action {times} times", nameof(times));
            Times = times;
        }

        public int Times { get; }
    }
}
