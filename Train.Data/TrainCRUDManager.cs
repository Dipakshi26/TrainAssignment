using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.Data.Models;

namespace Train.Data
{
    public class TrainCRUDManager
    {
        OrderEFDbContext orderEFDbContext = new OrderEFDbContext();
            //add in both table at once
        public void AddInTrainAndDaysSchedular(TrainInfo trainInfo, TrainDay trainDay)
        {
            var trainInfoObj = new TrainInfo
            {
                TrainNo = trainInfo.TrainNo,
                TrainName = trainInfo.TrainName,
                FromStation = trainInfo.FromStation,
                ToStation = trainInfo.ToStation,
                JourneyStartTime = trainInfo.JourneyStartTime,
                JourneyEndTime = trainInfo.JourneyEndTime,
                TrainDay = trainDay
            };
            orderEFDbContext.TrainInfos.Add(trainInfoObj);
            orderEFDbContext.SaveChanges();
            Console.WriteLine("Record added.");
        }

        #region Saperate-funct-to-add
        public void AddInTrainDetails(TrainInfo trainInfos)
        {
            var trainInfo = new TrainInfo
            {
                TrainNo = trainInfos.TrainNo,
                TrainName = trainInfos.TrainName,
                FromStation = trainInfos.FromStation,
                ToStation = trainInfos.ToStation,
                JourneyStartTime = trainInfos.JourneyStartTime,
                JourneyEndTime = trainInfos.JourneyEndTime,
            };

            orderEFDbContext.TrainInfos.Add(trainInfo);
            orderEFDbContext.SaveChanges();

        }
        public void AddInDaysShedualar(TrainDay trainDays)
        {
            var trainDay = new TrainDay
            {
                TrainNumber = trainDays.TrainNumber,
                Monday = trainDays.Monday,
                Tuesday = trainDays.Tuesday,
                Wednesday = trainDays.Wednesday,
                Thursday = trainDays.Thursday,
                Friday = trainDays.Friday,
                Saturday = trainDays.Saturday,
                Sunday = trainDays.Sunday,

            };
            orderEFDbContext.TrainDays.Add(trainDay);
            orderEFDbContext.SaveChanges();
            Console.WriteLine("Inserted");
        }
        #endregion
        public void UpdateInTrainDetails(int trainNumber, TrainInfo updatedDetail)
        {
            var trainDetail = orderEFDbContext.TrainInfos.Where(td => td.TrainNo == trainNumber).FirstOrDefault();
            if (trainDetail != null)
            {
                trainDetail.TrainName = updatedDetail.TrainName;
                trainDetail.FromStation = updatedDetail.FromStation;
                trainDetail.ToStation = updatedDetail.ToStation;
                trainDetail.JourneyStartTime = updatedDetail.JourneyStartTime;
                trainDetail.JourneyEndTime = updatedDetail.JourneyEndTime;

                orderEFDbContext.TrainInfos.Update(trainDetail);
                orderEFDbContext.SaveChanges();
                Console.WriteLine("Updated");
            }
            else
                Console.WriteLine($"Train number: {trainNumber} is not found");
        }

        public void DeleteInTrainsDetails(int trainNumber)
        {
            var trainSDetail = orderEFDbContext.TrainDays.Where(td => td.TrainNumber == trainNumber).FirstOrDefault();
            if (trainSDetail != null)
            {
                orderEFDbContext.TrainDays.Remove(trainSDetail);
                orderEFDbContext.SaveChanges();
                Console.WriteLine("Deleted from days schedular");
            }
            else
                Console.WriteLine($"Train number: {trainNumber} is not found");

            var trainDetail = orderEFDbContext.TrainInfos.Where(td => td.TrainNo == trainNumber).FirstOrDefault();
            if (trainDetail != null)
            {
                orderEFDbContext.TrainInfos.Remove(trainDetail);
                orderEFDbContext.SaveChanges();
                Console.WriteLine("Deleted from train info.");
            }
            else
                Console.WriteLine($"Train number: {trainNumber} is not found");

        }

        public void SearchByTrainNumber(int trainNumber)
        {
            var trainDetail = orderEFDbContext.TrainInfos.Where(td => td.TrainNo == trainNumber).FirstOrDefault();
            if (trainDetail != null)
            {
                Console.WriteLine($"Train Name: {trainDetail.TrainName},From Station: {trainDetail.FromStation},To Station: {trainDetail.ToStation},JurneySTime: {trainDetail.JourneyStartTime},JurneyETime: {trainDetail.JourneyEndTime}");
                Console.WriteLine($"From Station: {trainDetail.FromStation}");
                Console.WriteLine($"To Station: {trainDetail.ToStation}");
                Console.WriteLine($"JourneySTime: {trainDetail.JourneyStartTime}");
                Console.WriteLine($"JourneyETime: {trainDetail.JourneyEndTime}");

            }
            else
                Console.WriteLine($"Train number: {trainNumber} is not found");

        }

        public void SearchByFromAndToStation(string from, string to)
        {
            var trainDetail = orderEFDbContext.TrainInfos.Where(td => td.FromStation == from && td.ToStation == to).ToList();
            if (trainDetail != null)
            {
                foreach (var item in trainDetail)
                {
                    Console.WriteLine($"Train no. : {item.TrainNo},TrainName : {item.TrainName},JourneySTime: {item.JourneyStartTime},   JourneyETime: {item.JourneyEndTime}");
                }
            }
            else
            {
                Console.WriteLine($"No details available for train station from {from} to station {to}");
            }
        }


        /* DateTime dtStart,dtEnd;
        DateTime.TryParse("22/06/2022 7:00:00 AM", out dtStart);
        DateTime.TryParse("22/06/2022 6:00:00 PM", out dtEnd);

        TrainDetail obj = new TrainDetail
        {
            TrainNumber= 504,TrainName="Pune Express",FromStation="Pune",ToStaion="Goa",JourneyStime= dtStart,
            JourneyEtime= dtEnd
        }; */

        public void insert()
        {
            Console.WriteLine("Enter Train number.");
            int tN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Train name.");
            string tName = Console.ReadLine();

            Console.WriteLine("Enter from station.");
            string from = Console.ReadLine();

            Console.WriteLine("Enter to station.");
            string to = Console.ReadLine();
            Console.WriteLine("Enter journey start time and date(month/day/year : hour:minute:second)");
            string startDate = Console.ReadLine();

            Console.WriteLine("Enter journey end time and date(month/day/year : hour:minute:second)");
            string endDate = Console.ReadLine();



        }
    }
}
