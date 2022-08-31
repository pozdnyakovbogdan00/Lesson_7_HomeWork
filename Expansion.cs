class random_numbers
{
    public static void random_numbers_method()
    {
        string[] InPutDataArray = common_metods.DataInput("Enter M: ", "Enter N: ");
        double[,] DoubleArray = common_metods.CreateArray(Convert.ToInt32(InPutDataArray[0]), Convert.ToInt32(InPutDataArray[1]), -10, 11, 1);
        string StringArray = common_metods.ArrayToString(DoubleArray, Convert.ToInt32(InPutDataArray[0]), Convert.ToInt32(InPutDataArray[1]));
        common_metods.OutPutData(StringArray);
    }
}

class find_number
{
    public static void find_number_method()
    {
        string[] InPutDataArray = common_metods.DataInput("Enter M: ", "Enter N: ");
        double[,] DoubleArray = common_metods.CreateArray(Convert.ToInt32(InPutDataArray[0]), Convert.ToInt32(InPutDataArray[1]), 0, 11, 0);
        string StringArray = common_metods.ArrayToString(DoubleArray, Convert.ToInt32(InPutDataArray[0]), Convert.ToInt32(InPutDataArray[1]));
        common_metods.OutPutData("Your array: ", StringArray);
        string[] InPutDataArray_2 = common_metods.DataInput("Enter position: ");
        string result = Find_Array_Number(DoubleArray, Convert.ToInt32(InPutDataArray_2[0]), Convert.ToInt32(InPutDataArray[0]), Convert.ToInt32(InPutDataArray[1]));
        common_metods.OutPutData("RESULT: " + result);
    }

    private static string Find_Array_Number(double[,] DoubleArray, int WeFind, int m, int n)
    {
        string result = "";

        if (WeFind < 9 || WeFind > 99)
        {
            return "Число должно быть двух-значное (1 цифра - строка; 2 цифра - столбец)";
        }

        int i = WeFind / 10; // m
        int j = (WeFind % 10); // n 

        if (i > m || j > n)
        {
            return "There is no such number";
        }
        else
        {
            return Convert.ToString(DoubleArray[i-1, j-1]);
        }
 
        
    }
}

class find_average
{
    public static void find_average_method()
    {
        string[] InPutDataArray = common_metods.DataInput("Enter M: ", "Enter N: ");
        double[,] DoubleArray = common_metods.CreateArray(Convert.ToInt32(InPutDataArray[0]), Convert.ToInt32(InPutDataArray[1]), 0, 11, 0);
        double[] result = FindAverage(DoubleArray, Convert.ToInt32(InPutDataArray[0]), Convert.ToInt32(InPutDataArray[1]));
        string StringArray = common_metods.ArrayToString(DoubleArray, Convert.ToInt32(InPutDataArray[0]), Convert.ToInt32(InPutDataArray[1]));
        string StringResult = common_metods.ArrayToStringSimple(result);
        common_metods.OutPutData(StringArray, "RESULT: " + StringResult);
    }

    private static double[] FindAverage(double[,] DoubleArray, int m, int n)
    {
        double[] result = new double[n];


        for (int i = 0; i < n; i++)
        {
            double summ = 0;
            for (int j = 0; j < m; j++)
            {
                summ = summ + DoubleArray[j, i];
            }
            result[i] = Math.Round(summ / m, 1);

        }

        return result;


    }
}

class common_metods
{
    public static string[] DataInput(params string[] OffersToInPut)
    {
        int DataRequired = OffersToInPut.Length;
        string[] InputTextArr = new string[DataRequired];

        int i = 0;
        while (i < DataRequired)
        {
            Console.WriteLine(OffersToInPut[i]);
            InputTextArr[i] = Console.ReadLine();
            i++;
        }

        return InputTextArr;
    }

    public static double[,] CreateArray(int m, int n, int start, int stop, int accuracy)
    {
        double[,] DoubleArray = new double[m, n];

        Random rnd = new Random();

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                double newelement = rnd.NextDouble() * (start - stop) + stop;
                DoubleArray[i, j] = Math.Round(newelement, accuracy);
            }
        }

        return DoubleArray;
    }

    public static string ArrayToString(double[,] DoubleArray, int m, int n)
    {

        string StringArray = "";
        for (int i = 0; i < m; i++)
        {
            StringArray = StringArray + "[ ";
            for (int j = 0; j < n; j++)
            {
                StringArray = StringArray + DoubleArray[i, j] + "; ";
            }
            StringArray = StringArray + "]\n";

        }



        return StringArray;
    }

    public static string ArrayToStringSimple(double[] IntArray)
    {
        string StringArray = "[ ";

        foreach (var item in IntArray)
        {
            StringArray = StringArray + item + "; ";
        }

        StringArray = StringArray + "]";

        return StringArray;
    }

    public static void OutPutData(params string[] OutPutText)
    {
        foreach (var item in OutPutText)
        {
            Console.WriteLine(item);
        }

    }
}