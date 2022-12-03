using MobileBillCalculation;

Console.Write("Start Time : ");
var startTime = Console.ReadLine();
Console.Write("End Time : ");
var endTime = Console.ReadLine();


var bc = new BillCalculation();
var amount= bc.GetAmount(Convert.ToDateTime(startTime), Convert.ToDateTime(endTime));

Console.WriteLine(amount.ToString()+" Taka.");

