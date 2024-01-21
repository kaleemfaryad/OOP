using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firstlaboop
{
    internal class Program
    {
        static void header()
        {

            Console.WriteLine("\n");
            Console.WriteLine("______________________________________***************************_____________________________________\n");
            Console.WriteLine("                                                                                                      \n");
            Console.WriteLine("                                         BUS MANAGEMENT SYSTEM                                        \n");
            Console.WriteLine("                                                                                                      \n");
            Console.WriteLine("--------------------------------------***************************------------------------------------\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

        }

        static bool checkNamevalidation(string username)
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

        static bool Validbusid(string busId)
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

        static bool validpassengerd(string passengerId)
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

        static void signupdatastore(string[] username, string[] password, string[] role, ref int c)
        {
            using (StreamWriter signupFile = new StreamWriter("signup.txt"))
            {
                for (int i = 0; i < c; i++)
                {
                    if (string.IsNullOrEmpty(usernames[i]))
                        continue;

                    signupFile.WriteLine($"{usernames[i]},{passwords[i]},{roles[i]}");
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

        static void readsignupData(string[] username, string[] password, string[] role, ref int c)
        {
            using (StreamReader data = new StreamReader("signup.txt"))
            {
                string record;
                while ((record = data.ReadLine()) != null)
                {
                    usernames[c] = GetField(record, 1);
                    passwords[c] = GetField(record, 2);
                    roles[c] = GetField(record, 3);
                    c++;
                }
            }
        }

        static void adminbusdatastore(string[] busnumber, string[] busname, string[] busstartinglocation, string[] busendinglocation, string[] busdeparturetime, string[] busarrivaltime, string[] ticketprice, ref int count)
        {
            using (StreamWriter busDataFile = new StreamWriter("busdatabyadmin.txt"))
            {
                for (int i = 0; i < count; i++)
                {
                    if (string.IsNullOrEmpty(busNumbers[i]))
                        continue;

                    busDataFile.WriteLine($"{busnumber[i]},{busname[i]},{busstartinglocation[i]},{busendinglocation[i]},{busdeparturetime[i]},{busarrivaltime[i]},{ticketprice[i]}");
                }
            }
        }

        static void readbusdatabyadmin(string[] busnumber, string[] busname, string[] busstartinglocation, string[] busendinglocation, string[] busdeparturetime, string[] busarrivaltime, string[] ticketprice, ref int count)
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

        static void passengerdatastore(string[] passengerid, string[] passengername, string[] passengerSpoint, string[] passengerDpoint, string[] bookedseats, ref int passcount)
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

        static void readpassengerdata(string[] passengerid, string[] passengername, string[] passengerSpoint, string[] passengerDpoint, string[] bookedseats, ref int passcount)
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

        static void feedbackdatastore(string[] feedbackusername, string[] feedbackpoints, ref int fdcount)
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

        static void readfeedbackdata(string[] feedbackusername, string[] feedbackpoints, ref int fdcount)
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

        static void help()
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-Passenger HelpMenu");
            Console.SetCursorPosition(15, 8);
            Console.WriteLine("By Pressing 1 you can view all buses timetables that can be added by the admin.");
            Console.SetCursorPosition(15, 9);
            Console.WriteLine("By Pressing 2 you can book a ticket by adding your personal information and selecting a ticket.");
            Console.SetCursorPosition(15, 10);
            Console.WriteLine("By Pressing 3 you can view your ticket details.");
            Console.SetCursorPosition(15, 11);
            Console.WriteLine("By Pressing 4 you can edit or change your ticket.");
            Console.SetCursorPosition(15, 12);
            Console.WriteLine("By Pressing 5 you can cancel your ticket.");
            Console.SetCursorPosition(15, 13);
            Console.WriteLine("By Pressing 6 you can view your journey bus detail.");
            Console.SetCursorPosition(15, 14);
            Console.WriteLine("By Pressing 7 you can share your review about our application.");
            Console.SetCursorPosition(15, 18);
            Console.WriteLine("By pressing any key you can go back to the home page.");
            Console.ReadKey();
        }

        static void emptysignuparrays(string[] username, string[] password, string[] role, ref int c)
        {
            usernames[c] = "";
            passwords[c] = "";
            roles[c] = "";
        }

        static void busnotfound()
        {
            Console.SetCursorPosition(17, 13);
            Console.WriteLine("Buses are not added by admin. Press any key to continue");
            Console.ReadKey();
        }

        static int signIncheck(string name, string pass, string[] username, string[] password, string[] role, ref int c)
        {
            for (int i = 0; i < c; i++)
            {
                if (name == usernames[i] && pass == passwords[i])
                {
                    return i;
                }
            }
            return -1;
        }

        static void signuprecordnotfound()
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(14, 6);
            Console.WriteLine("-Home>SignInPage");
            Console.SetCursorPosition(15, 9);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Record not found! Please sign up first...");
            Console.ResetColor();
            Console.ReadKey();
        }

        static string editpassenger(ref string id, ref string uname, string[] busstartinglocation, string[] busendinglocation, ref string newSlocation, ref string newDlocation, string[] passengerid, string[] passengername, string[] passengerSpoint, string[] passengerDpoint, ref int passcount, ref int count)
        {
            for (int i = 0; i < passcount; i++)
            {
                if (id == passengerid[i] && uname == passengername[i] && newSlocation == busstartinglocation[i] && newDlocation == busendinglocation[i])
                {
                    passengerSpoint[i] = newSlocation;
                    passengerDpoint[i] = newDlocation;

                    return $"\tPassengerid: \t\t{passengerid[i]}\n" +
                           $"\tPassengerName: \t\t{passengername[i]}\n" +
                           $"\tPassSpoint: \t\t{passengerSpoint[i]}\n" +
                           $"\tPassDpoint: \t\t{passengerDpoint[i]}";
                }
            }

            return "not exist";
        }

        static void passengerinfoemptyarrays(ref string[] passengerid,ref string[] passengername, ref int passcount)
        {
            passengerid[passcount] = "";
            passengername[passcount] = "";
        }


        static bool checkseats(ref string[] bookedseats, ref int passcount)
        {
            for (int i = 0; i < passcount; i++)
            {
                if (passcount >= 1 && bookedseats[passcount] == bookedseats[i])
                {
                    return false;
                }
            }
            return true;
        }

        static void ticketdetails(ref string[] passengerid,ref string[] passengername,ref string[] passengerSpoint,ref string[] passengerDpoint,ref string[] bookedseats, ref int passcount)
        {
            for (int i = 0; i < passcount; i++)
            {
                Console.SetCursorPosition(40, 10);
                Console.WriteLine(passengerid[i]);
                Console.SetCursorPosition(40, 11);
                Console.WriteLine(passengername[i]);
                Console.SetCursorPosition(40, 12);
                Console.WriteLine(passengerSpoint[i]);
                Console.SetCursorPosition(40, 13);
                Console.WriteLine(passengerDpoint[i]);
                Console.SetCursorPosition(40, 14);
                Console.WriteLine(bookedseats[i]);
            }
        }

        static string cancelticket(ref string id1, ref string name1,ref string[] passengerid,ref string[] passengername,ref string[] passengerSpoint,ref string[] passengerDpoint, ref int passcount)
        {
            for (int i = 0; i < passcount; i++)
            {
                if (id1 == passengerid[i] && name1 == passengername[i])
                {
                    passengerid[i] = "";
                    passengername[i] = "";
                    passengerSpoint[i] = "";
                    passengerDpoint[i] = "";
                    return "Your ticket cancelled successfully...";
                }
            }
            return "not exist";
        }

        static void viewfeedback(ref string[] feedbackusername,ref string[] feedbackpoint, ref int fdcount)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-Admin Menu>Feedback List");
            Console.SetCursorPosition(14, 8);
            Console.WriteLine("NAME:     POINTS:   ");
            for (int j = 0; j < fdcount; j++)
            {
                Console.WriteLine($"\t{feedbackusername[j],-10} {feedbackpoint[j],-11}");
            }
            Console.WriteLine("\tPress any key to continue...");
            Console.ReadKey();
        }

        static bool checkbusdetails(ref string[] passengerid,ref string[] passengername,ref string[] passengerSpoint,ref string[] passengerDpoint,ref string[] busnumber,ref string[] busname,ref string[] busstartinglocation,ref string[] busendinglocation,ref string[] busdeparturetime,ref string[] busarrivaltime,ref string[] ticketprice,ref string[] bookedseats, ref string idd, ref int count, ref int passcount)
        {
            for (int i = 0; i < passcount; i++)
            {
                if (idd == passengerid[i])
                {
                    return true;
                }
            }
            return false;
        }

        static void busdetailsop(ref string[] passengerid,ref string[] passengername,ref string[] busNumber,ref string[] busName,ref string[] passengerSpoint,ref string[] passengerDpoint,ref string[] busdeparturetime,ref string[] busarrivaltime,ref string[] bookedseats,ref string[] ticketprice, ref string idd, ref int count, ref int passcount)
        {
            for (int i = 0; i < passcount; i++)
            {
                Console.SetCursorPosition(70, 10);
                Console.WriteLine(passengerid[i]);
                Console.SetCursorPosition(70, 11);
                Console.WriteLine(passengername[i]);
                Console.SetCursorPosition(70, 12);
                Console.WriteLine(busnumber[i]);
                Console.SetCursorPosition(70, 13);
                Console.WriteLine(busname[i]);
                Console.SetCursorPosition(70, 14);
                Console.WriteLine(passengerSpoint[i]);
                Console.SetCursorPosition(70, 15);
                Console.WriteLine(passengerDpoint[i]);
                Console.SetCursorPosition(70, 16);
                Console.WriteLine(busdeparturetime[i]);
                Console.SetCursorPosition(70, 17);
                Console.WriteLine(busarrivaltime[i]);
                Console.SetCursorPosition(70, 18);
                Console.WriteLine(bookedseats[i]);
                Console.SetCursorPosition(70, 19);
                Console.WriteLine(ticketprice[i]);
            }
        }

        static void PassList(string[] passengerIds, string[] passengerNames, string[] busNumbers, string[] busNames, string[] passengerSPoints, string[] passengerDPoints, string[] busDepartureTime, string[] busArrivalTime, string[] bookedSeats, ref string idd, ref int count, ref int passCount)
        {
            int y = 12;
            for (int i = 0; i < passCount; i++)
            {
                Console.SetCursorPosition(10, y);
                Console.WriteLine(passengerIds[i]);
                Console.SetCursorPosition(20, y);
                Console.WriteLine(passengerNames[i]);
                Console.SetCursorPosition(30, y);
                Console.WriteLine(busNumbers[i]);
                Console.SetCursorPosition(40, y);
                Console.WriteLine(busNames[i]);
                Console.SetCursorPosition(50, y);
                Console.WriteLine(passengerSPoints[i]);
                Console.SetCursorPosition(60, y);
                Console.WriteLine(passengerDPoints[i]);
                Console.SetCursorPosition(70, y);
                Console.WriteLine(busDepartureTime[i]);
                Console.SetCursorPosition(80, y);
                Console.WriteLine(busArrivalTime[i]);
                Console.SetCursorPosition(90, y);
                Console.WriteLine(bookedSeats[i]);
                y++;
            }
        }

        static void NotStoreNewBus(string[] busNumbers, string[] busNames, string[] busStartingLocations, string[] busEndingLocations, string[] busDepartureTime, string[] busArrivalTime, string[] ticketPrices, ref int count)
        {
            int currentCount = count;

            busNumbers[currentCount] = "";
            busNames[currentCount] = "";
            busStartingLocations[currentCount] = "";
            busEndingLocations[currentCount] = "";
            busDepartureTime[currentCount] = "";
            busArrivalTime[currentCount] = "";
            ticketPrices[currentCount] = "";
        }

        static string SearchBusOp(string number, string name, string[] busNumbers, string[] busNames, string[] busStartingLocations, string[] busEndingLocations, string[] busDepartureTime, string[] busArrivalTime, string[] ticketPrices, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (number == busNumbers[i] && name == busNames[i])
                {
                    return "\t\tBUS NO:\t\t\t\t\t\t\t" + busNumbers[i] + "\n" +
                           "\t\tBUSNAME:\t\t\t\t\t\t" + busNames[i] + "\n" +
                           "\t\tBUSDEPTERMINAL:\t\t\t\t\t" + busStartingLocations[i] + "\n" +
                           "\t\tBUSDESTINATION:\t\t\t\t\t" + busEndingLocations[i] + "\n" +
                           "\t\tBUSDEPTIME:\t\t\t\t\t\t" + busDepartureTime[i] + "\n" +
                           "\t\tBUSARRTIME:\t\t\t\t\t\t" + busArrivalTime[i] + "\n" +
                           "\t\tTICKETPRICE:\t\t\t\t\t\t" + ticketPrices[i];
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            return "not exist";
        }

        static string RecordNotFound()
        {
            Console.SetCursorPosition(15, 20);
            Console.ForegroundColor = ConsoleColor.Red;
            return "Record not exist. Press any key to continue";
        }

        static string DeleteBusOp(ref string number, ref string sroute, ref string eroute, string[] busNumbers, string[] busNames, string[] busStartingLocations, string[] busEndingLocations, string[] busDepartureTime, string[] busArrivalTime, string[] ticketPrices, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (number == busNumbers[i])
                {
                    busNumbers[i] = "";
                    busNames[i] = "";
                    busStartingLocations[i] = "";
                    busEndingLocations[i] = "";
                    busDepartureTime[i] = "";
                    busArrivalTime[i] = "";
                    ticketPrices[i] = "";

                    return "Bus record successfully deleted...";
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            return "not exist";
        }

        static void ViewMenu(string[] busNumbers, string[] busNames, string[] busStartingLocations, string[] busEndingLocations, string[] busDepartureTime, string[] busArrivalTime, string[] ticketPrices, string[] bookedSeats, string[] remainingSeats, int seats, int count)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-Admin Menu>BusesList");
            Console.SetCursorPosition(14, 8);
            Console.WriteLine("BUSNO:\t\tBUSNAME:\tBUSDEPTERMINAL:\tBUSTARTERMINAL:\tBUSDEPTIME:\tBUSARRTIME:\tPRICE:\tREMAINING SEATS:");

            for (int j = 0; j < count; j++)
            {
                Console.WriteLine($"\t{busNumbers[j],-10}{busNames[j],-11}{busStartingLocations[j],-15}{busEndingLocations[j],-19}{busDepartureTime[j],-16}{busArrivalTime[j],-16}{ticketPrices[j],-16}{remainingSeats[j],-16}");
            }

            Console.WriteLine("\tPress any key to continue...");
            Console.ReadKey();
        }

        static string ChangePriceOp(ref string number, ref string newPrice, string[] busNumbers, string[] busNames, string[] busStartingLocations, string[] busEndingLocations, string[] busDepartureTime, string[] busArrivalTime, string[] ticketPrices, int count)
        {
            if (ValidBusId(newPrice))
            {
                for (int i = 0; i < count; i++)
                {
                    if (number == busNumbers[i])
                    {
                        busNumbers[i] = number;
                        ticketPrices[i] = newPrice;

                        return $"\t\tBUSNO:\t\t\t\t\t{busNumbers[i]}\n\t\tNEWTICPRICE:\t\t\t\t{ticketPrices[i]}";
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                return "not exist";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid Input";
            }
        }

        static void ChangePrice(string[] busNumbers, string[] busNames, string[] busStartingLocations, string[] busEndingLocations, string[] busDepartureTime, string[] busArrivalTime, string[] ticketPrices, int count)
        {

            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-Admin Menu>changePriceOfTicket");
            Console.SetCursorPosition(15, 8);
            Console.Write("Enter the number of the bus (that contains only numbers): ");
            string number = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 9);
            Console.Write("Enter the new price per ticket (that contains only numbers): ");
            string newPrice = Console.ReadLine();
            Console.WriteLine();
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-Admin Menu>changePriceOfTicket");
            Console.SetCursorPosition(14, 10);
            Console.WriteLine(ChangePriceOp(number, newPrice, busNumbers, busNames, busStartingLocations, busEndingLocations, busDepartureTime, busArrivalTime, ticketPrices, count));
            Console.ReadKey();
        }

        static string ChangeTimeOp(ref string number, ref string departureTime, ref string arrivalTime, string[] busNumbers, string[] busDepartureTime, string[] busArrivalTime, int count)
        {
            if (CheckBusTimeValidation(departureTime) && CheckBusTimeValidation(arrivalTime))
            {
                for (int i = 0; i < count; i++)
                {
                    if (number == busNumbers[i])
                    {
                        busNumbers[i] = number;
                        busDepartureTime[i] = departureTime;
                        busArrivalTime[i] = arrivalTime;

                        return $"\t\tBUSNO:\t\t\t\t\t\t\t{busNumbers[i]}\n\t\tBUSDEPTIME:\t\t\t\t\t\t{busDepartureTime[i]}\n\t\tBUSARRTIME:\t\t\t\t\t\t{busArrivalTime[i]}";
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                return "not exist";
            }
            else if (!CheckBusTimeValidation(departureTime))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid departure time";
            }
            else if (!CheckBusTimeValidation(arrivalTime))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid arrival time";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid input";
            }
        }

        static void ChangeTime(string[] busNumbers, string[] busNames, string[] busStartingLocations, string[] busEndingLocations, string[] busDepartureTime, string[] busArrivalTime, string[] ticketPrices, ref int count)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-Admin Menu>changeTimeOfBus");
            Console.SetCursorPosition(15, 8);
            Console.Write("Enter the number of the bus (that contains only numbers): ");
            string number = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 9);
            Console.Write("Enter the new departure time of the bus (as 1pm): ");
            string departureTime = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 10);
            Console.Write("Enter the new arrival time of the bus (as 2pm): ");
            string arrivalTime = Console.ReadLine();
            Console.WriteLine();
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-Admin Menu>changeTimeOfBus");
            Console.SetCursorPosition(14, 10);
            Console.WriteLine(ChangeTimeOp(number, departureTime, arrivalTime, busNumbers, busDepartureTime, busArrivalTime, count));
            Console.ReadKey();
        }

        static void UpdateBusOp(ref string number, ref string name, ref string sroute, ref string eroute, ref string dtime, ref string atime, ref string newprice, string[] busNumbers, string[] busNames, string[] busStartingLocations, string[] busEndingLocations, string[] busDepartureTime, string[] busArrivalTime, string[] ticketPrices, int count)
        {
            if (ValidBusId(number) && CheckNameValidation(name) && BusRouteValidation(sroute) && BusRouteValidation(eroute) && CheckBusTimeValidation(dtime) && CheckBusTimeValidation(atime) && IsValidBusId(newprice))
            {
                for (int i = 0; i < count; i++)
                {
                    if (number == busNumbers[i])
                    {
                        busNumbers[i] = number;
                        busNames[i] = name;
                        busStartingLocations[i] = sroute;
                        busEndingLocations[i] = eroute;
                        busDepartureTime[i] = dtime;
                        busArrivalTime[i] = atime;
                        ticketPrices[i] = newprice;

                        Console.WriteLine($"\t\tBUS NO:\t\t\t\t\t\t\t{busNumbers[i]}\n\t\tBUSNAME:\t\t\t\t\t\t{busNames[i]}\n\t\tBUSDEPTERMINAL:\t\t\t\t\t{busStartingLocations[i]}\n\t\tBUSDESTINATION:\t\t\t\t{busEndingLocations[i]}\n\t\tBUSDEPTIME:\t\t\t\t\t\t{busDepartureTime[i]}\n\t\tBUSARRTIME:\t\t\t\t\t\t{busArrivalTime[i]}\n\t\tTICKETPRICE:\t\t\t\t\t{ticketPrices[i]}");
                        return;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("not exist");
                Console.ResetColor();
            }
            else if (!CheckNameValidation(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid username");
                Console.ResetColor();
            }
            else if (!BusRouteValidation(sroute))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid starting location");
                Console.ResetColor();
            }
            else if (!BusRouteValidation(eroute))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ending location");
                Console.ResetColor();
            }
            else if (!CheckBusTimeValidation(dtime))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid departure time");
                Console.ResetColor();
            }
            else if (!CheckBusTimeValidation(atime))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arrival time");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ticket price");
                Console.ResetColor();
            }
        }

        static void DeleteBus(string[] busNumbers, string[] busNames, string[] busStartingLocations, string[] busEndingLocations, string[] busDepartureTime, string[] busArrivalTime, string[] ticketPrices, ref int max, ref int count)
        {
            string number;
            string sroute;
            string eroute;

            Console.Clear();
            header();
            Console.WriteLine("-Admin Menu>DeleteBus");
            Console.Write("Enter the number of the bus(that contain only numbers): ");
            number = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the name of the bus: ");
            sroute = Console.ReadLine();
            Console.WriteLine();

            Console.Clear();
            header();
            Console.WriteLine("-Admin Menu>DeleteBus");
            Console.WriteLine(DeleteBusOp(number, sroute, eroute, busNumbers, busNames, busStartingLocations, busEndingLocations, busDepartureTime, busArrivalTime, ticketPrices, count));

            Console.ReadKey();
        }

        static void UpdateBus(string[] busnumber, string[] busname, string[] busstartinglocation, string[] busendinglocation, string[] busdeparturetime, string[] busarrivaltime, string[] ticketprice, ref int max, ref int count)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-Admin Menu>UpdateBus");
            Console.SetCursorPosition(15, 8);
            Console.Write("Enter the number of the bus(that contain only digits): ");
            string number = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 9);
            Console.Write("Enter the name of the bus: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 10);
            Console.Write("Enter the starting terminal of the new route of the bus: ");
            string sroute = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 11);
            Console.Write("Enter the ending terminal of the new route of the bus: ");
            string eroute = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 12);
            Console.Write("Enter the departure time of the new route of the bus(as 1pm): ");
            string dtime = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 13);
            Console.Write("Enter the arrival time of the new route of the bus(as 2pm): ");
            string atime = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 14);
            Console.Write("Enter the ticket price of the new route of the bus(that contain only digits): ");
            string newprice = Console.ReadLine();
            Console.WriteLine();
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-UpdatedBus");
            Console.SetCursorPosition(15, 10);
            Console.WriteLine(UpdateBusOp(number, name, sroute, eroute, dtime, atime, newprice, busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, max, count));
            Console.ReadKey();
        }

        static void SearchBus(string[] busnumber, string[] busname, string[] busstartinglocation, string[] busendinglocation, string[] busdeparturetime, string[] busarrivaltime, string[] ticketprice, ref int max, ref int count)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-Admin Menu>SearchBus");
            Console.SetCursorPosition(15, 8);
            Console.Write("Enter the number of the bus(that contain only numbers): ");
            string number = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 9);
            Console.Write("Enter the name of the bus: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-Admin Menu>SearchBus");
            Console.SetCursorPosition(15, 10);
            Console.WriteLine(SearchBusOp(number, name, busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, max, ref count));
            Console.ReadKey();
        }

        static string BusCheck(string[] busnumber, string[] busname, string[] busstartinglocation, string[] busendinglocation, string[] busdeparturetime, string[] busarrivaltime, string[] ticketprice, ref int max, ref int count)
        {
            if (((ValidBusId(busnumber[count]) && CheckNameValidation(busname[count])) && ((BusRouteValidation(busstartinglocation[count]) && BusRouteValidation(busendinglocation[count])) && ((CheckBusTimeValidation(busdeparturetime[count]) && CheckBusTimeValidation(busarrivaltime[count])) && ValidBusId(ticketprice[count]))))
            {
                for (int i = 0; i < count; i++)
                {
                    if (count >= 1 && busnumber[count] == busnumber[i])
                    {
                        NotStoreNewBus(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, count);
                        return "Already exist ...";
                    }
                }
                // AdminBusDataStore(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, count);
                count++;
                return "Bus has been added....";
            }
            else if (!ValidBusId(busnumber[count]))
            {
                NotStoreNewBus(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, count);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid Bus number";
            }
            else if (!CheckNameValidation(busname[count]))
            {
                NotStoreNewBus(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, count);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid Bus name";
            }
            else if (!BusRouteValidation(busstartinglocation[count]))
            {
                NotStoreNewBus(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, count);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid Bus starting location";
            }
            else if (!BusRouteValidation(busendinglocation[count]))
            {
                NotStoreNewBus(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, count);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid Bus ending location";
            }
            else if (!CheckBusTimeValidation(busdeparturetime[count]))
            {
                NotStoreNewBus(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, count);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid Bus departure time";
            }
            else if (!CheckBusTimeValidation(busarrivaltime[count]))
            {
                NotStoreNewBus(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, count);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid Bus arrival time";
            }
            else if (!ValidBusId(ticketprice[count]))
            {
                NotStoreNewBus(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, count);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid Bus ticket price";
            }
            else
            {
                NotStoreNewBus(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, count);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Bus is not added...";
            }
        }

        static void NewBus(string[] busnumber, string[] busname, string[] busstartinglocation, string[] busendinglocation, string[] busdeparturetime, string[] busarrivaltime, string[] ticketprice, ref int max, ref int count)
        {
            bool checkId = true;
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-Admin Menu>InsertBus");
            // while(checkId){
            Console.SetCursorPosition(15, 8);
            Console.Write("Enter the number of the bus(that contains only digits): ");
            busnumber[count] = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 9);
            Console.Write("Enter the name of the bus: ");
            busname[count] = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 10);
            Console.Write("Enter starting terminal of bus: ");
            busstartinglocation[count] = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 11);
            Console.Write("Enter ending terminal of bus: ");
            busendinglocation[count] = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 12);
            Console.Write("Enter the bus departure time(as 1pm): ");
            busdeparturetime[count] = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 13);
            Console.Write("Enter the arrival time of bus(as 1pm): ");
            busarrivaltime[count] = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 14);
            Console.Write("Enter the price per ticket of a bus(that contain only digits): Rs.");
            ticketprice[count] = Console.ReadLine();
            Console.WriteLine();

            Console.SetCursorPosition(19, 16);
            Console.WriteLine(BusCheck(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, max, ref count));
            Console.WriteLine();
            Console.SetCursorPosition(15, 25);
            Console.ReadKey();
        }

        static void ViewPassengerList(string[] busnumber, string[] busname, string[] busstartinglocation, string[] busendinglocation, string[] busdeparturetime, string[] busarrivaltime, string[] ticketprice, int seats, int max, ref int count, string[] passengerid, string[] passengername, string[] passengerSpoint, string[] passengerDpoint, string[] bookedseats, string[] remainingseats, string[] feedbackusername, string[] feedbackpoints, ref string newSlocation, ref string newDlocation, ref string idd, ref string id, ref string Id1, ref string uname, ref string Name1, ref int seatcount, ref int passcount)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(45, 6);
            Console.WriteLine("Passenger List");
            Console.SetCursorPosition(10, 10);
            Console.Write("I'D No: ");
            Console.SetCursorPosition(20, 10);
            Console.Write("Your Name: ");
            Console.SetCursorPosition(30, 10);
            Console.Write("Bus Num: ");
            Console.SetCursorPosition(40, 10);
            Console.Write("Bus Name: ");
            Console.SetCursorPosition(50, 10);
            Console.Write("StartPoint: ");
            Console.SetCursorPosition(60, 10);
            Console.Write("Destination: ");
            Console.SetCursorPosition(70, 10);
            Console.Write("Dep.Time: ");
            Console.SetCursorPosition(80, 10);
            Console.Write("ArrivalTime:");
            Console.SetCursorPosition(90, 10);
            Console.Write("SeatNo:");

            PassList(passengerid, passengername, passengerSpoint, passengerDpoint, busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, bookedseats, ref idd, count, ref passcount);

            Console.ReadKey();
        }

        static void busdetailsconditioncheck(ref string[] passengerid,ref string[] passengername,ref string[] passengerSpoint,ref string[] passengerDpoint,ref string[] busnumber,ref string[] busname,ref string[] busstartinglocation,ref string[] busendinglocation,ref string[] busdeparturetime,ref string[] busarrivaltime,ref string[] ticketprice,ref string[] bookedseats, ref int count, ref int passcount, ref string idd)
        {
            if (checkbusDetails(passengerid, passengername, passengerSpoint, passengerDpoint, busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, bookedseats, ref idd, ref count, ref passcount))
            {
                Console.Clear();
                header();
                Console.SetCursorPosition(45, 6);
                Console.WriteLine("Your Ticket Slip");
                Console.SetCursorPosition(30, 10);
                Console.Write("I'D No: ");
                Console.SetCursorPosition(30, 11);
                Console.Write("Your Name: ");
                Console.SetCursorPosition(30, 12);
                Console.Write("Bus Num: ");
                Console.SetCursorPosition(30, 13);
                Console.Write("Bus Name: ");
                Console.SetCursorPosition(30, 14);
                Console.Write("Starting Point: ");
                Console.SetCursorPosition(30, 15);
                Console.Write("Destination: ");
                Console.SetCursorPosition(30, 16);
                Console.Write("Departure Time: ");
                Console.SetCursorPosition(30, 17);
                Console.Write("Arrival Time: ");
                Console.SetCursorPosition(30, 18);
                Console.Write("Seat Num:  ");
                Console.SetCursorPosition(30, 19);
                Console.Write("Price:  ");
                busdetailsop(passengerid, passengername, passengerSpoint, passengerDpoint, busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, bookedseats, ref idd, ref count, ref passcount);
                Console.SetCursorPosition(45, 22);
                Console.WriteLine("Thank You ...");
            }
            else
            {
                Console.SetCursorPosition(40, 10);
                Console.WriteLine("Record not exist...");
            }
        }

        static void busdetails(ref string[] passengerid,ref string[] passengername,ref  string[] passengerSpoint,ref  string[] passengerDpoint,ref string[] busnumber,ref string[] busname,ref string[] busstartinglocation,ref string[] busendinglocation,ref string[] busdeparturetime,ref string[] busarrivaltime,ref string[] ticketprice,ref string[] bookedseats, ref int count, ref int passcount, ref string idd)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(45, 6);
            Console.WriteLine("Your Ticket Slip");
            Console.SetCursorPosition(15, 8);
            Console.Write("Enter your I'D Card No: ");
            idd = Console.ReadLine();
            busdetailsconditioncheck(passengerid, passengername, passengerSpoint, passengerDpoint, busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, bookedseats, ref count, ref passcount, ref idd);

            Console.ReadKey();
        }

        static void feedback(ref string[] feedbackusername,ref string[] feedbackpoints,ref string[] passengername, ref int passcount, ref int fdcount)
        {
            Console.Write("Rate our services (out of 5): ");
            feedbackpoints[fdcount] = Console.ReadLine();
            Console.WriteLine();

            if (validfeedbackpoints(feedbackpoints[fdcount]))
            {
                Console.SetCursorPosition(25, 13);
                feedbackdatastore(feedbackusername, feedbackpoints, ref fdcount);
                fdcount++;
                Console.WriteLine("Thank You for your feedback...");
            }
            else
            {
                invalidinput();
            }

            Console.ReadKey();
        }

        static void userfeedback(ref string[] feedbackusername,ref string[] feedbackpoints, ref string[] passengername, ref int passcount, ref int fdcount)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(28, 6);
            Console.WriteLine("User Feedback");
            Console.SetCursorPosition(15, 8);
            Console.Write("Enter your name: ");
            feedbackusername[fdcount] = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 10);
            feedback(feedbackusername, feedbackpoints, passengername, ref passcount, ref fdcount);
        }

        static void delticket(ref string Id1, ref string Name1,ref string[] passengerid,ref string[] passengername,ref string[] passengerSpoint,ref string[] passengerDpoint, ref int passcount)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(15, 8);
            Console.Write("Enter your I'D card No: ");
            Id1 = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 9);
            Console.Write("Enter your name: ");
            Name1 = Console.ReadLine();
            Console.WriteLine();
            Console.Clear();
            header();
            Console.SetCursorPosition(18, 10);
            Console.WriteLine(cancelticket(ref Id1,ref Name1, passengerid, passengername, passengerSpoint, passengerDpoint, ref passcount));
            Console.ReadKey();
        }

        static void ticketview(ref string[] passengerid,ref string[] passengername,ref string[] passengerSpoint,ref string[] passengerDpoint,ref string[] bookedseats, ref int passcount)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(25, 7);
            Console.WriteLine("Your Ticket\n\n");
            Console.SetCursorPosition(15, 10);
            Console.Write("I'D No: ");
            Console.SetCursorPosition(15, 11);
            Console.Write("Name: ");
            Console.SetCursorPosition(15, 12);
            Console.Write("Starting Point: ");
            Console.SetCursorPosition(15, 13);
            Console.Write("Destination: ");
            Console.SetCursorPosition(15, 14);
            Console.Write("Seat Num:  ");
            ticketdetails(passengerid, passengername, passengerSpoint, passengerDpoint, bookedseats, ref passcount);
            Console.ReadKey();
        }

        static string passengerseatconfirmation(ref string[] passengerid,ref string[] passengername,ref string[] passengerSpoint,ref string[] passengerDpoint,ref string[] busstartinglocation,ref string[] busendinglocation,ref string[] bookedseats,ref string[] remainingseats, ref int count, ref int passcount)
        {
            int num;
            int newnum;

            if (checkseats(bookedseats, passcount))
            {
                passengerdatastore(passengerid, passengername, passengerSpoint, passengerDpoint, bookedseats, ref passcount);
                num = int.Parse(bookedseats[passcount]);
                newnum = num - 30;
                remainingseats[passcount] = newnum.ToString();
                passcount++;
                return "Your seat is successfully booked...";
            }
            else
            {
                for (int i = 0; i <= passcount; i++)
                {
                    passengerid[i] = "";
                    passengername[i] = "";
                    passengerSpoint[i] = "";
                    passengerDpoint[i] = "";
                    bookedseats[i] = "";
                    return "Selected seat is already booked.";
                }
            }
        }

        static void passengerrouteconfirmation(ref string[] passengerid,ref  string[] passengername,ref string[] passengerSpoint,ref string[] passengerDpoint,ref string[] busstartinglocation,ref string[] busendinglocation,ref string[] bookedseats,ref string[] remainingseats, ref int count, ref int passcount)
        {
            for (int i = 0; i < count; i++)
            {
                if (passengerSpoint[passcount] == busstartinglocation[i] && passengerDpoint[passcount] == busendinglocation[i])
                {
                    Console.Write("Enter seat no. that you want to buy: ");
                    bookedseats[passcount] = Console.ReadLine();
                    Console.WriteLine();

                    if (validbusid(bookedseats[passcount]))
                    {
                        Console.SetCursorPosition(25, 13);
                        Console.WriteLine(passengerseatconfirmation(passengerid, passengername, passengerSpoint, passengerDpoint, busstartinglocation, busendinglocation, bookedseats, remainingseats, ref count, ref passcount));
                        break;
                    }
                    else
                    {
                        invalidinput();
                    }
                }
                else
                {
                    Console.SetCursorPosition(25, 13);
                    passengerid[passcount] = "";
                    passengername[passcount] = "";
                    passengerSpoint[passcount] = "";
                    passengerDpoint[passcount] = "";
                    Console.WriteLine("Bus is not exist ");
                }
            }
        }

        static void passengerroute(ref string[] passengerid,ref string[] passengername,ref string[] passengerSpoint,ref string[] passengerDpoint,ref string[] busstartinglocation,ref string[] busendinglocation,ref string[] bookedseats,ref string[] remainingseats, ref int count, ref int passcount)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(15, 8);
            Console.Write("Enter your starting location: ");
            passengerSpoint[passcount] = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 9);
            Console.Write("Enter your destination point: ");
            passengerDpoint[passcount] = Console.ReadLine();
            Console.WriteLine();

            if (busroutevalidation(passengerSpoint[passcount]) && busroutevalidation(passengerDpoint[passcount]))
            {
                Console.SetCursorPosition(15, 10);
                passengerrouteconfirmation(passengerid, passengername, passengerSpoint, passengerDpoint, busstartinglocation, busendinglocation, bookedseats, remainingseats, ref count, ref passcount);
            }
            else
            {
                Console.SetCursorPosition(15, 10);
                passengerid[passcount] = "";
                passengername[passcount] = "";
                passengerSpoint[passcount] = "";
                passengerDpoint[passcount] = "";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid route");
                Console.ResetColor();
            }

            Console.ReadKey();
        }

        static string passengerinfocheck(ref string[] passengerid,ref string[] passengername,ref int passcount)
        {
            if (validpassengerid(passengerid[passcount]) && checkNamevalidation(passengername[passcount]))
            {
                return "Successfully added...";
            }
            else if (!(validpassengerid(passengerid[passcount])))
            {
                passengerinfoemptyarrays(passengerid, passengername, ref passcount);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid ID number";
            }
            else if (!(checkNamevalidation(passengername[passcount])))
            {
                PassengerInfoEmptyArrays(passengerid, passengername, ref passcount);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid passenger name";
            }

            Console.ResetColor();
            return "Passenger information not added...";
        }

        static void passengerinfo(string[] busnumber, string[] passengerid, string[] passengername, ref int passcount, ref int count)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(15, 8);
            Console.Write("Enter your I'D number (that contains 13 digits without space): ");
            passengerid[passcount] = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 9);
            Console.Write("Enter your name: ");
            passengername[passcount] = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(25, 12);
            Console.WriteLine(passengerInfoCheck(passengerid, passengername, ref passcount));
            Console.ReadKey();
        }

        static void updateticket(ref string id,ref string uname,ref string[] busstartinglocation,ref string[] busendinglocation,ref string[] passengerid,ref string[] passengername,ref string[] passengerSpoint,ref string[] passengerDpoint, ref int passcount, ref int count)
        {
            if (!(string.IsNullOrEmpty(passengerid[passcount - 1])))
            {
                Console.Clear();
                header();
                Console.SetCursorPosition(15, 7);
                Console.Write("Enter your I'D card No: ");
                id = Console.ReadLine();
                Console.SetCursorPosition(15, 8);
                Console.Write("Enter your name: ");
                uname = Console.ReadLine();

                editpassengerop(ref id,ref uname, busstartinglocation, busendinglocation, passengerid, passengername, passengerSpoint, passengerDpoint, ref passcount, ref count);
            }
            else
            {
                Console.WriteLine(RecordNotFound());
            }
            Console.ReadKey();
        }

        static void editpassengerop(ref string id,ref string uname,ref string[] busstartinglocation,ref string[] busendinglocation,ref string[] passengerid,ref string[] passengername,ref string[] passengerSpoint,ref string[] passengerDpoint, ref int passcount, ref int count)
        {
            string newSlocation;
            string newDlocation;
            Console.Clear();
            header();
            Console.SetCursorPosition(15, 7);
            Console.Write("Enter your new starting point location: ");
            newSlocation = Console.ReadLine();
            Console.SetCursorPosition(15, 8);
            Console.Write("Enter your new destination point: ");
            newDlocation = Console.ReadLine();

            if (BusrouteValidation(newSlocation) && BusrouteValidation(newDlocation))
            {
                Console.Clear();
                header();
                Console.SetCursorPosition(18, 7);
                Console.WriteLine("Your Ticket");
                Console.WriteLine();
                Console.WriteLine(EditPassenger(id, uname, busstartinglocation, busendinglocation, newSlocation, newDlocation, passengerid, passengername, passengerSpoint, passengerDpoint, ref passcount, ref count));
            }
            else
            {
                Console.SetCursorPosition(15, 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Press any key to continue.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        static void bookaticket(ref string[] busnumber,ref string[] passengerid,ref string[] passengername,ref string[] passengerSpoint,ref string[] passengerDpoint,ref string[] busstartinglocation,ref string[] busendinglocation,ref string[] bookedseats,ref string[] remainingseats, ref int passcount, ref int count)
        {
            int tcounter;
            while (true)
            {
                Console.Clear();
                header();
                Console.SetCursorPosition(13, 6);
                Console.WriteLine("-Passenger Menu");
                Console.SetCursorPosition(15, 8);
                Console.WriteLine("Enter 1 to enter your I'D number and name.");
                Console.SetCursorPosition(15, 9);
                Console.WriteLine("Enter 2 to enter your route of journey.");
                Console.SetCursorPosition(15, 10);
                Console.WriteLine("Enter 3 to save data and exit.");
                Console.SetCursorPosition(15, 12);
                Console.WriteLine("Enter a number to continue...");
                Console.SetCursorPosition(43, 12);
                tcounter = Console.ReadKey().KeyChar;

                if (tcounter == '1')
                {
                    passengerinfo(busnumber, passengerid, passengername, ref passcount, ref count);
                }
                else if (tcounter == '2')
                {
                    passengerroute(passengerid, passengername, passengerSpoint, passengerDpoint, busstartinglocation, busendinglocation, bookedseats, remainingseats, ref count, ref passcount);
                }
                else if (tcounter == '3')
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(15, 14);
                    Console.WriteLine("Invalid Input. Press any key to continue");
                    Console.ReadKey();
                    break;
                }
            }
        }

        static void signinmain(ref string[] username,ref string[] password,ref string[] role, ref int c,ref string[] busnumber,ref string[] busname,ref string[] busstartinglocation,ref string[] busendinglocation,ref string[] busdeparturetime,ref string[] busarrivaltime,ref string[] ticketprice, int seats,ref int max, ref int count,ref string[] passengerid,ref string[] passengername,ref string[] passengerSpoint,ref string[] passengerDpoint,ref string[] bookedseats,ref string[] remainingseats,ref string[] feedbackusername,ref string[] feedbackpoints, ref int fdcount, ref string newSlocation, ref string newDlocation, ref string idd, ref string id, ref string Id1, ref string uname, ref string Name1, ref int seatcount, ref int passcount)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-Home>SignInPage");
            Console.SetCursorPosition(17, 9);
            Console.Write("Enter username: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(17, 11);
            Console.Write("Enter password: ");
            string pass = Console.ReadLine();
            Console.WriteLine();
            int indexOfCurrentUser = signIncheck(name, pass, username, password, role, ref c);
            if (indexOfCurrentUser != -1)
            {
                if (role[indexOfCurrentUser] == "admin")
                {
                    adminMainMenu(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, seats,ref max, ref count, passengerid, passengername, passengerSpoint, passengerDpoint, bookedseats, remainingseats, feedbackusername, feedbackpoints, ref fdcount, ref newSlocation, ref newDlocation, ref idd, ref id, ref Id1, ref uname, ref Name1, ref seatcount, ref passcount);
                }

                if (role[indexOfCurrentUser] == "passenger")
                {
                    passengerMainMenu(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, seats,ref max, ref count, passengerid, passengername, passengerSpoint, passengerDpoint, bookedseats, remainingseats, feedbackusername, feedbackpoints, ref fdcount, ref newSlocation, ref newDlocation, ref idd, ref id, ref Id1, ref uname, ref Name1, ref seatcount, ref passcount);
                }
            }
            else if (indexOfCurrentUser == -1)
            {
                signuprecordnotfound();
            }
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
            else if ((!checknamevalidation(username[c])))
            {
                emptysignuparrays(ref username, ref password, ref role, ref c);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid Username...";
            }
            else if( (!checkpassword(password[c])) )
            {
                emptysignuparrays(ref username, ref password, ref role, ref c);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid Password...";
            }
            else if (role[c] != "admin" && role[c] != "passenger")
            {
                emptysignuparrays(ref username, ref password, ref role, ref c);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid role...";
            }
            else
            {
                emptysignuparrays(ref username, ref password, ref role, ref c);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Not registered";
            }
        }

        static void signupmain(ref string[] username, ref string[] password, ref string[] role, ref int c)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-Home>SignUpPage");
            Console.SetCursorPosition(17, 9);
            Console.Write("Enter username(only use alphabets and numbers): ");
            username[c] = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(17, 11);
            Console.Write("Enter password(with length of 8): ");
            password[c] = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(17, 13);
            Console.Write("Enter role(admin or passenger): ");
            role[c] = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(17, 15);
            Console.WriteLine(signup(ref username, ref password, ref role, ref c));
            Console.ReadKey();
        }



        static void passengerMainMenu(string[] busnumber, string[] busname, string[] busstartinglocation, string[] busendinglocation, string[] busdeparturetime, string[] busarrivaltime, string[] ticketprice, int seats,ref int max, ref int count, string[] passengerid, string[] passengername, string[] passengerSpoint, string[] passengerDpoint, string[] bookedseats, string[] remainingseats, string[] feedbackusername, string[] feedbackpoints, ref int fdcount, ref string newSlocation, ref string newDlocation, ref string idd, ref string id, ref string Id1, ref string uname, ref string Name1, ref int seatcount, ref int passcount)
        {
            char counter = '1';
            while (true)
            {
                Console.Clear();
                header();
                Console.SetCursorPosition(13, 6);
                Console.WriteLine("-Passenger Menu");
                Console.SetCursorPosition(15, 8);
                Console.WriteLine("Press 1 to view all buses timetable.");
                Console.SetCursorPosition(15, 9);
                Console.WriteLine("Press 2 for book a ticket.");
                Console.SetCursorPosition(15, 10);
                Console.WriteLine("Press 3 to view your ticket.");
                Console.SetCursorPosition(15, 11);
                Console.WriteLine("Press 4 to edit your ticket.");
                Console.SetCursorPosition(15, 12);
                Console.WriteLine("Press 5 to cancel the ticket.");
                Console.SetCursorPosition(15, 13);
                Console.WriteLine("Press 6 to view your journey bus detail.");
                Console.SetCursorPosition(15, 14);
                Console.WriteLine("Press 7 for feedback.");
                Console.SetCursorPosition(15, 15);
                Console.WriteLine("Press 8 for help.");
                Console.SetCursorPosition(15, 16);
                Console.WriteLine("Press 9 to save data and exit.");
                Console.SetCursorPosition(15, 18);
                Console.WriteLine("Enter a number to continue...");
                Console.SetCursorPosition(43, 18);
                counter = Console.ReadKey().KeyChar;

                switch (counter)
                {
                    case '1':
                        viewmenu(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, bookedseats, remainingseats, seats,ref max, ref count);
                        break;
                    case '2':
                        bookaticket(busnumber, passengerid, passengername, passengerSpoint, passengerDpoint, busstartinglocation, busendinglocation, bookedseats, remainingseats, ref passcount, ref count);
                        break;
                    case '3':
                        ticketview(passengerid, passengername, passengerSpoint, passengerDpoint, bookedseats, ref passcount);
                        break;
                    case '4':
                        updateticket(ref id, ref uname, busstartinglocation, busendinglocation, passengerid, passengername, passengerSpoint, passengerDpoint, ref passcount, ref count);
                        break;
                    case '5':
                        delticket(ref Id1, ref Name1, passengerid, passengername, passengerSpoint, passengerDpoint, ref passcount);
                        break;
                    case '6':
                        busdetails(passengerid, passengername, passengerSpoint, passengerDpoint, busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, bookedseats, ref count, ref passcount, ref idd);
                        break;
                    case '7':
                        userfeedback(feedbackusername, feedbackpoints, passengername, ref passcount, ref fdcount);
                        break;
                    case '8':
                        help();
                        break;
                    case '9':
                        passengerdatastore(passengerid, passengername, passengerSpoint, passengerDpoint, bookedseats, ref passcount);
                        return;
                    default:
                        invalidinput();
                        break;
                }
            }
        }

        static void adminMainMenu(string[] busnumber, string[] busname, string[] busstartinglocation, string[] busendinglocation, string[] busdeparturetime, string[] busarrivaltime, string[] ticketprice, int seats,ref int max, ref int count, string[] passengerid, string[] passengername, string[] passengerSpoint, string[] passengerDpoint, string[] bookedseats, string[] remainingseats, string[] feedbackusername, string[] feedbackpoints,ref int fdcount, ref string newSlocation, ref string newDlocation, ref string idd, ref string id, ref string Id1, ref string uname, ref string Name1, ref int seatcount, ref int passcount)
        {
            char counter = '1';
            while (true)
            {
                Console.Clear();
                header();
                Console.SetCursorPosition(13, 6);
                Console.WriteLine("-Admin Menu");
                Console.SetCursorPosition(15, 8);
                Console.WriteLine("Enter 1 to add a new bus(Create).");
                Console.SetCursorPosition(15, 9);
                Console.WriteLine("Enter 2 to search a bus by its name(Retrieve).");
                Console.SetCursorPosition(15, 10);
                Console.WriteLine("Enter 3 to change the route of a bus(Update).");
                Console.SetCursorPosition(15, 11);
                Console.WriteLine("Enter 4 to remove bus(Delete).");
                Console.SetCursorPosition(15, 12);
                Console.WriteLine("Enter 5 to change the time of a bus.");
                Console.SetCursorPosition(15, 13);
                Console.WriteLine("Enter 6 to view passenger details.");
                Console.SetCursorPosition(15, 14);
                Console.WriteLine("Enter 7 to change the price of tickets.");
                Console.SetCursorPosition(15, 15);
                Console.WriteLine("Enter 8 to view the all buses.");
                Console.SetCursorPosition(15, 16);
                Console.WriteLine("Press 9 to view feedback list.");
                Console.SetCursorPosition(15, 17);
                Console.WriteLine("Press 0 to save data and exit.");
                Console.SetCursorPosition(15, 19);
                Console.WriteLine("Enter a number to continue...");
                Console.SetCursorPosition(43, 19);
                counter = Console.ReadKey().KeyChar;

                switch (counter)
                {
                    case '1':
                        Newbus(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice,ref max, ref count);
                        break;
                    case '2':
                        searchbus(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice,ref max, ref count);
                        break;
                    case '3':
                        updatebus(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice,ref max, ref count);
                        break;
                    case '4':
                        deletebus(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice,ref max, ref count);
                        break;
                    case '5':
                        changetime(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice,ref max, ref count);
                        break;
                    case '6':
                        viewpassengerlist(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, seats,ref max, ref count, passengerid, passengername, passengerSpoint, passengerDpoint, bookedseats, remainingseats, feedbackusername, feedbackpoints, ref newSlocation, ref newDlocation, ref idd, ref id, ref Id1, ref uname, ref Name1, ref seatcount, ref passcount);
                        break;
                    case '7':
                        changeprice(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice,ref max, ref count);
                        break;
                    case '8':
                        viewmenu(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, bookedseats, remainingseats, seats,ref max, ref count);
                        break;
                    case '9':
                        viewfeedback(feedbackusername, feedbackpoints, ref fdcount);
                        break;
                    case '0':
                        adminbusdatastore(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, ref count);
                        return;
                    default:
                        invalidinput();
                        break;
                }
            }
        }



        static void Main(string[] args)
        {
            char counter;
            const int max = 100;
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

                Console.SetCursorPosition(13, 6);
                Console.WriteLine("-Home");
                Console.SetCursorPosition(17, 9);
                Console.WriteLine("1.Sign Up");
                Console.SetCursorPosition(17, 11);
                Console.WriteLine("2.Sign In");
                Console.SetCursorPosition(17, 13);
                Console.WriteLine("3.Exit");
                Console.SetCursorPosition(17, 14);
                Console.WriteLine("Enter a number to continue...");
                Console.SetCursorPosition(46, 14);
                counter = Console.ReadKey().KeyChar;

                switch (counter)
                {
                    case '1':
                        signupmain(username, password, role, ref c);
                        break;
                    case '2':
                        signinmain(username, password, role, ref c, busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, seats,ref max, ref count, passengerid, passengername, passengerSpoint, passengerDpoint, bookedseats, remainingseats, feedbackusername, feedbackpoints, ref fdcount, ref newSlocation, ref newDlocation, ref idd, ref id, ref Id1, ref uname, ref Name1, ref seatcount, ref passcount);
                        break;
                    case '3':
                        adminbusdatastore(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, ref count);
                        passengerdatastore(passengerid, passengername, passengerSpoint, passengerDpoint, bookedseats, ref passcount);
                        Console.Clear();
                        return;
                    default:
                        invalidinput();
                        break;
                }
            }
        }
    }
}