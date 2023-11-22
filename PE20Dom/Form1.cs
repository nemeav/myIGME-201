using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE20Dom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

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

            // add the delegate method to be called after the webpage loads, set this up before Navigate()
            this.webBrowser1.DocumentCompleted += new
            WebBrowserDocumentCompletedEventHandler(this.WebBrowser1__DocumentCompleted);

            //to use the URL
            this.webBrowser1.Navigate("people.rit.edu/dxsigm/example.html");
        }

        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)sender;
            HtmlElementCollection htmlElementCollection;
            HtmlElement htmlElement;

            //change h1's text to My UFO Page
            htmlElementCollection = this.webBrowser1.Document.GetElementsByTagName("h1");
            foreach ( HtmlElement elem in htmlElementCollection )
            {
                elem.InnerText = "My UFO Page";
            }

            //change the first instance of h2's text to My UFO Info
            htmlElementCollection = this.webBrowser1.Document.GetElementsByTagName("h2");
            htmlElementCollection[0].InnerText = "My UFO Page";
            //change the.InnerText of the 2nd <h2> to "My UFO Pictures"
            htmlElementCollection[1].InnerText = "My UFO Pictures";
            //change the.InnerText of the 3rd <h2> to an empty string -""
            htmlElementCollection[2].InnerText = "";

            //change BODY
            htmlElement = webBrowser1.Document.Body;
            htmlElement.Style = "color: #880808;font-family:sans-serif";

            //select 1st paragraph
            htmlElementCollection = this.webBrowser1.Document.GetElementsByTagName("p");
            //change text w/ link - ERROR????
            htmlElementCollection[0].InnerHtml = "Report your UFO sightings here: <a href=\"http://www.nuforc.org\">www.nuforc.org</a>";
            //style changes: green, bold, 2em, touppercase, add text shadow
            htmlElementCollection[0].Style = "color: green;font-weight:bold;font-size:2em;text-transform:uppercase;text-shadow:3px 2px #A44";

            //2nd paragraph is empty string
            htmlElementCollection[1].InnerText = "";

            //insert random image of ufo
            htmlElement = webBrowser.Document.CreateElement("img");
            htmlElement.SetAttribute("src", "https://www.seti.org/sites/default/files/styles/original/public/2023-07/antique-UAP-envato-1200px.jpg?itok=ZpMp2_V4");
            htmlElement.SetAttribute("alt", "UFO");
            htmlElement.Style = "width: 80vw";
            htmlElementCollection[2].InnerHtml = htmlElement.OuterHtml + htmlElementCollection[2].InnerHtml;

            //add footer w/ copyright, year, name
            htmlElement = webBrowser1.Document.CreateElement("footer");
            string year = DateTime.Now.Year.ToString();
            htmlElement.InnerHtml = "&copy " + year + " Neme Velazquez";
            this.webBrowser1.Document.Body.AppendChild(htmlElement);
        }
    }
}
