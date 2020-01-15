namespace StorageForPainDLL
{
    public interface IShapeChangeObserver
    {
        bool Update(int dx, int dy, int width, int height);
    }
}