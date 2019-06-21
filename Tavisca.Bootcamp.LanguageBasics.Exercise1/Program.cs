using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            double result=0.0;
            int index=0;
            string tempString="";
            string[] subEq=Regex.Split(equation,"=");
            subEq[0]=subEq[0].Replace('*','=');
            string[] substr=Regex.Split(subEq[0],"=");
            
            if (subEq[0].Contains("?"))
            {
                if(substr[0].Contains("?"))
                {
                    index=substr[0].IndexOf('?');
                    result= Convert.ToDouble(double.Parse(subEq[1])/double.Parse(substr[1]));
                    tempString=substr[0];
                }
                else if(substr[1].Contains("?"))
                {
                    index=substr[1].IndexOf('?');
                    result= Convert.ToDouble(double.Parse(subEq[1])/double.Parse(substr[0]));
                    tempString=substr[1];

                }
            }
            else
            {
                index=subEq[1].IndexOf('?');
                result= Convert.ToDouble(double.Parse(substr[1])*double.Parse(substr[0]));
                tempString=subEq[1];
            }
            if (result%1!=0||tempString.Contains(result.ToString()))
            {
                return -1;
            }
            else
            {
                char result_string=((int)result).ToString()[index];
                return int.Parse(result_string.ToString());
            }

            //throw new NotImplementedException();
        }
    }
}
