﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNX
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> cards = new List<string>();
            cards.Add("s");
            cards.Add("m");
            cards.Add("c");

            List<int> cardCont = new List<int>();
            cardCont.Add(0);
            cardCont.Add(0);
            cardCont.Add(0);

            int maxItem = 2;

            string[,] mt = new string[3, 2] { { "", "" }, { "", "" }, { "", "" } };
            //int[] cardCont = new int[3];

            Random r = new Random();

            for (int slot = 0; slot < mt.GetLength(0); slot++)
            {
                for (int col = 0; col < mt.GetLength(1); col++)
                {
                    int index = r.Next(cards.Count);
                    string randomString = cards[index];

                    if (cardCont[index] < maxItem)
                    {

                        cardCont[index]++;

                        mt[slot, col] = randomString;
                        Console.WriteLine(randomString);
                        //cardCont[index] = 0;

                        if (cardCont[index] == maxItem)
                        {
                            Console.WriteLine("Achou");
                            //cards.Remove(randomString);
                            //cardCont.Remove(index);
                        }
                    }
                    else if (cardCont[index] <= maxItem + 1)
                    {
                        //if(slot == mt.GetLength(0) && col == mt.GetLength(1)){ break;}
                        Console.WriteLine(mt.GetLength(0) + "-x-" + mt.GetLength(1));
                        col--;
                        continue;
                    }
                    Console.WriteLine(slot + "-" + col);
                }

            }



            for (int slot = 0; slot < mt.GetLength(0); slot++)
            {
                for (int col = 0; col < mt.GetLength(1); col++)
                {
                    Console.Write("[" + mt[slot, col] + "]");
                }
                Console.WriteLine("");
            }

            for (int slot = 0; slot < cardCont.Count(); slot++)
            {
                Console.Write("[" + cardCont[slot] + "]");
            }
            //Your code goes here

        }
    }
}