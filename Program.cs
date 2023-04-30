using System.Xml;
using System;
using System.IO;


namespace ProjektHoldaJan
{
    class Program
    {

        static void Main(string[] args)
        {
            //Vytvoření objektů pro každou položku v "nákupu"
            Jablko jablko = new Jablko();
            Maslo maslo = new Maslo();
            Kureci kureci = new Kureci();
            Mydlo mydlo = new Mydlo();
            Kartacek kartacek = new Kartacek();

            //Menu
            //@Uživatel => Zadáva vstup aby si navolil kam chce pokračovat, při použití jiného znaku se napíše chyba a menu se načte znova
            while (true)
            {
                Console.Clear();
                StartMenu();
                string volba = Console.ReadLine() ?? "";
                switch(volba)
                {
                    //Volba 'A'
                    //@Uživatel => Zde může začít ukládat hodnoty produktů
                    case "a":
                        Console.Clear();
                        Nakup(jablko, maslo, kureci, mydlo, kartacek);
                        break;
                    //Volba 'S'
                    //@Uživatel => Zde se uživatel může podívat na to co má v košíku za jakou cenu, zadáním jakýmkoliv znakem může košík opustit
                    case "s":
                        Console.Clear();
                        for (int i = 0; i < 50; i++)
                        {
                            Console.Write('*');
                        }
                        Console.WriteLine();
                        Console.WriteLine("Máte v Košíku:");
                        Console.WriteLine("Jablka:" + jablko.mnozstvi + "  " + "CENA:" + jablko.mnozstvi * jablko.cena + "Kč");
                        Console.WriteLine("Maslo:" + maslo.mnozstvi + "  " + "CENA:" + maslo.mnozstvi * maslo.cena + "Kč");
                        Console.WriteLine("Kureří prsa:" + kureci.mnozstvi + "  " + "CENA:" + kureci.mnozstvi * kureci.cena + "Kč");
                        Console.WriteLine("Mýdla:" + mydlo.mnozstvi + "  " + "CENA:" + mydlo.mnozstvi * mydlo.cena + "Kč");
                        Console.WriteLine("Kartáčky:" + kartacek.mnozstvi + "  " + "CENA:" + kartacek.mnozstvi*kartacek.cena + "Kč");
                        for (int i = 0; i < 50; i++)
                        {
                            Console.Write('*');
                        }
                        Console.WriteLine();
                        Console.WriteLine("Zadejte cokoliv pro ukončení košíku....");
                        Console.ReadKey();
                        break;
                    //Volba 'D'
                    //Uživatel => Zde může uživatel vytisknout účtenku v případě, že už něco přidal do košíku
                    case "d":
                        Tisk(jablko, maslo, kureci, mydlo, kartacek);
                        break;
                    //Volba '0'
                    //Uživatel => Zde může uživatel opustit program
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
        ///Vytvoření/Přečtení XML souboru
        ///Tato Metoda není v programu zásadní, spíše pro demonstrování
        static void Soubor()
        {
            //Vytvoření XML Souboru
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
            //Čtení ze souboru
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
                            Console.Write(xr.GetAttribute("cena") + "Kč");
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
        //NAKUP() = Metoda pro Nakupování, metoda má argumenty tříd
        static void Nakup(Jablko jablko, Maslo maslo, Kureci kureci, Mydlo mydlo, Kartacek kartacek)
        {

            Soubor();
            while(true)
            {
                //Int(y) pro vstupy
                //vyber == vstup pro volbu menu
                //pocet == vstup pro navolení množství
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
                        Console.WriteLine("Zadejte množství:");
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
                        Console.WriteLine("Zadejte množství:");
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
                        Console.WriteLine("Zadejte množství:");
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
                        Console.WriteLine("Zadejte množství:");
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
                        Console.WriteLine("Zadejte množství:");
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
        /********************************************************/
        /********************************************************/
        //Tisk() = Metoda pro Tisk účtenky
        //Pokuď uživatel nemá v košíku nic, účtenku nemůže vytisknout 
        static void Tisk(Jablko jablko, Maslo maslo, Kureci kureci, Mydlo mydlo, Kartacek kartacek)
        {
            Console.Clear();
            for (int i = 0; i < 50; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
            Console.WriteLine("Výtejte u tisku účtenky");
            Console.WriteLine("[7] = Tisk Účtenky");
            Console.WriteLine("[8] = Navrácení do Menu");
            for (int i = 0; i < 50; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
            while (true)
            {
                
                int tisk;
                if (!int.TryParse(Console.ReadLine(), out tisk))
                {
                    Console.WriteLine("Neplatný vstup, Zadejte číslo.");
                    continue;
                }
                switch(tisk)
                {
                    case 7:
                        int kontrola = jablko.mnozstvi+maslo.mnozstvi+kureci.mnozstvi+mydlo.mnozstvi+kartacek.mnozstvi;
                        string path = @"c:/temp/Uctenka.txt";
                        if(kontrola > 0)
                        {
                            if (File.Exists(path))
                            {
                                File.Delete(path);
                            }
                            
                            if (!File.Exists(path))
                            {
                            using (StreamWriter sw =File.CreateText(path))
                            {
                                for (int i = 0; i < 25; i++)
                                {
                                    sw.Write('-');
                                }
                                sw.WriteLine();
                                sw.WriteLine("Účtenka");
                                sw.WriteLine("Datum:" + DateTime.Now.ToShortDateString());
                                sw.WriteLine("Obchod: Konzole");
                                sw.WriteLine("Adresa: Počítač");
                                sw.WriteLine("Zaplaceno: Dobrou známkou");
                                for (int i = 0; i < 25; i++)
                                {
                                    sw.Write('-');
                                }
                                sw.WriteLine();
                                if(jablko.mnozstvi > 0)
                                {
                                    int jc = jablko.mnozstvi * jablko.cena;
                                    sw.WriteLine("JABLKO - 10Kč: ");
                                    sw.WriteLine("počet:" + jablko.mnozstvi);
                                    sw.WriteLine("cena bez dph:" + jc/1.21 + "Kč");
                                    sw.WriteLine("CENA CELKEM:" + jc + "Kč" );
                                }
                                if (maslo.mnozstvi > 0)
                                {
                                    int mc = maslo.cena * maslo.mnozstvi;
                                    sw.WriteLine("MASLO - 50Kč: ");
                                    sw.WriteLine("počet:" + maslo.mnozstvi);
                                    sw.WriteLine("cena bez dph:" + mc / 1.21 + "Kč");
                                    sw.WriteLine("CENA CELKEM:" + mc + "Kč");
                                }
                                if (kureci.mnozstvi > 0)
                                {
                                    int kc = kureci.cena * kureci.mnozstvi;
                                    sw.WriteLine("KUŘECÍ PRSA - 110Kč: ");
                                    sw.WriteLine("počet:" + kureci.mnozstvi);
                                    sw.WriteLine("cena bez dph:" + kc / 1.21 + "Kč");
                                    sw.WriteLine("CENA CELKEM:" + kc + "Kč");
                                }
                                if (mydlo.mnozstvi > 0)
                                {
                                    int myc = mydlo.cena * mydlo.mnozstvi;
                                    sw.WriteLine("MÝDLO - 30Kč: ");
                                    sw.WriteLine("počet:" + mydlo.mnozstvi);
                                    sw.WriteLine("cena bez dph:" + myc / 1.21 + "Kč");
                                    sw.WriteLine("CENA CELKEM:" + myc + "Kč");
                                }
                                if (kartacek.mnozstvi > 0)
                                {
                                    int kac = kartacek.cena * kartacek.mnozstvi;
                                    sw.WriteLine("KARTÁČEK - 60Kč: ");
                                    sw.WriteLine("počet:" + kartacek.mnozstvi);
                                    sw.WriteLine("cena bez dph:" + kac / 1.21 + "Kč");
                                    sw.WriteLine("CENA CELKEM:" + kac + "Kč");
                                }
                                    sw.WriteLine();
                                for (int i = 0; i < 25; i++)
                                {
                                    sw.Write('-');
                                }
                                sw.WriteLine();
                                sw.WriteLine("Celkem:" + ((jablko.mnozstvi*jablko.cena) +(maslo.cena*maslo.mnozstvi)+(kureci.cena*kureci.mnozstvi)+(mydlo.cena*mydlo.mnozstvi)+(kartacek.cena*kartacek.mnozstvi)));
                                for (int i = 0; i < 25; i++)
                                {
                                    sw.Write('-');
                                }
                                sw.WriteLine();
                                sw.WriteLine("Děkujeme za nákup");
                                
                            }
                            Console.WriteLine("Účtenka vytisknuta v C://temp");
                        }
                        }
                        else
                        {
                            Console.WriteLine("Nemáte nic v košíku.....");
                        }
                        break;
                    case 8:
                        return;
                }
            }
           
        }

    }
   
}



