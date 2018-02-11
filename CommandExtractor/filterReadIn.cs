using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CommandExtractor
{
    class FilterReadIn
    {
        Stream file = null;
        ArrayList core = new ArrayList();
        ArrayList context = new ArrayList();
        int index = 0;
        String currentLine;
        char layout = 'a';
        int breakPoint = 10;

        public LinkedList<String> readInFile(Stream inputStream)
        {
            file = inputStream;
            LinkedList<string> items = new LinkedList<string>();
            StreamReader reader = new StreamReader(file);
            bool breakpointSet = false;
            bool layoutSet = false;
            layout = 'a';
            breakPoint = 10;

            using (reader)
            {
                index = 0;
                Console.WriteLine("*Trying to read in selected file...");
                while(!reader.EndOfStream)
                {
                    currentLine = reader.ReadLine();

                    if (!String.IsNullOrEmpty(currentLine))
                    {
                        if (index > 19)
                        {
                            break;
                        }
                        if (currentLine[0] == '#')
                        {
                            Console.WriteLine("*Control line found: " + currentLine);
                            if(currentLine[1] == 'E' && !breakpointSet)
                            {
                                breakSet(index-1);
                                breakpointSet = true;
                            }
                            else if(currentLine[1] == 'L' && !layoutSet)
                            {
                                layoutChange(currentLine[currentLine.Length - 1]);
                            }
                        }

                        else
                        {
                            items.AddLast(currentLine);
                        }
                        index++;
                        
                    }
                    
                }
                Console.WriteLine("*" + index + " buttons found");
            }
            return items;
        }

        private void layoutChange(char newLayout)
        {
            if(newLayout != 'a' && newLayout != 'b')
            {
                newLayout = 'a';
            }

            layout = newLayout;
        }

        public char getLayout()
        {
            return layout;
        }

        private void breakSet(int newBreak)
        {
            if(newBreak > 10 || newBreak < 0)
            {
                newBreak = 10;
            }

            breakPoint = newBreak;
        }

        public int getBreak()
        {
            return breakPoint;
        }

        

        /**public void readInFile()
        {
            foreach(String line in inputFile)
            {
                if(line == "###" || index > 9)
                {
                    swapGroup = true;
                }
                if(swapGroup == false && line != "###")
                {
                    core.Add(line);
                }
                else if(swapGroup == true && line != "###")
                {
                    context.Add(line);
                }
                index+=1;
            }
        }**/

        public ArrayList getCore()
        {
            return core;
        }
        public ArrayList getContext()
        {
            return context;
        }
    }
}
