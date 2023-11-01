using System;

public class Program
{
    public static void Main()
    {
        //Validator object
        InputValidator inputValidator = new InputValidator();

        Console.WriteLine("10'dan büyük bir sayı giriniz");
        int input = inputValidator.ValidateNumberInput(Console.ReadLine());

        Console.WriteLine("Girdiğiniz sayıya kadar olan sayıların tek mi çift mi olduğu hesaplanıyor....");

        //I added a small waiting period in the interface because it looks nicer. It will wait 1 seconds.
        Thread.Sleep(1000);
        for (int i = 0; i < input; i++)
        {
            
            if (i % 2 == 0)
            {
                Console.WriteLine(i + " çift sayıdır");
            }
            else
            {
                Console.WriteLine(i + " tek sayıdır");
            }
        }
    }
}


public class InputValidator
{

    private string exceptionMessage = "Lütfen doğru bir veri girişi sağlayınız. Doğru bir veri girişi sağlamadığınız için uygulama sonlandırılacaktır.";

    public int ValidateNumberInput(string input)
    {


        try
        {
            //If it cannot convert the string value type data received from the user into integer, it will give an error.
            int tempNumber = Convert.ToInt32(input);
            if (tempNumber > 10)
            {
                //Console.WriteLine("Doğru yerdeyim");
                return tempNumber;
            }
            Console.WriteLine(exceptionMessage);
            Environment.Exit(0);

        }
        catch (Exception e)
        {
            Console.WriteLine(exceptionMessage);
            Environment.Exit(0);
            return 1;
        }

        return 1;


    }
}