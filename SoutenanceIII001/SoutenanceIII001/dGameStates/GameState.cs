namespace SoutenanceIII001.dGameStates
{
    public abstract class GameState
    {
        public abstract void Initialize();

        public abstract void LoadContent();

        public virtual void Destroy() { }

        public abstract void Update();

        public abstract void Draw();
    }
}
