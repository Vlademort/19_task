using System;
using System.Collections.Generic;
using System.Linq;

namespace _19_task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Comp> list_comp = new List<Comp>()
            {
                new Comp() { Cod = 12345, Brand = "ASUS", CPU = "AMD Ryzen", FrequencCPU = 3.6, DDR = 4, SSD = 128, Graphics = 1792, Cost = 44990, Count = 6 },
                new Comp() { Cod = 56487, Brand = "HP", CPU = "Intel Core i5", FrequencCPU = 4.3, DDR = 8, SSD = 256, Graphics = 2112, Cost = 55900, Count = 7 },
                new Comp() { Cod = 98764, Brand = "Acer", CPU = "AMD Athlon", FrequencCPU = 4.4, DDR = 16, SSD = 512, Graphics = 2249, Cost = 77500, Count = 31 },
                new Comp() { Cod = 87654, Brand = "Dell", CPU = "Intel Core i7", FrequencCPU = 3.0, DDR = 8, SSD = 256, Graphics = 2112, Cost = 55300, Count = 10 },
                new Comp() { Cod = 65346, Brand = "ASUS", CPU = "Intel Core i7", FrequencCPU = 3.0, DDR = 8, SSD = 256, Graphics = 2112, Cost = 60300, Count = 7 },
                new Comp() { Cod = 34578, Brand = "ASUS", CPU = "AMD Ryzen", FrequencCPU = 3.0, DDR = 4, SSD = 128, Graphics = 2249, Cost = 71200, Count = 11 },
                new Comp() { Cod = 12865, Brand = "HP", CPU = "AMD Ryzen", FrequencCPU = 3.6, DDR = 4, SSD = 128, Graphics = 2249, Cost = 47360, Count = 2 },
                new Comp() { Cod = 98073, Brand = "Dell", CPU = "AMD Athlon", FrequencCPU = 4.3, DDR = 16, SSD = 256, Graphics = 1792, Cost = 81300, Count = 3 },
                new Comp() { Cod = 34678, Brand = "ASUS", CPU = "Intel Core i5", FrequencCPU = 4, DDR = 32, SSD = 512, Graphics = 2249, Cost = 90550, Count = 45 },
            };

            Console.WriteLine("Укажите один из вариантов процессора: \"AMD Ryzen\", \"AMD Athlon\", \"Intel Core i5\", \"Intel Core i7\"");
            string cpu = Convert.ToString(Console.ReadLine());
            List<Comp> cpu_comp = list_comp.Where(c => c.CPU == cpu).ToList();
            foreach (Comp c in cpu_comp)
            {
                Console.WriteLine($"{c.Cod}, {c.Brand} , {c.CPU}, {c.FrequencCPU}, {c.DDR} , {c.SSD}, {c.Graphics}, {c.Cost}, {c.Count}");
            }
            Console.WriteLine();

            Console.WriteLine("Укажите минимальный объем ОЗУ из вариантов: 4, 8, 16, 32");
            int ddr = Convert.ToInt32(Console.ReadLine());
            List<Comp> ddr_comp = list_comp.Where(d => d.DDR >= ddr).ToList();
            foreach (Comp d in ddr_comp)
            {
                Console.WriteLine($"{d.Cod}, {d.Brand} , {d.CPU}, {d.FrequencCPU}, {d.DDR} , {d.SSD}, {d.Graphics}, {d.Cost}, {d.Count}");
            }
            Console.WriteLine();

            Console.WriteLine("Список компьютеров по увеличению стоимости:");
            List<Comp> cost_comp = list_comp.OrderBy(c => c.Cost).ToList();
            foreach (Comp c in cost_comp)
            {
                Console.WriteLine($"{c.Cod}, {c.Brand} , {c.CPU}, {c.FrequencCPU}, {c.DDR} , {c.SSD}, {c.Graphics}, {c.Cost}, {c.Count}");
            }
            Console.WriteLine();

            //Console.WriteLine("Список компьютеров по процессорам:");
            //var cpugroup_comp = from lc in list_comp
            //                    group lc by lc.CPU into newGroup
            //                    orderby newGroup.Key
            //                    select newGroup;
            //foreach (var nameGroup in cpugroup_comp)
            //{
            //    Console.WriteLine($"{nameGroup.Key}");
            //    foreach (var lc in nameGroup)
            //    {
            //        Console.WriteLine($"{lc.Cod}, {lc.Brand} , {lc.CPU}, {lc.FrequencCPU}, {lc.DDR} , {lc.SSD}, {lc.Graphics}, {lc.Cost}, {lc.Count}");
            //    }
            //}
            //Console.WriteLine();

            Console.WriteLine("Список компьютеров по процессорам:");
            var cpugroup_comp = list_comp.GroupBy(gr => gr.CPU);            
            foreach (var gr in cpugroup_comp)
            {
                Console.WriteLine(gr.Key);
                foreach (var g in gr)
                {
                    Console.WriteLine($"{g.Cod}, {g.Brand} , {g.CPU}, {g.FrequencCPU}, {g.DDR} , {g.SSD}, {g.Graphics}, {g.Cost}, {g.Count}");
                }
            }
            Console.WriteLine();

            Comp costmax_comp = list_comp.OrderBy(max => max.Cost).Last();
            Comp costmin_comp = list_comp.OrderBy(min => min.Cost).First();
            Console.WriteLine($"Cамый дорогой компьютер \n{costmax_comp.Cod}, {costmax_comp.Brand} , {costmax_comp.CPU}, {costmax_comp.FrequencCPU}, {costmax_comp.DDR} , {costmax_comp.SSD}, {costmax_comp.Graphics}, {costmax_comp.Cost}, {costmax_comp.Count}");
            Console.WriteLine($"Cамый дешёвый компьютер \n{costmin_comp.Cod}, {costmin_comp.Brand} , {costmin_comp.CPU}, {costmin_comp.FrequencCPU}, {costmin_comp.DDR} , {costmin_comp.SSD}, {costmin_comp.Graphics}, {costmin_comp.Cost}, {costmin_comp.Count}");
            Console.WriteLine();

            bool count_comp = list_comp.Any(c => c.Count > 30);
            if (count_comp)
            {
                Console.WriteLine("В наличии больше 30 штук есть комплектации компьютеров");
            }
            else
            {
                Console.WriteLine("В наличии больше 30 штук нет ни одной комплектации");
            }

            Console.ReadKey();
        }

        class Comp
        {
            public int Cod { get; set; }
            public string Brand { get; set; }
            public string CPU { get; set; }
            public double FrequencCPU { get; set; }
            public int DDR { get; set; }
            public int SSD { get; set; }
            public int Graphics { get; set; }
            public double Cost { get; set; }
            public int Count { get; set; }

        }
    }
}
