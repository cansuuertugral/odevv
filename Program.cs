using System;
using Microsoft.EntityFrameworkCore;

namespace OgrenciBilgiSistemi
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
