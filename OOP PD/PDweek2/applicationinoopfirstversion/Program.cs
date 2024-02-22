using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    internal class Program
    {
        static void header()
        {
            Console.WriteLine("______________________________________***************************_____________________________________\n");
            Console.WriteLine("                                                                                                      \n");
            Console.WriteLine("                                         BUS MANAGEMENT SYSTEM                                        \n");
            Console.WriteLine("                                                                                                      \n");
            Console.WriteLine("--------------------------------------***************************------------------------------------\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

        }
        static void signupdatastore(List<application> signup, ref int c)
        {
            using (StreamWriter signupFile = new StreamWriter("C:\\study\\semester2\\oop\\OOP PD\\applicationinoopfirstversion\\signup.txt"))
            {
                for (int i = 0; i < c; i++)
                {
                    if (string.IsNullOrEmpty(signup[i].name))
                        continue;

                    signupFile.WriteLine($"{signup[i].name},{signup[i].password},{signup[i].role}");
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

        static void readsignupData(List<application> signup, ref int c)
        {
            using (StreamReader data = new StreamReader("C:\\study\\semester2\\oop\\OOP PD\\applicationinoopfirstversion\\signup.txt"))
            {
                string record;
                while ((record = data.ReadLine()) != null)
                {
                    // Check if the signup list has enough elements, if not, add a new element
                    if (c >= signup.Count)
                    {
                        signup.Add(new application());
                    }

                    signup[c].name = getField(record, 1);
                    signup[c].password = getField(record, 2);
                    signup[c].role = getField(record, 3);
                    c++;
                }
            }
        }


        static bool checknamevalidation(string username)
        {
            // username
            for (int i = 0; i < username.Length; i++)
            {
                if (!(Char.IsLetterOrDigit(username[i]) || username[i] == '_'))
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

        static void Main(string[] args)
        {
            char counter;
            int c = 0;
            int buscount = 0;
            int fdcount = 0;


            List<application> signup = new List<application>();
            List<busdata> busrecords = new List<busdata>();
            List<feedback> feedbacks = new List<feedback>();

            while (true)
            {
                Console.Clear();
                application s = new application();
                application s1 = new application();
                busdata b = new busdata();
                feedback f = new feedback();
                readsignupData(signup, ref c);
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

                switch (counter)
                {
                    case '1':
                        signupmain(signup, s, ref c);
                        break;
                    case '2':
                        signinmain(signup, s1,busrecords,feedbacks,b,f,ref buscount,ref fdcount, ref c);
                        break;
                    default:
                        invalidinput();
                        break;
                }
            }


        }
        static void signupmain(List<application> signup, application s, ref int c)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 9);
            Console.WriteLine("-Home>SignUpPage");
            signup.Add(sigupinput(s));
            Console.SetCursorPosition(17, 15);
            Console.WriteLine(signupcheck(signup, ref c));
            Console.ReadKey();
            Console.ResetColor();
        }
        static application sigupinput(application s)
        {
            bool flag;
            do
            {
                Console.Clear();
                flag = false;
                header();
                Console.ResetColor();

                Console.SetCursorPosition(17, 12);
                Console.Write("                                                             ");
                Console.SetCursorPosition(17, 12);
                Console.Write("Enter username(only use alphabets and numbers): ");
                s.name = Console.ReadLine();
                if (checknamevalidation(s.name))
                {
                   do
                   {
                    flag = false;
                    Console.ResetColor();
                    Console.SetCursorPosition(17, 13);
                    Console.Write("                                                             ");
                    Console.SetCursorPosition(17, 13);
                    Console.Write("Enter password(with length of 8): ");
                    s.password = Console.ReadLine();
                    
                        if (checkpassword(s.password))
                        {
                            do
                            {
                                flag = false;
                                Console.ResetColor();
                                Console.SetCursorPosition(17, 14);
                                Console.Write("                                                           ");
                                Console.SetCursorPosition(17, 14);
                                Console.Write("Enter role(admin or passenger): ");
                                s.role = Console.ReadLine();
                                if (s.role != "admin" && s.role != "passenger")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition(17, 15);
                                    Console.WriteLine("Invalid role...");
                                    flag = true;
                                }
                            } while (flag);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(17, 14);
                            Console.WriteLine("Invalid Password...");
                            s.password = "";
                            flag = true;
                        }
                    }while(flag);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(17, 13);
                    Console.WriteLine("Invalid Name...");  
                    flag = true;
                }
                Console.ResetColor();
            }while(flag);
            return s;
        }
        static string signupcheck(List<application> signup, ref int c)
        {
            if ((signup[c].role == "admin" || signup[c].role == "passenger"))
            {
                for (int j = 0; j < c; j++)
                {
                    if (c >= 1 && signup[c].name == signup[j].name)
                    {
                        signup.RemoveAt(c);
                        return "Already exist ...";
                    }
                }

                c++;
                signupdatastore(signup, ref c);
                return "Registered successfully. Press any key to continue.";
            }
            else
            {
                signup.RemoveAt(c);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Not registered";
            }

        }

        static void signinmain(List<application> signup, application s1,List<busdata> busrecords,List<feedback> feedbacks,busdata b,feedback f,ref int buscount,ref int fdcount, ref int c)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 9);
            Console.WriteLine("-Home>SignInPage");
            signininput(s1);
            int indexOfCurrentUser = signIncheck(signup, s1, ref c);
            if (indexOfCurrentUser != -1)
            {
                if (signup[indexOfCurrentUser].role == "admin")
                {
                    adminMainMenu(busrecords,feedbacks, b,f, ref buscount, ref fdcount);
                }
                if (signup[indexOfCurrentUser].role == "passenger")
                {
                    Console.WriteLine("Logined as passenger");
                }
            }
            else if (indexOfCurrentUser == -1)
            {
                signuprecordnotfound();
            }
            Console.ReadLine();
        }
        static int signIncheck(List<application> signup, application s1, ref int c)
        {
            for (int i = 0; i < c; i++)
            {
                if (s1.name == signup[i].name && s1.password == signup[i].password)
                {
                    return i;
                }
            }
            return -1;
        }
        static application signininput(application s1)
        {
            Console.SetCursorPosition(17, 12);
            Console.Write("Enter username: ");
            s1.name = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(17, 13);
            Console.Write("Enter password: ");
            s1.password = Console.ReadLine();
            return s1;
        }
        static void signuprecordnotfound()
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(14, 9);
            Console.WriteLine("-Home>SignInPage");
            Console.SetCursorPosition(15, 12);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Record not found! Please sign up first...");
            Console.ResetColor();
            Console.ReadKey();
        }
        static void invalidinput()
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(15, 9);
            Console.WriteLine("-Homepage");
            Console.SetCursorPosition(25, 13);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Input..");
            Console.ResetColor();
            Console.ReadKey();
            Environment.Exit(0);
        }

        static void adminMainMenu(List<busdata> busrecords,List<feedback> feedbacks,busdata b,feedback f,ref int buscount, ref int fdcount)
        {
            char counter = '1';
            while (true)
            {
                Console.Clear();
                header();
                Console.SetCursorPosition(13, 9);
                Console.WriteLine("-Admin Menu");
                Console.SetCursorPosition(15, 11);
                Console.WriteLine("Enter 1 to add a new bus(Create).");
                Console.SetCursorPosition(15, 12);
                Console.WriteLine("Enter 2 to search a bus by its name(Retrieve).");
                Console.SetCursorPosition(15, 13);
                Console.WriteLine("Enter 3 to change the route of a bus(Update).");
                Console.SetCursorPosition(15, 14);
                Console.WriteLine("Enter 4 to remove bus(Delete).");
                Console.SetCursorPosition(15, 15);
                Console.WriteLine("Enter 5 to change the time of a bus.");
                Console.SetCursorPosition(15, 16);
                Console.WriteLine("Enter 6 to view passenger details.");
                Console.SetCursorPosition(15, 17);
                Console.WriteLine("Enter 7 to change the price of tickets.");
                Console.SetCursorPosition(15, 18);
                Console.WriteLine("Enter 8 to view the all buses.");
                Console.SetCursorPosition(15, 19);
                Console.WriteLine("Press 9 to view feedback list.");
                Console.SetCursorPosition(15, 20);
                Console.WriteLine("Press 0 to save data and exit.");
                Console.SetCursorPosition(15, 21);
                Console.WriteLine("Enter a number to continue...");
                Console.SetCursorPosition(43, 21);
                counter = Console.ReadKey().KeyChar;

                switch (counter)
                {
                    case '1':
                        Newbus(busrecords,b, ref buscount);
                        break;
                    case '2':
                        searchbus(busrecords, b, ref buscount);
                        break;
                    case '3':
                       updatebus(busrecords, b, ref buscount);
                        break;
                    case '4':
                       deletebus(busrecords,  ref buscount);
                        break;
                    case '5':
                      changetime(busrecords, ref buscount);
                        break;
                    case '6':
                       /* viewpassengerlist(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, seats, ref max, ref count, passengerid, passengername, passengerSpoint, passengerDpoint, bookedseats, remainingseats, feedbackusername, feedbackpoints, ref newSlocation, ref newDlocation, ref idd, ref id, ref Id1, ref uname, ref Name1, ref seatcount, ref passcount);*/
                        break;
                    case '7':
                      changeprice(busrecords, ref buscount);
                        break;
                    case '8':
                       viewmenu(busrecords, ref buscount);
                        break;
                    case '9':
                        /*viewfeedback(feedbacks,f, ref fdcount);
                        break;*/
                    case '0':
                       /* adminbusdatastore(busrecords, b, ref buscount);
                        return;*/
                    default:
                        invalidinput();
                        break;
                }
            }
        }

        static void Newbus(List<busdata> busrecords,busdata b,ref int buscount)
        {
           
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 9);
            Console.WriteLine("-Admin Menu>InsertBus");
            busrecords.Add(busdatainput(b));
            Console.SetCursorPosition(15, 18);
            Console.WriteLine(buscheck(busrecords, ref buscount));
            Console.SetCursorPosition(15, 25);
            Console.ReadKey();
        }

        static busdata busdatainput(busdata b)
        {
            bool flag = true;
            do
            {
                flag = false;
                Console.ResetColor();
                Console.SetCursorPosition(15, 11);
                Console.Write("                                                                      ");
                Console.SetCursorPosition(15, 11);
                Console.Write("Enter the number of the bus(that contains only digits): ");
                b.busid = Console.ReadLine();
                if ((validbusid(b.busid)))
                {
                    do
                    {
                        flag = false;
                        Console.ResetColor();
                        Console.SetCursorPosition(15, 12);
                        Console.Write("                                                                      ");
                        Console.SetCursorPosition(15, 12);
                        Console.Write("Enter the name of the bus: ");
                        b.busname = Console.ReadLine();
                        if ((checknamevalidation(b.busname)))
                        {
                            do
                            {
                                flag = false;
                                Console.ResetColor();
                                Console.SetCursorPosition(15, 13);
                                Console.Write("                                                                      ");
                                Console.SetCursorPosition(15, 13);
                                Console.Write("Enter starting terminal of bus: ");
                                b.busstartinglocation = Console.ReadLine();
                                if ((busroutevalidation(b.busstartinglocation)))
                                {
                                    do
                                    {
                                        flag = false;
                                        Console.ResetColor();
                                        Console.SetCursorPosition(15, 14);
                                        Console.Write("                                                                      ");
                                        Console.SetCursorPosition(15, 14);
                                        Console.Write("Enter ending terminal of bus: ");
                                        b.busendinglocation = Console.ReadLine();
                                        if ((busroutevalidation(b.busendinglocation)))
                                        {
                                            do
                                            {
                                                flag = false;
                                                Console.ResetColor();
                                                Console.SetCursorPosition(15, 15);
                                                Console.Write("                                                                      ");
                                                Console.SetCursorPosition(15, 15);
                                                Console.Write("Enter the bus departure time(as 1pm): ");
                                                b.busdeparturetime = Console.ReadLine();
                                                if (checkbustimevalidation(b.busdeparturetime))
                                                {
                                                    do
                                                    {
                                                        flag = false;
                                                        Console.ResetColor();
                                                        Console.SetCursorPosition(15, 16);
                                                        Console.Write("                                                                      ");
                                                        Console.SetCursorPosition(15, 16);
                                                        Console.Write("Enter the arrival time of bus(as 1pm): ");
                                                        b.busarrivaltime = Console.ReadLine();
                                                        if (checkbustimevalidation(b.busdeparturetime))
                                                        {
                                                            do
                                                            {
                                                                flag = false;
                                                                Console.ResetColor();
                                                                Console.SetCursorPosition(15, 17);
                                                                Console.Write("                                                                      ");
                                                                Console.SetCursorPosition(15, 17);
                                                                Console.Write("Enter the price per ticket of a bus(that contain only digits): Rs.");
                                                                b.ticketprice = Console.ReadLine();
                                                                if (!(validbusid(b.ticketprice)))
                                                                {
                                                                  
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.SetCursorPosition(15, 18);
                                                                    Console.WriteLine( "Invalid Bus ticket price");
                                                                    flag = true;
                                                                }

                                                            } while (flag);
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.SetCursorPosition(15, 17);
                                                            Console.WriteLine("Invalid Busarrival time");
                                                            flag = true;
                                                        }
                                                    } while (flag);
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.SetCursorPosition(15, 16);
                                                    Console.WriteLine("Invalid Busdeparture time");
                                                    flag = true;
                                                }
                                            }while(flag);
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.SetCursorPosition(15, 15);
                                            Console.WriteLine("Invalid Bus ending location");
                                            flag = true;
                                        }

                                    } while (flag);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition(15, 14);
                                    Console.WriteLine("Invalid Bus starting location");
                                    flag = true;
                                }
                            }while (flag);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(15, 13);
                            Console.WriteLine( "Invalid Bus name");
                            flag = true;
                        }

                    } while (flag);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("Invalid Bus number");
                    flag = true;
                }
            } while (flag);
            return b;
        }
      
          
    

        static string buscheck(List<busdata> busrecords,ref int buscount)
        {
            if (((validbusid(busrecords[buscount].busid) && checknamevalidation(busrecords[buscount].busname)) && ((busroutevalidation(busrecords[buscount].busstartinglocation) && busroutevalidation(busrecords[buscount].busendinglocation)) && ((checkbustimevalidation(busrecords[buscount].busdeparturetime) && checkbustimevalidation(busrecords[buscount].busarrivaltime)) && validbusid(busrecords[buscount].ticketprice)))))
            {
                for (int i = 0; i < buscount; i++)
                {
                    if (buscount >= 1 && busrecords[buscount].busid == busrecords[i].busid)
                    {
                        busrecords.RemoveAt(buscount);
                        return "Already exist ...";
                    }
                }
                // AdminBusDataStore(busnumber, busname, busstartinglocation, busendinglocation, busdeparturetime, busarrivaltime, ticketprice, count);
                buscount++;
                return "Bus has been added....";
            }
            else
            {
                busrecords.RemoveAt(buscount);
                Console.ForegroundColor = ConsoleColor.Red;
                return "Bus is not added...";
            
            }

           
        }

        static void searchbus(List<busdata> busrecords, busdata b, ref int buscount)
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
            Console.WriteLine(searchbusop(ref number,ref name,busrecords, b ,ref buscount));
            Console.ReadKey();
            Console.ResetColor();
        }

        static string searchbusop(ref string number  , ref string name,List<busdata> busrecords,busdata b , ref int buscount)
        {
            for (int i = 0; i < busrecords.Count; i++)
            {
                if (b.busid == busrecords[i].busid && b.busname == busrecords[i].busname)
                {
                    return "\t\tBUS NO:\t\t\t\t\t\t\t" + busrecords[i].busid + "\n" +
                           "\t\tBUSNAME:\t\t\t\t\t\t" + busrecords[i].busname + "\n" +
                           "\t\tBUSDEPTERMINAL:\t\t\t\t\t" + busrecords[i].busstartinglocation + "\n" +
                           "\t\tBUSDESTINATION:\t\t\t\t\t" + busrecords[i].busendinglocation + "\n" +
                           "\t\tBUSDEPTIME:\t\t\t\t\t\t" + busrecords[i].busdeparturetime + "\n" +
                           "\t\tBUSARRTIME:\t\t\t\t\t\t" + busrecords[i].busarrivaltime + "\n" +
                           "\t\tTICKETPRICE:\t\t\t\t\t\t" + busrecords[i].ticketprice;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            return "not exist";
           
        }

        static void updatebus(List<busdata> busrecords,busdata b, ref int passcount)
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
            updatebusop(ref number, ref name, ref sroute, ref eroute, ref dtime, ref atime, ref newprice, busrecords ,b, ref passcount);
            Console.ReadKey();
        }
        static void updatebusop(ref string number, ref string name, ref string sroute, ref string eroute, ref string dtime, ref string atime, ref string newprice,List<busdata> busrecords ,busdata b, ref int passcount)
        {
            if (validbusid(number) && checknamevalidation(name) && busroutevalidation(sroute) && busroutevalidation(eroute) && checkbustimevalidation(dtime) && checkbustimevalidation(atime) && validbusid(newprice))
            {
                for (int i = 0; i < busrecords.Count; i++)
                {
                    if (number == busrecords[i].busid)
                    {
                    busrecords[i].busid = number;
                        busrecords[i].busname = name;
                        busrecords[i].busstartinglocation = sroute;
                        busrecords[i].busendinglocation = eroute;
                        busrecords[i].busdeparturetime = dtime;
                        busrecords[i].busarrivaltime = atime;
                        busrecords[i].ticketprice = newprice;

                        Console.WriteLine("\t\tBUS NO:\t\t\t\t\t\t\t{busrecords[i].busid}\n\t\tBUSNAME:\t\t\t\t\t\t{busrecords[i].busname}\n\t\tBUSDEPTERMINAL:\t\t\t\t\t{busrecords[i].busstartinglocation}\n\t\tBUSDESTINATION:\t\t\t\t{busrecords[i].busendinglocation}\n\t\tBUSDEPTIME:\t\t\t\t\t\t{busrecords[i].busdeparturetime}\n\t\tBUSARRTIME:\t\t\t\t\t\t{busrecords[i].busarrivaltime}\n\t\tTICKETPRICE:\t\t\t\t\t{busrecords[i].ticketprice");
                        
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("not exist");
                Console.ResetColor();
            }
            else if (!(checknamevalidation(name)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid username");
                Console.ResetColor();
            }
            else if (!(busroutevalidation(sroute)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid starting location");
                Console.ResetColor();
            }
            else if (!(busroutevalidation(eroute)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ending location");
                Console.ResetColor();
            }
            else if (!(checkbustimevalidation(dtime)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid departure time");
                Console.ResetColor();
            }
            else if (!(checkbustimevalidation(atime)))
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

        static void deletebus(List<busdata> busrecords, ref int buscount)
        {
            string number;
            string name;
           

            Console.Clear();
            header();
            Console.WriteLine("-Admin Menu>DeleteBus");
            Console.Write("Enter the number of the bus(that contain only numbers): ");
            number = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the name of the bus: ");
            name = Console.ReadLine();
            Console.WriteLine();

            Console.Clear();
            header();
            Console.WriteLine("-Admin Menu>DeleteBus");
            Console.WriteLine(deletebusop(ref number, ref name,busrecords , ref buscount));
            Console.ResetColor();
            Console.ReadKey();
        }
        static string deletebusop(ref string number, ref string name,List<busdata> busrecords  , ref int buscount)
        {
            for (int i = 0; i < busrecords.Count; i++)
            {
                if (number == busrecords[i].busid)
                {
                    busrecords[i].busid = "";
                    busrecords[i].busname = "";
                    busrecords[i].busstartinglocation = "";
                    busrecords[i].busendinglocation = "";
                    busrecords[i].busdeparturetime = "";
                    busrecords[i].busarrivaltime = "";
                    busrecords[i].ticketprice = "";

                    return "Bus record successfully deleted...";
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            return "not exist";
           
        }

        static void viewmenu(List<busdata> busrecords, ref int buscount)
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-Admin Menu>BusesList");
            Console.SetCursorPosition(14, 8);
            Console.WriteLine("BUSNO:\t\tBUSNAME:\tBUSDEPTERMINAL:\tBUSTARTERMINAL:\tBUSDEPTIME:\tBUSARRTIME:\tPRICE:\tREMAINING SEATS:");

            for (int j = 0; j < busrecords.Count; j++)
            {
                Console.WriteLine($"\t{ busrecords[j].busid,-10}{busrecords[j].busname,-11}{busrecords[j].busstartinglocation,-15}{busrecords[j].busendinglocation,-19}{busrecords[j].busdeparturetime,-16}{busrecords[j].busarrivaltime,-16}{busrecords[j].ticketprice,-16}");
            }

            Console.WriteLine("\tPress any key to continue...");
            Console.ReadKey();
        }

        static void changeprice(List<busdata> busrecords, ref int buscount)
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
            Console.WriteLine(changepriceop(ref number, ref newPrice,busrecords , ref buscount));
            Console.ReadKey();
            Console.ResetColor();
        }

        static string changepriceop(ref string number, ref string newprice, List<busdata> busrecords, ref int buscount)
        {
            if (validbusid(newprice))
            {
                for (int i = 0; i < busrecords.Count; i++)
                {
                    if (number == busrecords[i].busid)
                    {
                        busrecords[i].busid = number;
                        busrecords[i].ticketprice = newprice;

                        return $"\t\tBUSNO:\t\t\t\t\t{busrecords[i].busid}\n\t\tNEWTICPRICE:\t\t\t\t{busrecords[i].ticketprice}";
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

        static string changetimeop(ref string number, ref string dtime, ref string atime,List<busdata> busrecords, ref int buscount)
        {
            if (checkbustimevalidation(dtime) && checkbustimevalidation(atime))
            {
                for (int i = 0; i < busrecords.Count; i++)
                {
                    if (number == busrecords[i].busid)
                    {
                        busrecords[i].busid = number;
                        busrecords[i].busdeparturetime = dtime;
                        busrecords[i].busarrivaltime = atime;

                        return $"\t\tBUSNO:\t\t\t\t\t\t\t{busrecords[i].busid}\n\t\tBUSDEPTIME:\t\t\t\t\t\t{busrecords[i].busdeparturetime}\n\t\tBUSARRTIME:\t\t\t\t\t\t{busrecords[i].busarrivaltime}";
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                return "not exist";
       
            }
            else if (!checkbustimevalidation(dtime))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Invalid departure time";
          
            }
            else if (!checkbustimevalidation(atime))
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

        static void changetime(List<busdata> busrecords, ref int buscount)
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
            string dtime = Console.ReadLine();
            Console.WriteLine();
            Console.SetCursorPosition(15, 10);
            Console.Write("Enter the new arrival time of the bus (as 2pm): ");
            string atime = Console.ReadLine();
            Console.WriteLine();
            Console.Clear();
            header();
            Console.SetCursorPosition(13, 6);
            Console.WriteLine("-Admin Menu>changeTimeOfBus");
            Console.SetCursorPosition(14, 10);
            Console.WriteLine(changetimeop(ref number, ref dtime, ref atime,busrecords , ref buscount));
            Console.ReadKey();
            Console.ResetColor();
        }

    /*    static void viewfeedback(List<feedback> feedbacks,feedback f, ref int fdcount)
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
        }*/

    }

}
