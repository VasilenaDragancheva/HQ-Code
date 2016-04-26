using System.Globalization;
using System.Threading;

using ChepelareBookingSystem.Core;
using ChepelareBookingSystem.Data;

public class HotelBookingSystemMain
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        var database = new HotelBookingSystemData();
        var chelepareBookingEngine = new Engine(database);
        chelepareBookingEngine.StartOperation();
    }
}