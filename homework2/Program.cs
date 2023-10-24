

using System.Linq.Expressions;
using System.Runtime.CompilerServices;

            //Validator object
            InputValidator inputValidator = new InputValidator();

            //Variables
            string info;
            int vize = inputValidator.ValidateAndReturnIfItsCorrectFormat(Console.ReadLine());
            int final = inputValidator.ValidateAndReturnIfItsCorrectFormat(Console.ReadLine());
            int odevNotu = inputValidator.ValidateAndReturnIfItsCorrectFormat(Console.ReadLine());
            int puan = ((vize * 30) / 100) + ((odevNotu * 20) / 100) + ((final * 50) / 100);


        
        if (puan >= 90)
        {
            info = " Harf notu : " + "AA " + "Başarılı";
            Console.WriteLine(puan + info);
        }
        else if (puan >= 80 && puan < 90)
        {
            info = " Harf notu : " + "BA " + "Başarılı";
            Console.WriteLine(puan + info);
        }
        else if (puan >= 75 && puan < 80)
        {
            info = " Harf notu : " + "BB " + "Başarılı";
            Console.WriteLine(puan + info);
        }
        else if (puan >= 70 && puan < 75)
        {
            info = " Harf notu : " + "CB " + "Başarılı";
            Console.WriteLine(puan + info);
        }
        else if (puan >= 60 && puan < 70)
        {
            info = " Harf notu : " + "CB " + "Başarılı";
            Console.WriteLine(puan + info);
        }
        else if (puan >= 70 && puan < 75)
        {
            info = " Harf notu : " + "CB " + "Başarılı";
            Console.WriteLine(puan + info);
        }
        else if (puan >= 60 && puan < 70)
        {
            info = " Harf notu : " + "CC " + "Başarılı";
            Console.WriteLine(puan + info);
        }
        else if (puan >= 50 && puan < 60)
        {
            info = " Harf notu : " + "DC " + "Koşullu Başarılı / Başarısız ( Yönetmelik Madde 24 (3) b'ye göre değerlendirilir.)";
            Console.WriteLine(puan + info);
        }
        else if (puan >= 40 && puan < 50)
        {
            info = " Harf notu : " + "DD " + "Başarısız";
            Console.WriteLine(puan + info);
        }
        else if (puan >= 30 && puan < 40)
        {
            info = " Harf notu : " + "FD " + "Başarısız";
            Console.WriteLine(puan + info );
        }
        else if (puan >= 0 && puan < 30)
        {
            info = " Harf notu : " + "FF " + "Başarısız";
            Console.WriteLine(puan + info);
        }

 


public class InputValidator 
{
    private string exceptionMessage;

    // It validates the grade value ​​and returns it if it is in the correct form. If not, it terminates the application.
    public int ValidateAndReturnIfItsCorrectFormat(String input)
    {
        int score = 0;

        try
        {
            //If it cannot convert the string value type data received from the user into integer, it will give an error.
            score = Convert.ToInt32(input);
        }
        catch (Exception e)
        {

            Console.WriteLine("Lütfen doğru bir veri girişi sağlayınız. Doğru bir veri girişi sağlamadığınız için uygulama sonlandırılacaktır.");
            Environment.Exit(0);
        }

        if (score < 0)
        {
            exceptionMessage = "Not değeriniz 0'dan küçük olamaz. Doğru bir veri girişi sağlamadığınız için uygulama sonlandırılacaktır.";
            Console.WriteLine(exceptionMessage);
            Environment.Exit(0);
            return 1;

        }
        else if (score > 100) {
            exceptionMessage = "Not değeriniz 100'den büyük olamaz. Doğru bir veri girişi sağlamadığınız için uygulama sonlandırılacaktır.";
            Console.WriteLine(exceptionMessage);
            Environment.Exit(0);
            return 1;

        }
        else
        {
            return score;
        }
    }
}



