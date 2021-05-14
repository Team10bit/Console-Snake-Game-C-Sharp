using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Snake
    {
        public enum Directions : int { UP = 0, DOWN = 1, LEFT = 2, RIGHT = 3 };
        int x, y;
        public bool alive = true;
        bool head;
        String symbol = "";
        public Directions direction = Directions.LEFT;
        public Directions nextDir = Directions.LEFT;
        public Directions lastDir = Directions.LEFT;

        public Snake(int X, int Y, bool isHead)
        {
            x = X;
            y = Y;
            head = isHead;
            if (head)
            {
                symbol = "S";
            }
            else
            {
                symbol = "T";
            }
        }

        public bool isHead()
        {
            return head;
        }

        public void update()
        {            
            direction = nextDir;

            switch (nextDir) 
            {
                case Directions.LEFT:
                    y -= 1;
                    break;
                case Directions.RIGHT:
                    y += 1;
                    break;
                case Directions.UP:
                    x -= 1;
                    break;
                case Directions.DOWN:
                    x += 1;
                    break;
            }
            lastDir = direction;
        }

        public void setDir(Directions dir)
        {
            nextDir = dir;
        }

        public String getChar()
        {
            return symbol;
        }

        public void setX(int X)
        {
            x = X;
        }

        public void setY(int Y)
        {
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
    }
}
