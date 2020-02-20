using System;
using System.Collections.Generic;
using System.Text;
using Sharprompt;
using Newtonsoft.Json;
using System.IO;

namespace ASCIIMazeGenerator
{
    class Menu
    {
        public Menu()
        {
            Console.Clear();
            switch (Prompt.Select(MenuText.SELECT_OPTION, new[] 
            {
                MenuText.OPTION_GENERATE_DEFAULT,
                MenuText.OPTION_GENERATE_CUSTOM,
                MenuText.OPTION_OPEN_FROM_FILE,
                MenuText.OPTION_EXIT_PROGRAM
            }))
            {
                case MenuText.OPTION_GENERATE_DEFAULT:
                    Generate(Default.MAZE_WIDTH, Default.MAZE_HEIGHT);
                    break;
                case MenuText.OPTION_GENERATE_CUSTOM:
                    var inputWidth = Prompt.Input<int>(MenuText.INPUT_MAZE_WIDTH);
                    var inputHeight = Prompt.Input<int>(MenuText.INPUT_MAZE_HEIGHT);
                    Generate(inputWidth, inputHeight);
                    break;
                case MenuText.OPTION_OPEN_FROM_FILE:
                    Open();
                    break;
                case MenuText.OPTION_EXIT_PROGRAM:
                    break;
            }
        }
        private void Generate(int width, int height)
        {
            Console.WriteLine(MenuText.GENERATING, width, height);
            Loaded(new Maze(width, height));
        }
        private void Open()
        {
            while (true)
            {
                try
                {
                    var inputFileName = Prompt.Input<string>(MenuText.OPEN_INPUT_FILE_NAME);
                    if (!inputFileName.Contains(Default.FILE_EXTENSION))
                    {
                        inputFileName += Default.FILE_EXTENSION;
                    }
                    using StreamReader file = File.OpenText(inputFileName);
                    JsonSerializer serializer = new JsonSerializer();
                    Loaded((Maze)serializer.Deserialize(file, typeof(Maze)));
                }
                catch (IOException)
                {
                    Console.WriteLine(MenuText.IO_ERROR);
                    switch (Prompt.Select(MenuText.SELECT_OPTION, new[]
                    {
                    MenuText.OPTION_TRY_AGAIN,
                    MenuText.OPTION_RETURN
                }))
                    {
                        case MenuText.OPTION_TRY_AGAIN:
                            break;
                        case MenuText.OPTION_RETURN:
                            new Menu();
                            break;
                    }
                } 
            }
        }
        private void Loaded(Maze maze)
        {
            Console.WriteLine(Environment.NewLine + maze.Display());
            switch (Prompt.Select(MenuText.SELECT_OPTION, new[]
            {
                MenuText.OPTION_SAVE_TO_FILE,
                MenuText.OPTION_GENERATE_NEW,
                MenuText.OPTION_RETURN
            }))
            {
                case MenuText.OPTION_SAVE_TO_FILE:
                    SaveToFile(maze);
                    break;
                case MenuText.OPTION_GENERATE_NEW:
                    Generate(maze.Width, maze.Height);
                    break;
                case MenuText.OPTION_RETURN:
                    new Menu();
                    break;
            }
        }
        private void SaveToFile(Maze maze)
        {
            var inputFileName = Prompt.Input<string>(MenuText.SAVE_INPUT_FILE_NAME);
            if (!inputFileName.Contains(Default.FILE_EXTENSION))
            {
                inputFileName += Default.FILE_EXTENSION;
            }
            using StreamWriter file = File.CreateText(inputFileName);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, maze);
        }
    }
}
