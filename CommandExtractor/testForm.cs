using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CommandExtractor
{
    public partial class testForm : Form
    {
        private LinkedList<String> filter = new LinkedList<String>();

        private String[] groupNames = new String[2] { "Group 1", "Group 2" };

        private int breakPoint = 9;
        private char layout = 'a';

        public testForm()
        {
            InitializeComponent();
        }

        private void testForm_Load(object sender, EventArgs e)
        {
            //Thread loader = new Thread(loadFile);
            //loader.Start();
            if (!parser.wordFinder("WINWORD"))
            {
                MessageBox.Show("Could not find an instance of the specified program! Ensure your program is running, then restart UI Filters.");
                Application.Exit();
            }
            
            ClientSize = new System.Drawing.Size(parser.getWidth(), 150);
            Location = new System.Drawing.Point(parser.getX(), parser.getY() + 36);
            hideAll();
            status.Text = "   You haven't selected a Filter yet. Click the 'Open Filter' button to get started.";
        }

        //This method is called when the user tries to use the Open File button. The filestream of the selected text file is passed through to the file reader.
        private void loadFile()
        {
            if(fileOpen.ShowDialog() == DialogResult.OK)
            {
                status.Text = "   Trying to read in file...";

                filter = reader.readInFile(fileOpen.OpenFile());
                breakPoint = reader.getBreak();
                layout = reader.getLayout();

                Console.WriteLine("*Filter breakpoint = " + breakPoint);
                Console.WriteLine("*Filter layout = " + layout);

                status.Text = "   File read!";
                setFilter(filter);
            } 
        }

        //Runs through every button and applies styling based on filter
        private void setFilter(LinkedList<String> newFilter)
        {
            int index = 0;
            hideAll();
            for(int i = 0; i < newFilter.Count; i++)
            {
                
                if (layout == 'a')
                {
                    if (i == breakPoint)
                    {
                        index = 10;
                    }
                    if (index > 19)
                    {
                        break;
                    }
                    else
                    {
                        buttons[index].Location = new Point(coords1[index, 0], coords1[index, 1]);
                        buttons[index].Size = sizes1[index];
                        buttons[index].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    }
                    
                }
                else if (layout == 'b')
                {
                    if (i == breakPoint)
                    {
                        index = 5;
                    }
                    if (index > 9)
                    {
                        break;
                    }
                    else
                    {
                        buttons[index].Location = new Point(coords2[index, 0], coords2[index, 1]); //watch for out of bounds exceptions here
                        buttons[index].Size = sizes2[index];
                        buttons[index].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    }
                    
                }
                buttons[index].Name = newFilter.ElementAt(i);
                buttons[index].Text = buttons[index].Name;
                buttons[index].Show();
                index++;
            }
        }

        //This method hides every button on the form.
        private void hideAll()
        {
            foreach(Button b in buttons)
            {
                b.Hide();
            }
        }

        private void displayName()
        {
            MessageBox.Show("Target window is: " + parser.getWindowName() + ".");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(ClientSize != new System.Drawing.Size(parser.getWidth(), 150))
            {
                ClientSize = new System.Drawing.Size(parser.getWidth(), 150);
            }

            if (Location != new System.Drawing.Point(parser.getX(), parser.getY() + 36))
            {
                Location = new System.Drawing.Point(parser.getX(), parser.getY() + 36);
            }

            if(parser.zOrderCheck() == true)
            {
                BringToFront();
            }

            if(parser.offscreen() == true)
            {
                Hide();
            }
            else
            {
                Show();
                //TopMost = true;
            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            loadFile();
        }

        private void closeFormButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void getWindowButton_Click(object sender, EventArgs e)
        {
            displayName();
        }

        private void bigButton1_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[0].Name);
        }

        private void bigButton2_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[1].Name);
        }

        private void medButton1_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[2].Name);
        }

        private void medButton2_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[3].Name);
        }

        private void medButton3_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[4].Name);
        }

        private void medButton4_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[5].Name);
        }

        private void smallButton1_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[6].Name);
        }

        private void smallButton2_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[7].Name);
        }

        private void smallButton3_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[8].Name);
        }

        private void smallButton4_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[9].Name);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[10].Name);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[11].Name);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[12].Name);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[13].Name);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[14].Name);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[15].Name);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[16].Name);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[17].Name);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[18].Name);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            parser.itemLookup(buttons[19].Name);
        }

        private void openFileButton_Hover(object sender, EventArgs e)
        {
            status.Text = "   Open a new filter.";
        }

        private void closeFormButton_Hover(object sender, EventArgs e)
        {
            status.Text = "   Close UI Filters.";
        }

        private void getWindowButton_Hover(object sender, EventArgs e)
        {
            status.Text = "   Display the name of the target program window.";
        }

        private void bigButton1_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[0].Name);
        }

        private void bigButton2_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[1].Name);
        }

        private void medButton1_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[2].Name);
        }

        private void medButton2_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[3].Name);
        }

        private void medButton3_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[4].Name);
        }

        private void medButton4_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[5].Name);
        }

        private void smallButton1_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[6].Name);
        }

        private void smallButton2_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[7].Name);
        }

        private void smallButton3_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[8].Name);
        }

        private void smallButton4_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[9].Name);
        }

        private void button11_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[10].Name);
        }

        private void button12_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[11].Name);
        }

        private void button13_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[12].Name);
        }

        private void button14_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[13].Name);
        }

        private void button15_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[14].Name);
        }

        private void button16_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[15].Name);
        }

        private void button17_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[16].Name);
        }

        private void button18_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[17].Name);
        }

        private void button19_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[18].Name);
        }

        private void button20_Hover(object sender, EventArgs e)
        {
            status.Text = parser.helpLookup(buttons[19].Name);
        }
    }
}
