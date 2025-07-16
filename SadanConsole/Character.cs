namespace SadanConsole
{
    public abstract class Character
    {
        protected Map map;
        public int X { get; set; }
        public int Z { get; set; }
        public int Y { get; set; }
        public char Symbol { get; protected set; }

        public Character(Map map, int X, int Y, char Symbol)
        {
            this.map = map;
            this.X = X;
            this.Y = Y;
            this.Symbol = Symbol;
        }

        public virtual void Draw()                      //virtual yapmamizin sebebi alt sınıflarda draw methodunu
                                                        //kendi ozelliginde tekrar yazmasını saglar tekrar override edilebilir
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }

        public virtual void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }

        public abstract void Move(ConsoleKey key); //abstract kullanmamızın sebebi
                                                   //her sınıfın ( enemy , player ) farklı move yonleri olucagı icin
    }
}
