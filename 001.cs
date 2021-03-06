using System;
using System.Threading;

namespace ConsoleAppIsFun
{
	class Program
	{
		/// <summary>
		/// Draw to new map after map is cleared.
		/// </summary>
		/// <param name="map">
		/// Characters for each cursor point.
		/// </param>
		static void drawScreen(char[,] map)
		{
			// Firstly, we need to clear screen.
			Console.Clear();

			// And then, we are goint to draw all characters on the screen.
			for (int y = 0; y < map.GetLength(0); y++)
			{
				for (int x = 0; x < map.GetLength(1); x++)
					Console.Write(map[y, x]);
				Console.WriteLine();
			}
		}

		/// <summary>
		/// Fill the map by drawing a ellipse.
		/// </summary>
		/// <param name="map">
		/// Map characters.
		/// </param>
		/// <param name="centerX">
		/// Where will the ellipse at x as origin?
		/// </param>
		/// <param name="centerY">
		/// Where will the ellipse at y as origin?
		/// </param>
		/// <param name="width">
		/// What is the width of ellipse?
		/// </param>
		/// <param name="height">
		/// What is the height of ellipse?
		/// </param>
		static void ellipse(char[,] map, int centerX, int centerY, int width, int height)
		{
			for (int degree = 0; degree < 360; degree++)
			{
				var radian = (Math.PI / 180) * degree;
				map[(int)(centerY + (Math.Sin(radian) * height)), (int)(centerX + (Math.Cos(radian) * width))] = '.';
			}
			map[centerY, centerX] = 'O';
		}

		static void Main(string[] args)
		{
			// These increasing variables help us to change size of ellipse.
			sbyte increaseWidth = 1;
			sbyte increaseHeight = 2;
			
			// Total size of ellipse variables.
			int width = 0;
			int height = 0;

			// Map size.
			int mapWidth = 40;
			int mapHeight = 40;

			// We keeps on change size of ellipse continuously.
			while (true)
			{
				var map = new char[mapWidth, mapHeight];

				// Fill the ellipse.
				ellipse(map, mapWidth / 2, mapHeight / 2, width, height);

				// Draw map on the screen.
				drawScreen(map);

				// Change increasing amount of size.
				width += increaseWidth;
				if (width == 0 || width == 18)
					increaseWidth *= -1;

				height += increaseHeight;
				if (height == 0 || height == 18)
					increaseHeight *= -1;

				// Wait a while for preventing lock.
				Thread.Sleep(1);
			}
		}
	}
}
