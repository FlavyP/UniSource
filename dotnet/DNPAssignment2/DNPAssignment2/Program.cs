using System;
using System.Collections.Generic;
// Delegate types to describe predicates on ints and actions on ints.
public delegate bool IntPredicate(int x);
public delegate void IntAction(int x);
// Integer lists with Act and Filter operations.
// An IntList containing the element 7 9 13 may be constructed as
// new IntList(7, 9, 13) due to the params modifier.
class IntList : List<int>
{
    public IntList(params int[] elements) : base(elements)
    {
    }

    public void Act(IntAction f)
    {
        foreach (int i in this)
        {
            f(i);
        }
    }
    public IntList Filter(IntPredicate p)
    {
        IntList res = new IntList();
        foreach (int i in this)
            if (p(i))
                res.Add(i);
        return res;
    }
}
class Program
{
    public static void Main(String[] args)
    {
        IntList list1 = new IntList(7, 9, 13, 26, 35, 44);

        Console.WriteLine("Printing out all numbers of list: ");
        list1.Act(Console.WriteLine);
        Console.WriteLine();

        Console.WriteLine("Printing out even numbers of list: ");
        list1.Filter(delegate (int x) { return x % 2 == 0; }).Act(Console.WriteLine);
        Console.WriteLine();

        Console.WriteLine("Anonymous method with delegate to print numbers greater than 25: ");
        IntPredicate gt = delegate (int x) {
            return x > 25;
        };
        list1.Filter(gt).Act(Console.WriteLine);
        Console.WriteLine();

        int sum = 0;
        IntAction listSum = delegate (int x)
        {
            Console.WriteLine("Adding {0} to current sum {1}", x, sum);
            sum += x;
            Console.WriteLine("New sum = {0}", sum);
        };
        Console.WriteLine("Anonymous method to sum numbers in the list: ");
        list1.Act(listSum);
        Console.WriteLine();

        Console.ReadKey();
    }
}
