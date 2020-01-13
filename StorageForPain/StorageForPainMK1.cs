using System;
using System.IO;
using System.Threading;

namespace StorageForPainDLL
{
    public class Storage
    {
        Shape[] _box;
        int _maxSize, lenght = 0;

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
        }

        public int GetMaxIdex()
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

        public void SaveToFile(string fileName)
        {
            using (var writer = new StreamWriter(fileName, false))
            {
                writer.WriteLine(lenght);
                for (var i = 0; i < lenght; i++)
                {
                    _box[i].Save(writer);
                }
            }
        }
    }
}