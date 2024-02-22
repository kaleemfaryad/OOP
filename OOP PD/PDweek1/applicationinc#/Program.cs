using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace applicationinc_
{
    internal class Program
    {

        static void header()
        {

           /* Console.WriteLine("\n");*/
            Console.WriteLine("______________________________________***************************_____________________________________\n");
            Console.WriteLine("                                                                                                      \n");
            Console.WriteLine("                                         BUS MANAGEMENT SYSTEM                                        \n");
            Console.WriteLine("                                                                                                      \n");
            Console.WriteLine("--------------------------------------***************************------------------------------------\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

        }
        static bool checknamevalidation(string username)
        {
            // username
            for (int i = 0; i < username.Length; i++)
            {
                if (!((Char.IsLetter(username[i]) && Char.IsLetterOrDigit(username[i])) || username[i] == '_'))
                {
                    return false;
                }
            }
            return true;
        }

        static bool checkbustimevalidation(string input)
        {
            // username
            for (int i = 0; i < input.Length; i++)
            {
                if (!((Char.IsLetter(input[i]) && Char.IsLetterOrDigit(input[i])) || (Char.IsDigit(input[i]) || input[i] == ':')))
                {
                    return false;
                }
            }
            return true;
        }

        static bool busroutevalidation(string route)
        {
            for (int i = 0; i < route.Length; i++)
            {
                if (!((Char.IsLetter(route[i]) && Char.IsLetterOrDigit(route[i]))))
                {
                    return false;
                }
            }
            return true;
        }

        static bool checkpassword(string pass)
        {
            if (pass.Length >= 8)
            {
                for (int i = 0; i < pass.Length; i++)
                {
                    if ((Char.IsLetter(pass[i]) || Char.IsDigit(pass[i])))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        static bool validbusid(string busId)
        {
            for (int i = 0; i < busId.Length; i++)
            {
                if (Char.IsDigit(busId[i]))
                {
                    return true;
                }
            }
            return false;
        }

        static bool validfeedbackpoints(string feedbackPoints)
        {
            for (int i = 0; i < feedbackPoints.Length; i++)
            {
                if (feedbackPoints[i] >= '0' && feedbackPoints[i] <= '5')
                {
                    return true;
                }
            }
            return false;
        }

        static bool validpassengerid(string passengerId)
        {
            if (passengerId.Length == 13)
            {
                for (int i = 0; i < passengerId.Length; i++)
                {
                    if (!(Char.IsDigit(passengerId[i])))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        static void signupdatastore(ref string[] username, ref string[] password, ref string[] role, ref int c)
        {
            using (StreamWriter signupFile = new StreamWriter("signup.txt"))
            {
                for (int i = 0; i < c; i++)
                {
                    if (string.IsNullOrEmpty(username[i]))
                        continue;

                    signupFile.WriteLine($"{username[i]},{password[i]},{role[i]}");
                }
            }
        }

        static string getField(string record, int field)
        {
            int commaCount = 1;
            string item = "";

            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    item += record[x];
                }
            }

            return item;
        }

        static void readsignupData(ref string[] username, ref string[] password, ref string[] role, ref int c)
        {
            using (StreamReader data = new StreamReader("signup.txt"))
            {
                string record;
                while ((record = data.ReadLine()) != null)
                {
                    username[c] = getField(record, 1);
                    password[c] = getField(record, 2);
                    role[c] = getField(record, 3);
                    c++;
                }
            }
        }

        static void adminbusdatastore(ref string[] busnumber, ref string[] busname, ref string[] busstartinglocation, ref string[] busendinglocation, ref string[] busdeparturetime, ref string[] busarrivaltime, ref string[] ticketprice, ref int count)
        {
            using (StreamWriter busDataFile = new StreamWriter("busdatabyadmin.txt"))
            {
                for (int i = 0; i < count; i++)
                {
                    if (string.IsNullOrEmpty(busnumber[i]))
                        continue;

                    busDataFile.WriteLine($"{busnumber[i]},{busname[i]},{busstartinglocation[i]},{busendinglocation[i]},{busdeparturetime[i]},{busarrivaltime[i]},{ticketprice[i]}");
                }
            }
        }

        static void readbusdatabyadmin(ref string[] busnumber, ref string[] busname, ref string[] busstartinglocation, ref string[] busendinglocation, ref string[] busdeparturetime, ref string[] busarrivaltime, ref string[] ticketprice, ref int count)
        {
            using (StreamReader data = new StreamReader("busdatabyadmin.txt"))
            {
                string record;
                while ((record = data.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(record))
                        continue;

                    busnumber[count] = getField(record, 1);
                    busname[count] = getField(record, 2);
                    busstartinglocation[count] = getField(record, 3);
                    busendinglocation[count] = getField(record, 4);
                    busdeparturetime[count] = getField(record, 5);
                    busarrivaltime[count] = getField(record, 6);
                    ticketprice[count] = getField(record, 7);
                    count++;
                }
            }
        }

        static void passengerdatastore(ref string[] passengerid, ref string[] passengername, ref string[] passengerSpoint, ref string[] passengerDpoint, ref string[] bookedseats, ref int passcount)
        {
            using (StreamWriter passengerDataFile = new StreamWriter("passengerdata.txt"))
            {
                for (int i = 0; i < passcount; i++)
                {
                    if (string.IsNullOrEmpty(passengerid[i]))
                        continue;

                    passengerDataFile.WriteLine($"{passengerid[i]},{passengername[i]},{passengerSpoint[i]},{passengerDpoint[i]},{bookedseats[i]}");
                }
            }
        }

        static void readpassengerdata(ref string[] passengerid, ref string[] passengername, ref string[] passengerSpoint, ref string[] passengerDpoint, ref string[] bookedseats, ref int passcount)
        {
            using (StreamReader data = new StreamReader("passengerdata.txt"))
            {
                string record;
                while ((record = data.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(record))
                        continue;

                    passengerid[passcount] = getField(record, 1);
                    passengername[passcount] = getField(record, 2);
                    passengerSpoint[passcount] = getField(record, 3);
                    passengerDpoint[passcount] = getField(record, 4);
                    bookedseats[passcount] = getField(record, 5);
                    passcount++;
                }
            }
        }

        static void feedbackdatastore(ref string[] feedbackusername, ref string[] feedbackpoints, ref int fdcount)
        {
            using (StreamWriter feedbackDataFile = new StreamWriter("feedbackdata.txt"))
            {
                for (int i = 0; i < fdcount; i++)
                {
                    if (string.IsNullOrEmpty(feedbackusername[i]))
                        continue;

                    feedbackDataFile.WriteLine($"{feedbackusername[i]},{feedbackpoints[i]}");
                }
            }
        }

        static void readfeedbackdata(ref string[] feedbackusername, ref string[] feedbackpoints, ref int fdcount)
        {
            using (StreamReader data = new StreamReader("feedbackdata.txt"))
            {
                string record;
                while ((record = data.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(record))
                        continue;

                    feedbackusername[fdcount] = getField(record, 1);
                    feedbackpoints[fdcount] = getField(record, 2);
                    fdcount++;
                }
            }
        }

        static void invalidinput()
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(15, 6);
            Console.WriteLine("-Homepage");
            Console.SetCursorPosition(25, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Input..");
            Console.ResetColor();
            Console.ReadKey();
            Environment.Exit(0);
        }
        static void emptysignuparrays(ref string[] username, ref string[] password, ref string[] role, ref int c)
        {
            username[c] = "";
            password[c] = "";
            role[c] = "";
        }

        static void busnotfound()
        {
            Console.SetCursorPosition(17, 13);
            Console.WriteLine("Buses are not added by admin. Press any key to continue");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            char counter;
            int max = 100;
            int c = 0;
            int count = 0;
            string[] username = new string[max];
            string[] password = new string[max];
            string[] role = new string[max];
            string[] busnumber = new string[max];
            string[] busname = new string[max];
            string[] busstartinglocation = new string[max];
            string[] busendinglocation = new string[max];
            string[] busdeparturetime = new string[max];
            string[] busarrivaltime = new string[max];
            string[] ticketprice = new string[max];
            int seats = 30;

            int passcount = 0;
            int fdcount = 0;
            string[] passengerid = new string[max];
            string[] passengername = new string[max];
            string[] feedbackusername = new string[max];
            string[] feedbackpoints = new string[max];
            string[] passengerSpoint = new string[max];
            string[] passengerDpoint = new string[max];
            string id = "";
            string Id1 = "";
            string Name1 = "";
            string uname = "";
            string newSlocation = "";
            string newDlocation = "";
            int idx = 30;
            string idd;
            string[] bookedseats = new string[max];
            string[] remainingseats = new string[max];
            int seatcount = 0;

            //readsignupdata(username, password, role, ref c);
            //readbusdatabyadmin(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, ref count);
            //readpassengerdata(passengerid, passengername, passengerSpoint, passengerDpoint, bookedseats, ref passcount);
            //readfeedbackdata(feedbackusername, feedbackpoints, ref fdcount);

            while (true)
            {
                Console.Clear();
                header();

                Console.SetCursorPosition(13, 9);
                Console.Write("-Home");
                Console.SetCursorPosition(17, 12);
                Console.WriteLine("1.Sign Up");
                Console.SetCursorPosition(17, 14);
                Console.WriteLine("2.Sign In");
                Console.SetCursorPosition(17, 16);
                Console.WriteLine("3.Exit");
                Console.SetCursorPosition(17, 18);
                Console.WriteLine("Enter a number to continue...");
                Console.SetCursorPosition(46, 18);
                counter = Console.ReadKey().KeyChar;
               /* Console.Read();*/

                switch (counter)
                {
                    case '1':
                        signupmain(ref username,ref  password,ref role, ref c);
                       break;
                //    case '2':
                       /* signinmain(username, password, role, ref c, busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, seats,ref max, ref count, passengerid, passengername, passengerSpoint, passengerDpoint, bookedseats, remainingseats, feedbackusername, feedbackpoints, ref fdcount, ref newSlocation, ref newDlocation, ref idd, ref id, ref Id1, ref uname, ref Name1, ref seatcount, ref passcount);*/
                //        break;
                //    case '3':
                //        adminbusdatastore(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, ref count);
                //        passengerdatastore(passengerid, passengername, passengerSpoint, passengerDpoint, bookedseats, ref passcount);
                //        Console.Clear();
                //        return;
                //    default:
                //        invalidinput();
                //        break;
                }
            }

        }
        static void signupmain(ref string[] username, ref string[] password, ref string[] role, ref int c)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 9);
            Console.WriteLine("-Home>SignUpPage");
            Console.SetCursorPosition(17, 12);
            Console.WriteLine("Enter username(only use alphabets and numbers): ");
            username[c] = Console.ReadLine();
           /* Console.WriteLine();*/
            Console.SetCursorPosition(17, 13);
            Console.Write("Enter password(with length of 8): ");
            password[c] = Console.ReadLine();
            /*Console.WriteLine();*/
            Console.SetCursorPosition(17, 14);
            Console.Write("Enter role(admin or passenger): ");
            role[c] = Console.ReadLine();
            /*Console.WriteLine();*/
            Console.SetCursorPosition(17, 16);
            Console.WriteLine(signup(ref username, ref password, ref role, ref c));
            Console.ReadKey();
        }
        static string signup(ref string[] username, ref string[] password, ref string[] role, ref int c)
        {
            if ((role[c] == "admin" || role[c] == "passenger") && checknamevalidation(username[c]) && checkpassword(password[c]))
            {
                for (int j = 0; j < c; j++)
                {
                    if (c >= 1 && username[c] == username[j])
                    {
                        emptysignuparrays(ref username, ref password, ref role, ref c);
                        return "Already exist ...";
                    }
                }
                signupdatastore(ref username, ref password, ref role, ref c);
                c++;
                return "Registered successfully. Press any key to continue.";
            }
            else if (!(checknamevalidation(username[c])))
            {
                emptysignuparrays(ref username, ref password, ref role, ref c);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid Username...";
                Console.ResetColor();
            }
            else if (!(checkpassword(password[c])))
            {
                emptysignuparrays(ref username, ref password, ref role, ref c);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid Password...";
                Console.ResetColor();
            }
            else if (role[c] != "admin" && role[c] != "passenger")
            {
                emptysignuparrays(ref username, ref password, ref role, ref c);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid role...";
                Console.ResetColor();
            }
            else
            {
                emptysignuparrays(ref username, ref password, ref role, ref c);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Not registered";
                Console.ResetColor();
            }
        }
    }
}
