using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class MovingTotal
    {
        public List<int> Sequences = new List<int>();
        public List<int> Appended = new List<int>();

        public void Append(int[] list)
        {
            foreach (var element in list)
            {
                Appended.Add(element);
            }

            var appendedCount = Appended.Count;
            for (int i = Sequences.Count; i < appendedCount; i++)
            {
                if (appendedCount - i > 2)
                {
                    Sequences.Add(Appended[i]+Appended[i+1]+Appended[i+2]);
                }
            }
        }

        public bool Contains(int total)
        {
            return Sequences.Contains(total);
        }
        

        [DataTestMethod]
        public void Google()
        {
            MovingTotal movingTotal = new MovingTotal();

            movingTotal.Append(new int[] { 1, 2, 3, 4 });

            Console.WriteLine(movingTotal.Contains(6));
            Console.WriteLine(movingTotal.Contains(9));
            Console.WriteLine(movingTotal.Contains(12));
            Console.WriteLine(movingTotal.Contains(7));

            movingTotal.Append(new int[] { 5 });

            Console.WriteLine(movingTotal.Contains(6));
            Console.WriteLine(movingTotal.Contains(9));
            Console.WriteLine(movingTotal.Contains(12));
            Console.WriteLine(movingTotal.Contains(7));

        }


        public class Block
        {
            public Block(bool hasGym, bool hasSchool, bool hasStore, int initialMaxDistance)
            {
                Gym = hasGym;
                School = hasSchool;
                Store = hasStore;
                LeftDistance = initialMaxDistance;
                RightDistance = initialMaxDistance;
            }

            public int LeftDistance { get; set; }
            public int RightDistance { get; set; }

            public bool Gym { get; set; }
            public bool School { get; set; }
            public bool Store { get; set; }

            public bool IsSatisfied()
            {
                return Gym && School && Store;
            }

            public void ShareActivities(Block visitedBlock)
            {
                if (!this.Gym)
                {
                    this.Gym = visitedBlock.Gym;
                }

                if (!this.School)
                {
                    this.School = visitedBlock.School;
                }

                if (!this.Store)
                {
                    this.Store = visitedBlock.Store;
                }
            }

        }

        public class Distance
        {
            public Distance(int index, int leftDistance, int rightDistance)
            {
                Index = index;
                MinDistance = Math.Min(leftDistance, rightDistance);
            }

            public int Index { get; set; }
            public int MinDistance { get; set; }
        }
    }
}
