using Train.Data;
using Train.Data.Models;

public class Program
{
    public static void Main()
    {
        TrainCRUDManager crud = new TrainCRUDManager();

        DateTime dtStart, dtEnd;
        DateTime.TryParse("22/06/2022 ", out dtStart);
        DateTime.TryParse("22/06/2022 ", out dtEnd);

        TrainInfo obj = new TrainInfo
        {
            TrainNo = 506,
            TrainName = "Chandigarh Express",
            FromStation = "Dehradun",
            ToStation = "Lucknow",
            JourneyStartTime = dtStart,
            JourneyEndTime = dtEnd
        };

        //days schedular
        TrainDay trainDay = new TrainDay
        {
            TrainNumber = 508,
            Monday = true,
            Tuesday = true,
            Wednesday = true,
            Thursday = true,
            Friday = true,
            Saturday = false,
            Sunday = false
        };

        // crud.AddInTrainAndDaysSchedular(obj, trainDay);

        ////update
        //DateTime.TryParse("22/06/2022", out dtStart);
        //obj.JourneyStartTime = dtStart;
        //crud.UpdateInTrainDetails(506, obj);

        //////delete
        ////crud.DeleteInTrainsDetails(506);

        //////search by train number
        //crud.SearchByTrainNumber(508);

        //////method to search by from station and to station
        string fromStation = "MP", toStation = "Goa";
        crud.SearchByFromAndToStation(fromStation, toStation);
    }
}

