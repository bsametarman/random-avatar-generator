using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _201505058
{
    internal class Program
    {
        static Color grayColor()
        {
            Random random = new Random();

            // if red, green, blue are same and between 50 - 200, gray returns but i used 70 - 200
            int rnd = random.Next(70, 200);

            Color gray = Color.FromArgb(rnd, rnd, rnd);

            return gray;
        }

        static Color randColorBlock()
        {
            Random random = new Random();

            int red, green, blue;

            // to not produce light colors, it is between 0 - 230 
            red = random.Next(0, 230);
            green = random.Next(0, 230);
            blue = random.Next(0, 230);

            // prevents producing gray

            if (red <= green + 30 || red >= green - 30 || red <= blue + 30 || red >= blue + 30)
            {
                while (!(red >= blue + 20 || red <= blue - 20))
                {
                    red = random.Next(0, 230);
                }
            }

            if (green <= blue + 30 || green >= blue - 30 || green <= red + 30 || green >= red + 30)
            {
                while (!(green >= red + 20 || green <= red - 20))
                {
                    green = random.Next(0, 230);
                }
            }

            if (blue <= green + 30 || blue >= green - 30 || blue <= red + 30 || blue >= red + 30)
            {
                while (!(blue >= green + 20 || blue <= green - 20))
                {
                    blue = random.Next(0, 230);
                }
            }

            Color color = Color.FromArgb(red, green, blue);

            Console.WriteLine("Red: {0}, Green: {1}, Blue: {2} \n", red, green, blue);

            return color;
        }

        static void Main(string[] args)
        {

            // you can change canvas scale
            int scale = 100;

            Random random = new Random();
            Bitmap bitmap = new Bitmap(scale, scale);

            Color gray = grayColor();
            Color color = randColorBlock();


            // painting whole canvas to gray

            for (int i = 0; i < scale; i++)
            {
                for (int x = 0; x < scale; x++)
                {
                    bitmap.SetPixel(i, x, gray);
                }
            }

            // painting 10x10 random boxes and their symmetries

            for (int x = 0; x < (scale / 20); x++)
            {
                for (int y = 0; y < (scale / 10); y++)
                {
                    bool key = random.Next(2) == 1;
                    if (key)
                    {
                        for (int i = x * 10; i < (x * 10) + 10; i++)
                        {
                            for (int j = y * 10; j < (y * 10) + 10; j++)
                            {
                                bitmap.SetPixel(i, j, color);
                                bitmap.SetPixel((scale - i) - 1, j, color);
                            }
                        }
                    }
                }
            }

            bitmap.Save("avatar.png", System.Drawing.Imaging.ImageFormat.Png);

            Console.WriteLine("Canvas has been saved successfully! (Check the project directory)");
            Console.ReadKey();

        }
    }
}
