using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataAccess;

public class GuessingGame
{

    string correctAnswer = "hund";

    string guess;

    public void Game()
    {

        Console.WriteLine("Hvad er mennesket bedste ven?");

        while (guess != correctAnswer)
        {
            Console.WriteLine("Svarmuligheder");
            Console.WriteLine("1.  Hund");
            Console.WriteLine("2.  Ven");
            Console.WriteLine("3.  Kat");
            Console.WriteLine("4.  Cykel");


            Console.Write("Enter guess: ");

            //Sets the answer to lower case, so that any correct ansver is still valid despite case
            guess = Console.ReadLine().ToLower();
        }
        Console.WriteLine("You Win!");

        //Keeps the console open
        Console.ReadLine();
    }


}
