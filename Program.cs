using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaEntry
{
    class Program
    {
        static string[,] filmList = new string[,]
            {
                {"Rush", "15" },
                {"How I Live Now", "15" },
                {"Thor: The Dark World", "12" },
                {"Filth", "18" },
                {"Planes", "U" },
                {"Inglorious Bastards", "18" },
                {"A Bug's Life", "U" }
                {"No Country for Old Men", "18" }
            };
        static string CreateListOfMovies()
        {
            string printList = "";
            for (int i = 0; i < filmList.GetLength(0); i++)
            {
                for (int k = 0; k < filmList.GetLength(1); k++)
                {
                    if (k == 0) //this whole forming of the list is really sloppy, try and see if there is a better way of doing
                        printList += (i + 1) + ". ";
                    printList += filmList[i, k];
                    if (k == 0)
                        printList += ": ";
                    else
                        printList += "\n";
                }
            }
            return printList;
        }
        private static bool CheckInputIsANumber(string valueToCheck) //checks to see if a value is a valid int, passes back T/F
        {
            int pointlessVariable;
            bool validNumber = int.TryParse(valueToCheck, out pointlessVariable);
            return validNumber;
        }
        private static bool ValidFilmChoice(int filmSelectionInt)
        {
            if (filmList[filmSelectionInt - 1, 1] == "U")
            {
                Console.WriteLine("Booking completed, enjoy " + filmList[filmSelectionInt - 1, 0] + ".");
                return false;
            }

            else
            {
                Console.Write("This film has age restrictions attached, please provide your age" +
                    ", and don't you dare lie: ");
                if (IsUserOldEnough(filmSelectionInt))
                {
                    Console.Write("Well, it doesn't look like you are old enough, " +
                        "please pick another film that you are old enough to see: ");
                    return true; 
                }
                else
                {
                    Console.WriteLine("Well done for being old enough and definitely not lying about it," +
                        " enjoy " + filmList[filmSelectionInt - 1, 0] + ".");
                    return false;
                }
            }
        }
        static void ChoseFilm()
        {
            bool exitValue = true;
            do
            {
                string filmSelection = Console.ReadLine();
                bool validNumber = CheckInputIsANumber(filmSelection);
                if (validNumber)
                {
                    int filmSelectionInt = int.Parse(filmSelection);
                    if (filmSelectionInt < 1 || filmSelectionInt > filmList.GetLength(0))
                    {
                        Console.Write("\nYou have picked a number that doesn't have a corresponding film.\n" +
                            "Please enter the number of a film: ");
                    }
                    else
                    {
                        exitValue = ValidFilmChoice(filmSelectionInt);
                    }
                }
                else
                    Console.Write("That is not a valid number, please pick another film: ");
                
            }while (exitValue);
        }
        //TRY AND ADD SOME KIND OF CODE THAT WILL ONLY ALLOW YOU TO MAKE SURE THE AGE IS A REALISTIC AGE OF SOMEONE (0-125?
        //ohhh yes
        private static bool IsUserOldEnough(int filmSelection)
        {
            int userAge=0;
            try
            {
                userAge = int.Parse(Console.ReadLine());

            }
            catch (SystemException e)
            {
                Console.WriteLine("Well that is not a realistic age in the slightest, stop trying to be so funny. \n" +
                    "I'm going to treat you like the child you are.\n\n" + e + "\n");
            }
            if (userAge >= int.Parse(filmList[filmSelection - 1, 1]))
            {
                return false;
            }
            else 
            { 
                return true;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the cinema mother fuck \n" +
                "The films we are currently showing are: \n");

            Console.WriteLine(CreateListOfMovies());
            Console.Write("Which movie would you like to watch (pick the number of the film)? ");
            ChoseFilm();
            Console.ReadLine();
        }
    }
}
