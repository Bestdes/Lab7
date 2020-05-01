using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace MovieList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> listOfMovies = new List<Movie>();
            listOfMovies.Add(new Movie("Matrix", "Scifi"));
            listOfMovies.Add(new Movie("Godfather", "Crime"));
            listOfMovies.Add(new Movie("Casablanca", "Classic"));
            listOfMovies.Add(new Movie("Pulp Fiction", "Crime"));
            listOfMovies.Add(new Movie("Star Wars", "Scifi"));
            listOfMovies.Add(new Movie("Baby Driver", "Thriller"));
            listOfMovies.Add(new Movie("Inception", "Thriller"));
            listOfMovies.Add(new Movie("Edge of Tomorrow", "Scifi"));
            listOfMovies.Add(new Movie("Mad Max", "Scifi"));
            listOfMovies.Add(new Movie("Terminator", "Scifi"));

            List<string> listOfCategories = new List<string>();
            listOfCategories.Add("Scifi");
            listOfCategories.Add("Thriller");
            listOfCategories.Add("Crime");
            listOfCategories.Add("Classic");

            Console.WriteLine("Hello World!");

            //-------------------------------------------------------------------
            // Program Logic Starts Here

            bool runProgram = true;
            bool reRunProgram = true;

            while (runProgram)
            {
                GreetingPrompt();
                PrintListOfCategories(listOfCategories);
                string userInput = ReadAndReturnInput();

                if (ValidateCategory(userInput, listOfCategories))
                {
                    List<string> matchingMovies = SearchMovieForCategory(SearchCategory(userInput, listOfCategories), listOfMovies);

                    PrintMovieList(matchingMovies);
                }
                else if(userInput == "")
                {
                    Console.WriteLine("Sorry , something went wrong. It seems you didn't input any text, try again.");
                    Console.WriteLine("-----------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Invalid Input! Try again please.");
                    Console.WriteLine("--------------------------------------------");
                }
            }


        }

        public static void GreetingPrompt()
        {
            Console.WriteLine("Welcome to the Movie Genre Searcher!\nEnter a genre of movies that you would like to search from our collection:");
        }

        public static void PrintListOfCategories(List<string> categoryList)
        {
            Console.WriteLine("The following list represents the categories of movies we have: ");
            foreach (string category in categoryList)
            {
                Console.WriteLine(category);
            }
        }

        public static string ReadAndReturnInput()
        {
            return Console.ReadLine();
        }

        public static bool ValidateCategory(string testingCategory, List<string> categoryList)
        {
            bool isInList = false;

            foreach(string category in categoryList)
            {
                if(testingCategory == category)
                {
                    isInList = true;
                    return isInList;
                }
            }
            return isInList;
        }

        public static string SearchCategory(string movieCategory, List<string> categoryList)
        {
            string foundCategory = "";

            foreach(string category in categoryList)
            {
                if(movieCategory == category)
                {
                    foundCategory = category;
                    return foundCategory;
                }
            }
            return foundCategory;
        }

        public static List<string> SearchMovieForCategory(string category, List<Movie> movieList)
        {
            List<string> specificGenreMovies = new List<string>();
            string movieCategory = "";


            foreach (Movie movie in movieList)
            {
                movieCategory = movie.Category;
                if (movieCategory == category)
                {
                    specificGenreMovies.Add(movieCategory);
                }
            }
            return specificGenreMovies;
        }
        public static void PrintMovieList(List<string> movieList)
        {
            foreach(string movie in movieList)
            {
                Console.WriteLine(movie);
            }
        }
    }
}
