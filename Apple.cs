using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Apple
    {
        int x, y;
        Boolean eaten = false;
        public Apple(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }
        
        public void update()
        {
            if (isEaten())
            {
                respawn();
            }
        }

        public void respawn()
        {
            x = 5;
            y = 5;
        }

        private Boolean isEaten()
        {
            return eaten;
        }

    }
}
