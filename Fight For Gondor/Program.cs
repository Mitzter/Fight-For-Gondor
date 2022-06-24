using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Fight_For_Gondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            int[] aragornPlates = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> orcs = new Stack<int>();
            Queue<int> plates = new Queue<int>();

            for (int i = 0; i < aragornPlates.Length; i++)
            {
                plates.Enqueue(aragornPlates[i]);
            }

            for (int wave = 1; wave <= waves; wave++)
            {
                int[] orcPower = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < orcPower.Length; j++)
                {
                    orcs.Push(orcPower[j]);
                }
                if (wave % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                }
                while (true)
                {
                    if (orcs.Count == 0 || plates.Count == 0)
                    {
                        break;
                    }
                    int currentOrc = orcs.Peek();
                    int currentPlate = plates.Peek();
                    if (currentOrc > currentPlate)
                    {
                        currentOrc -= currentPlate;
                        orcs.Pop();
                        if (currentOrc > 0)
                        {
                            orcs.Push(currentOrc);
                        }
                        plates.Dequeue();
                    }
                    else if (currentPlate > currentOrc)
                    {
                        currentPlate -= currentOrc;
                        if (currentPlate > 0)
                        {
                            plates.Dequeue();
                            List<int> reversePlates = new List<int>();
                            reversePlates.Add(currentPlate);

                            for (int i = 0; i < plates.Count; i++)
                            {
                                int plateToReverse = plates.ElementAt(i);
                                reversePlates.Add(plateToReverse);

                            }
                            plates.Clear();
                            foreach (var item in reversePlates)
                            {
                                plates.Enqueue(item);
                            }
                            

                        }
                        else
                        {
                            plates.Dequeue();
                        }
                        orcs.Pop();

                    }
                    else if (currentPlate == currentOrc)
                    {
                        plates.Dequeue();
                        orcs.Pop();
                    }
                }

                if (plates.Count == 0)
                {
                    Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                    Console.WriteLine("Orcs left: " + string.Join(", ", orcs));
                    break;
                }

            }
            if (plates.Count != 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine("Plates left: " + string.Join(", ", plates));
            }
            
        }
    }
}
