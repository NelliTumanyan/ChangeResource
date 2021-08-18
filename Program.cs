using System;
using System.IO;
using Vestris.ResourceLib;

namespace ChangeResource
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter Screen path:");
            string path = Console.ReadLine();
            Console.WriteLine("Module Version(6.7, 6.8):");
            string appversion = Console.ReadLine();
            Console.WriteLine("Product Version(2020E, 2020F):");
            string prversion = Console.ReadLine();
            Console.WriteLine("Copyright(2001-2020):");
            string copyright = Console.ReadLine();
            int appvers = 68;


            string[] dirs = Directory.GetFiles(path, "*eng.dll", SearchOption.AllDirectories);
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
                
                VersionResource versionResource = new VersionResource();
                versionResource.LoadFrom(dir);

                versionResource.FileVersion = appversion + ".0.0";
                versionResource.ProductVersion = appvers.ToString() + ".0.0";

                StringFileInfo stringFileInfo = (StringFileInfo)versionResource["StringFileInfo"];
                stringFileInfo["FileVersion"] = appversion + ".0.0\0";
                stringFileInfo["LegalCopyright"] = "Copyright © " + copyright + " SYSTRONICS llc. All rights reserved.\0";
                stringFileInfo["ProductVersion"] = prversion + "\0";
                versionResource.SaveTo(dir);
            }
            Console.ReadLine();
            
        }
    }
}
