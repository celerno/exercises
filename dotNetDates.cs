using System;
					
public class Program
{
	public static void Main()
	{
		DateTime lastrun = new DateTime(2018, 01,31);
		DateTime today = new DateTime(2018, 02, 28);
		DateTime start_date = new DateTime(2017,12,31);
		
		Console.WriteLine("should run {0}", today.Year==lastrun.Year &&
						  (today.Month>lastrun.Month) &&
						 (start_date.IsEndOfMonth()? today.IsEndOfMonth() : today.Day>=start_date.Day));
	}
}
public static class Extensions{

	public static bool IsEndOfMonth(this DateTime date){
		return date.Day == DateTime.DaysInMonth(date.Year, date.Month);
	}
}
