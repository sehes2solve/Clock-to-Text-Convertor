using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Clock_to_Text_Converter
{
    class Clock_Text_Methodes
    {
        public bool validation(string Clock, string lang, string dayhalf, out int err_id, out string err_message)
        {
            if (ClockValidation(Clock.Trim(), out err_id, out err_message))
            {
                if (language_validation(lang.Trim(), out err_id, out err_message))
                {
                    if (DayhalfValidation(Clock.Trim(),lang.Trim(), dayhalf.Trim(), out err_id, out err_message))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
        public bool DayhalfValidation(string clock, string lang, string dayhalf, out int err_id, out string err_message)
        {
            if(lang == "EN")
            {
                if(dayhalf == "PM" || dayhalf == "AM" )
                {
                    if (Convert.ToInt32(clock.Split(':')[0]) < 13 && Convert.ToInt32(clock.Split(':')[0]) != 0)
                    {
                        err_id = 0;
                        err_message = "success";
                        return true;
                    }
                    else
                    {
                        err_id = 10;
                        err_message = "24 hr format can't take half of day.";
                        return false;
                    }

                }
                else if(dayhalf == "" || dayhalf == null)
                {
                    err_id = 0;
                    err_message = "success";
                    return true;
                }
                else
                {
                    err_id = 9;
                    err_message = "there's no such half of the day.";
                    return false;
                }
            }
            else
            {
                if (dayhalf == "م" || dayhalf == "ص")
                {
                    if (Convert.ToInt32(clock.Split(':')[0]) < 13 && Convert.ToInt32(clock.Split(':')[0]) != 0)
                    {
                        err_id = 0;
                        err_message = "success";
                        return true;
                    }
                    else
                    {
                        err_id = 9;
                        err_message = "24 hr format can't take half of day.";
                        return false;
                    }

                }
                else if (dayhalf == "" || dayhalf == null)
                {
                    err_id = 0;
                    err_message = "success";
                    return true;
                }
                else
                {
                    err_id = 9;
                    err_message = "there's no such half of the day.";
                    return false;
                }
            }
        }
        /// <summary>
        /// defines whether the language (that the number will be convrted in it's format) is valid or invalid
        /// ,save error message incase error occured & save id for that message.
        /// /// err_id : err_message
        ///    0   | "success"
        ///    1   | "undefined language"
        /// </summary>
        /// <param name="lang">string carry the indicator of the language</param>
        /// <param name="err_id">int id of error type occured</param>
        /// <param name="err_message">string save message explain that type of error</param>
        /// <returns>returns true the indicator of language is right</returns>
        public bool language_validation(string lang, out int err_id, out string err_message)
        {
            if (lang == "AR" || lang == "EN")//Check whther the string carry defined indicator
            {
                err_id = 0;
                err_message = "success";//set error id of not occuring error.
                return true;//set message of success for validation.
            }
            else
            {
                if (lang.Length == 0)
                { 
                    err_id = 8;//set id of the error.
                    err_message = "language field is empty";// set error message describe the error type.
                    return false;
                }
                err_id = 9;//set id of the error.
                err_message = "undefined language";// set error message describe the error type.
                return false;
            }
        }
        public bool ClockValidation(string Clock,out int err_id,out string err_message)
        {
            if (Clock.Length > 0 && Clock.Length < 6)
            {
                if (!new Regex("[^:\\d]").IsMatch(Clock))
                {
                    Regex ClockFormat = new Regex("^\\d{1,2}:\\d{1,2}$");
                    if (ClockFormat.IsMatch(Clock))
                    {
                        if (Convert.ToInt32(Clock.Split(':')[0]) >= 0 && Convert.ToInt32(Clock.Split(':')[0]) < 24)
                        {
                            if (Convert.ToInt32(Clock.Split(':')[1]) >= 0 && Convert.ToInt32(Clock.Split(':')[1]) < 60)
                            {
                                err_id = 0;
                                err_message = "success";
                                return true;
                            }
                            else
                            {
                                err_id = 7;
                                err_message = "there's no such min";
                                return false;
                            }
                        }
                        else
                        {
                            err_id = 6;
                            err_message = "there's no such hour";
                            return false;
                        }
                    }
                    else
                    {
                        err_id = 5;
                        err_message = "invalid format";
                        return false;
                    }
                }
                else
                {
                    if(new Regex("[!@#$%^&*()_+\\-=\\[\\]{};'\"\\\\|,.<>/?]").IsMatch(Clock))
                    {
                        err_id = 3;
                        err_message = "Special char";
                        return false;
                    }
                    else
                    {
                        err_id = 4;
                        err_message = "invalid char";
                        return false;
                    }
                }
            }
            else
            {
                if (Clock.Length == 0)
                {
                    err_id = 1;
                    err_message = "Clock field is empty";
                    return false;
                }
                else
                {
                    err_id = 2;
                    err_message = "length is out of range";
                    return false;
                }
            }
        }
        /// <summary>
        /// converts a decimal number that is integral only into a text in english
        /// </summary>
        /// <param name="integer">decimal carries the value of the integer that will be converted</param>
        /// <returns>returns the equivalent text for the integer number</returns>
        public string integer_converter_En(decimal integer)
        {
            if (integer == 0)// check if the number is 0.
                return "";// returns nothing.
            else
            {
                string text = "";//set string that the value of each three digits of the number will accumlate in it.
                if ((long)integer / 1000000000 > 0)//check whether the 3 digits (that describe the billion value) there value not zero.
                {
                    text += integer_converter_En((long)integer / 1000000000) + " Billion ";
                    //add for text the text conversion of the three digits (but starts from units level) and add word billion.
                    integer %= 1000000000;//remove from the integer the three digit of billion level.
                }
                if ((int)integer / 1000000 > 0)//check whether the 3 digits (that describe the Million value) there value not zero.
                {
                    text += integer_converter_En((int)integer / 1000000) + " Million ";
                    //add for text the text conversion of the three digits (but starts from units level) and add word Milion.
                    integer %= 1000000;//remove from the integer the three digit of Million level.
                }
                if ((int)integer / 1000 > 0)//check whether the 3 digits (that describe the Million value) there value not zero.
                {
                    text += integer_converter_En((int)integer / 1000) + " Thousand ";
                    //add for text the text conversion of the three digits (but starts from units level) and add word thousand.
                    integer %= 1000;//remove from the integer the three digit of thousand level.
                }
                if ((int)integer / 100 > 0)//check whether the hundered digit isn't zero.
                {
                    text += integer_converter_En((int)integer / 100) + " hundered ";
                    //add for text the text conversion of the hundered digit (but starts as unit) and add word hundered.
                    integer %= 100;//remove from the integer the hundered digit.
                }
                if (integer == 0)//check whether the units & tenth digits summation value is zero.
                    return text;//return the text reulted from digits from hundered to billion.

                string[] units_tenth = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                //intialize array carries the name of numbers less than twenty.
                string[] tenth = new string[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                //intialize array that carry the names of tenth digits except that first the one as theeach combination of it with units gives specified name.
                if (integer < 20)//check whether the integer value is less than twenty.
                {
                    text += units_tenth[(int)integer];//add the name of the number that less than 20 and it's value is integer.
                }
                else
                {
                    text += tenth[(int)integer / 10];//get the value of the tenth digit only and add it's name as a tenth.
                    if (integer % 10 > 0)//check whether the units digit isn't zero.
                        text += "-" + integer_converter_En(integer % 10);//add dash then the name of the digit in units digit.
                }


                return text;

            }
        }
        public string MinConverter_En(int min)
       {
           if (min == 0)
                return "";
           if(min % 15 == 0)
           {
                if(min == 15)
                {
                    return "Quarter Past";
                }
                else if(min == 30)
                {
                    return "Half past";
                }
                else
                {
                    return "Quarter To";
                }
           }
           else
           {
                if(min > 30)
                {
                    if(min % 5 == 0)
                    {
                        return integer_converter_En(60-min) + " To";
                    }
                    else
                    {
                        if(60 - min == 1)
                            return integer_converter_En(60 - min) + " Minute To";
                        return integer_converter_En(60-min) + " Minutes To";
                    }
                }
                else
                {
                    if (min % 5 == 0)
                    {
                        return integer_converter_En(min) + " Past";
                    }
                    else
                    {
                        if (min == 1)
                            return integer_converter_En(min) + " Minute Past";
                        return integer_converter_En(min) + " Minutes Past";
                    }
                }
           }
       }
        public void CheckFormat_En(ref int hr ,ref string dayhalf)
        {
            if(hr < 12)
            {
                if (dayhalf == null || dayhalf == "")
                    dayhalf = "AM";
            }
            else
            {
                if (dayhalf == null || dayhalf == "")
                    dayhalf = "PM";
                hr -= 12;
            }
            if (hr == 0)
                hr = 12;
        }
        public string daypart_En(int hr, string dayhalf)
        {
            CheckFormat_En(ref hr, ref dayhalf);
            if (dayhalf == "AM")
            {
                if (hr > 5 && hr < 12)
                {
                    return "in the Morning.";
                }
                else
                {
                    return "in the Night.";
                }
            }
            else
            {
                if (hr > 5 && hr < 12)
                {
                    return "in the Evening.";
                }
                else
                {
                    return "in the Afternoon.";
                }
            }
        }
        public string HrConverter_En(int hr, string dayhalf, int min)
        {
            if (min > 30)
                hr++;
            CheckFormat_En(ref hr, ref dayhalf);
            if(min == 0)
            {
                if (hr == 12)
                {
                    if (dayhalf == "AM")
                        return "Midnight";
                    else
                        return "Midday";
                }
                else
                {
                    return integer_converter_En(hr) + " O'Clock";
                }
            }
            else
            {
                return integer_converter_En(hr);
            }
            
        }
        public string Clock_Converter_En(string Clock, string dayhalf)
        {
            string res;
            res = MinConverter_En(Convert.ToInt32(Clock.Split(':')[1]));
            if (res != "")
                res += " ";
            res += HrConverter_En(Convert.ToInt32(Clock.Split(':')[0]), dayhalf, Convert.ToInt32(Clock.Split(':')[1]));
            if (res.Contains("Midday") || res.Contains("Midnight"))
                return res;
            else
                return res + " " + daypart_En(Convert.ToInt32(Clock.Split(':')[0]), dayhalf);

        }
        /// <summary>
        /// converts a decimal number that is integral only into a text in Arabic
        /// </summary>
        /// <param name="integer">decimal carries the value of the integer that will be converted</param>
        /// <returns>returns the equivalent text for the integer number</returns>
        public string integer_converter_Ar(decimal integer)
        {
            if (integer == 0)// check if the number is 0.
                return "";
            string text = "";//set string that the value of each three digits of the number will accumlate in it.
            if ((long)integer / 1000000000 > 0)//check whether the 3 digits (that describe the billion value) there value not zero.
            {
                if ((long)integer / 1000000000 == 1)//check whether those digits value is 1.
                    text += " مليار ";//add the suiting word according to grammer.
                else if ((long)integer / 1000000000 == 2)//check whether those digits value is 2.
                    text += " ملياران ";//add the suiting word according to grammer.
                else if ((long)integer / 1000000000 < 11)//check whether those digits value is less than 11.
                    text += integer_converter_Ar((long)integer / 1000000000) + " مليارات ";
                //add for text the text conversion of the three digits (but starts from units level) and suiting word grammarly.
                else
                    text += integer_converter_Ar((long)integer / 1000000000) + " ملياراَ ";
                //add for text the text conversion of the three digits (but starts from units level) and suiting word grammarly.
                integer %= 1000000000;//remove from the integer the three digit of billion level.
            }
            if ((int)integer / 1000000 > 0)//check whether the 3 digits (that describe the Million value) there value not zero.
            {
                if (text != "")//check whether there's value in text from pervious condition.
                    text = text + " و ";//add linking char according to grammer.
                if ((int)integer / 1000000 == 1)//check whether those digits value is 1.
                    text = " مليون " + text;//add the suiting word according to grammer.
                else if ((int)integer / 1000000 == 2)//check whether those digits value is 2.
                    text += " مليونان ";//add the suiting word according to grammer.
                else if ((int)integer / 1000000 < 11)//check whether those digits value is less than 11.
                    text += integer_converter_Ar((int)integer / 1000000) + " ملايين ";
                //add for text the text conversion of the three digits (but starts from units level) and suiting word grammarly.
                else
                    text += integer_converter_Ar((int)integer / 1000000) + " مليوناً ";
                // add for text the text conversion of the three digits(but starts from units level) and suiting word grammarly.
                integer %= 1000000;// remove from the integer the three digit of million level.
            }
            if ((int)integer / 1000 > 0)//check whether the 3 digits (that describe the thousand value) there value not zero.
            {
                if (text != "")//check whether there's value in text from pervious conditions.
                    text = text + " و ";//add linking char according to grammer.
                if ((int)integer / 1000 == 1)//check whether those digits value is 1.
                    text += "ألف ";//add the suiting word according to grammer.
                else if ((int)integer / 1000 == 2)//check whether those digits value is 2.
                    text += "ألفان ";//add the suiting word according to grammer.
                else if ((int)integer / 1000 < 11)//check whether those digits value is less than 11.
                    text += integer_converter_Ar((int)integer / 1000) + " ألاف ";
                //add for text the text conversion of the three digits (but starts from units level) and suiting word grammarly.
                else
                    text += integer_converter_Ar((int)integer / 1000) + " ألفاً ";
                // add for text the text conversion of the three digits(but starts from units level) and suiting word grammarly.
                integer %= 1000;// remove from the integer the three digit of thousand level.
            }
            if ((int)integer / 100 > 0)//check whether the hundered digit isn't zero.
            {
                if (text != "")//check whether there's value in text from pervious conditions.
                    text = text + " و ";//add linking char according to grammer.
                string[] hundered = new string[] { "صفر", "مائة", "مائتان", "ثلاثمائة", "أربعمائة", "خمسمائة", "ستمائة", "سبعمائة", "ثمانمائة", "تسعمائة" };
                //intialize array names of digits in hundereds according to grammer.
                text += hundered[(int)integer / 100];//add the name of the digit in hundered level
                integer %= 100;// remove the hundered digit.
            }
            if (integer == 0)//check whether the units & tenth digits summation value is zero.
                return text;//return the text reulted from digits from hundered to billion.
            if (text != "")//check whether there's value in text from pervious conditions.
                text = text + " و ";//add linking char according to grammer.
            string[] units = new string[] { "صفر", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة", "عشرة" };
            //array carry the names of numbers at units digit and the name of first one in tenth digit with zero combination of units digit.
            string[] tenth = new string[] { "صفر", "عشرة", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };
            //array carry the names of numbers at tenth digit.
            if (integer <= 10)//check whether the total value of the two digits is less than or equal ten.
                text = text + units[(int)integer];//add the name of the digit from the array of units
            else if (integer < 20)//check whether the total value of two digits is less than 20
            {
                if (integer == 11)//check whether it's 11 
                    text = text + "أحد عشر";//add name of eleven
                else if (integer == 12)//check whther it's twelve
                    text = text + "اثنا عشر";//add name of twelve
                else
                    text = text + units[(int)integer % 10] + " عشر";//add the units name of the units digit and add the suiting constan word according to grammer.
            }
            else
            {
                if ((int)integer % 10 != 0)//check whether the units digit is not zero.
                    text += units[(int)integer % 10] + " و " + tenth[(int)integer / 10];
                // add the tenth name of the tenth digit and linking char and the units name of units digit.
                else
                    text += tenth[(int)integer / 10];//add the tenth name of tenth digit.
            }

            return text;
        }
        public string MinConverter_Ar(int min)
        { 
           if (min == 0)
                return "";
           if(min <= 30)
           {
                if(min == 30)
                {
                    return " و النصف";
                }
                else if(min == 15)
                {
                    return " و الربع";
                }
                else if(min == 20)
                {
                    return " و الثلث";
                }
                else
                {
                    if(min == 1)
                        return " و دقيقة";
                    if (min == 2)
                        return " و دقيقتان";
                    if(min > 10)
                        return " و " + integer_converter_Ar(min) + " دقيقة";
                    else
                        return " و " + integer_converter_Ar(min) + " دقائق";
                }
           }
           else
           {
                if (min == 40)
                {
                    return " إلا ثلث";
                }
                else if (min == 45)
                {
                    return " إلا ربع";
                }
                else
                {
                    if (60 - min == 1)
                        return " إلا دقيقة";
                    if (60 - min == 2)
                        return " إلا دقيقتان";
                    return " إلا " + integer_converter_Ar(60 - min) + " دقائق";
                }
            }
                
        }
        public void CheckFormat_Ar(ref int hr, ref string dayhalf)
        {
            if (hr < 12)
            {
                if (dayhalf == null || dayhalf == "")
                    dayhalf = "ص";
            }
            else
            {
                if (dayhalf == null || dayhalf == "")
                    dayhalf = "م";
                hr -= 12;
            }
            if (hr == 0)
                hr = 12;
        }
        public string daypart_Ar(int hr, string dayhalf)
        {
            CheckFormat_Ar(ref hr, ref dayhalf);
            if (dayhalf == "ص")
            {
                if (hr > 5 && hr < 12)
                {
                    return "صباحاً.";
                }
                else
                {
                    return "ليلاً.";
                }
            }
            else
            {
                if (hr > 5 && hr < 12)
                {
                    return "مساءً.";
                }
                else
                {
                    return "ظهراً.";
                }
            }
        }
        public string HrConverter_Ar(int hr, string dayhalf, int min)
        {
            if (min > 30)
                hr++;
            CheckFormat_Ar(ref hr, ref dayhalf);
            if (hr == 12 && min == 0)
            {
                if (dayhalf == "ص")
                    return "منتصف الليل";
                else
                    return "الظهر";
            }
            else
            {
                string[] HR = new string[]
                {"الواحدة",
                "الثانية",
                "الثالثة",
                "الرابعة",
                "الخامسة",
                "السادسة",
                "السابعة",
                "الثامنة",
                "التاسعة",
                "العاشرة",
                "الحادية عشر",
                "الثانية عشر"};
                return "الساعة " + HR[hr-1];
            }
        }
        public string Clock_Converter_Ar(string Clock, string dayhalf)
        {
            string res = "";
            res += HrConverter_Ar(Convert.ToInt32(Clock.Split(':')[0]), dayhalf, Convert.ToInt32(Clock.Split(':')[1]));
            if (res == "منتصف الليل" || res == "الظهر")
                return res;
            else
            {
                return res + MinConverter_Ar(Convert.ToInt32(Clock.Split(':')[1])) + " " + daypart_Ar(Convert.ToInt32(Clock.Split(':')[0]), dayhalf);
            }
        }
        public string Clock_Converter(string Clock,string lang,string dayhalf)
        {
            int err_id;
            string err_message;
            if (validation(Clock, lang, dayhalf, out err_id, out err_message))
            {
                Clock = Clock.Trim();
                lang = lang.Trim();
                dayhalf = dayhalf.Trim();
                if (lang == "EN")
                    return Clock_Converter_En(Clock, dayhalf);
                else
                    return Clock_Converter_Ar(Clock, dayhalf);
            }
            return err_id + " : " + err_message;
        }



    }
}
