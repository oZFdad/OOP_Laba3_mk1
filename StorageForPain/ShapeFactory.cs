using System;

namespace StorageForPainDLL
{
    public static class ShapeFactory
    {
        public static Shape Create(string name)
        {
            switch (name.ToLower())
            {
                case "triangle":
                    return new Triangle(0, 0, 0);
                case "square":
                    return new Square(0, 0, 0);
                case "circle":
                    return new Circle(0, 0, 0);
                case "group":
                    return new Group(0, 0, 0);
                default:
                    throw new ArgumentException($"Неизвестный тип объекта {name}", nameof(name));
            }
        }
    }
}