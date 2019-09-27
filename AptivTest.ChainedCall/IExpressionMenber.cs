using System;

namespace AptivTest.ChainedCall
{
    interface IExpressionMenber<T>
    {
        IExpressionMenber<T> Print(Func<T, object> p);
    }
}
