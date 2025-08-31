
public static class Arrays

{

    /// <summary>

    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'. For 

    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}. Assume that length is a positive

    /// integer greater than 0.

    /// </summary>

    /// <returns>array of doubles that are the multiples of the supplied number</returns>

    public static double[] MultiplesOf(double number, int length)

    {

        // TODO Problem 1 Start

        // Remember: Using comments in your program, write down your process for solving this problem

        // step by step before you write the code. The plan should be clear enough that it could

        // be implemented by another person.



        // Plan:

        // 1. Create a new double array of the specified length.

        // 2. Loop from 0 to length - 1.

        // 3. For each iteration 'i', calculate the multiple as number * (i + 1).

        // 4. Assign the calculated multiple to the current index of the array.

        // 5. Return the completed array.



        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)

        {

            multiples[i] = number * (i + 1);

        }

        return multiples;

    }



}

   public static class Arrays

{

    // ... MultiplesOf method



    /// <summary>

    /// Rotate the 'data' to the right by the 'amount'. For example, if the data is 

    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 

    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}. The value of amount will be in the range of 1 to data.Count, inclusive.

    ///

    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.

    /// </summary>

    public static void RotateListRight(List<int> data, int amount)

    {

        // TODO Problem 2 Start

        // Remember: Using comments in your program, write down your process for solving this problem

        // step by step before you write the code. The plan should be clear enough that it could

        // be implemented by another person.



        // Plan:

        // 1. Calculate the effective rotation amount using the modulo operator to handle cases where 'amount' is

        //    greater than the list count.

        // 2. If the effective amount is 0, no rotation is needed, so return.

        // 3. Get the sublist of elements that need to be moved from the end. The starting index for the sublist is data.Count - effective_amount.

        // 4. Remove these elements from the end of the original list.

        // 5. Insert the extracted elements at the beginning of the original list.



        int rotations = amount % data.Count;

        if (rotations == 0)

        {

            return;

        }



        List<int> elementsToMove = data.GetRange(data.Count - rotations, rotations);

        data.RemoveRange(data.Count - rotations, rotations);

        data.InsertRange(0, elementsToMove);

    }

}




