namespace CodeIt.Cli
{
    public class Startup
    {
        const string SourceCode = "using System; namespace ConsoleApp1 { class Program { static void Main(string[] args) { int a = int.Parse(Console.ReadLine()); Console.WriteLine(a + 1); } } } ";

        public static void Main()
        {
            //var jsonUtil = new JsonUtils();
            //var requester = new HttpRequester(jsonUtil);

            //var engine = new SphereEngineApiClient("ac5f8f48d0ec8e7e9df71cbebd004e56", requester, jsonUtil);
            //var eval = new SubmissionEvaluator(engine);
            //var tests = new List<Test>
            //{
            //    new Test
            //    {
            //       Parameters = new TestParams()
            //       {
            //           Input = "2",
            //           Output = "3"
            //       }
            //    },
            //    new Test
            //    {
            //        Parameters = new TestParams()
            //       {
            //           Input = "9",
            //           Output = "10"
            //       }
            //    },
            //    new Test
            //    {
            //       Parameters = new TestParams()
            //       {
            //           Input = "p",
            //           Output = "3"
            //       }
            //    }
            //};

            //// Testing

            //Execute(eval, tests);
            //Console.ReadLine();
        }

        //static async Task Execute(SubmissionEvaluator eval, IList<Test> tests)
        //{
        //    tests = await eval.ExecuteTest(SourceCode, SphereLanguage.CSharp, tests);
        //    await GetResults(eval, tests);
        //}

        //static async Task GetResults(SubmissionEvaluator eval, IList<Test> tests)
        //{
        //    Thread.Sleep(2000);
        //    foreach (var item in await eval.GetResults(tests))
        //    {
        //        Console.WriteLine($"!{item.Output.Trim()}!");
        //        //Console.WriteLine(item.RuntimeException);
        //    }
        //}
    }
}
