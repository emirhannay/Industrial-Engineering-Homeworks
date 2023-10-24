//String, char, int, double, bool ifadeleri ile değişkenler tanımlayınız.
//Değişken değerleri konsoldan alınacak şekilde programınızı yazdınız.
//Ardından konsoldan alınan değerleri yazdırınız.
// >>> Ödeve ek olarak kullanıcıdan aldığımız inputların doğruluğunu yüzeysel olarak kontrol ettim. Console App olduğu için sınırlı çalışabildim. <<<

using System.Runtime.Serialization.Formatters;
using System.Text.RegularExpressions;


string exceptionMessage = "Doğru bir veri girişi yapmadınız. Uygulama sonlandırılacaktır";


string name, surname,department;
bool preparation;
int birthYear;
long studentNumber;
double length;





Console.WriteLine("------ Btü Öğrenci Bilgi Formu ------");    
Console.Write("İsim : ");
name = IfStringCorrectFormatReturnIt(Console.ReadLine());
Console.Write("Soy isim : ");
surname = IfStringCorrectFormatReturnIt(Console.ReadLine());
Console.Write("Doğum yılı : ");
birthYear = ReturnBirthYearIfItsCorrectFormat(Console.ReadLine());
Console.Write("Okuduğu bölüm : ");
department = IfStringCorrectFormatReturnIt(Console.ReadLine());
Console.Write("Öğrenci numarası : "); 
studentNumber = ReturnStudentNumberIfItsCorrectFormat(Console.ReadLine());
Console.Write("Hazırlık okudunuz mu? (true/false): ");
preparation = ReturnBoolIfItsCorrectFormat(Console.ReadLine());
Console.Write("Boy (m): ");
length = ReturnDoublefItsCorrectFormat(Console.ReadLine());   

Console.WriteLine("\n \n *********** Btü Öğrenci Kimliği ***********");
Console.WriteLine("Öğrencinin ismi: " + name + " "+ surname);
Console.WriteLine("Öğrencinin numarası: " + studentNumber);
Console.WriteLine("Öğrencinin bölümü: " + department);
Console.WriteLine("Hazırlık okuma durumu: " + preparation);
Console.WriteLine("Öğrencinin yaşı: "+ (DateTime.Now.Year - birthYear) );
Console.WriteLine("Öğrencinin boyu: " + length);


//Checks the given string expression , if format is not valid it throws an error
bool ReturnStringIfItsValidFormat(String input) 
{

    if (!String.IsNullOrEmpty(input))
    {
                                                   //Validate input with regex
        bool allCharactersInStringAreValidFormat = Regex.IsMatch(input, @"^[a-zA-Z/\s İĞÜŞÖÇzığüşöç]+$");

        if (allCharactersInStringAreValidFormat)
        {
            return true;
        }
        throw new Exception(exceptionMessage);
    }
    else
    {
        throw new Exception(exceptionMessage);
        
    }                
    
    
}
//If the format is correct, it will return. If not, the application closes.
String IfStringCorrectFormatReturnIt(String input)
{
    try
    {
        bool isStringValidFormat = ReturnStringIfItsValidFormat(input);
        return input;
    }
    catch (Exception e) 
    {
        Console.Write(e.Message);
        Environment.Exit(0);
        return "";
    }
}
//If the format is correct, it will return. If not, the application closes.
bool ReturnBoolIfItsCorrectFormat(String input)
{
    try
    {
        if (input == "false")
        {
            return false;
        }
        if (input == "true")
        {
            return true;
        }

        throw new Exception(exceptionMessage);
    }
    catch(Exception e) {
        Console.Write(e.Message);
        Environment.Exit(0);
        return false;
    }
}
//If the format is correct, it will return. If not, the application closes.
long ReturnStudentNumberIfItsCorrectFormat(String input)
{
    try
    {             
      
        if (Regex.IsMatch(input, "\\b\\d{11}\\b"))
        {
            return long.Parse(input);
        }
     

        throw new Exception(exceptionMessage);
    }
    catch(Exception e)
    {
        Console.Write(e.Message);
        Environment.Exit(0);
        return 3L;
    }
}
//If the format is correct, it will return. If not, the application closes.
int ReturnBirthYearIfItsCorrectFormat(String input)
{
    try
    {

        if (Regex.IsMatch(input, "\\b\\d{4}\\b"))
        {
            int birthYearInput = Convert.ToInt32(input);
            if ( Math.Abs(DateTime.Now.Year - birthYearInput) <= 150 & birthYearInput < DateTime.Now.Year)
            {
                return birthYearInput;
            }
            
        }


        throw new Exception(exceptionMessage);
    }
    catch (Exception e)
    {
        Console.Write(e.Message);
        Environment.Exit(0);
        return 3;
    }
}

//If the format is correct, it will return. If not, the application closes.
int ReturnIntIfItsCorrectFormat(String input)
{
    try
    {
        bool isInputInteger = input.All(Char.IsDigit);
        if (isInputInteger)
        {
            return Convert.ToInt32(input);
        }

        throw new Exception(exceptionMessage);
    }
    catch (Exception e)
    {
        Console.Write(e.Message);
        Environment.Exit(0);
        return 3;
    }
}
//If the format is correct, it will return. If not, the application closes.
double ReturnDoublefItsCorrectFormat(String input)
{
    try
    {
        double result;
        bool isDouble = Double.TryParse(input, out result );
        if (isDouble)
        {
            return result;
        }

        throw new Exception(exceptionMessage);
    }
    catch (Exception e)
    {
        Console.Write(e.Message);
        Environment.Exit(0);
        return 3;
    }
}






