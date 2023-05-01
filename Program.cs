using System;
namespace HierarchicalStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the Tree Structure from the problem
        
            //{1} has 2 branches {2,3}
            var root = new Branch(1);
            var SecondLayer = new Branch(2);
            root.AddSubBranch(SecondLayer);
            //{2} has branch 4
            SecondLayer.AddSubBranch(new Branch(4));
            SecondLayer = new Branch(3);
            root.AddSubBranch(SecondLayer);
            //{3} has branch {5,6,7}
            var ThirdLayer = new Branch(5);
            SecondLayer.AddSubBranch(ThirdLayer);
            //{5} has branch {8}
            ThirdLayer.AddSubBranch(new Branch(8));
            ThirdLayer = new Branch(6);
            SecondLayer.AddSubBranch(ThirdLayer);
            //{6} has branches {9,10}
            var FourthLayer = new Branch(9);
            ThirdLayer.AddSubBranch(FourthLayer);
            var FifthLayer = new Branch(11);
            FourthLayer.AddSubBranch(FifthLayer);
            ThirdLayer.AddSubBranch(new Branch(10));
            SecondLayer.AddSubBranch(new Branch(7));

            root.PrintTree();

            Console.WriteLine("Using Recursion, The depth of the tree provided is: " + Program.CalculateDepth(root));
            
        }


        public static int CalculateDepth(Branch branch)
        {
            int maxDepth = 0;

            foreach (var subBranch in branch.SubBranches)
            {
                int depth = CalculateDepth(subBranch);
                
                if (depth > maxDepth)
                {
                    maxDepth = depth;
                }
            }
            
            return maxDepth + 1;
        }
    }

    class Branch
    {
        public int Value {get; set;}
        public List<Branch> SubBranches {get; set;}

        public Branch(int value)
        {
            this.Value = value;
            this.SubBranches = new List<Branch>();
        }

        public void AddSubBranch(Branch SubBranch)
        {
            this.SubBranches.Add(SubBranch);
        }

        public int GetValue()
        {
            return this.Value;
        }

        public void PrintTree()
        {
            PrintBranch(this, 0);
        }

        private void PrintBranch(Branch branch, int depth)
        {
          Console.WriteLine($"{new string('-', depth)} {branch.Value}");

            // Recursively print sub-branches, if any
            foreach (var subBranch in branch.SubBranches)
            {
                PrintBranch(subBranch, depth + 1);
            }   
        }

        
    }
}
