using System;
using System.Collections.Generic;

class PrintItem
{
    public int Index;
    public int Priority; 
    public PrintItem(int key, int val) { Index = key; Priority = val; }
}

class PriorityQueue
{
    private int heapSize;
    List<PrintItem> itemList;

 
    public PriorityQueue()
    {
        heapSize = 0;
        itemList = new List<PrintItem>();
    }

    public void Enqueue(PrintItem PrintItem)
    {  // requires public
        heapSize++;
        itemList.Add(PrintItem);
    }

    void exchange(int i, int j)
    {
        PrintItem temp = itemList[i];

        itemList[i] = itemList[j];
        itemList[j] = temp;
    }

    void heapify(int i)
    {
        int l = 2 * i + 1;
        int r = 2 * i + 2;
        int largest = -1;
       
        if (l < heapSize && (itemList[l].Priority < itemList[i].Priority))
            largest = l;
        else
            largest = i;
        if (r < heapSize && (itemList[r].Priority < itemList[largest].Priority))
            largest = r;
        if (largest != i)
        {
            exchange(i, largest);
            heapify(largest);
        }
    }

   
    public void buildHeap()
    {  
        for (int i = heapSize / 2; i >= 0; i--)
            heapify(i);
    }

    int heapSearch(PrintItem PrintItem)
    {
        for (int i = 0; i < heapSize; i++)
        {
            PrintItem aPrintItem = itemList[i];
            if (PrintItem.Index == aPrintItem.Index)
                return i;
        }
        return -1;
    }

    public int Count
    {
        get { return heapSize; }
    }

    public PrintItem elementAt(int i)
    {
        return itemList[i];
    }

    void heapSort()
    {
        int temp = heapSize;
        buildHeap();

        for (int i = heapSize - 1; i >= 1; i--)
        {
            exchange(0, i);
            heapSize--;
            heapify(0);
        }
        heapSize = temp;
    }

    public PrintItem extractMin()
    {
        if (heapSize < 1)
            return null;

        heapSort();
        exchange(0, heapSize - 1);
        heapSize--;
        return itemList[heapSize];
    }

    public int find(PrintItem PrintItem)
    {
        return heapSearch(PrintItem);
    }
}


public class Test
{
    public static void Main()
    {
        int T = int.Parse(Console.ReadLine());
        while (T-- > 0)
        {
            string[] tokens = Console.ReadLine().Split();
            int n = int.Parse(tokens[0]);
            int m = int.Parse(tokens[1]);
            tokens = Console.ReadLine().Split();
            Queue<PrintItem> queue = new Queue<PrintItem>();
            PriorityQueue priority_queue = new PriorityQueue();

            for (int i = 0; i < n; i++)
            {
                int pr = int.Parse(tokens[i]);
                PrintItem item = new PrintItem(i, pr);
                queue.Enqueue(item);
                priority_queue.Enqueue(item);
            }

            int count = 0;
            PrintItem highPItem = priority_queue.extractMin(); ;
            while (queue.Count > 0)
            {
                PrintItem item = queue.Dequeue();
                if (item.Priority == highPItem.Priority)
                { 
                    count++;
                    if (item.Index == m)
                        break;
                    highPItem = priority_queue.extractMin();
                }
                else
                { 
                    queue.Enqueue(item);
                }
            }
            Console.WriteLine(count);
        }
    }
}

/* Input
3
1 0
5
4 2
1 2 3 4
6 0
1 1 9 1 1 1
*/