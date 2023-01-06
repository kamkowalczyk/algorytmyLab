using System;
using System.Collections;
using System.Collections.Generic;



    public class Heap<T> : IEnumerable<T> where T : IComparable<T>
    {
        private List<T> list;
       
        public HeapOptions Option { get; }

        public int Count => list.Count;

        // tworzy pusty kopiec dla określonego porządku
        public Heap(HeapOptions option = HeapOptions.MinHeap)
        {
            Option = option;
            list = new List<T>();
        }

        public Heap(IEnumerable<T> collection, HeapOptions option = HeapOptions.MinHeap)
        {
            Option = option;
            list = new List<T>();
            foreach (var element in collection)
            {
                Insert(element);
            }
        }

        public void Insert(T x)
        {
            list.Add(x);
            var xIndex = list.Count - 1;
            var parentIndex = Convert.ToInt32(Math.Floor((double)(xIndex - 1) / 2));
            while (parentIndex >= 0 && list[parentIndex].CompareTo(x) == (int)Option)
            {
                var rememberedValue = list[parentIndex];
                list[parentIndex] = x;
                list[xIndex] = rememberedValue;
                xIndex = parentIndex;
                parentIndex = Convert.ToInt32(Math.Floor((double)(xIndex - 1) / 2));
            }
        }

        public T Delete()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException();
            }
            var deletedElement = list[0];
            var elementToMove = list[list.Count - 1];
            list[0] = elementToMove;
            var elementToMoveIndex = 0;
            list.RemoveAt(list.Count - 1);
            var firstChildrenIndex = 2 * elementToMoveIndex + 1;
            var secondChildrenIndex = 2 * elementToMoveIndex + 2;
            while (list[firstChildrenIndex].CompareTo(elementToMove) == (int)Option || list[secondChildrenIndex].CompareTo(elementToMove) == (int)Option)
            {
                if (list[firstChildrenIndex].CompareTo(elementToMove) == (int)Option &&
                    list[secondChildrenIndex].CompareTo(elementToMove) == (int)Option)
                {
                    if (list[firstChildrenIndex].CompareTo(list[secondChildrenIndex]) == (int)Option)
                    {
                        SwitchElements(elementToMove, elementToMoveIndex, list[firstChildrenIndex], firstChildrenIndex);
                        elementToMoveIndex = firstChildrenIndex;
                    }
                    else
                    {
                        SwitchElements(elementToMove, elementToMoveIndex, list[secondChildrenIndex], secondChildrenIndex);
                        elementToMoveIndex = secondChildrenIndex;
                    }
                }
                else if (list[firstChildrenIndex].CompareTo(elementToMove) == (int)Option)
                {
                    SwitchElements(elementToMove, elementToMoveIndex, list[firstChildrenIndex], firstChildrenIndex);
                    elementToMoveIndex = firstChildrenIndex;
                }
                else if (list[secondChildrenIndex].CompareTo(elementToMove) == (int)Option)
                {
                    SwitchElements(elementToMove, elementToMoveIndex, list[secondChildrenIndex], secondChildrenIndex);
                    elementToMoveIndex = secondChildrenIndex;
                }
                firstChildrenIndex = 2 * elementToMoveIndex + 1;
                secondChildrenIndex = 2 * elementToMoveIndex + 2;
            }

            return deletedElement;
        }

        private void SwitchElements(T fistElement, int firstElementIndex, T secondElement, int secondElementIndex)
        {
            var rememberedElement = fistElement;
            list[firstElementIndex] = secondElement;
            list[secondElementIndex] = rememberedElement;
        }

        public T Top() => list.Count == 0 ? throw new InvalidOperationException() : list[0];

        public void Clear() => list.Clear();

        public T[] ToArray() => list.ToArray();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in list)
            {
                yield return element;
            }
        }
    }
