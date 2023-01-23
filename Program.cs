using System;

/*  O výrobu instancí objektů se starají podtřídy creatoru
 *  - v tomto případě subclasses WebDialog, WindowsDialog
 */

namespace Factory_Method
{
    class Program
    {
        public static Dialog dialog;

        static void Main(string[] args)
        {
            Init("Windows");
            dialog.render();

            Console.WriteLine("\n");

            Init("html");
            dialog.render();
        }

        public static void Init(string env)
        {
            if (env == "html")
            {
                dialog = new WebDialog();
            }
            else if (env == "Windows")
            {
                dialog = new WindowsDialog();
            }
            else
            {
                throw new Exception("Unimplemented env");
            }
        }
    }

    abstract public class Dialog
    {
        abstract public IButton CreateButton();

        public void render()
        {
            IButton okButton = CreateButton();
            okButton.Render();
        }
    }

    public class WindowsDialog : Dialog
    {
        public override WindowsButton CreateButton()
        {
            return new WindowsButton();
        }
    }

    public class WebDialog : Dialog
    {
        public override HTMLButton CreateButton()
        {
            return new HTMLButton();
        }
    }

    public interface IButton
    {
        public void Render();
    }
    public class WindowsButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("/--------------\\");
            Console.WriteLine("|  Windows btn |");
            Console.WriteLine("\\--------------/");
        }
    }

    public class HTMLButton : IButton { 
        public void Render()
        {
            Console.WriteLine("/--------------\\");
            Console.WriteLine("|   HTML btn   |");
            Console.WriteLine("\\--------------/");
        }
    }
}
