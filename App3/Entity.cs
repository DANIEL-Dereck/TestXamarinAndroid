namespace App3
{
    public class Entity
    {
        #region Attributs
        private int? num;
        private string ess;
        private int? diam1;
        private int diam2;
        #endregion

        #region Constructors
        public Entity()
        {

        }

        public Entity(int num, string ess, int diam1, int diam2)
        {
            this.num = num;
            this.ess = ess;
            this.diam1 = diam1;
            this.diam2 = diam2;
        }
        #endregion

        #region Properties
        public int? Num
        {
            get { return num; }
            set { num = value; }
        }

        public string Ess
        {
            get { return ess; }
            set { ess = value; }
        }

        public int? Diam1
        {
            get { return diam1; }
            set { diam1 = value; }
        }

        public int Diam2
        {
            get { return diam2; }
            set { diam2 = value; }
        }
        #endregion
    }
}
