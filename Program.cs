using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ProjektHoldaJan
{
    class Program
    {
        //static List<object> kosik = new List<object>();
      
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();
                StartMenu();
                string volba = Console.ReadLine() ?? "";
                switch(volba)
                {
                    case "a":
                        Console.Clear();
                        Nakup();
                        break;
                    case "s":
                        Console.Clear();
                        Console.WriteLine("s");
                        break;
                    case "d":
                        Console.WriteLine("d");
                        break;
                    case "0":
                        Console.WriteLine("");
                        return;
                    default:
                        Console.WriteLine("Zadali jste neplatný výraz...");
                        break;

                }
               
            }

            

        }
        ////METODY
        /********************************************************/
        ///STARTMENU() = Metoda pro vypsání uživatelského menu
        static void StartMenu()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
            Console.WriteLine("Výtejte v Menu, vyberte jednu z možností:");
            Console.WriteLine();
            Console.WriteLine("[a]: Nákup");
            Console.WriteLine("[b]: Košík");
            Console.WriteLine("[c]: Účtenka");
            Console.WriteLine();
            Console.WriteLine("[0]: Navrácení do Menu");
            for (int i = 0; i < 50; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
        }
        /********************************************************/
        /********************************************************/
        ///Vytvoření/Přečtení souboru
        static void Soubor()
        {
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            using (XmlWriter xw = XmlWriter.Create(@"soubor.xml", set))
            {
                xw.WriteStartDocument();
                xw.WriteStartElement("polozky");
                xw.WriteStartElement("polozka");
                xw.WriteAttributeString("id", "1");
                xw.WriteAttributeString("name", "Jablko");
                xw.WriteAttributeString("cena", "10");
                xw.WriteEndElement();
                xw.WriteStartElement("polozka");
                xw.WriteAttributeString("id", "2");
                xw.WriteAttributeString("name", "Maslo");
                xw.WriteAttributeString("cena", "50");
                xw.WriteEndElement();
                xw.WriteStartElement("polozka");
                xw.WriteAttributeString("id", "3");
                xw.WriteAttributeString("name", "Kureci Prsa");
                xw.WriteAttributeString("cena", "110");
                xw.WriteEndElement();
                xw.WriteStartElement("polozka");
                xw.WriteAttributeString("id", "4");
                xw.WriteAttributeString("name", "Mydlo");
                xw.WriteAttributeString("cena", "30");
                xw.WriteEndElement();
                xw.WriteStartElement("polozka");
                xw.WriteAttributeString("id", "5");
                xw.WriteAttributeString("name", "Kartacek");
                xw.WriteAttributeString("cena", "60");
                xw.WriteEndElement();
                xw.WriteEndElement();
                xw.Flush();

            }
            using (XmlReader xr = XmlReader.Create(@"soubor.xml"))
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
                Console.WriteLine("Výtejte na nákupu, zadejte jednu z možností pro nákup:");
                while(xr.Read())
                {
                    if(xr.NodeType == XmlNodeType.Element)
                    {
                        if(xr.Name == "polozka")
                        {
                            Console.Write("[" + xr.GetAttribute("id") + "]" + " ");
                            Console.Write(xr.GetAttribute("name") + " ");
                            Console.Write(xr.GetAttribute("cena") + " ");
                            Console.WriteLine();
                        }
                    }
                }
                Console.WriteLine("Zadáním [0] ukončíte nákup.");
                for (int i = 0; i < 50; i++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }

        }
        /********************************************************/
        /********************************************************/
        //NAKUP() = Metoda pro Nakupování
        static void Nakup()
        {
            Soubor();
            while(true)
            {
                int vyber;
                if(!int.TryParse(Console.ReadLine(), out vyber))
                {
                    Console.WriteLine("Neplatný vstup, Zadejte číslo.");
                    continue;
                }
                switch(vyber)
                {
                    case 1:
                        Console.WriteLine("Tada");
                        Jablko j = new Jablko();
                        
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 0:
                        return;
                    default: 
                        Console.WriteLine("Neplatná volba"); 
                        break;

                }
            }
        }


    }
}


