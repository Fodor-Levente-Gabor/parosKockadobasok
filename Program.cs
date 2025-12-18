using System;
using System.IO;
using System.Linq;

namespace ExplicitProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //feladat1
            string[] kockaDobasokFile = File.ReadAllLines("pároskockadobások.txt");
            List<string> kockaDobasok = new List<string>();
            foreach (string sor in kockaDobasokFile)
            {
                if(sor.All(c => char.IsDigit(c) || c == ','))
                {
                    kockaDobasok.Add(sor);
                }
            }
            
            
            int dontetlen = 0;
            int annaNyert = 0;
            int beaNyert = 0;
            for (int a = 0; a < kockaDobasok.Count; a++)
            {
                string[] szamBetu = kockaDobasok[a].Split(',');

                if (int.Parse(szamBetu[0]) == int.Parse(szamBetu[1]))
                {
                    dontetlen++;
                }
                else if (int.Parse(szamBetu[0]) > int.Parse(szamBetu[1]))
                {
                    annaNyert++;
                }
                else
                {
                    beaNyert++;
                }
            }
            Console.WriteLine($"Anna nyerései: {annaNyert}");
            //feladat2
            Console.WriteLine($"Döntetlenek száma: {dontetlen}");
            //feladat3
            string fileName = "összegzés.txt";
            string contentAnna = $"Anna nyerései: {annaNyert} \n";
            File.WriteAllText(fileName, contentAnna);
            string contentBea = $"Bea nyerései: {beaNyert} \n";
            File.AppendAllText(fileName, contentBea);
            //feladat4
            int counter = 0;
            bool run = true;
            int hatos = 0;
            bool hatosTobszor = false;
            while(run)
            {
                string[] szamBetu = kockaDobasok[counter].Split(',');
                if (int.Parse(szamBetu[1]) == 6)
                {
                    hatos++;
                }
                else
                {
                    hatos = 0;
                }
                if (hatos > 1)
                {
                    hatosTobszor = true;
                    run = false;
                }
                if (counter == kockaDobasok.Count - 1)
                {
                    run = false;
                }
                counter++;
            }
            File.AppendAllText(fileName, hatosTobszor?$"Beának volt hatos egymás után \n":$"Beának nem volt hatos egymás után \n");
            //feladat5
            int[] dobasokSzamonkent = {0,0,0,0,0,0};
            for (int a = 0; a < kockaDobasok.Count; a++)
            {
                string[] szamBetu = kockaDobasok[a].Split(',');

                dobasokSzamonkent[int.Parse(szamBetu[0])-1]++;
                
            }

            for (int a = 0; a < dobasokSzamonkent.Length; a++)
            {
                File.AppendAllText(fileName, $"{a+1}: {dobasokSzamonkent[a]} \n");            
            }
        }
    }
}
