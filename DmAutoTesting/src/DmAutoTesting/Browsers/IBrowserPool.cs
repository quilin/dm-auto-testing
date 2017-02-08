namespace DmAutoTesting.Browsers
{
    public interface IBrowserPool
    {
        IBrowser Get();
        void Release(IBrowser browser);
        void RemoveFromPool(IBrowser browser);
    }
}