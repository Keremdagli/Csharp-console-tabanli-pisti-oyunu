using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta3_PistiOyunu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            oyun game = new oyun();
            Console.WriteLine("Pişti oyununa giriş yapmak için enter'a çıkış yapmak için bir tuşa basınız\n");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                do
                {
                    Console.Clear();                

                    game.anamenü();
                    var secim = Console.ReadKey().Key;
                    if (secim == ConsoleKey.NumPad1)
                    {
                        game.kural();
                        Console.WriteLine("ana menüye dönmek için bir tuşa basınız");


                    }
                    else if (secim == ConsoleKey.NumPad2)
                    {
                        game.hazırlayan();
                        Console.WriteLine("ana menüye dönmek için bir tuşa basınız");
                    }
                    else if (secim == ConsoleKey.NumPad3)
                    {
                        game.parti();
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("\nlütfen geçerli bir karakter giriniz");
                    }
                    Console.ReadKey();

                } while (true);

            }



        }
        public class oyun
        {
            public void hg()
            {
                Console.WriteLine(
                    "***************************************************************\n\n" +
                    "      P İ Ş T İ  O Y U N U N A   H O Ş G E L D İ N İ Z \n" +
                    "\n***************************************************************\n");
            }
            public void anamenü()
            {

                hg();
                Console.WriteLine("--------ANA MENÜ--------\n");
                Console.WriteLine("-Oyun kuralları için 1'e tıklaynız\n");
                Console.WriteLine("-Oyunda emeği geçenleri görmek için 2'ye tıklaynız\n");
                Console.WriteLine("-Oyuna başlamak için 3'e tıklayınız\n");



            }
            public void kural()
            {
                Console.Clear();
                hg();
                Console.WriteLine("Oyun başladığında oyunculara 4 er kağıt dağıtılır. Yere 3 kapalı 1 açık kağıt konulur.\n");
                Console.WriteLine("Oyuncular sırasıyla ellerindeki bir kağıdı yerdekinin üstüne atarlar.\n");
                Console.WriteLine("Elinde en üstte bulunan kağıdın aynısından bulunan oyuncu onu atarak yerdeki bütün kağıtları alır.\n");
                Console.WriteLine("Joker(J) yerdeki kağıdın ne olduğuna bakılmaksızın yerdeki bütün kağıtları alan bir kağıttır.\n");
                Console.WriteLine("Oyuna kartları dağıtan oyuncunun rakibi başlar.\n");
                Console.WriteLine("Yerde hiç kağıt yokken rakibiniz yere bir kağıt attığında, siz bu kağıtla aynı olan bir kağıdı yere atarsanız pişti yapmış olursunuz.\n");
                Console.WriteLine("El başında yere koyulan kağıtları ilk alan oyuncu yerdeki 3 kapalı kağıdın ne olduğunu da görebilir.\n");
                Console.WriteLine("İki oyuncunun elindeki kağıtlar bitince yeniden 4’er kağıt dağıtılır. Destede kağıt bitince o elde kazanılan puanlar hesaplandıktan sonra yeni ele geçilir. \n");
                Console.WriteLine("Yine yeni el, oyunculara 4 er kağıt dağıtılması ve yere 3 kapalı 1 açık kağıt konulması ile devam eder.\n ");
                Console.WriteLine("Her deste bittiğinde oyuncuların kazandığı puanlar toplanır.\n");
                Console.WriteLine("Oyunculardan birisinin puan toplamı, oyun başında belirlenen bitiş puanını ( 51, 101, 151, 201 ) geçtiği zaman oyun bitmiş olur.\n");
                Console.WriteLine("Kart puanları;\nPişti:10\nKaro 10:3\nSinek 2:2\nJoker,As:1'er puandır\n");
            }
            public void hazırlayan()
            {
                Console.Clear();
                hg();
                Console.WriteLine("----oyun tasarımcısı----\n");
                Console.WriteLine("Kerem Dağlı\n\n");
                Console.WriteLine("----teşekkürler----\n");
                Console.WriteLine("Murat Taşyürek\n");
                Console.WriteLine();
            }
            public void parti()
            {
                Console.Clear();
                string ilk_oyuncu;
                string son_oyuncu;



                List<string> kartlarliste = new List<string>();
                List<string> ilkkartları = new List<string>();
                List<string> ilktopladığı = new List<string>();
                List<string> sonkartları = new List<string>();
                List<string> sontopladığı = new List<string>();
                List<string> ortakart = new List<string>();
                List<string> masa = new List<string>();
                List<string> ilkoyuncu_el = new List<string>();
                List<string> sonoyuncu_el = new List<string>();
                int ilk_pişti = 0;
                int son_pişti = 0;
                List<string> ilk_pişti_kartları = new List<string>();
                List<string> son_pişti_kartları = new List<string>();





                void ekleme()
                {

                    for (int i = 2; i <= 10; i++)
                    {
                        kartlarliste.Add("Karo " + Convert.ToString(i));
                        kartlarliste.Add("Sinek " + Convert.ToString(i));
                        kartlarliste.Add("Kupa " + Convert.ToString(i));
                        kartlarliste.Add("Maça " + Convert.ToString(i));
                    }

                    List<string> ozelkartlar = new List<string>();
                    ozelkartlar.Add("Joker");
                    ozelkartlar.Add("Kız");
                    ozelkartlar.Add("Kral");
                    ozelkartlar.Add("As");


                    foreach (string o in ozelkartlar)
                    {
                        kartlarliste.Add("Karo " + o);
                        kartlarliste.Add("Sinek " + o);
                        kartlarliste.Add("Kupa " + o);
                        kartlarliste.Add("Maça " + o);
                    }
                }
                ekleme();

                Console.WriteLine("1.oyuncunun adı:");
                string kullanici1 = Console.ReadLine();
                Console.WriteLine("\n2. oyuncunun adı: ");
                string kullanici2 = Console.ReadLine();
                Console.WriteLine("oyuna başlayacak kişi seçiliyor...\n");
                Random rd = new Random();
                int first = rd.Next(1, 3);
                if (first == 1)
                {
                    ilk_oyuncu = kullanici1;
                    son_oyuncu = kullanici2;
                    Console.WriteLine("oyuna ilk başlayacak kişi {0}", kullanici1);
                }
                else
                {
                    ilk_oyuncu = kullanici2;
                    son_oyuncu = kullanici1;
                    Console.WriteLine("oyuna ilk başlayacak kişi {0}", kullanici2);
                }

                Console.WriteLine("kartların kaç kez karılmasını istediğinizi giriniz");
                int karma = int.Parse(Console.ReadLine());


                for (int j = 0; j < 100 * karma; j++)
                {

                    int index = rd.Next(0, 52);
                    int index2 = rd.Next(0, 52);
                    (kartlarliste[index], kartlarliste[index2]) = (kartlarliste[index2], kartlarliste[index]);

                }


                for (int j = 0; j <= 9; j += 3)
                {
                    ilkkartları.Add(kartlarliste[j]);
                    masa.Add(kartlarliste[j + 1]);
                    sonkartları.Add(kartlarliste[j + 2]);
                }
                string kapalıkart = masa[0];
                for (int x = 12; x <= 50; x += 2)
                {
                    ilkkartları.Add(kartlarliste[x]);
                    sonkartları.Add(kartlarliste[x + 1]);
                }

                Console.Clear();
                Console.WriteLine("oyun başlyor devam etmek için enter tuşuna basınız");
                Console.ReadLine();
                Console.Clear();

                do
                {
                    for (int e = 0; e <= 3; e++)
                    {
                        ilkoyuncu_el.Add(ilkkartları[0]);
                        sonoyuncu_el.Add(sonkartları[0]);
                        ilkkartları.RemoveAt(0);
                        sonkartları.RemoveAt(0);
                    }

                    int eldönüşü = 4;
                    do
                    {
                        //1
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("sıra {0} isimli oyuncuda\n", ilk_oyuncu);
                        Console.WriteLine("elindeki kartlar:");
                        foreach (string eldekiler in ilkoyuncu_el)
                        {
                            Console.Write("{0},  ", eldekiler);
                        }
                        Console.WriteLine("");
                        Console.WriteLine("\nmasadaki kartlar:");
                        if (masa.Count > 0)
                        {
                            if (kapalıkart == masa[0])
                            {
                                Console.Write("*, *, *, ");
                                int q = masa.Count();
                                for (int l = 3; l < q; l++)
                                {

                                    Console.Write(" {0}  ", masa[l]);
                                }
                                Console.WriteLine("");
                            }
                            else
                            {
                                foreach (string p in masa)
                                {
                                    Console.Write("{0}, ", p);
                                }

                            }

                        }
                        else
                        {
                            Console.WriteLine("");
                        }

                        Console.WriteLine("\natmak istediğiniz kartı giriniz\n");

                        do
                        {
                            string atilan = Console.ReadLine();


                            if (ilkoyuncu_el.Contains(atilan) == true)
                            {
                                ilkoyuncu_el.Remove(atilan);
                                masa.Add(atilan);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("lütfen geçerli bir kart giriniz\n");
                            }

                        } while (true);
                        Console.WriteLine("");
                        if (masa.Count >= 2)
                        {


                            int test = masa.Count();
                            string[] atılan = masa[test - 1].Split(' ');
                            string ilk_attığı = (atılan[1]);
                            string[] masadaki = masa[test - 2].Split(' ');
                            string masadakikart = (masadaki[1]);


                            if (kapalıkart == masa[0])
                            {
                                if (ilk_attığı == masadakikart || ilk_attığı == "Joker")
                                {
                                    Console.WriteLine($"{ilk_oyuncu} kartları aldı");
                                    Console.WriteLine("\nmasadaki kapalı olan 3 kart:");
                                    for (int w = 0; w <= 2; w++)
                                    {
                                        Console.Write("{0}, ", masa[w]);
                                    }
                                    Console.ReadKey();
                                    Console.WriteLine("");
                                    foreach (string p in masa)
                                    {
                                        ilktopladığı.Add(p);

                                    }
                                    masa.Clear();
                                }
                            }
                            if (masa.Count == 2 && ilk_attığı == masadakikart)
                            {
                                Console.WriteLine($"{ilk_oyuncu} kartları aldı");
                                ilk_pişti++;
                                foreach (string ü in masa)
                                {
                                    ilktopladığı.Add(ü);
                                    ilk_pişti_kartları.Add(masadakikart);
                                    ilk_pişti_kartları.Add(ilk_attığı);


                                }
                                masa.Clear();
                            }
                            if (masa.Count == 2 && ilk_attığı == "Joker")
                            {
                                Console.WriteLine($"{ilk_oyuncu} kartları aldı");
                                foreach (string ö in masa)
                                {
                                    ilktopladığı.Add(ö);

                                }
                                masa.Clear();
                            }
                            if (masa.Count > 2 && ilk_attığı == masadakikart || ilk_attığı == "Joker")
                            {
                                Console.WriteLine($"{ilk_oyuncu} kartları aldı");
                                foreach (string s in masa)
                                {
                                    ilktopladığı.Add(s);
                                }
                                masa.Clear();
                            }
                        }
                        Console.WriteLine("---------------------------------------------");
                        //2
                        Console.WriteLine("\nsıra {0} isimli oyuncuda\n", son_oyuncu);
                        Console.WriteLine("elindeki kartlar:");
                        foreach (string eldekiler in sonoyuncu_el)
                        {
                            Console.Write("{0},  ", eldekiler);
                        }
                        Console.WriteLine("");
                        Console.WriteLine("\nmasadaki kartlar:");
                        if (masa.Count > 0)
                        {
                            if (kapalıkart == masa[0])
                            {
                                Console.Write("*, *, *, ");
                                int q = masa.Count();
                                for (int l = 3; l < q; l++)
                                {
                                    Console.Write(" {0}  ", masa[l]);
                                }
                                Console.WriteLine("");
                            }
                            else
                            {
                                foreach (string p in masa)
                                {
                                    Console.Write("{0}, ", p);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("");
                        }
                        Console.WriteLine("\natmak istediğiniz kartı giriniz\n");

                        do
                        {
                            string atilan = Console.ReadLine();


                            if (sonoyuncu_el.Contains(atilan) == true)
                            {
                                sonoyuncu_el.Remove(atilan);
                                masa.Add(atilan);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("lütfen geçerli bir kart giriniz\n");
                            }

                        } while (true);
                        Console.WriteLine("");
                        Console.WriteLine("");
                        if (masa.Count >= 2)
                        {
                            int test = masa.Count();
                            string[] atılan = masa[test - 1].Split(' ');
                            string son_attığı = (atılan[1]);
                            string[] masadaki = masa[test - 2].Split(' ');
                            string masadakikart = (masadaki[1]);


                            if (kapalıkart == masa[0])
                            {
                                if (son_attığı == masadakikart || son_attığı == "Joker")
                                {
                                    Console.WriteLine($"{son_oyuncu} kartları aldı");
                                    Console.WriteLine("\nmasadaki kapalı olan 3 kart:");
                                    for (int w = 0; w <= 2; w++)
                                    {
                                        Console.Write("{0}, ", masa[w]);
                                    }
                                    Console.ReadKey();
                                    Console.WriteLine("");
                                    foreach (string p in masa)
                                    {
                                        sontopladığı.Add(p);

                                    }
                                    masa.Clear();
                                }
                            }
                            if (masa.Count == 2 && son_attığı == masadakikart)
                            {
                                Console.WriteLine($"{son_oyuncu} kartları aldı");
                                son_pişti++;
                                foreach (string ü in masa)
                                {
                                    sontopladığı.Add(ü);
                                    son_pişti_kartları.Add(masadakikart);
                                    son_pişti_kartları.Add(son_attığı);
                                }
                                masa.Clear();
                            }
                            if (masa.Count == 2 && son_attığı == "Joker")
                            {
                                Console.WriteLine($"{son_oyuncu} kartları aldı");
                                foreach (string ö in masa)
                                {
                                    sontopladığı.Add(ö);

                                }
                                masa.Clear();
                            }
                            if (masa.Count > 2 && son_attığı == masadakikart || son_attığı == "Joker")
                            {
                                Console.WriteLine($"{son_oyuncu} kartları aldı");
                                foreach (string s in masa)
                                {
                                    sontopladığı.Add(s);

                                }
                                masa.Clear();
                            }

                        }

                        eldönüşü--;
                    } while (eldönüşü >= 1);
                } while (sonkartları.Count > 0);               
                Console.Clear();
                Console.WriteLine("oyun sona erdi");
                Console.WriteLine("puan tablosunu girmek için klavyeye basınız");
                Console.ReadKey();

                List<string> sondegerli = new List<string>();
                List<string> ilkdegerli = new List<string>();
                int sonpuan = 0;
                int ilkpuan = 0;
                if (sontopladığı.Count > 0)
                {
                    foreach (string s in sontopladığı)
                    {
                        string[] sonpuankelime = s.Split(' ');
                        string sonpuanözellik = sonpuankelime[1];
                        string sonpuansıfat = sonpuankelime[0];
                        if (sonpuanözellik == "Joker")
                        {
                            sonpuan++;
                            sondegerli.Add(s);
                        }
                        else if (sonpuanözellik == "As")
                        {
                            sonpuan++;
                            sondegerli.Add(s);
                        }
                        else if (sonpuansıfat == "Karo" && sonpuanözellik == "10")
                        {
                            sonpuan += 3;
                            sondegerli.Add(s);
                        }
                        else if (sonpuansıfat == "Sinek" && sonpuanözellik == "2")
                        {
                            sonpuan += 2;
                            sondegerli.Add(s);
                        }
                    }

                }
                if (ilktopladığı.Count > 0)
                {
                    foreach (string s in ilktopladığı)
                    {
                        string[] ilkpuankelime = s.Split(' ');
                        string ilkpuanözellik = ilkpuankelime[1];
                        string ilkpuansıfat = ilkpuankelime[0];
                        if (ilkpuanözellik == "Joker")
                        {
                            ilkpuan++;
                            ilkdegerli.Add(s);

                        }
                        else if (ilkpuanözellik == "As")
                        {
                            ilkpuan++;
                            ilkdegerli.Add(s);
                        }
                        else if (ilkpuansıfat == "Karo" && ilkpuanözellik == "10")
                        {
                            ilkpuan += 3;
                            ilkdegerli.Add(s);
                        }
                        else if (ilkpuansıfat == "Sinek" && ilkpuanözellik == "2")
                        {
                            ilkpuan += 2;
                            ilkdegerli.Add(s);
                        }
                    }
                    sonpuan += son_pişti * 10;
                    ilkpuan += ilk_pişti * 10;


                }
                Console.Clear();

                Console.WriteLine("ilk oyuncunun topladığı kartlar:");
                foreach (string s in ilktopladığı)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("");
                Console.WriteLine("değerli kartlar: ");
                foreach (string s in ilkdegerli)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("");
                Console.WriteLine("ilk oyuncunun yapmış olduğu pişti sayısı: ");
                Console.WriteLine(ilk_pişti);
                Console.WriteLine("");
                if (ilk_pişti != 0)
                {
                    Console.WriteLine("pişti yaptığınız kartlar: ");
                    foreach (string s in ilk_pişti_kartları)
                    {
                        Console.WriteLine(s);
                    }

                }
                Console.WriteLine("");
                Console.WriteLine($"total puanınız: {ilkpuan}");
                Console.WriteLine("");

                Console.ReadKey();
                Console.Clear();
                //2

                Console.WriteLine("son oyuncunun topladığı kartlar:");
                foreach (string s in sontopladığı)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("");
                Console.WriteLine("değerli kartlar: ");
                foreach (string s in sondegerli)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("");
                Console.WriteLine("son oyuncunun yapmış olduğu pişti sayısı: ");
                Console.WriteLine(son_pişti);
                Console.WriteLine("");
                if (son_pişti != 0)
                {
                    Console.WriteLine("pişti yaptığınız kartlar: ");
                    foreach (string s in son_pişti_kartları)
                    {
                        Console.WriteLine(s);
                    }

                }
                Console.WriteLine("");
                Console.WriteLine($"total puanınız: {sonpuan}");
                Console.WriteLine("");              
                Console.ReadKey();
                Console.Clear();

                if (ilkpuan - sonpuan > 0)
                {
                    Console.WriteLine("KANANAN İLK OYUNCU");
                    Console.WriteLine($"ilk oyuncunun puanı: {ilkpuan} son oyuncunun puanı: {sonpuan} aradaki fark: {ilkpuan - sonpuan}");
                }
                else if (ilkpuan - sonpuan < 0)
                {
                    Console.WriteLine("KANANAN SON OYUNCU");
                    Console.WriteLine($"son oyuncunun puanı: {sonpuan} ilk oyuncunun puanı: {ilkpuan}  aradaki fark: {-1 * (ilkpuan - sonpuan)}");
                }
                else
                {
                    Console.WriteLine("PUANLAR EŞİT BERABERE");
                    Console.WriteLine($"ilk oyuncunun puanı: {ilkpuan} son oyuncunun puanı: {sonpuan} aradaki fark: {ilkpuan - sonpuan}");
                }
                Console.ReadKey();


            }

        }
    }
}