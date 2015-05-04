namespace Crawler.GameObjects.Living
{
    public class Statistics
    {

        public int Speed { get; set; }

        public int FOV { get; set; }

        public int PV { get; set; }

        public int Intelligence { get; set; }

        public int Force { get; set; }


        public static Statistics operator +(Statistics s, Statistics s2)
        {
            var result = new Statistics();
            result.FOV = s.FOV + s2.FOV;
            result.PV = s.PV + s2.PV;
            result.Intelligence = s.Intelligence + s2.Intelligence;
            result.Speed = s.Speed + s2.Speed;
            result.Force = s.Force + s2.Force;
            return result;
        }

        public static Statistics operator -(Statistics s, Statistics s2)
        {
            var result = new Statistics();
            result.FOV = s.FOV - s2.FOV;
            result.Speed = s.Speed - s2.Speed;
            result.Force = s.Force - s2.Force;
            result.PV = s.PV - s2.PV;
            result.Intelligence = s.Intelligence - s2.Intelligence;
            return result;
        }
    }
}
