using DrugAdministration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RIVarX;



namespace DrugAdministrationUI
{
    static class Program
    {
       

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            var bag = new Bag();
            var pump = new Pump(bag);

            var bagUserControl = new UserControl_Bag(bag);
            var pumpUserControl = new UserControl_Pump(pump);

            System.IO.File.AppendAllText($"log.txt", "new session " + DateTime.Now.ToString());

            Application.Run(new Form(bagUserControl, pumpUserControl));
        }
    }


}
