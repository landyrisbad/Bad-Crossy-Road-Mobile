using Microsoft.Xna.Framework;

namespace Shit_Crossy_Road
{
    public class Scale
    {
        

        public static Matrix SetResolutionAndScale(float deviceWidth, float deviceHeight)
        {

            return Matrix.CreateScale(deviceWidth / Game1.self.SCREENSIZEWIDTH,
                                             deviceHeight / Game1.self.SCREENSIZEHEIGHT,
                                             1f);
        }
    }
}