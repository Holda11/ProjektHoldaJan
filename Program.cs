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
            Jablko jablko = new Jablko();
            Maslo maslo = new Maslo();
            Kureci kureci = new Kureci();
            Mydlo mydlo = new Mydlo();
            Kartacek kartacek = new Kartacek();


            while (true)
            {
                
                StartMenu();
                string volba = Console.ReadLine() ?? "";
                switch(volba)
                {
                    case "a":
                        Console.Clear();
                        Nakup(jablko, maslo, kureci, mydlo, kartacek);
                        break;
                    case "s":
                        Console.WriteLine(jablko.mnozstvi);
                        Console.WriteLine(maslo.mnozstvi);
                        Console.WriteLine(kureci.mnozstvi);
                        Console.WriteLine(mydlo.mnozstvi);
                        Console.WriteLine(kartacek.mnozstvi);
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
            Console.WriteLine("[s]: Košík");
            Console.WriteLine("[d]: Účtenka");
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
        static void Nakup(Jablko jablko, Maslo maslo, Kureci kureci, Mydlo mydlo, Kartacek kartacek)
        {

            Soubor();
            while(true)
            {
                int pocet;
                int vyber;
                if(!int.TryParse(Console.ReadLine(), out vyber))
                {
                    Console.WriteLine("Neplatný vstup, Zadejte číslo.");
                    continue;
                }
                switch(vyber)
                {
                    //Jablko
                    case 1:
                        if (!int.TryParse(Console.ReadLine(), out pocet))
                        {
                            Console.WriteLine("Neplatný vstup, Zadejte číslo.");
                            continue;
                        }
                        if (jablko.mnozstvi == 0)
                        {
                            Console.WriteLine("Zadali jste množství Jablek");
                            jablko.mnozstvi = pocet;
                        }
                        else
                        {
                            Console.WriteLine("Přičetli jste Jablka");
                            Console.WriteLine("Zadejte ");
                            jablko.mnozstvi = jablko.mnozstvi + pocet;
                        }
                        break;
                    //Maslo
                    case 2:
                        if (!int.TryParse(Console.ReadLine(), out pocet))
                        {
                            Console.WriteLine("Neplatný vstup, Zadejte číslo.");
                            continue;
                        }
                        if (maslo.mnozstvi == 0)
                        {
                            Console.WriteLine("Zadali jste množství Másla");
                            maslo.mnozstvi = pocet;
                        }
                        else
                        {
                            Console.WriteLine("Přičetli jste Másla");
                            Console.WriteLine("Zadejte ");
                            maslo.mnozstvi = maslo.mnozstvi + pocet;
                        }
                        break;
                    //Kuřecí prsa
                    case 3:
                        if (!int.TryParse(Console.ReadLine(), out pocet))
                        {
                            Console.WriteLine("Neplatný vstup, Zadejte číslo.");
                            continue;
                        }
                        if (kureci.mnozstvi == 0)
                        {
                            Console.WriteLine("Zadali jste množství Kuřecích Prsou");
                            kureci.mnozstvi = pocet;
                        }
                        else
                        {
                            Console.WriteLine("Přičetli jste Kuřecí Prsa");
                            Console.WriteLine("Zadejte ");
                            kureci.mnozstvi = kureci.mnozstvi + pocet;
                        }
                        break;
                    //Mydlo
                    case 4:
                        if (!int.TryParse(Console.ReadLine(), out pocet))
                        {
                            Console.WriteLine("Neplatný vstup, Zadejte číslo.");
                            continue;
                        }
                        if (mydlo.mnozstvi == 0)
                        {
                            Console.WriteLine("Zadali jste množství Jablek");
                            mydlo.mnozstvi = pocet;
                        }
                        else
                        {
                            Console.WriteLine("Přičetli jste Jablka");
                            Console.WriteLine("Zadejte ");
                            mydlo.mnozstvi = mydlo.mnozstvi + pocet;
                        }
                        break;
                    //Kartacek
                    case 5:
                        if (!int.TryParse(Console.ReadLine(), out pocet))
                        {
                            Console.WriteLine("Neplatný vstup, Zadejte číslo.");
                            continue;
                        }
                        if (kartacek.mnozstvi == 0)
                        {
                            Console.WriteLine("Zadali jste množství Kartácků");
                            kartacek.mnozstvi = pocet;
                        }
                        else
                        {
                            Console.WriteLine("Přičetli jste Kartácků");
                            Console.WriteLine("Zadejte ");
                            kartacek.mnozstvi = kartacek.mnozstvi + pocet;
                        }
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


