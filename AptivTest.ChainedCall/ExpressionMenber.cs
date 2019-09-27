using System;

namespace AptivTest.ChainedCall
{
    class ExpressionMenber<T>:IExpressionMenber<T>
    {
        private readonly T t;

        public ExpressionMenber(T t)
        {
            this.t = t;
        }

        public IExpressionMenber<T> Print(Func<T, object> p)
        {
            Console.WriteLine(p(t));
            return this;
        }
    }
}
