using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBillCalculation
{
    public class BillCalculation
    {
        string pickHourstart = "9.00.00";
        string pickHourend = "22.59.59";

        int pulse = 20;


        private bool IsInPickHour(DateTime startTime,DateTime endTime)
        {
            var hourStart = pickHourstart.Split(".");
            var hourEnd = pickHourend.Split(".");

            var pHourStartForCallStart = new DateTime(startTime.Year, startTime.Month, startTime.Day, Convert.ToInt32(hourStart[0]), Convert.ToInt32(hourStart[1]), Convert.ToInt32(hourStart[2]));

            var pHourEndForCallStart = new DateTime(startTime.Year, startTime.Month, startTime.Day, Convert.ToInt32(hourEnd[0]), Convert.ToInt32(hourEnd[1]), Convert.ToInt32(hourEnd[2]));

            var pickHourStart = new DateTime(endTime.Year, endTime.Month, endTime.Day, Convert.ToInt32(hourStart[0]), Convert.ToInt32(hourStart[1]), Convert.ToInt32(hourStart[2]));

            var pickHourEnd = new DateTime(endTime.Year, endTime.Month, endTime.Day, Convert.ToInt32(hourEnd[0]), Convert.ToInt32(hourEnd[1]), Convert.ToInt32(hourEnd[2]));

            var inStartTime = (startTime >= pHourStartForCallStart && startTime <= pHourEndForCallStart);
            var inEndTimeTime = (endTime >= pickHourStart && endTime <= pickHourEnd);

            return (inEndTimeTime || inStartTime);


        }


        public decimal GetAmount(DateTime startTime, DateTime endTime)
        {
            var amount = 0.0M;
            var callDurationInSec = (endTime - startTime).TotalSeconds;
            var pulseCount = (decimal)Math.Ceiling(callDurationInSec / pulse);
            for (int i = 0; i < pulseCount; i++)
            {
                var pulseStart = startTime.AddSeconds(pulse * i);
                var pulseEnd = startTime.AddSeconds(pulse * (i+1));
                var isinPick = IsInPickHour(pulseStart, pulseEnd);
                if (isinPick)
                {
                    amount += 0.3M;
                }
                else
                {
                    amount += 0.2M;
                }
            }


            return amount;

        }
    }
}
