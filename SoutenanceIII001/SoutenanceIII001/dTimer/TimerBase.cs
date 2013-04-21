using System;

namespace SoutenanceIII001.dTimer
{
    class TimerBase
    {
        #region Fields

        private TimeSpan elapsed;

        private bool enable;

        #endregion

        #region Constructors

        public TimerBase()
        {
            this.elapsed = TimeSpan.Zero;
            this.enable = false;
        }

        public TimerBase(bool start)
        {
            this.elapsed = TimeSpan.Zero;
            this.enable = false;

            if (start)
            {
                this.Start();
            }
        }

        #endregion

        #region properties

        public TimeSpan Elapsed
        {
            get { return this.elapsed; }
        }

        public bool Enabled
        {
            get { return enable; }
            private set
            {
                this.enable = value;
            }
        }

        public int UpdateOrder
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region Events
        #endregion

        #region Methods

        public void Reset()
        {
            this.Enabled = false;
            this.elapsed = TimeSpan.Zero;
        }

        public void Start()
        {
            this.Enabled = true;
        }

        public void Stop()
        {
            this.Enabled = false;
        }

        public virtual void Update()
        {
            if (!this.enable)
            {
                this.elapsed += GD.gameTime.ElapsedGameTime;
            }
        }
        #endregion
    }
}
