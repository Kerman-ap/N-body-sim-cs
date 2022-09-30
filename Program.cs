namespace N_Body_Sim
{
    public class Object
    {
        public float x;
        public float y;
        public float xvel;
        public float yvel;
        public float mass;


    }
    public class Calc
    {
        public static List<Object> Objects = new List<Object>();
        public static void Main(string[] args)
        {
            Thread thd = new Thread(render);
            thd.Start();
            gen(800, Objects);
            bool running = true;
            while(running)
            {
                    foreach (var CurrentObject in Objects)
                    {
                        calcgravity(CurrentObject, Objects);
                    }
                    Objects = calcmove(Objects);

            }


        }

        public static List<Object> calcmove(List<Object> Objects)
        {
            List<Object> tmp = new List<Object>();
            foreach (var Object in Objects)
            {
                var Obj = new Object();
                Obj.x = Object.x + Object.xvel;
                Obj.y = Object.y + Object.yvel;
                Obj.xvel = Object.xvel;
                Obj.yvel = Object.yvel;
                Obj.mass = Object.mass;
                tmp.Add(Obj);
            }
            return tmp;
        }
        public static void calcgravity(Object input, List<Object> Objects)
        {
            foreach (var pair in Objects)
            {   
                if(pair != input)
                {
                    float dist = (float)Math.Sqrt(Math.Pow(pair.x - input.x, 2) + Math.Pow(pair.y - input.y, 2)) + 1f;
                    input.xvel = input.xvel + pair.mass * (pair.x - input.x) / (float)(Math.Pow(dist, 3));
                    input.yvel = input.yvel + pair.mass * (pair.y - input.y) / (float)(Math.Pow(dist, 3));
                }
            }
        }
        public static void gen(int Num, List<Object> Objects) //Create Objects
        {
            Random rnd = new Random();
            for (int i = 1; i < Num; i++)
            {
                var Obj = new Object();
                Obj.x = Lerp(-100, 100, (float)rnd.NextDouble());
                Obj.y = Lerp(-100, 100, (float)rnd.NextDouble());
                Obj.xvel = 0;
                Obj.yvel = 0;
                Obj.mass = 0.02f;
                Objects.Add(Obj);
            }
        }

        public static float Lerp(float float1, float float2, float input) //Lerp Function
        {
            return float1 * (1 - input) + float2 * input;
        }
        public static void render()
        {
            Application.Run(new N_Body_Sim());
        }
    }
}