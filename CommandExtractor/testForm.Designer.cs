/**
 * The buttons need to be made smaller than they currently are - no need having huge
 * targets when this is exclusively going to be navigated using a mouse, as well as 
 * probably not having any icons taking up space.
 * Is there a way of automatically aligning buttons to a grid?
 * */


namespace CommandExtractor
{
    partial class testForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(testForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();

            //
            //coords1
            //

            this.coords1 = new int [,]{ 
                { 12, 5}, 
                { 118, 5}, 
                { 224, 5}, 
                { 224, 58}, 
                { 279, 5}, 
                { 279, 58}, 
                { 333, 5}, 
                { 333, 30}, 
                { 333, 58}, 
                { 333, 83},
                { 12+450, 5},
                { 118+450, 5},
                { 224+450, 5},
                { 224+450, 58},
                { 279+450, 5},
                { 279+450, 58},
                { 333+450, 5},
                { 333+450, 30},
                { 333+450, 58},
                { 333+450, 83}
            };

            //
            //coords2
            //

            this.coords2 = new int[,]{
                { 12, 5},
                { 118, 5},
                { 224, 5},
                { 330, 5},
                { 436, 5},
                { 12 + 553, 5},
                { 118 + 553, 5},
                { 224 + 553, 5},
                { 330 + 553, 5},
                { 436 + 553, 5},
            };

            //
            //sizes1
            //

            this.sizes1 = new System.Drawing.Size[20]{
                bigSize,
                bigSize,
                mediumSize,
                mediumSize,
                mediumSize,
                mediumSize,
                smallSize,
                smallSize,
                smallSize,
                smallSize,
                bigSize,
                bigSize,
                mediumSize,
                mediumSize,
                mediumSize,
                mediumSize,
                smallSize,
                smallSize,
                smallSize,
                smallSize
            };

            //
            //sizes2
            //

            this.sizes2 = new System.Drawing.Size[10]{
                bigSize,
                bigSize,
                bigSize,
                bigSize,
                bigSize,
                bigSize,
                bigSize,
                bigSize,
                bigSize,
                bigSize
            };

            //
            //group1
            //

            this.group1.Location = new System.Drawing.Point(0, 0);
            this.group1.Size = new System.Drawing.Size(coords1[9, 0]+25, coords1[9, 1]+10);
            this.group1.Name = "Group 1";
            this.group1.Text = this.group1.Name;

            //
            //buttons
            //

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new System.Windows.Forms.Button();
                this.Controls.Add(buttons[i]);
                this.buttons[i].Location = new System.Drawing.Point(coords1[i, 0], coords1[i, 1]);
                if (i > 9)
                {
                    buttons[i].Hide();
                }

            }

            //
            //fileOpen
            //
            this.fileOpen.InitialDirectory = "c:\\";
            this.fileOpen.Filter = "txt files (*.txt)|*.txt";
            this.fileOpen.FilterIndex = 2;
            this.fileOpen.RestoreDirectory = true;
            this.fileOpen.Multiselect = false;
            this.fileOpen.Title = "Select the .txt file with the desired filter";

            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Start();
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            //
            //OpenFileButton
            //

            this.Controls.Add(openFileButton);
            this.openFileButton.Location = new System.Drawing.Point(12, 110);
            this.openFileButton.Name = "Open Filter";
            this.openFileButton.Size = smallSize;
            this.openFileButton.TabIndex = 21;
            this.openFileButton.Text = this.openFileButton.Name;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            this.openFileButton.MouseHover += new System.EventHandler(this.openFileButton_Hover);

            //
            //closeFormButton
            //

            this.Controls.Add(closeFormButton);
            this.closeFormButton.Location = new System.Drawing.Point(118, 110);
            this.closeFormButton.Name = "Close Window";
            this.closeFormButton.Size = smallSize;
            this.closeFormButton.TabIndex = 22;
            this.closeFormButton.Text = this.closeFormButton.Name;
            this.closeFormButton.Click += new System.EventHandler(this.closeFormButton_Click);
            this.closeFormButton.MouseHover += new System.EventHandler(this.closeFormButton_Hover);

            //
            //getWindowButton
            //

            this.Controls.Add(getWindowButton);
            this.getWindowButton.Location = new System.Drawing.Point(224, 110);
            this.getWindowButton.Name = "Target Name";
            this.getWindowButton.Size = smallSize;
            this.getWindowButton.TabIndex = 23;
            this.getWindowButton.Text = this.getWindowButton.Name;
            this.getWindowButton.Click += new System.EventHandler(this.getWindowButton_Click);
            this.getWindowButton.MouseHover += new System.EventHandler(this.getWindowButton_Hover);


            //
            //bigButton1
            //


            this.buttons[0].Name = "Cut";
            this.buttons[0].Size = bigSize;
            this.buttons[0].TabIndex = 1;
            this.buttons[0].Text = this.buttons[0].Name;
            this.buttons[0].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[0].Click += new System.EventHandler(this.bigButton1_Click);
            this.buttons[0].MouseHover += new System.EventHandler(this.bigButton1_Hover);

            //
            //bigButton2
            //

            
            this.buttons[1].Name = "Paste";
            this.buttons[1].Size = bigSize;
            this.buttons[1].TabIndex = 2;
            this.buttons[1].Text = this.buttons[1].Name;
            this.buttons[1].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[1].Click += new System.EventHandler(this.bigButton2_Click);
            this.buttons[1].MouseHover += new System.EventHandler(this.bigButton2_Hover);

            //
            //medButton1
            //

            
            this.buttons[2].Name = "Underline";
            this.buttons[2].Size = mediumSize;
            this.buttons[2].TabIndex = 3;
            this.buttons[2].Text = this.buttons[2].Name;
            this.buttons[2].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[2].Click += new System.EventHandler(this.medButton1_Click);
            this.buttons[2].MouseHover += new System.EventHandler(this.medButton1_Hover);

            //
            //buttons[3]
            //

            
            this.buttons[3].Name = "Insert Footnote";
            this.buttons[3].Size = mediumSize;
            this.buttons[3].TabIndex = 4;
            this.buttons[3].Text = this.buttons[3].Name;
            this.buttons[3].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[3].Click += new System.EventHandler(this.medButton2_Click);
            this.buttons[3].MouseHover += new System.EventHandler(this.medButton2_Hover);

            //
            //buttons[4]
            //

            
            this.buttons[4].Name = "Center";
            this.buttons[4].Size = mediumSize;
            this.buttons[4].TabIndex = 5;
            this.buttons[4].Text = this.buttons[4].Name;
            this.buttons[4].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[4].Click += new System.EventHandler(this.medButton3_Click);
            this.buttons[4].MouseHover += new System.EventHandler(this.medButton3_Hover);

            //
            //buttons[5]
            //

           
            this.buttons[5].Name = "Align Left";
            this.buttons[5].Size = mediumSize;
            this.buttons[5].TabIndex = 6;
            this.buttons[5].Text = this.buttons[5].Name;
            this.buttons[5].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[5].Click += new System.EventHandler(this.medButton4_Click);
            this.buttons[5].MouseHover += new System.EventHandler(this.medButton4_Hover);

            //
            //buttons[6]
            //

            
            this.buttons[6].Name = "Align Right";
            this.buttons[6].Size = smallSize;
            this.buttons[6].TabIndex = 7;
            this.buttons[6].Text = this.buttons[6].Name;
            this.buttons[6].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttons[6].Click += new System.EventHandler(this.smallButton1_Click);
            this.buttons[6].MouseHover += new System.EventHandler(this.smallButton1_Hover);

            //
            //smallButton2
            //

           
            this.buttons[7].Name = "Bullets";
            this.buttons[7].Size = smallSize;
            this.buttons[7].TabIndex = 8;
            this.buttons[7].Text = this.buttons[7].Name;
            this.buttons[7].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttons[7].Click += new System.EventHandler(this.smallButton2_Click);
            this.buttons[7].MouseHover += new System.EventHandler(this.smallButton2_Hover);

            //
            //buttons[8]
            //

            
            this.buttons[8].Name = "Delete";
            this.buttons[8].Size = smallSize;
            this.buttons[8].TabIndex = 9;
            this.buttons[8].Text = this.buttons[8].Name;
            this.buttons[8].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttons[8].Click += new System.EventHandler(this.smallButton3_Click);
            this.buttons[8].MouseHover += new System.EventHandler(this.smallButton3_Hover);

            //
            //buttons[9]
            //

            
            this.buttons[9].Name = "New Comment";
            this.buttons[9].AutoEllipsis = true;
            this.buttons[9].Size = smallSize;
            this.buttons[9].TabIndex = 10;
            this.buttons[9].Text = this.buttons[9].Name;
            this.buttons[9].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttons[9].Click += new System.EventHandler(this.smallButton4_Click);
            this.buttons[9].MouseHover += new System.EventHandler(this.smallButton4_Hover);

            //
            //buttons[10]
            //


            this.buttons[10].AutoEllipsis = true;
            this.buttons[10].Size = bigSize;
            this.buttons[10].TabIndex = 11;
            this.buttons[10].Text = this.buttons[10].Name;
            this.buttons[10].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[10].Click += new System.EventHandler(this.button11_Click);
            this.buttons[10].MouseHover += new System.EventHandler(this.button11_Hover);

            //
            //buttons[11]
            //

            this.buttons[11].AutoEllipsis = true;
            this.buttons[11].Size = bigSize;
            this.buttons[11].TabIndex = 12;
            this.buttons[11].Text = this.buttons[11].Name;
            this.buttons[11].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[11].Click += new System.EventHandler(this.button12_Click);
            this.buttons[11].MouseHover += new System.EventHandler(this.button12_Hover);

            //
            //buttons[12]
            //

            this.buttons[12].AutoEllipsis = true;
            this.buttons[12].Size = mediumSize;
            this.buttons[12].TabIndex = 13;
            this.buttons[12].Text = this.buttons[12].Name;
            this.buttons[12].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[12].Click += new System.EventHandler(this.button13_Click);
            this.buttons[12].MouseHover += new System.EventHandler(this.button13_Hover);

            //
            //buttons[13]
            //

            this.buttons[13].AutoEllipsis = true;
            this.buttons[13].Size = mediumSize;
            this.buttons[13].TabIndex = 14;
            this.buttons[13].Text = this.buttons[13].Name;
            this.buttons[13].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[13].Click += new System.EventHandler(this.button14_Click);
            this.buttons[13].MouseHover += new System.EventHandler(this.button14_Hover);

            //
            //buttons[14]
            //

            this.buttons[14].AutoEllipsis = true;
            this.buttons[14].Size = mediumSize;
            this.buttons[14].TabIndex = 15;
            this.buttons[14].Text = this.buttons[14].Name;
            this.buttons[14].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[14].Click += new System.EventHandler(this.button15_Click);
            this.buttons[14].MouseHover += new System.EventHandler(this.button15_Hover);

            //
            //buttons[15]
            //

            this.buttons[15].AutoEllipsis = true;
            this.buttons[15].Size = mediumSize;
            this.buttons[15].TabIndex = 16;
            this.buttons[15].Text = this.buttons[15].Name;
            this.buttons[15].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[15].Click += new System.EventHandler(this.button16_Click);
            this.buttons[15].MouseHover += new System.EventHandler(this.button16_Hover);

            //
            //buttons[16]
            //

            this.buttons[16].AutoEllipsis = true;
            this.buttons[16].Size = mediumSize;
            this.buttons[16].TabIndex = 17;
            this.buttons[16].Text = this.buttons[16].Name;
            this.buttons[16].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[16].Click += new System.EventHandler(this.button17_Click);
            this.buttons[16].MouseHover += new System.EventHandler(this.button17_Hover);

            //
            //buttons[17]
            //

            this.buttons[17].AutoEllipsis = true;
            this.buttons[17].Size = mediumSize;
            this.buttons[17].TabIndex = 18;
            this.buttons[17].Text = this.buttons[17].Name;
            this.buttons[17].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[17].Click += new System.EventHandler(this.button18_Click);
            this.buttons[17].MouseHover += new System.EventHandler(this.button18_Hover);

            //
            //buttons[18]
            //

            this.buttons[18].AutoEllipsis = true;
            this.buttons[18].Size = mediumSize;
            this.buttons[18].TabIndex = 19;
            this.buttons[18].Text = this.buttons[18].Name;
            this.buttons[18].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[18].Click += new System.EventHandler(this.button19_Click);
            this.buttons[18].MouseHover += new System.EventHandler(this.button19_Hover);

            //
            //buttons[19]
            //

            this.buttons[19].AutoEllipsis = true;
            this.buttons[19].Size = mediumSize;
            this.buttons[19].TabIndex = 20;
            this.buttons[19].Text = this.buttons[19].Name;
            this.buttons[19].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons[19].Click += new System.EventHandler(this.button20_Click);
            this.buttons[19].MouseHover += new System.EventHandler(this.button20_Hover);

            //
            // status
            //

            this.Controls.Add(status);
            this.status.Size = new System.Drawing.Size(150, 20);
            this.status.Location = new System.Drawing.Point(0, 130);
            this.status.Text = "    Welcome to UI Filters!";

            // 
            // testForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.Controls.Add(this.group1);
            this.Name = "Filtered Ribbon";
            this.Text = this.Name;
            this.Load += new System.EventHandler(this.testForm_Load);
            this.ResumeLayout(false);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusBar status = new System.Windows.Forms.StatusBar();

        private System.Windows.Forms.GroupBox group1 = new System.Windows.Forms.GroupBox();
        private System.Windows.Forms.GroupBox group2 = new System.Windows.Forms.GroupBox();

        private System.Windows.Forms.Button[] buttons = new System.Windows.Forms.Button[20];
        private System.Windows.Forms.Button openFileButton = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button closeFormButton = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button getWindowButton = new System.Windows.Forms.Button();

        private InputParser parser = new InputParser();
        private FilterReadIn reader = new FilterReadIn();

        private int scrWidth = (int)System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        private int scrHeight = (int)System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        private int[,] coords1;
        private int[,] coords2;
        private System.Drawing.Size[] sizes1 = new System.Drawing.Size[20];
        private System.Drawing.Size[] sizes2 = new System.Drawing.Size[10];
        private System.Drawing.Size bigSize = new System.Drawing.Size(100, 100);
        private System.Drawing.Size mediumSize = new System.Drawing.Size(49, 47);
        private System.Drawing.Size smallSize = new System.Drawing.Size(100, 22);

        private System.Windows.Forms.OpenFileDialog fileOpen = new System.Windows.Forms.OpenFileDialog();
    }
}