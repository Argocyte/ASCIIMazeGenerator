using System;
using System.IO;

namespace ASCIIMazeGenerator
{
    class Program
    {
        static Maze Maze;

        /// <summary>
        /// Where the program initialises itself.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool generated = false;
            while(WhatToDo(generated))//Menu loop.
            {
                generated = true;
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Runs the selection the user makes in the menu. Not fully implemented for saving and importing mazes yet.
        /// </summary>
        /// <param name="generated">If the program has generated a maze yet. (Menu changes output if true.)</param>
        /// <returns>boolean of if the user wishes to continue using the application.</returns>
        static bool WhatToDo(bool generated)
        {
            Console.Write(WriteMenu(generated));//Outputs the menu.
            switch (Console.ReadLine().ToLower())//Determines what to do based on user input.
            {
                case "x":
                    return false;
                case "1"://Generates a maze and outputs it to the console.
                    MakeMaze();
                    return true;
                case "2"://Load a maze from a file
                    LoadMaze();
                    return true;
                case "3"://Saves the current maze in memory to a file.
                    SaveMaze();
                    return true;
                default://if no input it will ask again.
                    return true;
            }
        }

        /// <summary>
        /// Writes the menu for the user selection.
        /// </summary>
        /// <param name="generated">Has a maze been generated yet?</param>
        /// <returns>Returns the menu to be outputted.</returns>
        static string WriteMenu(bool generated)
        {
            string menuText = "Please Pick an Option from below:\n";
            if (generated)
            {
                menuText += "1.   Generate a maze. (Current maze will be lost if not saved!)\n";
                menuText += "2.   Load maze from file.  (Current maze will be lost if not saved!)\n";
                menuText += "3.   Save maze to file.\n";
            }
            else
            {
                menuText += "1.   Generate a maze.\n";
                menuText += "2.   Load maze from file.\n";
            }
            menuText += "x.   Exit\n";
            menuText += "Please enter selection: ";
            return menuText;
        }

        /// <summary>
        /// Makes a maze to a specified width and height, then outputs it.
        /// </summary>
        static void MakeMaze()
        {
            Console.Write("Please enter the width of the maze: ");
            int width = int.Parse(Console.ReadLine());

            Console.Write("Please enter the height of the maze: ");
            int height = int.Parse(Console.ReadLine());

            Maze = new Maze(width, height);
            Console.WriteLine("\n" + Maze.Display() + "\n");
        }

        /// <summary>
        /// Loads a maze from a file into memory.
        /// </summary>
        static void LoadMaze()
        {
            Console.WriteLine("Not Implemented!");
        }

        /// <summary>
        /// Saves a maze from memory to a file.
        /// </summary>
        static void SaveMaze()
        {
            Console.WriteLine("Not Implemented!");
        }
    }
}
