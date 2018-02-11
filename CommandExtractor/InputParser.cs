using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Windows;

namespace CommandExtractor
{
    //This class is used to interface with the target program.
    class InputParser
    {
        AutomationElement wordAuto;
        PropertyCondition isTab = new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "Tab Item");
        PropertyCondition isButton = new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "Button");
        PropertyCondition findTabs = new PropertyCondition(AutomationElement.NameProperty, "Ribbon");
        PropertyCondition findButtons = new PropertyCondition(AutomationElement.NameProperty, "Lower Ribbon");

        Hashtable hashList = new Hashtable();
        Hashtable helpText = new Hashtable();

        //Method: This creates a hashtable with the name of the given tab as the first element, with the names of its associated controls listed afterwards.
        private void hashMaker(AutomationElementCollection inputElements, AutomationElement tab)
        {

            foreach(AutomationElement auto in inputElements)
            {
                if (!hashList.ContainsKey(auto.Current.Name))
                {
                    hashList.Add(auto.Current.Name, tab.Current.Name);
                    helpText.Add(auto.Current.Name, "   " + auto.Current.HelpText); //The three spaces serve as padding so the status bar text doesn't go off the side of the screen.
                }
            }

        }

        //Method: Print the values and associated keys inside the given Hashtable
        private void printHash()
        {
            foreach(DictionaryEntry entry in hashList)
            {
                String temp = (String) entry.Value;
                Console.WriteLine("Key: " + entry.Key + " | " + "Value: " + temp);
            }
        }

        //Read all the tabs and construct hashtables for them.
        private void tabScanner(bool printTabs)
        {
            AutomationElement ribbonLocation = wordAuto.FindFirst(TreeScope.Descendants, findTabs);
            AutomationElementCollection wordChildren = ribbonLocation.FindAll(TreeScope.Descendants, isTab);
            int index = 0;

            foreach (AutomationElement auto in wordChildren)
            {
                selectTab(auto);
                AutomationElement lowRib = ribbonLocation.FindFirst(TreeScope.Descendants, findButtons);
                AutomationElementCollection currentButtons = lowRib.FindAll(TreeScope.Descendants, isButton);
                hashMaker(currentButtons, auto);
                index += 1;
            }

            if(printTabs == true)
            {
                printHash();
            }
            if(index == 0)
            {
                Console.WriteLine("The ribbon was not found. Is it set to auto-hide?");
            }
        }

        //Method: This method finds the first instance of word, if one exists.
        public bool wordFinder(String processName)
        {
            int processAsInt;
            Process wordProcess;
            bool wordExists = false;
            int index = 0;


            Console.WriteLine("Trying to get all desktop children...");

            //This grabs every window currently open on the desktop
            AutomationElementCollection desktopChildren = AutomationElement.RootElement.FindAll(TreeScope.Children, Condition.TrueCondition);
            Console.WriteLine("Current Window order:");

            foreach(AutomationElement auto in desktopChildren)
            {
                processAsInt = (int)auto.GetCurrentPropertyValue(AutomationElement.ProcessIdProperty);
                wordProcess = Process.GetProcessById(processAsInt);
                Console.WriteLine("*" + index + ". " + wordProcess.ProcessName);
                if (wordProcess.ProcessName == processName)
                {
                    wordAuto = auto;
                    wordExists = true;
                    break;
                }
                index++;
            }

            if(wordExists == true)
            {
                Console.WriteLine("Instance of Word found.");
                tabScanner(true);

            }
            else
            {
                Console.WriteLine("There is no instance of Word running.");
            }
            return wordExists;
        }

        //Method: Tries to invoke the given button. If the button cannot be used, say so!
        private void invokeButton(AutomationElement input)
        {
            
            if(input.Current.IsEnabled == true)
            {
                try
                {
                    object outputPattern;
                    InvokePattern activateButton;
                    TogglePattern toggleButton;
                    if (true == input.TryGetCurrentPattern(InvokePattern.Pattern, out outputPattern))
                    {
                        activateButton = outputPattern as InvokePattern;
                        activateButton.Invoke();
                        Console.WriteLine("* " + input.Current.Name + " was invoked.");
                    }
                    else if(true == input.TryGetCurrentPattern(TogglePattern.Pattern, out outputPattern)){
                        toggleButton = outputPattern as TogglePattern;
                        toggleButton.Toggle();
                        Console.WriteLine("* " + input.Current.Name + " was toggled.");
                    }
                    
                } catch(InvalidOperationException ex)
                {
                    Console.WriteLine("Command could not be invoked correctly: " + ex.Message);
                }
                
            }
            else
            {
                Console.WriteLine(input.Current.Name + " cannot be invoked at the moment.");
            }
        }

        //Method: Selects the given tab if it isn't already selected, otherwise do nothing.
        private void selectTab(AutomationElement input)
        {
            try
            {
                SelectionItemPattern tabCheck;
                tabCheck = input.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                if (tabCheck.Current.IsSelected == false)
                {
                    tabCheck.Select();
                    Console.WriteLine("* " + input.Current.Name + " was selected.");
                }
                else
                {
                    Console.WriteLine("* " + input.Current.Name + " is already selected!");
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("***" + ex.Message + "***");
            }
            
        }

        //OLD: Given the name of a command, search each tab's linked list to see where it exists, then select the tab and invoke the button.
        /**public void itemLookup(String commandName)
        {
            bool commandFound = false;
            String command = commandName;
            String tabName;          
            foreach(Hashtable h in hashes)
            {
                if (h.ContainsValue(commandName))
                {
                    commandFound = true;
                    tabName = (String) h[0];
                    PropertyCondition locateTab = new PropertyCondition(AutomationElement.NameProperty, tabName);
                    PropertyCondition locateButton = new PropertyCondition(AutomationElement.NameProperty, commandName);

                    AutomationElement tab =  wordAuto.FindFirst(TreeScope.Descendants, locateTab);
                    selectTab(tab);
                    AutomationElement lowRib = wordAuto.FindFirst(TreeScope.Descendants, findButtons);
                    AutomationElement button = lowRib.FindFirst(TreeScope.Descendants, locateButton);
                    Console.WriteLine(button.Current.Name + " was found.");
                    invokeButton(button);

                }
            }
            if (commandFound == false)
            {
                Console.WriteLine(commandName + " doesn't exist!");
            }

        }**/

        //Find the entry in the hashList whose key corresponds to the command, then get the tab listed under that key and invoke the command.
        public void itemLookup(String command)
        {
            try
            {
                String tabName = (String)hashList[command];

                PropertyCondition locateTab = new PropertyCondition(AutomationElement.NameProperty, tabName);
                PropertyCondition locateButton = new PropertyCondition(AutomationElement.NameProperty, command);

                AutomationElement tab = wordAuto.FindFirst(TreeScope.Descendants, locateTab);
                selectTab(tab);
                AutomationElement lowRib = wordAuto.FindFirst(TreeScope.Descendants, findButtons);
                AutomationElement button = lowRib.FindFirst(TreeScope.Descendants, locateButton);
                Console.WriteLine("* " + button.Current.Name + " was found.");
                invokeButton(button);
            } catch(NullReferenceException ex)
            {
                Console.WriteLine("***Could not find " + command + "! Did you type the name correctly?***");
            }
            
        }

        //Finds the tooltip text for the given command.
        public String helpLookup(String command)
        {
            try
            {
                String help = (String)helpText[command];
                return help;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("***Could not find item specified! Did you type the name correctly?***");
                return null;
            }

        }

        public int getWidth()
        {
            try
            {
                Rect targetRect = new Rect();
                targetRect = wordAuto.Current.BoundingRectangle;

                int width = (int)targetRect.Width;

                return width;
            } catch(NullReferenceException ex)
            {
                Console.WriteLine("Window width could not be found: " + ex);
                return 0;
            }
           
        }

        public int getY()
        {
            try
            {
                Rect targetRect = new Rect();
                targetRect = wordAuto.Current.BoundingRectangle;

                int position = (int)targetRect.Y;

                return position;
            }catch(NullReferenceException ex)
            {
                Console.WriteLine("Y-value could not be found: " + ex);
                return 0;
            }
            
        }

        public int getX()
        {
            try
            {
                Rect targetRect = new Rect();
                targetRect = wordAuto.Current.BoundingRectangle;

                int position = (int)targetRect.X;

                return position;
            }catch(NullReferenceException ex)
            {
                Console.WriteLine("X-value could not be found: " + ex);
                return 0;
            }
            
        }

        public String getWindowName()
        {
            String name = wordAuto.Current.Name;
            return name;
        }

        public bool offscreen()
        {
            try
            {
                bool visible = wordAuto.Current.IsOffscreen;
                return visible;
            }catch(NullReferenceException ex)
            {
                Console.WriteLine("Window could not be identified: " + ex);
                return false;
            }
            
        }

        public bool zOrderCheck()
        {
            AutomationElement topMost = AutomationElement.RootElement.FindFirst(TreeScope.Children, Condition.TrueCondition);
            int processAsInt = (int)topMost.GetCurrentPropertyValue(AutomationElement.ProcessIdProperty);
            Process topProcess = Process.GetProcessById(processAsInt);
            if(topProcess.ProcessName == "WINWORD")
            {
                //Console.WriteLine("Word is on top.");
                return true;
            }
            else
            {
                //Console.WriteLine("Word is not on top.");
                return false;
            }
        }

    }
}
