namespace FlightSchedule.Tools
{
    public class Tools
    {
        public static bool ContainsAllParameters(params string[] parameters)
        {
            foreach (var parameter in parameters)
            {
                if (string.IsNullOrWhiteSpace(parameter)) return false;
            }

            return true;
        }
    }
}