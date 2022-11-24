using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//@Suw-inc 2022-22-10 01:21:11:00
namespace ToRomanNumeral
{
    /// <summary>
    /// Class Roman contains all the methods that convert a given integer value to its roman numeral equivalent 
    /// </summary>
    public class Roman
    {
        /// <summary>
        /// Function checks values range and calls the corresponding method to convert it to a roman numeral 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string CalculateRomanValue(int value)
        {
            if (value <= 5)
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("value cannot be less than 1");
                else
                    return GetFive(value);
            }
            else if (value <= 10)
                return GetTen(value);
            else if (value <= 50)
                return GetFifty(value);
            else if (value <= 100)
                return GetHundred(value);
            else if (value <= 500)
                return GetFiveHundred(value);
            else if (value <= 1000)
                return GetThousand(value);
            else
            {
                if (value < 4000)
                    return GetFourThousand(value);
                else
                    throw new ArgumentOutOfRangeException("value cannot be greater than 3999");
            }

        }
        /// <summary>
        /// Function get Five handles all values less than 6
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetFive(int value)
        {
            string roman = "";
            if (value == 5)
            {
                roman += GetCharecter(value);
            }
            else if ((5 - value) == 1)
            {
                roman += GetCharecter(1) + "" + GetCharecter(5);

            }
            else
            {
                for (int i = 0; i < value; i++)
                {
                    roman = GetCharecter(1) + "" + roman;
                }
            }
            return roman;


        }
        /// <summary>
        /// Function Get Ten handles all values in the range (6-10)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetTen(int value)
        {
            string roman = "";

             if (value == 10)
            {
                roman += GetCharecter(value);
            }
            else if (value == 9) 
            {
                roman += GetCharecter(1) + "" + GetCharecter(10);

            }
            else  
            {
                roman = GetCharecter(5).ToString();
                roman = roman + "" + GetFive(value - 5);
             
            }

            return roman;

        }
        /// <summary>
        /// Function GetFifty handles all values in the range (11-50)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetFifty(int value)
        {
            string roman = "";
            

            if (value == 50)
            {
                roman += GetCharecter(value);
            }
            else
            {
                int runs = (int)value / 10;           //get the remainder of value / 10 and use it as the number of X's we add
                int remainder = value % 10;           //use the remainder of value / 10 as the roman numeral equi less than 10
                if (value >= 40)
                {
                    roman = GetCharecter(10) + "" + GetCharecter(50);

                      
                }
                else
                {
                    for (int i = 0; i < runs; i++)
                    {
                        roman = roman + "" + GetCharecter(10);
                    }
                   
                }
                if (remainder != 0)
                {
                    if(remainder > 5)
                    roman = roman + "" + GetTen(remainder);
                    else
                    roman = roman + "" + GetFive(remainder);

                }


            }

            return roman;

        }
        /// <summary>
        /// Function GetHundred handles all values in the range (51-100)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetHundred(int value)
        {
            string roman = "";

            if (value == 100)
            {
                roman += GetCharecter(value);
            }
            else
            {

                int remainder;

                if (value >= 90)   //if value is in btn 90 and 100, we check for the value of the remainder and use it to get its roman numeral equi 
                {
                    remainder = value - 90;

                    roman = GetCharecter(10) + "" + GetCharecter(100);

                 
                }
                else
                {
                    remainder = value - 50;

                    roman = GetCharecter(50).ToString();
                   
                   
                }
                roman = roman + "" + GetFifty(remainder);


            }
            return roman;
        }
        /// <summary>
        /// Function GetFiveHundred handles all values in the range (101-500)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public  string GetFiveHundred(int value)
        {
            string roman = "";


            if (value == 500)
            {
                roman += GetCharecter(value);
            }
            else
            {
                int runs = (int)value / 100;         //get the remainder of value / 100 and use it as the number of C's we add
                int remainder = value % 100;         //use the remainder of value / 100 as the roman numeral equi less than 100
                if (value >= 400)
                {
                    roman = GetCharecter(100) + "" + GetCharecter(500);


                }
                else
                {
                    for (int i = 0; i < runs; i++)
                    {
                        roman = roman + "" + GetCharecter(100);
                    }

                }
                if (remainder != 0)
                {
                    if (remainder > 50)   //if remainder > 50 we need to convert it using the getHundred function and add the result to curr roman value
                        roman = roman + "" + GetHundred(remainder);
                    else
                        roman = roman + "" + GetFifty(remainder);  //otherwise we use the getfifty function which will handle all values down to 1, then we add this value to our curr roman value

                }


            }

            return roman;
        }
        /// <summary>
        /// Function GetThousand Handles all values in the range (501,1000)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetThousand(int value)

        {
           
            string roman = "";

            if (value == 1000)
            {
                roman += GetCharecter(value);
            }
            else
            {

                int remainder;

                if (value >= 900)
                {
                    remainder = value - 900;

                    roman = GetCharecter(100) + "" + GetCharecter(1000);


                }
                else
                {
                    remainder = value - 500;

                    roman = GetCharecter(500).ToString();


                }
                roman = roman + "" + GetFiveHundred(remainder);




                
            }
            return roman;
        }




        /// <summary>
        /// Function GetFoueThousand Handles all values in the range (1001,3999)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetFourThousand(int value)

        {
            string roman = "";

            int runs = (int)value / 1000;         //get the remainder of value / 100 and use it as the number of C's we add
            int remainder = value % 1000;         //use the remainder of value / 100 as the roman numeral equi less than 100
           
           
                for (int i = 0; i < runs; i++)
                {
                    roman = roman + "" + GetCharecter(1000);
                }

            
            if (remainder != 0)
            {
                if (remainder > 500)   //if remainder > 50 we need to convert it using the getHundred function and add the result to curr roman value
                    roman = roman + "" + GetThousand(remainder);
                else
                    roman = roman + "" + GetFiveHundred(remainder);  //otherwise we use the getfifty function which will handle all values down to 1, then we add this value to our curr roman value

            }

            return roman;
        }



        /// <summary>
        /// Function returns a char based on the value of val
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private char GetCharecter(int val)
        {
            char res = ' ';

            switch (val)
            {
                case 1: res = 'I'; break;
                case 5: res = 'V'; break;
                case 10: res = 'X'; break;
                case 50: res = 'L'; break;
                case 100: res = 'C'; break;
                case 500: res = 'D'; break;
                case 1000: res = 'M'; break;
            }

            return res;
        }
    }
}
