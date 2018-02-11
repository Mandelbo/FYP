/*Current issues:
 * The windows form and inputparser cannot currently perform tasks at the same time, 
 * so the program hangs because the form isn't fully written.
 * Even when the form is complete, it will still need to perform tasks at the same time as 
 * the parser, such as polling the active window for size information and so on.
 * I suspect I will need to look into multithreading, and find a way of having the form
 * operate on its own thread while having the inputparser relegated to another so they can
 * both operate concurrently.
 *
 * What's the best way of getting the buttons to work? Every button needs its own invokation
 * method, so while instantiating all of them at once in an array may make more sense, it may
 * end up being harder to work with because I'm not certain how the methods would work if
 * all the buttons aren't separate instances. This could be fixed by writing a new class which
 * contains all the information about a button - including its invokation method - but I'm still
 * not entirely sure how the invokation method actually works, and whether or not separating it
 * from the form itself would preserve its functionality.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace CommandExtractor
{
    class Program
    {
        
        [STAThread]//This is necessary for the windows form to work. Apparently it specifies that the program should be single threaded. Maybe replacing this with MTAThread would help?
        static void Main()
        {
            /**ArrayList coreGroup;
            ArrayList contextGroup;

            InputParser parser = new InputParser();
            FilterReadIn reader = new FilterReadIn();

            reader.readInFile();
            coreGroup = reader.getCore();
            contextGroup = reader.getContext();

            
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new testForm());

            /**Thread testParse = new Thread(parser.wordFinder);
            testParse.Start();

            //This does not appear to work.
            Thread executeCommand = new Thread(() =>
                parser.itemLookup("New Comment")
            );
            executeCommand.Start();
            */
            

            //Console.WriteLine("Press any key to close window.");
            //Console.ReadKey();
        }

    }
}

/**It doesn't seem like any of this thread stuff works. What's clear is that every time a command is invoked, a new thread will
 * have to be made to find it. This appears to be simple to do - I could just write a method which makes a new thread and calls
 * the itemLookup function with the specified parameter, but that doesn't solve the problem of the windows form hogging all the
 * resources anyway.
 * */