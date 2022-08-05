using Microsoft.Xna.Framework;

namespace Shit_Crossy_Road
{
    public class Scenery : Background {
        public Scenery (int y) : base(0, y){
            color = Color.White;
            texture = new Rectangle(0, 60, 422, 20);
        }
    }
}