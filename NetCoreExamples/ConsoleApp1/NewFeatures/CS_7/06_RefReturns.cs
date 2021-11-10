namespace NetCoreExamples.NewFeatures.CS_7
{
    using System;
	using NetCoreExamples.RunnableInterfaces;

	public class RefReturns : IRunnableCS_7
    {
        public ref int FindRefInArray(int number, int[] arrayNumber)
        {
            for (int i = 0; i < arrayNumber.Length; i++)
            {

                if (arrayNumber[i] == number)
                {
                    return ref arrayNumber[i];
                }
            }
            throw new IndexOutOfRangeException($"{nameof(number)} not found");
        }

        public int FindInArray(int number, int[] arrayNumber)
        {
            for (int i = 0; i < arrayNumber.Length; i++)
            {

                if (arrayNumber[i] == number)
                {
                    return arrayNumber[i];
                }
            }
            throw new IndexOutOfRangeException($"{nameof(number)} not found");
        }

        public void Run()
        {
            int[] numbers = new int[] { 23, 45, 100, 234, 2500 };
            ref int foundRef = ref FindRefInArray(234, numbers);

            foundRef = 14;
            int foundValue = FindInArray(45, numbers);
            foundValue = 35;
        }
    }
}
