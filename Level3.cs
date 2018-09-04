using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Proyecto_Level_03
{
    class Program
    {
        static void Main(string[] args)
        {
			//Abrir Archivo txt
            string DATA = System.IO.File.ReadAllText(@"level3.txt");
			//Dividirlo por el Splitter
            string[] Splitted = Regex.Split(DATA, "中国电视 - 中国电视 - 中国电视");
			//Meter los 7 Frames en un Arrray Splitted[2-8], Splitted[0] y Splitted[1] son el header, y Splitted[9] el Greetings
            string[] MovieData = { Splitted[2].Trim(), Splitted[3].Trim(), Splitted[4].Trim(), Splitted[5].Trim(), Splitted[6].Trim(), Splitted[7].Trim(), Splitted[8].Trim() };
            int FrameNumber = 1;
            int y = 0;
            int x = 0;
			//Lista de Frames Decodificados
            List<Bitmap> Movie = new List<Bitmap>(); 
			//Foreach para agarrar cada Frame Codificado
            foreach (String FrameData in MovieData)
            {
				//Crear el bitmap
                Bitmap Frame = new Bitmap(240, 360);
				//Dividir en las 240 Lineas
                string[] lines = FrameData.Split('\n');
				//volver a la linea 0
				//X y Y estan intercambiados porque la especificacion dice que el video esta rotado
                y = 0;
				//Foreach para agarrar cada Linea del Frame
                foreach (String line in lines)
                {
					//Volver al lugar 0
                    x = 0;
					//Dividir la linea cada 3 para obtener un array de 3 caracteres que corresponden a rgb
                    string[] pixels = Split(line, 3).ToArray();
					//Foreach para agarrar cada Pixel del array
                    foreach (string pixel in pixels)
                    {
						//Agarrar los valores rgb y traducirlos con en el diccionario basado en la tabla de frecuencias de caracteres chinos
                        int R = TVDic[pixel[0]];
                        int G = TVDic[pixel[1]];
                        int B = TVDic[pixel[2]];
						//Armar el color con los valores RGB
                        Color color = Color.FromArgb(R, G, B);
						//Setear el pixel con el color
                        Frame.SetPixel(y, x,color);
                        x++;
                    }
                    y++;
                }
				//Agegar el Frame Decodificado a la lista
                Movie.Add(Frame);
                FrameNumber++;
            }
            FrameNumber = 1 ;
			//Foreach para agarrar cada frame decodificado
            foreach(Bitmap Frame in Movie)
            {
				//Guardamos el frame en jpg
                Frame.Save("Frame "+FrameNumber.ToString() + ".jpg");
                FrameNumber++;
            }
        }
		//Metodo que devuelve un array de Substrings de 1 Tamaño determinado, dados los parametros str (String a Dividir) y chunkSize (Tamaño de cada substring)
        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
		//Diccionario basado en la tabla de frecuencias de caracteres chinos
        static Dictionary<char, int> TVDic = new Dictionary<char, int>()
        {
        {'的',1},
        {'一',2},
        {'是',3},
        {'不',4},
        {'了',5},
        {'在',6},
        {'人',7},
        {'有',8},
        {'我',9},
        {'他',10},
        {'这',11},
        {'个',12},
        {'们',13},
        {'中',14},
        {'来',15},
        {'上',16},
        {'大',17},
        {'为',18},
        {'和',19},
        {'国',20},
        {'地',21},
        {'到',22},
        {'以',23},
        {'说',24},
        {'时',25},
        {'要',26},
        {'就',27},
        {'出',28},
        {'会',29},
        {'可',30},
        {'也',31},
        {'你',32},
        {'对',33},
        {'生',34},
        {'能',35},
        {'而',36},
        {'子',37},
        {'那',38},
        {'得',39},
        {'于',40},
        {'着',41},
        {'下',42},
        {'自',43},
        {'之',44},
        {'年',45},
        {'过',46},
        {'发',47},
        {'后',48},
        {'作',49},
        {'里',50},
        {'用',51},
        {'道',52},
        {'行',53},
        {'所',54},
        {'然',55},
        {'家',56},
        {'种',57},
        {'事',58},
        {'成',59},
        {'方',60},
        {'多',61},
        {'经',62},
        {'么',63},
        {'去',64},
        {'法',65},
        {'学',66},
        {'如',67},
        {'都',68},
        {'同',69},
        {'现',70},
        {'当',71},
        {'没',72},
        {'动',73},
        {'面',74},
        {'起',75},
        {'看',76},
        {'定',77},
        {'天',78},
        {'分',79},
        {'还',80},
        {'进',81},
        {'好',82},
        {'小',83},
        {'部',84},
        {'其',85},
        {'些',86},
        {'主',87},
        {'样',88},
        {'理',89},
        {'心',90},
        {'她',91},
        {'本',92},
        {'前',93},
        {'开',94},
        {'但',95},
        {'因',96},
        {'只',97},
        {'从',98},
        {'想',99},
        {'实',100},
        {'日',101},
        {'军',102},
        {'者',103},
        {'意',104},
        {'无',105},
        {'力',106},
        {'它',107},
        {'与',108},
        {'长',109},
        {'把',110},
        {'机',111},
        {'十',112},
        {'民',113},
        {'第',114},
        {'公',115},
        {'此',116},
        {'已',117},
        {'工',118},
        {'使',119},
        {'情',120},
        {'明',121},
        {'性',122},
        {'知',123},
        {'全',124},
        {'三',125},
        {'又',126},
        {'关',127},
        {'点',128},
        {'正',129},
        {'业',130},
        {'外',131},
        {'将',132},
        {'两',133},
        {'高',134},
        {'间',135},
        {'由',136},
        {'问',137},
        {'很',138},
        {'最',139},
        {'重',140},
        {'并',141},
        {'物',142},
        {'手',143},
        {'应',144},
        {'战',145},
        {'向',146},
        {'头',147},
        {'文',148},
        {'体',149},
        {'政',150},
        {'美',151},
        {'相',152},
        {'见',153},
        {'被',154},
        {'利',155},
        {'什',156},
        {'二',157},
        {'等',158},
        {'产',159},
        {'或',160},
        {'新',161},
        {'己',162},
        {'制',163},
        {'身',164},
        {'果',165},
        {'加',166},
        {'西',167},
        {'斯',168},
        {'月',169},
        {'话',170},
        {'合',171},
        {'回',172},
        {'特',173},
        {'代',174},
        {'内',175},
        {'信',176},
        {'表',177},
        {'化',178},
        {'老',179},
        {'给',180},
        {'世',181},
        {'位',182},
        {'次',183},
        {'度',184},
        {'门',185},
        {'任',186},
        {'常',187},
        {'先',188},
        {'海',189},
        {'通',190},
        {'教',191},
        {'儿',192},
        {'原',193},
        {'东',194},
        {'声',195},
        {'提',196},
        {'立',197},
        {'及',198},
        {'比',199},
        {'员',200},
        {'解',201},
        {'水',202},
        {'名',203},
        {'真',204},
        {'论',205},
        {'处',206},
        {'走',207},
        {'义',208},
        {'各',209},
        {'入',210},
        {'几',211},
        {'口',212},
        {'认',213},
        {'条',214},
        {'平',215},
        {'系',216},
        {'气',217},
        {'题',218},
        {'活',219},
        {'尔',220},
        {'更',221},
        {'别',222},
        {'打',223},
        {'女',224},
        {'变',225},
        {'四',226},
        {'神',227},
        {'总',228},
        {'何',229},
        {'电',230},
        {'数',231},
        {'安',232},
        {'少',233},
        {'报',234},
        {'才',235},
        {'结',236},
        {'反',237},
        {'受',238},
        {'目',239},
        {'太',240},
        {'量',241},
        {'再',242},
        {'感',243},
        {'建',244},
        {'务',245},
        {'做',246},
        {'接',247},
        {'必',248},
        {'场',249},
        {'件',250},
        {'计',251},
        {'管',252},
        {'期',253},
        {'市',254},
        {'直',255}
    };
    }
}
