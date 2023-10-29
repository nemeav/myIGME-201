using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTest2_Q9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadManga readManga = new ReadManga("My Hero Academia");
            ReadDanmei readDanmei = new ReadDanmei("Heaven Official's Blessing");

            MyMethod(readManga);
            MyMethod(readDanmei);

        }

        //wasn't sure if this was how this was meant to be implemented but I think this still gets the job done?
        static void MyMethod(object obj)
        {
            if (obj is IText)
            {
                IText novelObj = (IText)obj;
                novelObj.ReadText();
            }

            if (obj is IImages)
            {
                IImages comicObj = (IImages)obj;
                comicObj.ScanPanels();
            }
        }
    }

    // parent class to be inherited from
    public abstract class Reading
    {
        //mtds - things to do with book
        public abstract string ChooseBook();
        public void PickUpBook()
        {

        }
        public virtual void TurnPage()
        {

        }
    }

    // interface 1 to be inherited from
    public interface IText
    {
        //mtds
        void ReadText();
    }

    //interface 2
    public interface IImages
    {
        //mtds
        void ScanPanels();
    }

    // first child class
    public class ReadDanmei : Reading, IText
    {
        //enter here
        public string bookTitle;

        //mtds
        public override string ChooseBook()
        {
            //added this b/c was getting errors with just blank method - didn't want to use void again
            return bookTitle;
        }
        public void ReadText()
        {
            Console.WriteLine(bookTitle + ": Hmm... much words yes...");
        }

        public override void TurnPage()
        {

        }

        //constructors
        public ReadDanmei(string title)
        {
            this.bookTitle = title;
        }
    }

    public class ReadManga : Reading, IImages
    {
        //field
        public string mangaTitle;

        //mtds
        public override string ChooseBook()
        {
            //added this b/c getting errors w/ just blank method - didn't want to use void again
            return mangaTitle;
        }
        public void ScanPanels()
        {
            Console.WriteLine(mangaTitle + ": Hmmm very nice art...");
        }

        public override void TurnPage()
        {

        }

        //constructor
        public ReadManga(string title)
        {
            this.mangaTitle = title;
        }
    }
}
