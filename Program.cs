namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var Program = new Program();
            var run = true;
            while (run){
                Console.WriteLine("Please cloose to be aboveBelow (1) or stringRotation (2)");
                var input = Console.ReadLine();
                switch(input)
                {
                    case "aboveBelow":
                    case "ab":
                    case "1":
                        var NumberList = new List<int>();
                        int ComparisonNum = 0;
                        while(true){
                            Console.WriteLine("Please input a comma seperated list of numbers");
                            var Numbers = Console.ReadLine();
                            if (!Program.CheckInput(ref NumberList, Numbers)) Console.WriteLine("incorrect input, please try again");
                            else break;
                        }
                        while(true){
                            Console.WriteLine("Please input a comparison value");
                            var Number = Console.ReadLine();
                            if (!Int32.TryParse(Number, out ComparisonNum)) Console.WriteLine("incorrect input, please try again");
                            else break;
                        }
                        var map = Program.aboveBelow(ComparisonNum, NumberList);
                        Console.WriteLine(map.ToString());

                        break;
                    case "stringRotation":
                    case "sr":
                    case "2":
                        var originalString = "";
                        int rotation = 0;
                        while(true){
                            Console.WriteLine("Please input a string");
                            originalString = Console.ReadLine();
                            if (string.IsNullOrEmpty(originalString)) Console.WriteLine("incorrect input, please try again");
                            else break;
                        }

                        while(true){
                            Console.WriteLine("Please input a rotation value");
                            var Number = Console.ReadLine();
                            if (!Int32.TryParse(Number, out rotation)) Console.WriteLine("incorrect input, please try again");
                            else if (originalString.Length < rotation -1) Console.WriteLine("incorrect input, please try again");
                            else break;
                        }

                        Console.WriteLine(Program.stringRotation(rotation, originalString));
                        break;
                    case "exit":
                        Console.WriteLine("Good bye");
                        run = false;
                        break;
                    default:
                        Console.WriteLine("unrecognized input, please try again");
                        break;
                }
            }
        }

        public bool CheckInput(ref List<int> NumberList, string? Numbers)
        {
            if (Numbers == null) return false;
            foreach (string number in Numbers.Split(","))
            {
                if (Int32.TryParse(number, out int num)) NumberList.Add(num);
                else return false;
            }

            return true;
        }

        public class map
        {
            public int above {get; set;}
            public int below {get; set;}

            public override string ToString()
            {
                return "{\"above\":" + above + ", \"below\":" + below + "}";
            }
        }

        public map aboveBelow(int comparison, List<int> IntList)
        {
            var result = new map();
            IntList.Sort();
            foreach (int i in IntList){
                if (i < comparison) result.below++;
                else break;
            }
            result.above = IntList.Count() - result.below;
            
            return result;
        }

        public string stringRotation(int rotation, string originalString){
            return originalString.Substring(rotation) + originalString.Substring(0, rotation);
        }
    }
}