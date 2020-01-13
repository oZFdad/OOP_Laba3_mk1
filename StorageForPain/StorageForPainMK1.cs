using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace StorageForPainDLL
{
    public class Storage
    {
        Shape[] _box;
        int _maxSize, lenght = 0;

        private readonly List<IStorageObserver> _storageObservers = new List<IStorageObserver>();

        public Storage()
        {
            _maxSize = 10;
            _box = new Shape[_maxSize + 1];
        }

        public Storage(int maxSize)
        {
            _maxSize = maxSize;
            _box = new Shape[_maxSize + 1];
        }

        private bool CheckSpace() 
        {
            if (lenght < _maxSize)
            {
                return true;
            }
            return false;
        }

        private void AddSpace()
        {
            Shape[] _bufer = new Shape[_maxSize * 2 + 1];
            for(int i = 0; i < _maxSize; i++)
            {
                _bufer[i] = _box[i];
            }
            _box = _bufer;
            _maxSize = _maxSize * 2;
        }

        public void AddItem (Shape item)
        {
            if (!CheckSpace()) 
            {
                AddSpace();
            }
            _box[lenght] = item;
            lenght++;

            CallStorageObservers();
        }

        public void DeleteItem (int index)
        {
            if (lenght > 0)
            {
                if (index <= lenght)
                {
                    for (int i = index - 1; i < lenght - 1; i++)
                    {
                        _box[i] = _box[i + 1];
                    }
                    lenght--;
                    Array.Clear(_box, lenght, 1);
                    
                    CallStorageObservers();
                }
            }
            else
            {
                Console.WriteLine("В хранилище больше нет фигур");
            }
        }

        public void DeleteItem()
        {
            if (lenght > 0)
            {
                lenght--;
                Array.Clear(_box, lenght, 1);
                
                CallStorageObservers();
            }
            else
            {
                Console.WriteLine("В хранилище больше нет фигур");
            }
        }

        public void DeleteAll()
        {
            Array.Clear(_box, 0, lenght);
            lenght = 0;
            
            CallStorageObservers();
        }

        public int GetMaxIndex()
        {
            return lenght;
        }

        public Shape GetItem(int index)
        {
            return _box[index-1];
        }

        public Shape GetItem()
        {
            return _box[lenght-1];
        }

        public void Save(StreamWriter writer, int spacing)
        {
            writer.Write(new string(' ', spacing));
            writer.WriteLine($"Count {lenght}"); // "Count " + length
            for (var i = 0; i < lenght; i++)
            {
                _box[i].Save(writer, spacing);
            }
        }

        public void SaveToFile(string fileName)
        {
            var writer = new StreamWriter(fileName, false);
            Save(writer, 0);
            writer.Dispose();
        }

        public void Load(StreamReader reader)
        {
            var count = reader.ReadLine();
            if (count == null) throw new FormatException("Пустая строка");

            var parts = count.Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            var intCount = int.Parse(parts[1]);

            DeleteAll();

            for (var i = 0; i < intCount; i++)
            {
                var shapeLine = reader.ReadLine();
                if (shapeLine == null) throw new FormatException("Пустая строка");

                var shapeParts = shapeLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var shape = ShapeFactory.Create(shapeParts[0]);

                shape.Load(shapeLine, reader);

                AddItem(shape);
            }
            
            CallStorageObservers();
        }

        public void LoadFromFile(string fileName)
        {
            var reader = new StreamReader(fileName);
            Load(reader);
            reader.Dispose();
        }

        public void CallStorageObservers()
        {
            foreach (var observer in _storageObservers)
            {
                observer.Update(this);
            }
        }

        public void AddStorageObserver(IStorageObserver observer)
        {
            _storageObservers.Add(observer);
        }
    }
}