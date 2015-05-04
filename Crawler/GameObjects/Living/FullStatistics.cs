namespace Crawler.GameObjects.Living
{
    public class FullStatistics : Statistics
    {
        public Statistics BasicStatistics { get; set; }

        public Statistics AddedStatistics { get; set; }

        private int _currentPv ;

        public int CurrentPv
        {
            get { return _currentPv; }
        }

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

        public int MaxPv
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
            this._currentPv = this.MaxPv;
        }

        public void ApplyBonus(Statistics s)
        {
            this.AddedStatistics += s;
            this._currentPv += s.PV;
        }

        public void RemoveBonus(Statistics s)
        {
            this.AddedStatistics -= s;
            this._currentPv -= s.PV;
        }

        public void RemovePv(int pvToRemove)
        {
            this._currentPv -= pvToRemove;
           
        }

        public void AddPv(int pvToAdd)
        {
            this._currentPv += pvToAdd;
            if (this._currentPv > this.MaxPv)
            {
                this._currentPv = this.MaxPv;
            }
        }
    }
}
