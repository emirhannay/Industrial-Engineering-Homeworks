// See https://aka.ms/new-console-template for more information
namespace YBS
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;


    class Program
    {
        static public void Main(String[] args)
        {

            int numberOfCandidates = 0;
            List<Candidate> candidateList = new List<Candidate>();
            InputValidator inputValidator = new InputValidator();

            Console.WriteLine("Kaç aday için bilgi girişi yapacaksınız?");
            numberOfCandidates = inputValidator.ValidateNumberOfCandidatesInput(Console.ReadLine());


            for (int i = 0; i < numberOfCandidates; i++)
            {
                Console.WriteLine(i + 1 + ". Kullanıcı için isim giriniz");
                string tempName = inputValidator.ValidateNameInput(Console.ReadLine());

                Console.WriteLine(i + 1 + ". Kullanıcı için boy(cm cinsinden) giriniz ( örneğin : 175)");
                int tempHeight = inputValidator.ValidateHeightInput(Console.ReadLine());

                Console.WriteLine(i + 1 + ". Kullanıcı için kilo(kg) giriniz ( örneğin : 75 )");
                int tempWeight = inputValidator.ValidateWeightInput(Console.ReadLine());

                candidateList.Add(new Candidate(tempName, tempHeight, tempWeight));

            }

            Console.WriteLine("Aday bilgileri : ");
            Console.WriteLine("***********************************");
            foreach (Candidate _candidate in candidateList)
            {
                Console.WriteLine("İsim : " + _candidate.Name);
                Console.WriteLine("Boy : " + _candidate.Height);
                Console.WriteLine("Kilo : " + _candidate.Weight);
                Console.Write("Boy kilo endeksi : ");
                _candidate.WriteIndex();
                Console.WriteLine("\n***********************************");


            }

        }
    }

    class Candidate
    {



        private string name;
        private int height;
        private int weight;
        private double index;

        public Candidate(string name, int height, int weight)
        {
            this.Name = name;
            this.Height = height;
            this.Weight = weight;

        }

        public string Name { get => name; set => name = value; }
        public int Height { get => height; set => height = value; }
        public int Weight { get => weight; set => weight = value; }
        public double Index { get => index; set => index = value; }

        public void CalculateIndex()
        {

            Index = (double)Height / Weight;
        }
        public void WriteIndex()
        {
            if (Index != 0)
            {
                Console.Write(Index);
            }
            else
            {
                CalculateIndex();
                Console.Write(Index);
            }
        }
    }

    class InputValidator
    {
        private string exceptionMessage = "Doğru bir veri girişi sağlamadığınız için uygulama sonlandırılacaktır...";
        public int ValidateNumberOfCandidatesInput(string input)
        {
            try
            {
                int numberOfCandidatesInput = Convert.ToInt16(input);
                if (numberOfCandidatesInput <= 0)
                {
                    Console.WriteLine(exceptionMessage);
                    Environment.Exit(0);
                }

                return numberOfCandidatesInput;

            }
            catch (Exception e)
            {
                Console.WriteLine(exceptionMessage);
                Environment.Exit(0);
                return 0;
            }
        }

        public string ValidateNameInput(string input)
        {
            try
            {
                string name = input;
                //Validate input with regex
                bool isStringValidFormat = Regex.IsMatch(input, @"^[a-zA-Z/\s İĞÜŞÖÇzığüşöç]+$");
                if (isStringValidFormat)
                {
                    return name;
                }
                else
                {
                    Console.WriteLine(exceptionMessage);
                    Environment.Exit(0);
                    return "";
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(exceptionMessage);
                Environment.Exit(0);
                return "";
            }
        }

        public int ValidateHeightInput(string input)
        {
            try
            {
                int height = Convert.ToInt16(input);
                if (20 < height && height < 300)
                {
                    return height;
                }
                else
                {
                    Console.WriteLine(exceptionMessage);
                    Environment.Exit(0);
                    return 0;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(exceptionMessage);
                Environment.Exit(0);
                return 0;
            }
        }

        public int ValidateWeightInput(string input)
        {
            try
            {
                int weight = Convert.ToInt16(input);
                if (1 < weight && weight < 700)
                {
                    return weight;
                }
                else
                {
                    Console.WriteLine(exceptionMessage);
                    Environment.Exit(0);
                    return 0;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(exceptionMessage);
                Environment.Exit(0);
                return 0;
            }
        }
    }


}
