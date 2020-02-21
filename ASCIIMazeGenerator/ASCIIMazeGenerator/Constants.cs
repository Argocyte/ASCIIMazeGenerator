namespace ASCIIMazeGenerator
{
    public static class Passage
    {
        public const char NONE = '▒';
        public const char NORTHSOUTHEASTWEST = '╬';
        public const char NORTHSOUTHEAST = '╠';
        public const char NORTHSOUTHWEST = '╣';
        public const char NORTHEASTWEST = '╩';
        public const char SOUTHEASTWEST = '╦';
        public const char NORTHSOUTH = '║';
        public const char NORTHEAST = '╚';
        public const char NORTHWEST = '╝';
        public const char SOUTHEAST = '╔';
        public const char SOUTHWEST = '╗';
        public const char EASTWEST = '═';
        public const char NORTH = NORTHSOUTH; //don't have a capped ASCII character, which is unfortunate. This works fine.
        public const char SOUTH = NORTHSOUTH;
        public const char EAST = EASTWEST;
        public const char WEST = EASTWEST;
    }
    public static class Default
    {
        public const int MAZE_WIDTH = 25;
        public const int MAZE_HEIGHT = 25;
        public const char WILDCARD = '*';
        public const string MZE_FILE_EXTENSION = ".mze";
        public const string TXT_FILE_EXTENSION = ".txt";
        public const string MZE_FILE_FOLDER = "MazeFiles\\";
        public const string TXT_FILE_FOLDER = "MazeOutpt\\";
    }
    public static class MenuOption
    {
        public const string GENERATE_DEFAULT = "Generate a maze of a standard size";
        public const string GENERATE_CUSTOM = "Generate a custom sized maze";
        public const string GENERATE_NEW = "Generate a new maze of the same size";
        public const string SAVE_TO_FILE = "Save current maze to a file";
        public const string OPEN_FROM_FILE = "Open a maze from a file";
        public const string OUTPUT_TO_TXT = "Output this maze to a text file";
        public const string TRY_AGAIN = "Try again";
        public const string RETURN = "Return to main menu";
        public const string EXIT_PROGRAM = "Exit the program";
    }
    public static class MenuPrompt
    {
        public const string SELECT_OPTION = "Select an option";
        public const string INPUT_MAZE_WIDTH = "Enter the width";
        public const string INPUT_MAZE_HEIGHT = "Enter the height";
        public const string SAVE_INPUT_FILE_NAME = "Input the name you wish to call this maze";
        }
    public static class MenuConfirm
    {
        public const string OVERWRITE = "Do you want to over-write this file? Original will be lost";
        public const string ENTER_AGAIN = "Do you want to try again with a different file name?";
    }
    public static class Progress
    {
        public const string GENERATE = "Generating a maze of size ({0}, {1})...";
        public const string SAVE = "Saving maze as {0}...";
        public const string OPEN = "Opening maze {0}...";
        public const string SUCCESS_GENERATE = "Generated a maze of size ({0}, {1})";
        public const string SUCCESS_SAVE = "Saved maze as: {0}";
        public const string SUCCESS_OPEN = "Opened maze at: {0}";
    }
    public static class Error
    {
        public const string NO_MAZES_SAVED = "There are no mazes saved";
        public const string SAVE_FILE_EXISTS = "A file by the name of {0} already exists";
        public const string MAZE_TOO_BIG = "The size for the maze you entered is too big";
        public const string INVALID_FILE_NAME = "The file name {0} has invalid characters";
    }
}