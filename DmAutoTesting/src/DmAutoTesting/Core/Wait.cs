using System;
using System.Threading;

namespace DmAutoTesting.Core
{
    public static class Wait
    {
        public static void For(Func<bool> waitFunc, int timeout = 5000, string timeoutMessage = "Timeout exception")
        {
            For(waitFunc, () => timeoutMessage, timeout);
        }

        public static void For(Func<bool> waitFunc, Func<string> errorMessageFunc, int timeout = 5000)
        {
            if (!SpinWait.SpinUntil(waitFunc, timeout))
            {
                throw new TimeoutException(errorMessageFunc());
            }
        }
        public static void UntilEquals<T>(T expected, Func<T> actual, int timeout = 5000)
        {
            For(() => expected.Equals(actual()), timeout, $"Value has never changed to \"{expected}\"");
        }
        public static void UntilChanged<T>(T oldValue, Func<T> getNewValue, int timeout = 5000)
        {
            For(() => !oldValue.Equals(getNewValue()), timeout, $"Value \"{oldValue}\" never changed");
        }
        public static void BecomeFalse(Func<bool> waitFunc, string errorMessage, int timeout = 5000)
        {
            For(() => !waitFunc(), timeout, errorMessage);
        }
    }
}