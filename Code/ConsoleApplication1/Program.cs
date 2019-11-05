using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerApplication
{
    class Program
    {
        struct Mower
        {
            public int x;
            public int y;
            public char orientation;//Only N,S,W,E are allowed 
        }
        struct Lawn
        {
            public int width;
            public int length;
        }
        static void Main(string[] args)
        {
            var p = new Program();
            p.RunFile(@"File.txt");
        }
        public void RunFile(string FileName)
        {
           
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(FileName);
                     
            //Get the lawn's witdh and length
            Lawn lawn = new Lawn();                              
            lawn.length = (int)Char.GetNumericValue(lines[0][0]) +1 ;//add one because coordinates of corners starts with (0,0)
            lawn.width = (int)Char.GetNumericValue(lines[0][0])+1 ; 
            for (int j = 1; j< lines.Length; j= j+2) 
            {
                Mower mower = new Mower();
                //Get the mower's initial position and orientation             
                mower.x = (int)Char.GetNumericValue(lines[j][0]);
                mower.y = (int)Char.GetNumericValue(lines[j][2]);
                mower.orientation = lines[j][4];
                //Reading and interpreting the sequence of instruction                  
                foreach (char instruction in lines[j+1])
                {                   
                    switch (instruction)
                    {
                        case 'F': //Moving forward while respecting the oriontation of the mower
                            {
                                if (mower.orientation.Equals('N') && mower.y < lawn.width - 1) //then we add 1 to y 
                                {
                                    mower.y = mower.y + 1;
                                }
                                if (mower.orientation.Equals('S') && mower.y > 0)
                                {
                                    mower.y = mower.y - 1;
                                }
                                if (mower.orientation.Equals('E') && mower.x < lawn.length - 1) //then we add 1 to x 
                                {
                                    mower.x = mower.x + 1;
                                }
                                if (mower.orientation.Equals('W') && mower.x > 0)
                                {
                                    mower.x = mower.x - 1;
                                }
                            }
                            break;
                        case 'L'://Rotate the mower to the left with 90°
                            {
                                switch (mower.orientation)
                                {
                                    case 'N':
                                        mower.orientation = 'W';
                                        break;
                                    case 'S':
                                        mower.orientation = 'E';
                                        break;
                                    case 'E':
                                        mower.orientation = 'N';
                                        break;
                                    case 'W':
                                        mower.orientation = 'S';
                                        break;
                                }
                                                               

                            }
                            break;
                        case 'R'://Rotate the mower to the right with 90°
                            {
                                switch (mower.orientation)
                                {
                                    case 'N':
                                        mower.orientation = 'E';
                                        break;
                                    case 'S':
                                        mower.orientation = 'W';
                                        break;
                                    case 'E':
                                        mower.orientation = 'S';
                                        break;
                                    case 'W':
                                        mower.orientation = 'N';
                                        break;
                                }                            
                            }
                            break;
                    }

                    
                }
                Console.WriteLine("\n" + mower.x +" "+ mower.y+" "+ mower.orientation);      
                                    
            }
            Console.WriteLine("\n" + "Press any button to continue...");
            Console.ReadKey();

        }
       
    }
}
