using _02.Data;
using _02.Data.Interfaces;
using _02.Data.Models;
using System;
using System.Collections.Generic;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();


            for (int i = 0; i < 20; i++)
            {
                IEntity entity = new Invoice(i + 1, i);
                data.Add(entity);
            }



        }
    }
}
