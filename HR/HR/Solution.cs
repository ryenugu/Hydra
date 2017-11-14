using System;
using System.Linq;
class Test
{
    static void Main()
    {
        Console.WriteLine(new Test().makeArrayConsecutive2(new int[] { 6, 2, 3, 8 }));
    }


    int makeArrayConsecutive2(int[] statues)
    {
        var count = 0;
        Random rnd = new Random();
        var x = Enumerable.Range(statues.Min(), statues.Max()).ToList();
        foreach (var xx in x)
        {
            if (!statues.Contains(xx))
            {
                count++;
                Console.WriteLine(xx);
            }
        }
        return count;


    }




}
