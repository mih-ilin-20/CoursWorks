using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Figure
    {
        public int x;
        public int y;
        public int[,] matr;
        public int matr_size;

        public int[,] ii = new int[4, 4]
        {   {0,1,0,0},
            {0,1,0,0},
            {0,1,0,0},
            {0,1,0,0}, };
        public int[,] ll = new int[3, 3]
        {   {0,2,0},
            {0,2,0}, 
            {0,2,2} };
        public int[,] jj = new int[3, 3] 
        {   {0,3,0}, 
            {0,3,0}, 
            {3,3,0} };
        public int[,] ss = new int[3, 3]
        {   {4,0,0},
            {4,4,0},
            {0,4,0}, };
        public int[,] zz = new int[3, 3]
        {   {0,5,0},
            {5,5,0},
            {5,0,0} };
        public int[,] tt = new int[3, 3] 
        {   {6,6,6},
            {0,6,0}, 
            {0,0,0} };
        public int[,] oo = new int[2, 2]
        {   {7,7},
            {7,7} };

        public Figure(int _x, int _y)
        {
            x = _x;
            y = _y;
            NewMatr();
        }

        public void NewMatr()
        {
            matr_size = 3;
            Random random = new Random();
            switch (random.Next(1, 8))
            { 
                case 1:
                    matr_size = 4;
                    matr = ii;
                    break;
                case 2:
                    matr = ll;
                    break;
                case 3:
                    matr = jj;
                    break;
                case 4:
                    matr = ss;
                    break;
                case 5:
                    matr = zz;
                    break;
                case 6:
                    matr = tt;
                    break;
                case 7:
                    matr_size = 2;
                    matr = oo;
                    break;
            }
        }


        public void MoveDown()
        {
            y++; 
        }

        public void MoveRight()
        {
            x++; 
        }

        public void MoveLeft()
        {
            x--; 
        }

        public void Rotate()
        {
            int[,] rotatematr = new int[matr_size, matr_size];
            for (int i = 0; i < matr_size; i++)
            {
                for (int j = 0; j < matr_size; j++)
                {
                    rotatematr[i, j] = matr[j, (matr_size - 1) - i];
                }
            }
            matr = rotatematr;
            if (Form1.a - (x + matr_size) < 0) // проверка насколько мы уходим за границы справа
            {
                for (int i = 0; i < Math.Abs(Form1.a - (x + matr_size)) ; i++)
                    MoveLeft();
            }
            if (x < 0)
            {
                for (int i = 0; i < Math.Abs(Form1.a - (x + matr_size)) ; i++)
                    MoveRight();
            }
            

        }

    }
}
