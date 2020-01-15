namespace StorageForPainDLL
{
    public interface IMoveObserver
    {
        void Update(Shape shape, int dx, int dy, int dr);
    }
}