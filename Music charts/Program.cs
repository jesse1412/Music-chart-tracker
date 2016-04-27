using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_charts
{
    class Program
    {

        struct song
        {
            public string artistAndTitle;
            public int sales;

        }
        static void Main(string[] args)
        {

            int SONG_COUNT = 3;

            int lowestSalesIndex = 0;

            int highestSalesIndex = 0;

            int totalSales = 0;

            int trackCount = 0;

            bool failed = true;

            song[] songs = new song[SONG_COUNT];

            for (int i = 0; i < SONG_COUNT; i++)
            {

                Console.Clear();

                Console.WriteLine("\nPlease enter an artist and song title: ");
                songs[i].artistAndTitle = Console.ReadLine();

                Console.WriteLine("\nPlease enter the sales of the chart you entered: ");
                do
                {
                    try
                    {
                        songs[i].sales = int.Parse(Console.ReadLine());
                        failed = false;
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("That is not a valid value. Please try again: ");
                        failed = true;
                    }
                    finally
                    {
                        if(songs[i].sales < 0 || songs[i].sales > 50000)
                        {
                            Console.WriteLine("Your sales values must be within the range of 0 to 50,000.");
                        }
                    }
                }
                while (songs[i].sales < 0 || songs[i].sales > 50000 || failed);

                trackCount++;

                Console.Clear();

                totalSales = 0;

                for (int j = 0; j < trackCount; j++)
                {

                    if (songs[j].sales < songs[lowestSalesIndex].sales)
                    {

                        lowestSalesIndex = j;

                    }

                    if (songs[j].sales > songs[highestSalesIndex].sales)
                    {

                        highestSalesIndex = j;

                    }

                    totalSales += songs[j].sales;

                }

                Console.WriteLine("Download manager.");
                Console.WriteLine("Current highest sales: " + songs[highestSalesIndex].sales);
                Console.WriteLine("Highest selling track: " + songs[highestSalesIndex].artistAndTitle);
                Console.WriteLine("Current lowest sales: " + songs[lowestSalesIndex].sales);
                Console.WriteLine("Lowest selling track: " + songs[lowestSalesIndex].artistAndTitle);
                Console.WriteLine("Total sales: " + totalSales);
                Console.WriteLine("Amount of tracks entered: " + trackCount);
                if(i + 1 < SONG_COUNT)
                {
                    Console.WriteLine("\nPress return to enter the next track.");
                    Console.ReadKey();
                }

            }

            //Finding bad tracks.
            bool badTrackCheck = true;

            for(int i = 0; i < songs.Count(); i++)
            {

                if(songs[i].sales < 1000)
                {

                    if(badTrackCheck)
                    {

                        Console.WriteLine("\nThese songs have sold less than 1000 units:\n");
                        badTrackCheck = false;

                    }

                    Console.WriteLine(songs[i].artistAndTitle + " ~ " + songs[i].sales);

                }

            }

            //Sorting.
            song tempSwapSong = new song();

            int swapCount = 0;

            do
            {

                swapCount = 0;

                for (int i = 0; i < songs.Count() - 1; i++)
                {

                    if (songs[i].sales < songs[i + 1].sales)
                    {

                        tempSwapSong = songs[i];
                        songs[i] = songs[i + 1];
                        songs[i + 1] = tempSwapSong;

                        swapCount++;

                    }

                }

                if(swapCount == 0)
                {

                    break;

                    Console.WriteLine("ffs");

                }

            }
            while (true);

            //Printing songs in order.
            Console.WriteLine("\nSongs in order of sales:\n");

            for(int i = 0; i < songs.Count(); i++)
            {

                Console.WriteLine(songs[i].artistAndTitle + " ~ " + songs[i].sales);

            }

            Console.ReadLine();

        }

    }

}
