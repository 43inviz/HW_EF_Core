namespace HW_27_08_1_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Trains trains = new Trains {
                WagonCount = 10,
                EmployeeCount = 20,
                BossSurname = "Sidorov123",
                Milleage = 15432.12,
                TrainType = "high speed"
            }; 

            RequestManager requestManager = new RequestManager();
            //requestManager.AddData();

            /////
            //requestManager.AddTrain(trains);

            /////
            //Trains train2 = requestManager.GetTrainById(3);

            //Console.WriteLine(train2);


            //requestManager.UpdateTrain(trains);
            //Trains train2 = requestManager.GetTrainById(3);

            //Console.WriteLine(train2);


            requestManager.DeleteTrainById(3);
            List<Trains> trains1 = requestManager.GetTrains();

            foreach (var el in trains1)
            {
                Console.WriteLine(el.TrainType, "\n");
            }







        }
    }
}
