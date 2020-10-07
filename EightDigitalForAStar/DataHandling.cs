using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EightDigitalForAState
{
	struct Mark
	{
		public int[,] State; 
		public int Step; //步数
		/// <summary>
		/// G为起点到此处，H为此处到终点, F = G + H
		/// </summary>
		public int G, H, F; 
	};
	class DataHandling
	{
		public static int[,] State = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
		public static int[,] Target = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
		public static int Step = 0;
		public static ArrayList OpenList = new ArrayList();
		public static ArrayList CloseList = new ArrayList();
		public int State_x,State_y; //用于表示0的位置

		/// <summary>
		/// 九宫格初始化
		/// </summary>
		public void Init_State()
		{
			int[] temp = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
			do
			{
				GetDisorderBytes(temp);
				for (int i = 0; i < 9; i++)
				{
					State[i / 3, i % 3] = temp[i];
				}
			}
			while (!IsSolvable()); //此处可优化
			#region
			/*Random rd = new Random();
			for (int i = 1; i < 9; i++)
			{
				int temp = rd.Next(0, 8);
				while(true)
				{
					if (State[temp / 3, temp % 3] == 0) 
					{
						State[temp / 3, temp % 3] = i;
					}
					else
					{

					}
				}
			}*/
			#endregion
		}

		/// <summary>
		/// 乱序排列一个数列
		/// </summary>
		/// <param name="byt"></param>
		public static void GetDisorderBytes(int[] byt)
		{
			int min = 1;
			int max = byt.Length;
			int inx = 0;
			Random rnd = new Random();
			while (min != max)
			{
				int r = rnd.Next(min++, max);
				int b = byt[inx];
				byt[inx] = byt[r];
				byt[r] = b;
				inx++;
			}
		}

		/// <summary>
		/// 复制八数码格
		/// </summary>
		/// <param name="a">存放的位置</param>
		/// <param name="b">被复制的位置</param>
		public void StateCpy(int[,] a ,int[,] b)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					a[i,j] = b[i,j];
				}
			}
		}

		/// <summary>
		/// 判断问题是否有解
		/// </summary>
		/// <returns></returns>
		public bool IsSolvable()
		{
			int sum = 0;
			for (int i = 0; i < 3 * 3; i++)
			{
				for (int j = i + 1; j < 3 * 3; j++)
				{
					int m, n, c, d;
					m = i / 3; n = i % 3;
					c = j / 3; d = j % 3;
					if (State[c, d] == 0)
					{
						State_x = c;
						State_y = d;
						continue;
					}
					if (State[m, n] > State[c, d]) sum++;
				}
			}
			if (sum % 2 != 0)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// 判断两个九宫格是否相同
		/// </summary>
		/// <returns></returns>
		public bool IsEqual(int[,] a, int[,] b)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (a[i,j] != b[i,j]) return false;
				}
			}
			return true;
		}

		public int StateToInt(int[,] state)
		{
			int sum = 0;
			for (int i = 0; i < 9; i++) 
			{
				sum *= 10;
				sum += state[i / 3, i % 3];
			}
			return sum;
		}

		/// <summary>
		/// 寻找可以移动的方向
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="dir">1 up 2 down 3 left 4 right</param>
		/// <returns></returns>
		public bool move(int[,] a, int[,] b, int dir)
		{
			//
			int x = 0, y = 0;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					b[i,j] = a[i,j];
					if (a[i,j] == 0)
					{
						x = i; y = j;
					}
				}
			}
			if (x == 0 && dir == 1) return false;
			if (x == 3 - 1 && dir == 2) return false;
			if (y == 0 && dir == 3) return false;
			if (y == 3 - 1 && dir == 4) return false;
			if (dir == 1) { b[x - 1,y] = 0; b[x,y] = a[x - 1,y]; }
			else if (dir == 2) { b[x + 1,y] = 0; b[x,y] = a[x + 1,y]; }
			else if (dir == 3) { b[x,y - 1] = 0; b[x,y] = a[x,y - 1]; }
			else if (dir == 4) { b[x,y + 1] = 0; b[x,y] = a[x,y + 1]; }
			else return false;
			return true;
		}

		public int AStar()
		{

			return 0;
		}


		/// <summary>
		/// 测试单元
		/// </summary>
		public void Test()
		{
			Init_State();
			MessageBox.Show(StateToInt(State).ToString());
		}

	}

}
