namespace Crawler.GameObjects.Living
{
    public class FullStatistics : Statistics
    {

        public Statistics BasicStatistics { get; set; }

        public Statistics AddedStatistics { get; set; }



        public int FOV
        {
            get
            {
                return this.BasicStatistics.FOV + this.AddedStatistics.FOV;
            }
        }


        public int Speed
        {
            get
            {
                return this.BasicStatistics.Speed + this.AddedStatistics.Speed;
            }
        }

        public int PV
        {
            get { return this.BasicStatistics.PV + this.AddedStatistics.PV; }
        }

        public int Intelligence
        {
            get { return this.BasicStatistics.Intelligence + this.AddedStatistics.Intelligence; }
        }

        public int Force
        {
            get { return this.BasicStatistics.Force + this.AddedStatistics.Force; }
        }

        public FullStatistics(Statistics baseic)
        {
            this.BasicStatistics = baseic;
            this.AddedStatistics = new Statistics();
        }

        public void ApplyBonus(Statistics s)
        {
            this.AddedStatistics += s;
        }

        public void RemoveBonus(Statistics s)
        {
            this.AddedStatistics -= s;
        }


    }
}
