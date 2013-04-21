using System;

namespace SoutenanceIII001.dTimer
{
    class Countdown : TimerBase
    {
        #region Fields

        private TimeSpan duration;

        #endregion

        #region Constructors

        public Countdown()
            : base()
        {
            duration = TimeSpan.Zero;
        }

        public Countdown(TimeSpan duration)
            : base()
        {
            this.duration = duration;
        }

        public Countdown(TimeSpan duration, EventHandler end)
            : base()
        {
            this.duration = duration;
            End += end;
        }

        public Countdown(TimeSpan duration, EventHandler end, bool start)
            : base(start)
        {
            this.duration = duration;
            End += end;
        }


        #endregion

        #region Properties

        public TimeSpan Left
        {
            get { return duration - Elapsed; }
        }

        public TimeSpan Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        #endregion

        #region Events

        public event EventHandler End;

        #endregion

        #region Methods

        public override void Update()
        {
            base.Update();

            if (Elapsed >= Duration)
            {
                OnEnded();
                Reset();
            }
        }

        protected void OnEnded()
        {
            if (End != null)
                End(this, EventArgs.Empty);
        }

        #endregion

    }

    /*      *** Utilisation de Countdown ***
     * 
     * Créer un nouveau 'timer' dans ta classe actuelle (par exemple 'game1' si tu veux l'utiliser dans ton 'game1') :
     *  => Countdown timer;
     *  
     * Initialisation avec des params :
     *  => this.timer = new Countdown( 1° 2° 3° );
     *  
     *      ici :
     *          1° correspond à la durée du timer
     *              Exemple : TimeSpan.FromMilliseconds(4000) (durée de 4 sec)
     *              Exemple : TimeSpan.FromSecond(4) (durée de 4 sec)
     *              
     *          2° correspond à l'action à effectuer à la fin du timer
     *              Exemple : this.Deplacement (effectue la methode 'Deplacement' défini dans la class actuelle)
     *              La methode à effectuer s'écrit de la manière suivante :
     *              
     *                  void Deplacement(object sender, EventArgs e)
                        {
                            //Ton action (Dans cet exemple, le déplacement à réaliser)
                        }
     * 
     *          3° correspond au booleen d'action ou non, si on veut ou non réaliser l'action
     *          
     * Update banal :
     *  => timer.Update(gameTime);
     *  
     * Util à savoir :
     *  - On peut réinitialiser le timer dans la methode que le timer effectue.
     *  - On peut récupérer la durée écoulée :
     *      => timer.Elapsed.TotalMilliseconds
     *  - On peut récupérer la durée totale :
     *      => timer.Duration.TotalMilliseconds
     *      
     * 
     * En résumer dans la 'class' actuelle :
     * 
     * Countdown timer
     * 
     * Public 'class'()
     *  {
     *      ...
     *      timer = new Countdown( 1° 2°, 3° )
     *      ...
     *  }
     *  
     * Public void 'Update'( )
     *  {
     *      ...
     *      timer.Update(gameTime)
     *      ...
     *  }
     *  
     *  void 2°(object sender, EventArgs e)
     *  {
     *      //ACTION
     *  }
     *
     * 
     * adrienfenechg@gmail.com
     *          
     */
}
