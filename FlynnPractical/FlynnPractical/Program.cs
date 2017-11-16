using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlynnPractical
{
    class Program
    {
        static void Main(string[] args)
        {
            Model1 mContext = new Model1();
            
            var innerJoin = (from t in mContext.Table_1
                            join t2 in mContext.Table_2 on t.Id equals t2.Id
                            select new{
                            t.Id,
                            t.Code,
                            t2.Name
                        });

            var leftJoin = from t in mContext.Table_1
                                 join t2 in mContext.Table_2
                                 on t.Id equals t2.Id
                                 into temp
                                 from t2 in temp.DefaultIfEmpty()
                                 select new
                                 {
                                     t.Id,
                                     t.Code,
                                     t2.Name
                                 };

            var rightJoin = from t2 in mContext.Table_2
                                 join t in mContext.Table_1
                                 on t2.Id equals t.Id
                                 into temp
                                 from t in temp.DefaultIfEmpty()
                                 select new
                                 {
                                     t2.Id,
                                     t.Code,
                                     t2.Name
                                 };
            var outerJoin = leftJoin.Union(rightJoin);

            Console.WriteLine("Inner join");

            foreach (var item in innerJoin)
            {
                var id = item.Id;
                var name = item.Name;
                var count = item.Code;
                Console.WriteLine(id + " " + name + " "+ count);
               
            }

            Console.WriteLine("Left join");

            foreach (var item in leftJoin)
            {
                var id = item.Id;
                var name = item.Name;
                var count = item.Code;
                Console.WriteLine(id + " " + name + " " + count);

            }

            Console.WriteLine("Right join");

            foreach (var item in rightJoin)
            {
                var id = item.Id;
                var name = item.Name;
                var count = item.Code;
                Console.WriteLine(id + " " + name + " " + count);

            }


            Console.WriteLine("Outer join");

            foreach (var item in outerJoin)
            {
                var id = item.Id;
                var name = item.Name;
                var count = item.Code;
                Console.WriteLine(id + " " + name + " " + count);

            }

            Console.ReadLine();


        }
    }
}
