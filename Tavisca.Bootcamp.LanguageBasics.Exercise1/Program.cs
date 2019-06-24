using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
            try{
            equation=equation.Replace('*','=');
            string[] subEq=Regex.Split(equation,"=");
            if(subEq[0].Contains("?"))
            {
               return getResult(subEq[2],subEq[1],subEq[0],"divide");
            }
            else if(subEq[1].Contains("?"))
            {
               return getResult(subEq[2],subEq[0],subEq[1],"divide");
            }
            else
            {
               return getResult(subEq[0],subEq[1],subEq[2],"multiply");
            }
          }
          catch(Exception e)
          {
            Console.Write(e);
            throw new NotImplementedException();
          }
        }
        
        public static int getResult(string equation1,string equation2,string equation3,string operation)
        {
            int result=0;
            switch(operation)
            {
                case "divide":result= int.Parse(equation1)/int.Parse(equation2);
                if (int.Parse(equation1)%int.Parse(equation2)!=0||equation3.Contains(result.ToString()))
                {
                    return -1;
                }
                break;
                
                case "multiply":result= int.Parse(equation1)*int.Parse(equation2);
                break;
                
                 default: return -1;
                
            }
            char result_string=((int)result).ToString()[equation3.IndexOf('?')];
            return int.Parse(result_string.ToString());
        }
    }
}
