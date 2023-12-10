using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
    public class SettingDTO
    {
        UserDTO _user;
        bool _darkTheme;
        int _equalizerBass;
        int _equalizerHigh;
        int _equalizerVol;
        bool _premium;
        int _numberDispositives;
        List<Dispositives> dispositives = new List<Dispositives>();

        public bool DarkTheme { get => _darkTheme; set => _darkTheme = value; }

        public bool Premium { get => _premium; set => _premium = value; }
        public int NumberDispositives { get => _numberDispositives; set => _numberDispositives = value; }
        internal UserDTO User { get => _user; set => _user = value; }
        public int EqualizerBass { get => _equalizerBass; set => _equalizerBass = value; }
        public int EqualizerHigh { get => _equalizerHigh; set => _equalizerHigh = value; }
        public int Volume { get => _equalizerVol; set => _equalizerVol = value; }
        internal List<Dispositives> Dispositives { get => dispositives; set => dispositives = value; }
        internal List<Dispositives> Dispositives1 { get => dispositives; set => dispositives = value; }
        public void SetDispositives()
        {

            bool basee = true;
            while (basee == true)
            {
                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("List of Connected Devices:"); Console.ForegroundColor = ConsoleColor.White;
                foreach (Dispositives dispositives in dispositives)
                {
                    Console.WriteLine(dispositives.Name);
                }
                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Number of Connected Devices:" + " " + NumberDispositives);
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Add a dispositive with ADD or esc enter something else:"); Console.ForegroundColor = ConsoleColor.White;
                string inn = Console.ReadLine();
                if (inn == "ADD" || inn == "add")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Write the name:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string input = Console.ReadLine();
                    Dispositives dis = new(input);
                    dispositives.Add(dis);
                    NumberDispositives = NumberDispositives + 1;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{dis.Name} added!"); Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    basee = false;
                    break;
                }
            }





        }
        public void SetTheme()
        {

            bool entra = true;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter W for White Theme, D for Dark Theme,E for Esc:");
                Console.ForegroundColor = ConsoleColor.White;

                string input = Console.ReadLine();
                if (input == "D" || input == "d")
                {
                    DarkTheme = true;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (input == "W" || input == "w")
                {
                    DarkTheme = false;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else { entra = false; break; }
            }
        }
        public void SetEqualizer()
        {
            bool entra = true;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter B for Bass Sounds, H for High Sounds, V for Volume, Push something else to Esc:");
                Console.ForegroundColor = ConsoleColor.White;

                string input = Console.ReadLine();
                if (input == "B" || input == "b" || input == "H" || input == "h" || input == "V" || input == "v")
                {
                    bool enter = true;

                    while (enter == true)
                    {
                        if (input == "B" || input == "b")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("push P for +1 and M for -1 or enter something else to esc:"); Console.ForegroundColor = ConsoleColor.White;
                            string input1 = Console.ReadLine();

                            if (input1 == "P" || input1 == "p")
                            {
                                if (EqualizerBass < 10)
                                {
                                    EqualizerBass = EqualizerBass + 1;
                                    Console.WriteLine("Bass: " + EqualizerBass);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Maximum reached"); Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else if (input1 == "M" || input1 == "m" && EqualizerBass > 0)
                            {
                                if (EqualizerBass > 0)
                                {
                                    EqualizerBass = EqualizerBass - 1;
                                    Console.WriteLine("Bass: " + EqualizerBass);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Minimum reached");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else
                            {
                                enter = false;
                            }
                        }
                        else if (input == "H" || input == "h")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("push P for +1 and M for -1  or enter something else to esc:");
                            Console.ForegroundColor = ConsoleColor.White;
                            string input1 = Console.ReadLine();

                            if (input1 == "P" || input1 == "p")
                            {
                                if (EqualizerHigh < 10)
                                {
                                    EqualizerHigh = EqualizerHigh + 1; Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("High: " + EqualizerHigh); Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Maximum reached"); Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else if (input1 == "M" || input1 == "m" && EqualizerHigh > 0)
                            {
                                if (EqualizerHigh > 0)
                                {
                                    EqualizerHigh = EqualizerHigh - 1;
                                    Console.WriteLine("High: " + EqualizerHigh);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Minimum reached"); Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else
                            {
                                enter = false;
                            }
                        }
                        else if (input == "V" || input == "v")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("push P for +1 and M for -1  or enter something else to esc:"); Console.ForegroundColor = ConsoleColor.White;
                            string input1 = Console.ReadLine();

                            if (input1 == "P" || input1 == "p")
                            {
                                if (Volume < 10)
                                {
                                    Volume = Volume + 1;
                                    Console.WriteLine("Volume: " + Volume);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Maximum reached"); Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else if (input1 == "M" || input1 == "m" && Volume > 0)
                            {
                                if (Volume > 0)
                                {
                                    Volume = Volume - 1;
                                    Console.WriteLine("Volume: " + Volume);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Minimum reached");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else
                            {
                                enter = false;
                            }
                        }
                    }
                }
                else
                {

                    entra = false;
                    break;
                }
            }
        }


    }
}
