namespace Project
{
    class ProgMain
    {
        static void Main() 
        {

            bool isnum = true;
            string str = "";
            int Num,
                Sum =0,//Ответ
                NumOfLoops=0,//Количество циклов
                fromwell=0, // От колодца до грядки
                Width=0,//Ширина
                Height=0;//Высота
                         //                    ||
                         //Начало ввода данных \/
            do
            {
                Console.Write("Количество циклов = ");
                str = Console.ReadLine();
                isnum = int.TryParse(str, out Num);

                NumOfLoops = Num;

                Console.Write("Расстояние от колодца до грядки = ");
                str = Console.ReadLine();
                isnum = int.TryParse(str, out Num);

                fromwell = Num;

                Console.Write("Ширина = ");
                str = Console.ReadLine();
                isnum = int.TryParse(str, out Num);

                Width = Num;

                Console.Write("Высота = ");
                str = Console.ReadLine();
                isnum = int.TryParse(str, out Num);

                Height = Num;
                if (isnum == false)
                {
                    Console.WriteLine("Вы где-то ошиблись при вводе данных, попробуйте снова");
                    isnum = true;
                    continue;
                }
                isnum = false;
            } while (isnum == true);




            //Конец ввода данных   /\
            //                     ||
            for (int i = 1; i<=NumOfLoops;i++)
            {
                Sum += (Width + Height)*2
                + Width*(i-1)*2
                + (2*fromwell);
            }
            Console.WriteLine
                (
                $"Цикл:{Sum}," 
                +
                $"По формуле:{
                    2*NumOfLoops*(fromwell+Height)
                    + 
                    Width*NumOfLoops*(NumOfLoops+1)
                    }"
                );
            Console.ReadKey();
        }
}
}