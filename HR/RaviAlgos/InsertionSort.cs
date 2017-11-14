namespace RaviAlgos
{
    public class Swapper
    {
        public static void Swap(int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;

        }
    }


    public class InsertionSort
    {
        public InsertionSort()
        {

        }

        public void Sort(int[] inarr)
        {
            for (int i = 0; i < inarr.Length; i++)
            {
                for (int j = i + 1; j < inarr.Length; j++)
                {
                    if (inarr[j] < inarr[i])
                    {
                        Swap(inarr, i, j);
                    }

                }

            }

        }

        private void Swap(int[] inarr, int i, int j)
        {
            var temp = inarr[i];
            inarr[i] = inarr[j];
            inarr[j] = temp;
        }
    }


}
