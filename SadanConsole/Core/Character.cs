namespace SadanConsole.Core
{
    public abstract class Character
    {
        public Position Position { get; set; }
        public char Symbol { get; protected set; }
        protected IRenderer renderer;

        protected Character(Position position, char symbol, IRenderer renderer)
        {
            Position = position;
            Symbol = symbol;
            this.renderer = renderer;
        }

        public virtual void Draw()
        {
            renderer.Draw(Position, Symbol);
        }

        public virtual void Clear()
        {
            renderer.Clear(Position);
        }
    }
}
