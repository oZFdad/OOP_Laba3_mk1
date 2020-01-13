using StorageForPainDLL;

namespace OOP_Laba6_mk1
{
    public class ShapeFlagObserver : IFlagObserver
    {
        private readonly Shape _shape;

        public ShapeFlagObserver(Shape shape)
        {
            _shape = shape;
        }
        
        public void Update(bool flag)
        {
            _shape.Flag = flag;
        }
    }
}