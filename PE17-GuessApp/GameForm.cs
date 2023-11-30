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
    public partial class GameForm : Form
    {
        int nRandom; //moved here to use form-wide
        int nGuesses = 1; //moved here b/c each time button was pressed, it was resetting to 1
        bool bCorrect = false;

        GameSettingsForm gameSettingsForm;
        public GameForm(int low, int high)
        {
            InitializeComponent();

            Random rand = new Random();
            nRandom = rand.Next(low, high);

            this.timer1.Tick += new EventHandler(Timer1__Tick);
            this.guessButton.Click += new EventHandler(GuessButton__Click);

            
        }

        private void GuessButton__Click(object sender, EventArgs e)
        {
            int? nGuess = null;
            string status;

            //convert text field entry into number
            try
            {
                timer1.Start();
                nGuess = Int32.Parse(currentGuessTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid numerical guess!");
            }

            if ( nGuess == this.nRandom )
            {
                bCorrect = true;
                timer1.Stop();
                MessageBox.Show($"Woohoo, you got it in {nGuesses} guesses!");
                this.Close();
            }
            else
            {
                if (nGuess > this.nRandom)
                {
                    status = "HIGH";
                }
                else
                {
                    status = "LOW";
                }

                outputLabel.Text = "Your guess of " + nGuess + " was " + status;
            }
            nGuesses++;
        }

        private void Timer1__Tick(object sender, EventArgs e)
        {
            this.toolStripProgressBar1.Value--;

            if (this.toolStripProgressBar1.Value == 0)
            {
                this.guessButton.Enabled = false;
                this.outputLabel.Text = "Times up!";
                this.toolStripProgressBar1.Value = this.toolStripProgressBar1.Maximum;
                timer1.Stop();

                if (bCorrect == false)
                {
                    MessageBox.Show($"Game over! The number was {nRandom}");
                    this.Close();
                }
            }
        }
    }
}
