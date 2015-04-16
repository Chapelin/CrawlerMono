namespace Crawler.Living
{
    public class Statistics
    {

        public int Speed { get; set; }

        public int FOV { get; set; }


        public static Statistics operator +(Statistics s, Statistics s2)
        {
            var result = new Statistics();
            result.FOV = s.FOV + s2.FOV;
            result.Speed = s.Speed + s2.Speed;
            return result;
        }

        public static Statistics operator -(Statistics s, Statistics s2)
        {
            var result = new Statistics();
            result.FOV = s.FOV - s2.FOV;
            result.Speed = s.Speed - s2.Speed;
            return result;
        }
    }
}
