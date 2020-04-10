namespace Pilkarze_MVVM
{
    class ModelUtils
    {
        public static int[] wiek()
        {
            int[] wiek = new int[41];
            int i = 15;
            for (int j = 0; j <= 40; j++)
            {
                wiek[j] = i;
                i++;
            }
            return wiek;
        }
    }
}
