using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Spider
{
    class Coords
    {
        float
            Mx,
            My,
            Mz;
        public Coords() 
        {
            Mx = Convert.ToSingle(Console.ReadLine());
            My = Convert.ToSingle(Console.ReadLine());
            Mz = Convert.ToSingle(Console.ReadLine());
        }
        public Coords(float mx, float my, float mz)
        {
            Mx = mx;
            My = my;
            Mz = mz;
        }

        public float x {
            get 
            {
                return Mx;
            }
            
        }
        public float y {
            get 
            {
                return My;
            }
             
        }
        public float z {
            get 
            {
                return Mz;
            }
           
        }


    }
    class SAF
    {
        static Coords Vector(Coords a, Coords b)
        {
            Coords Nap = new(b.x - a.x, b.y - a.y, b.z - a.z);
            return Nap;
        }
        static double Potenc_Otvet(Coords YXZ)
        {
            double dl = 0f;
            dl += Math.Pow(YXZ.x, 2);
            dl += Math.Pow(YXZ.y, 2);
            dl += Math.Pow(YXZ.z, 2);
            return Math.Pow(dl, 0.5f);
        }
        static void Main()
        {
            Coords MaxCoords = new Coords();
            Coords Spider = new Coords();
            Coords Fly = new Coords();
            double otvet = 0f;
            if (Fly.x == 0)
            {
                if (Spider.x == 0)
                    otvet = Potenc_Otvet(Vector(Fly, Spider));
                if (Spider.z == MaxCoords.z)
                    otvet = Potenc_Otvet(Vector(new(Fly.y, Fly.z, 0f), new(Spider.y, MaxCoords.z + Spider.x, 0f)));
                if (Spider.z == 0)
                    otvet = Potenc_Otvet(Vector(new(Fly.y, Fly.z, 0f), new(Spider.y, -Spider.x, 0f)));
                if (Spider.y == 0)
                    otvet = Potenc_Otvet(Vector(new(-Fly.y, Fly.z, 0f), new(Spider.x, Spider.z, 0f)));
                if (Spider.y == MaxCoords.y)
                    otvet = Potenc_Otvet(Vector(new(Fly.y, Fly.z, 0f), new(MaxCoords.y + Spider.x, -Spider.z, 0f)));
                if (Spider.x == MaxCoords.x)
                    otvet = Math.Min
                        (
                        Math.Min
                            (
                            Potenc_Otvet(Vector(new(-Fly.y, Fly.z, 0f), new(MaxCoords.x + Spider.x, Spider.z, 0f))),
                            Potenc_Otvet(Vector(new(Fly.y, Fly.z, 0f), new(Spider.y, MaxCoords.z * 2 - Spider.z + MaxCoords.x, 0f)))
                            ),
                        Math.Min
                            (
                            Potenc_Otvet(Vector(new(Fly.y, Fly.z, 0f), new(Spider.y, -(MaxCoords.x + Spider.z), 0f))),
                            Potenc_Otvet(Vector(new(Fly.y, Fly.z, 0f), new(MaxCoords.y * 2 + MaxCoords.x - Spider.y, Spider.z, 0f)))
                            )
                        );
            }
            if (Fly.y == 0)
            {
                if (Spider.y == 0)
                    otvet = Potenc_Otvet(Vector(Fly, Spider));
                if (Spider.x == 0)
                    otvet = Potenc_Otvet(Vector(new(Fly.x, Fly.z, 0f), new(-Spider.y, Spider.z, 0f)));
                if (Spider.z == 0)
                    otvet = Potenc_Otvet(Vector(new(Fly.x, Fly.z, 0f), new(Spider.x, -Spider.y, 0f)));
                if (Spider.z == MaxCoords.z)
                    otvet = Potenc_Otvet(Vector(new(Fly.x, Fly.z, 0f), new(Spider.x, MaxCoords.z + Spider.z, 0f)));
                if (Spider.x == MaxCoords.x)
                    otvet = Potenc_Otvet(Vector(new(Fly.x, Fly.z, 0f), new(MaxCoords.x + Spider.y, Spider.z, 0f)));
                if (Spider.y == MaxCoords.y)
                    otvet = Math.Min
                        (
                        Math.Min
                            (
                            Potenc_Otvet(Vector(new(Fly.x, Fly.z, 0f), new(Spider.x, MaxCoords.z * 2 + MaxCoords.y - Spider.z, 0f))),
                            Potenc_Otvet(Vector(new(Fly.x, Fly.z, 0f), new(2 * MaxCoords.x + MaxCoords.y - Spider.x, Spider.z, 0f)))
                            ),
                        Math.Min
                            (
                            Potenc_Otvet(Vector(new(Fly.x, Fly.z, 0f), new(-(MaxCoords.y + Spider.x), Spider.z, 0f))),
                            Potenc_Otvet(Vector(new(Fly.x, Fly.z, 0f), new(Spider.x, -(MaxCoords.y + Spider.z), 0f)))
                            )
                        );
            }
            if (Fly.z == 0) 
            {
                if (Spider.z == 0)
                    otvet = Potenc_Otvet(Vector(Fly, Spider));
                if (Spider.x == 0)
                    otvet = Potenc_Otvet(Vector(new(Fly.y, -Fly.x, 0f), new(Spider.y, Spider.z, 0f)));
                if (Spider.y == 0)
                    otvet = Potenc_Otvet(Vector(new(Fly.x, -Fly.y, 0f), new(Spider.x, Spider.z, 0f)));
                if (Spider.x == MaxCoords.x)
                    otvet = Potenc_Otvet(Vector(new(Fly.y, Fly.x, 0f), new(Spider.y, MaxCoords.x + Spider.z, 0f)));
                if (Spider.y == MaxCoords.y)
                    otvet = Potenc_Otvet(Vector(new(Fly.x, Fly.y, 0f), new(Spider.x, MaxCoords.y + Spider.z, 0f)));
                if (Spider.z == MaxCoords.z)
                    otvet = Math.Min(Math.Min
                           (
                           Potenc_Otvet(Vector(new(Fly.x, -Fly.y, 0f), new(Spider.x, MaxCoords.z + Spider.y, 0f))),
                           Potenc_Otvet(Vector(new(Fly.y, -Fly.x, 0f), new(Spider.y, MaxCoords.z + Spider.x, 0f)))
                           ),
                           Math.Min(
                           Potenc_Otvet(Vector(new(Fly.x, Fly.y, 0f), new(Spider.x, MaxCoords.y * 2 + MaxCoords.z - Spider.y, 0f))),
                           Potenc_Otvet(Vector(new(Fly.y, Fly.x, 0f), new(Spider.y, MaxCoords.x + MaxCoords.z - Spider.x, 0f))))
                           );
            }
            if (Fly.z == MaxCoords.z) 
            {
                if (Spider.z == MaxCoords.z)
                    otvet = Potenc_Otvet(Vector(new(Fly.x, Fly.y, Fly.z), new(Spider.x, Spider.y, Spider.z)));
                if (Spider.x == 0)
                    otvet = Potenc_Otvet(Vector(new(Fly.y, MaxCoords.z + Fly.x, 0f), new(Spider.y, Spider.z, 0f)));
                if (Spider.y == 0)
                    otvet = Potenc_Otvet(Vector(new(Fly.x, MaxCoords.z + Fly.y, 0f), new(Spider.x, Spider.z, 0f)));
                if (Spider.y == MaxCoords.y)
                    otvet = Potenc_Otvet(Vector(new(Fly.x, MaxCoords.z + Fly.y, 0f), new(Spider.x, MaxCoords.z * 2 + MaxCoords.y - Spider.z, 0f)));
                if (Spider.x == MaxCoords.x)
                    otvet = Potenc_Otvet(Vector(new(Fly.y, MaxCoords.z + Fly.x, 0f), new(Spider.y, MaxCoords.z * 2 + MaxCoords.x - Spider.z, 0f)));
                if (Spider.z == 0)
                    otvet = Math.Min
                                    (
                        Math.Min
                                   (
                                   Potenc_Otvet(Vector(new(Fly.y, MaxCoords.z + Fly.x, 0f), new(Spider.y, -Spider.x, 0f))),
                                   Potenc_Otvet(Vector(new(Fly.x, MaxCoords.z + Fly.y, 0f), new(Spider.x, -Spider.y, 0f)))
                                   ),
                        Math.Min
                                   (
                                   Potenc_Otvet(Vector(new(Fly.y, MaxCoords.z + Fly.x, 0f), new(Spider.y, MaxCoords.z * 2 + MaxCoords.x - Spider.x, 0f))),
                                   Potenc_Otvet(Vector(new(Fly.x, MaxCoords.z + Fly.y, 0f), new(Spider.x, MaxCoords.z * 2 + MaxCoords.y * 2 - Spider.y, 0f)))
                                   )
                                   );
            }
            if (Fly.y == MaxCoords.y)
            {
                if (Spider.y == MaxCoords.y)
                    otvet = Potenc_Otvet(Vector(Fly, Spider));
                if (Spider.x == 0)
                    otvet = Potenc_Otvet(Vector(new(MaxCoords.y + Fly.x, Fly.z, 0f), new(Spider.y, Spider.z, 0f)));
                if (Spider.z == 0)
                    otvet = Potenc_Otvet(Vector(new(MaxCoords.y + Fly.x, Fly.z, 0f), new(Spider.y, -Spider.x, 0f)));
                if (Spider.z == MaxCoords.y)
                    otvet = Potenc_Otvet(Vector(new(MaxCoords.y + Fly.x, Fly.z, 0f), new(Spider.y, MaxCoords.z + Spider.x, 0f)));
    if (Spider.x == MaxCoords.x)
                    otvet = Potenc_Otvet(Vector(new(MaxCoords.y + Fly.x, Fly.z, 0), new(2*MaxCoords.y + MaxCoords.x - Spider.y, Spider.z, 0)));
    if (Spider.y == 0)
                    otvet = Math.Min
                                    (
                        Math.Min(
                                   Potenc_Otvet(Vector(new(Fly.x, MaxCoords.z * 2 + MaxCoords.y - Fly.z, 0), new(Spider.x, Spider.z, 0f))),
                                   Potenc_Otvet(Vector(new(MaxCoords.x * 2 + MaxCoords.y - Fly.x, Fly.z, 0), new(Spider.x, Spider.z, 0f)))
                                ),
                        Math.Min(
                                   Potenc_Otvet(Vector(new(Fly.x, -(MaxCoords.y + Fly.z), 0f), new(Spider.x, Spider.z, 0f))),
                                   Potenc_Otvet(Vector(new(-(MaxCoords.y + Fly.x), Fly.z, 0f), new(Spider.x, Spider.z, 0f)))
                                )
                        );
            }
            if (Fly.x == MaxCoords.x)
            {
                if (Spider.x == MaxCoords.x)
                    otvet = Potenc_Otvet(Vector(new(Fly.x, Fly.y, Fly.z), new(Spider.x, Spider.y, Spider.z)));
                if (Spider.y == 0)
                {
                    otvet = Potenc_Otvet(Vector(new(MaxCoords.x + Fly.y, Fly.z, 0), new(Spider.x, Spider.z, 0f)));
                    Console.WriteLine(Math.Round(otvet, 3));
                    return;
                }
                if (Spider.z == 0)
                    otvet = Potenc_Otvet(Vector(new(Fly.y, MaxCoords.x + Fly.z, 0), new(Spider.y, Spider.x, 0)));
                if (Spider.z == MaxCoords.z)
                    otvet = Potenc_Otvet(Vector(new(Fly.y, MaxCoords.z*2 + MaxCoords.x  - Fly.z, 0),new (Spider.y, MaxCoords.z + Spider.x, 0)));
                if (Spider.y == MaxCoords.y)
                    otvet = Potenc_Otvet(Vector(new(MaxCoords.y*2+MaxCoords.x - Fly.y, Fly.z, 0),new (MaxCoords.y + Spider.x, Spider.z, 0)));
                if (Spider.x == 0)
                    otvet = Math.Min
                        (
                                   Math.Min
                                   (
                                   Potenc_Otvet(Vector(new(Fly.y, MaxCoords.z * 2 + MaxCoords.x - Fly.z, 0), new(Spider.y, Spider.z, 0))),
                                   Potenc_Otvet(Vector(new(MaxCoords.x + Fly.y, Fly.z, 0), new(-Spider.y, Spider.z, 0)))
                                   ),
                                   Math.Min
                                   (
                                   Potenc_Otvet(Vector(new(Fly.y, -(MaxCoords.x + Fly.z), 0),new (Spider.y, Spider.z, 0))),
                                   Potenc_Otvet(Vector(new(MaxCoords.y*2 + MaxCoords.x - Fly.y, Fly.z, 0),new (Spider.y, Spider.z, 0)))
                                   )
                        );
            }

            Console.WriteLine(Math.Round(otvet, 3));
        }
            
    }
}