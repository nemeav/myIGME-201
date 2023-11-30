using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE17_GuessApp
{
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();

            this.button1.Click += new EventHandler(StartButton__Click);
        }

        private void StartButton__Click(object sender, EventArgs e)
        {
            bool bConv;
            int lowNumber = 0;
            int highNumber = 0;

            // convert the strings entered in lowTextBox and highTextBox
            // to lowNumber and highNumber Int32.Parse
            try
            {
                lowNumber = Int32.Parse(lowTextBox.Text);

                highNumber = Int32.Parse(highTextBox.Text);
                bConv = true;
            }
            catch
            {
                bConv = false;
            }

            //check if lowest number is in fact lower than the high
            if ( highNumber < lowNumber )
            {
                bConv = false;
            }

            // if not a valid range
            //started all this before seeing the KeyPress and Char.IsDigit() part but still works the same so didn't change it
            if ( bConv == false )
            {
                // show a dialog that the numbers are not valid
                MessageBox.Show("The numbers are invalid.");
            }
            else
            {
                // otherwise we're good
                // create a form object of the second form 
                // passing in the number range
                GameForm gameForm = new GameForm(lowNumber, highNumber);

                // display the form as a modal dialog, 
                // which makes the first form inactive
                gameForm.ShowDialog();
            }
        }

    }
}
