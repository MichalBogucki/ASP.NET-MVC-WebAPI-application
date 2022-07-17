using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        private List<Block> Blocks = new List<Block>()
        {
            new Block(false,true,false),
            new Block(true,false,false),
            new Block(true,true,false),
            new Block(false,true,false),
            new Block(false,true,true)
        };



        [DataTestMethod]
        [DataRow(3, 1, true, true, true)]
        public void Google(int finalIndex, int correctDistance, bool wantGym, bool wantSchool, bool wantStore)
        {
            var results = new List<Distance>();

            for (int i = 0; i < Blocks.Count; i++)
            {
                results.Add(GetLeftRightMinimum(i, wantGym, wantSchool, wantStore));
            }
            Assert.IsTrue(results.Single(r => r.Index == finalIndex).MinDistance == correctDistance);
            var filteredResults = results.Where(r => r.Index != finalIndex);
            Assert.IsFalse(filteredResults.Any(r => r.MinDistance <= correctDistance));
        }

        private Distance GetLeftRightMinimum(int currentIndex, bool wantGym, bool wantSchool, bool wantStore)
        {
            int leftDistanceTraversed = 0;
            int rightDistanceTraversed = 0;
            var temporaryBlock = new Block(false, false, false, Blocks.Count);

            while (leftDistanceTraversed < Blocks.Count && rightDistanceTraversed < Blocks.Count)
            {
                if (temporaryBlock.IsSatisfied())
                {
                    return new Distance(currentIndex, temporaryBlock.LeftDistance, temporaryBlock.RightDistance);
                } //ToDo kontynuowac

            }
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
