using System.Collections.Generic;
using System;

namespace Shit_Crossy_Road
{
    public class Log : Cars {
        public Log (int pSpeed, bool pDirection, List<Cars> pCollection, River pParent) : base(pSpeed, pDirection, pCollection, pParent) {
            carCollisionList.Remove(this);
            logCollisionList.Add(this);
            width = 80;

            if (width == 80) {
                    texture = textures[3,2];
            } else if (width == 60) {
                    texture = textures[3,1];
            } else if (width == 40) {
                    texture = textures[3,0];
            } 
        }

        static Random random = new Random();

        public static List<Log> logCollisionList = new List<Log>();
    }
}