using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement; //keeps adding this and i'm too tired to keep deleting it

namespace UT3_Q1_PresidentApp
{
    public partial class presidentsForm : Form
    {
        //variables needed throughout program
        string wikiPrefix = "https://en.m.wikipedia.org/wiki/";
        string imgPrefix = "https://people.rit.edu/dxsigm/";
        int bComplete = 0;
        ErrorProvider errorProvider = new ErrorProvider();

        public presidentsForm()
        {
            InitializeComponent();

            //adding IE
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            //event handler for browser load - anchor manipulation
            this.webBrowser1.DocumentCompleted += new
            WebBrowserDocumentCompletedEventHandler(WebBrowser1__DocumentCompleted);

            //to use the URL - starts at harrison
            this.webBrowser1.Navigate(wikiPrefix + "Benjamin_Harrison");
            this.groupBox1.Text = wikiPrefix + "Benjamin_Harrison";

            this.ControlBox = false;
            this.toolStripProgressBar.Value = this.toolStripProgressBar.Maximum;
            this.exitButton.Enabled = false;

            //picture box events
            this.pictureBox1.MouseHover += new EventHandler(PictureBox__MouseHover);
            this.pictureBox1.MouseLeave += new EventHandler(PictureBox__MouseLeave);

            //radio button events - pres
            this.bHRadioButton.CheckedChanged += new EventHandler(President__CheckedChanged);
            this.fDRRadioButton.CheckedChanged += President__CheckedChanged;
            this.wJCRadioButton.CheckedChanged += President__CheckedChanged;
            this.jBRadioButton.CheckedChanged += President__CheckedChanged;
            this.fPRadioButton.CheckedChanged += President__CheckedChanged;
            this.gWBRadioButton.CheckedChanged += President__CheckedChanged;
            this.bORadioButton.CheckedChanged += President__CheckedChanged;
            this.jFKRadioButton.CheckedChanged += President__CheckedChanged;
            this.wMRadioButton.CheckedChanged += President__CheckedChanged;
            this.rRRadioButton.CheckedChanged += President__CheckedChanged;
            this.dDERadioButton.CheckedChanged += President__CheckedChanged;
            this.mVBRadioButton.CheckedChanged += President__CheckedChanged;
            this.gWRadioButton.CheckedChanged += President__CheckedChanged;
            this.jARadioButton.CheckedChanged += President__CheckedChanged;
            this.tRRadioButton.CheckedChanged += President__CheckedChanged;
            this.tJRadioButton.CheckedChanged += President__CheckedChanged;

            //radio button events - radioButton.Checked
            this.allRadioButton.Checked = true;
            this.allRadioButton.CheckedChanged += new EventHandler(Filter__CheckedChanged);
            this.democratRadioButton.CheckedChanged += Filter__CheckedChanged;
            this.republicanRadioButton.CheckedChanged += Filter__CheckedChanged;
            this.dRRadioButton.CheckedChanged += Filter__CheckedChanged;
            this.federalistRadioButton.CheckedChanged += Filter__CheckedChanged;

            //textbox event handlers - mouse
            this.textBox1.MouseHover += new EventHandler(TextBox__MouseHover);
            this.textBox2.MouseHover += TextBox__MouseHover;
            this.textBox3.MouseHover += TextBox__MouseHover;
            this.textBox4.MouseHover += TextBox__MouseHover;
            this.textBox5.MouseHover += TextBox__MouseHover;
            this.textBox6.MouseHover += TextBox__MouseHover;
            this.textBox7.MouseHover += TextBox__MouseHover;
            this.textBox8.MouseHover += TextBox__MouseHover;
            this.textBox9.MouseHover += TextBox__MouseHover;
            this.textBox10.MouseHover += TextBox__MouseHover;
            this.textBox11.MouseHover += TextBox__MouseHover;
            this.textBox12.MouseHover += TextBox__MouseHover;
            this.textBox13.MouseHover += TextBox__MouseHover;
            this.textBox14.MouseHover += TextBox__MouseHover;
            this.textBox15.MouseHover += TextBox__MouseHover;
            this.textBox16.MouseHover += TextBox__MouseHover;

            //key press for timer start
            this.textBox1.KeyPress += new KeyPressEventHandler(TextBox__KeyPress);
            this.textBox2.KeyPress += TextBox__KeyPress;
            this.textBox3.KeyPress += TextBox__KeyPress;
            this.textBox4.KeyPress += TextBox__KeyPress;
            this.textBox5.KeyPress += TextBox__KeyPress;
            this.textBox6.KeyPress += TextBox__KeyPress;
            this.textBox7.KeyPress += TextBox__KeyPress;
            this.textBox8.KeyPress += TextBox__KeyPress;
            this.textBox9.KeyPress += TextBox__KeyPress;
            this.textBox10.KeyPress += TextBox__KeyPress;
            this.textBox11.KeyPress += TextBox__KeyPress;
            this.textBox12.KeyPress += TextBox__KeyPress;
            this.textBox13.KeyPress += TextBox__KeyPress;
            this.textBox14.KeyPress += TextBox__KeyPress;
            this.textBox15.KeyPress += TextBox__KeyPress;
            this.textBox16.KeyPress += TextBox__KeyPress;

            //text cahnged for each text box
            this.textBox1.Leave += new EventHandler(TextBox__Leave);
            this.textBox2.Leave += TextBox__Leave;
            this.textBox3.Leave += TextBox__Leave;
            this.textBox4.Leave += TextBox__Leave;
            this.textBox5.Leave += TextBox__Leave;
            this.textBox6.Leave += TextBox__Leave;
            this.textBox7.Leave += TextBox__Leave;
            this.textBox8.Leave += TextBox__Leave;
            this.textBox9.Leave += TextBox__Leave;
            this.textBox10.Leave += TextBox__Leave;
            this.textBox11.Leave += TextBox__Leave;
            this.textBox12.Leave += TextBox__Leave;
            this.textBox13.Leave += TextBox__Leave;
            this.textBox14.Leave += TextBox__Leave;
            this.textBox15.Leave += TextBox__Leave;
            this.textBox16.Leave += TextBox__Leave;

            //exit handler
            this.exitButton.Click += new EventHandler(ExitButton__Click);

            //timer handler
            this.timer1.Tick += new EventHandler(Timer1__Tick);
        }



        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)sender;
            HtmlElementCollection htmlElementCollection;

            //change anchor tags to president schuh tooltip
            htmlElementCollection = this.webBrowser1.Document.GetElementsByTagName("a");
            foreach (HtmlElement elem in htmlElementCollection)
            {
                elem.SetAttribute("title", "Professor Schuh for President!");
            }
        }

        //picture box handlers - manage resing on mouse events
        private void PictureBox__MouseHover(object sender, EventArgs e)
        {
            this.pictureBox1.Size = new Size(301, 365);
        }

        private void PictureBox__MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Size = new Size(145, 196);
        }

        //pres handler
        public void President__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton presRb = (RadioButton)sender;

            //changes picture box and wiki page based on radio selection
            if (presRb.Checked)
            {

                string imgName = presRb.Text.Replace("\u0020", "");
                string extension;
                if (imgName == "BarackObama") //had to manage names because obama is a png for some reason
                {
                    extension = ".png"; //this is cruel btw
                }
                else
                {
                    extension = ".jpeg";
                }
                string imgUrl = imgPrefix + imgName + extension;
                pictureBox1.ImageLocation = imgUrl;

                string wikiUrl = wikiPrefix + presRb.Text.Replace(' ', '_');
                this.webBrowser1.Navigate(wikiUrl);
                groupBox1.Text = wikiUrl;
            }
        }

        private void Filter__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            //looks through all controls
            foreach (Control radio in this.Controls)
            {
                //finds radio controls
                if (radio.GetType() == typeof(RadioButton))
                {
                    //all filter makes all visible
                    if (rb.Checked == allRadioButton.Checked)
                    {
                        if (radio.Tag != null)
                        {
                            radio.Visible = true;
                        };
                    }
                    //democrat visible only
                    else if (rb.Checked == democratRadioButton.Checked)
                    {
                        if (radio.Tag.ToString() == "Democrat" || radio.Tag.ToString() == "Filter")
                        {
                            radio.Visible = true;
                        }
                        else
                        {
                            radio.Visible = false;
                        }
                    }
                    //repub. visible only
                    else if (rb.Checked == republicanRadioButton.Checked)
                    {
                        if (radio.Tag.ToString() == "Republican" || radio.Tag.ToString() == "Filter")
                        {
                            radio.Visible = true;
                        }
                        else
                        {
                            radio.Visible = false;
                        }
                    }
                    //dem-rep. visible only
                    else if (rb.Checked == dRRadioButton.Checked)
                    {
                        if (radio.Tag.ToString() == "DR" || radio.Tag.ToString() == "Filter")
                        {
                            radio.Visible = true;
                        }
                        else
                        {
                            radio.Visible = false;
                        }
                    }
                    //fed. visible only
                    else if (rb.Checked == federalistRadioButton.Checked)
                    {
                        if (radio.Tag.ToString() == "Federalist" || radio.Tag.ToString() == "Filter")
                        {
                            radio.Visible = true;
                        }
                        else
                        {
                            radio.Visible = false;
                        }
                    }
                }
            }
        }

        private void TextBox__MouseHover(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            ToolTip toolTip = new ToolTip();
            toolTip.IsBalloon = true;
            toolTip.SetToolTip(textBox, "Which # President?");
        }

        private void TextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            timer1.Start();
        }

        private void TextBox__Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text != textBox.Tag.ToString())
            {
                errorProvider.SetError(textBox, "That is the wrong number.");
            }
            else
            {
                errorProvider.SetError(textBox, "");
                bComplete++;
            }

            if (bComplete == 16)
            {
                this.webBrowser1.Navigate("https://media.giphy.com/media/TmT51OyQLFD7a/giphy.gif");
                this.exitButton.Enabled = true;
                timer1.Stop();
            }
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Timer1__Tick(object sender, EventArgs e)
        {
            this.toolStripProgressBar.Value--;

            if (this.toolStripProgressBar.Value == 0 )
            {
                this.textBox1.Text = "0";
                this.textBox2.Text = "0";
                this.textBox3.Text = "0";
                this.textBox4.Text = "0";
                this.textBox5.Text = "0";
                this.textBox6.Text = "0";
                this.textBox7.Text = "0";
                this.textBox8.Text = "0";
                this.textBox9.Text = "0";
                this.textBox10.Text = "0";
                this.textBox11.Text = "0";
                this.textBox12.Text = "0";
                this.textBox13.Text = "0";
                this.textBox14.Text = "0";
                this.textBox15.Text = "0";
                this.textBox16.Text = "0";
                this.toolStripProgressBar.Value = 120;
                timer1.Stop();
                allRadioButton.Checked = true;
            }
        }
    }
}
