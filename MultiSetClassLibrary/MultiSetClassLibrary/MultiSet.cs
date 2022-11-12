using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MultiSetClassLibrary
{
    public class MultiSet<T> : IMultiSet<T>
    {
        private Dictionary<T, int> mset = new Dictionary<T, int>();

        public override string ToString()
        {
            StringBuilder wynik = new StringBuilder("{");
            foreach (var x in mset)
            {
                wynik.Append($"{x.Key}:{x.Value}, ");
            }
            if (mset.Count == 0)
                return "Multiset is empty";
            return wynik.ToString(0, wynik.Length - 2) + "}";
        }

        public IMultiSet<T> Add(T item, int numberOfItems = 1)
        {
            if (mset.ContainsKey(item))
                mset[item] += numberOfItems;
            else
                mset.Add(item, 1);
            return this;
        }

        public void Add(T item) => this.Add(item, 1);

        public int Count => mset.Values.Sum();
        public bool IsEmpty => mset.Count == 0;
        public bool IsReadOnly => false;

        public IEqualityComparer<T> Comparer => throw new NotImplementedException();

        public void Clear() => mset.Clear();

        public bool Contains(T item) => mset.ContainsKey(item);

        public static MultiSet<T> Empty => new MultiSet<T>();

        public static bool IsMultiSetReadonly(MultiSet<T> ms) => ms.IsReadOnly == true ? throw new NotSupportedException() : false;

        public MultiSet()
        { }

        public MultiSet(IEnumerable<T> sequence)
        {
            foreach (var el in sequence)
            {
                this.Add(el);
            }
        }

        public IMultiSet<T> Remove(T item, int numberOfItems = 1)
        {
            IsMultiSetReadonly(this);
            if (mset[item] < numberOfItems)
                numberOfItems = mset[item];
            if (mset.ContainsKey(item))
            {
                for (int i = 0; i < numberOfItems; i++)
                    this.Remove(item);
            }
            return this;
        }

        public bool Remove(T item)
        {
            IsMultiSetReadonly(this);
            if (!mset.ContainsKey(item))
                return false;
            if (mset[item] > 1)
            {
                mset[item]--;
                return true;
            }
            else
            {
                mset.Remove(item);
                return true;
            }
        }

        public IMultiSet<T> RemoveAll(T item)
        {
            IsMultiSetReadonly(this);
            if (mset.ContainsKey(item))
                mset.Remove(item);
            return this;
        }

        public int this[T item] => mset[item];

        public IReadOnlyDictionary<T, int> AsDictionary() => mset;

        public IReadOnlySet<T> AsSet() => throw new ArgumentNullException();

        public void CopyTo(T[] array, int arrayIndex)
        {
            List<T> tempList = new List<T>();
            foreach (var x in this)
            {
                tempList.Add(x);
            }
            tempList.CopyTo(array, arrayIndex);
        }

        public IMultiSet<T> ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();
            IsMultiSetReadonly(this);
            foreach (var otherEl in other)
            {
                if (!mset.ContainsKey(otherEl))
                    continue;
                RemoveAll(otherEl);
            }
            return this;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var (item, multiplicity) in mset)
            {
                for (int i = 0; i < multiplicity; i++)
                    yield return item;
            }
        }

        private void NotNullReturnsList(IEnumerable<T> other, out List<T> tempList)
        {
            if (other == null)
                throw new ArgumentNullException();
            tempList = new List<T>(other);
        }

        public IMultiSet<T> IntersectWith(IEnumerable<T> other)
        {
            IsMultiSetReadonly(this);
            NotNullReturnsList(other, out List<T> tempList);
            foreach (var el in mset)
            {
                if (tempList.Contains(el.Key))
                    continue;
                RemoveAll(el.Key);
            }
            foreach (var el in mset.ToList())
            {
                mset[el.Key] = 1;
            }
            return this;
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            NotNullReturnsList(other, out List<T> tempList);
            if (IsSubsetOf(other) && tempList.Count > this.Count)
                return true;
            return false;
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            NotNullReturnsList(other, out List<T> tempList);
            if (IsSupersetOf(other) && this.Count > tempList.Count)
                return true;
            return false;
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            NotNullReturnsList(other, out List<T> tempList);
            foreach (var el in mset)
            {
                if (!tempList.Contains(el.Key))
                    return false;
            }
            return true;
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            NotNullReturnsList(other, out List<T> tempList);
            foreach (var el in tempList)
            {
                if (!mset.ContainsKey(el))
                    return false;
            }
            return true;
        }

        public bool MultiSetEquals(IEnumerable<T> other)
        {
            NotNullReturnsList(other, out List<T> tempList);
            var groupedList = tempList.GroupBy(el => el);
            foreach (var el in groupedList)
            {
                if (!mset.ContainsKey(el.Key))
                    return false;
                if (mset[el.Key] != el.Count())
                    return false;
            }
            return !IsProperSubsetOf(other) && !IsProperSupersetOf(other);
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();
            foreach (var el in other)
            {
                if (mset.ContainsKey(el))
                    return true;
            }
            return false;
        }

        public IMultiSet<T> SymmetricExceptWith(IEnumerable<T> other)
        {
            IsMultiSetReadonly(this);
            NotNullReturnsList(other, out List<T> tempList);
            foreach (var el in mset)
            {
                if (tempList.Contains(el.Key))
                {
                    RemoveAll(el.Key);
                    tempList.Remove(el.Key);
                }
            }
            this.UnionWith(tempList);
            return this;
        }

        public IMultiSet<T> UnionWith(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();
            IsMultiSetReadonly(this);
            foreach (var el in other)
                this.Add(el);
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}