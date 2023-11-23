using System;
using System.Collections.Generic;
using System.Threading;

namespace tester
{
    internal class Program
    {

    
        private static bool isPlaying = false;
        private static bool isPaused = false;
        private static int currentSongIndex = 0;
        private static int currentSecond = 0;

        // Utilizziamo un ManualResetEvent per coordinare i thread
        private static ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true);

        public static void Main()
        {
            // Esempio di utilizzo
            var playlist = new List<Song>(); // Assicurati di avere una lista di canzoni (classe Song) come input

            // Inizia il thread per la gestione dell'input
            Thread inputThread = new Thread(new ThreadStart(HandleInput));
            inputThread.Start();

            // Avvia il ciclo di riproduzione
            Play(playlist, 0);

            // Attendiamo che il thread di input finisca prima di uscire dal programma
            inputThread.Join();
        }

        public static void Play(List<Song> playlist, int startIndex)
        {
            if (startIndex >= 0 && startIndex < playlist.Count)
            {
                isPlaying = true;
                isPaused = false;
                currentSongIndex = startIndex;

                Console.WriteLine($"Playing the song {playlist[currentSongIndex].Title}");

                while (currentSecond < playlist[currentSongIndex].Duration && !isPaused)
                {
                    currentSecond++;
                    Console.WriteLine($"Seconds scrolling bar: {currentSecond} s");

                    // Aggiungi il codice del tuo ciclo qui

                    WaitForSecond(); // Wait for one second
                }

                isPlaying = false;
                isPaused = false;

                // Segnaliamo all'evento di pausa che il ciclo è terminato
                pauseEvent.Set();
            }
            else
            {
                Console.WriteLine("Invalid start index. Please provide a valid index.");
            }
        }

        public static void HandleInput()
        {
            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.KeyChar)
                    {
                        case 'q':
                            Console.WriteLine("Hai premuto 'q'. Uscita dal ciclo.");
                            isPlaying = false;
                            break;
                        case 'p':
                            Console.WriteLine("Hai premuto 'p'. Mettendo in pausa il ciclo.");
                            isPaused = true;

                            // Azioniamo l'evento di pausa
                            pauseEvent.Reset();
                            break;
                        case 't':
                            Console.WriteLine("Hai premuto 't'. Riprendendo il ciclo.");
                            isPaused = false;

                            // Segnaliamo all'evento di pausa che possiamo riprendere
                            pauseEvent.Set();
                            break;
                    }
                }

                // Attendiamo un po' per evitare di consumare troppe risorse
                Thread.Sleep(100);
            }
        }

        public static void WaitForSecond()
        {
            // Attendiamo l'evento di pausa
            pauseEvent.Wait();

            // Implementa la tua logica per aspettare un secondo
            Thread.Sleep(1000);
        }
    }

    public class Song
    {
        public string Title { get; set; }
        public int Duration { get; set; }
    }
}