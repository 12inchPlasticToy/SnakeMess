﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RefactoredSnake {
	class View {

		private Controller gameLogic;
		public int X { get; private set; }
		public int Y { get; private set; }


		public View(Controller controller) {
			gameLogic = controller;
			SetupBoard();
		}

		/// <summary>
		///  Starts the terminal
		/// </summary>
		private void SetupBoard()
		{
			Console.Title = "Westerdals Oslo ACT - SNAKE";

			X = Console.WindowWidth;
			Y = Console.BufferHeight;
			Console.CursorVisible = false;
		}

		/// <summary>
		/// Prints an entity in the terminal according to its
		/// properties
		/// </summary>
		/// <param name="entity"></param>
		private void PaintEntity(PrintableEntity entity)
		{
			Console.ForegroundColor = entity.Color;
			Console.SetCursorPosition(entity.Coords.X, entity.Coords.Y);
			Console.Write(entity.Character);
		}

		/// <summary>
		/// Prints every entity present in an entity buffer
		/// according to their respective properties 
		/// (coordinates, colour, sign)
		/// </summary>
		public void PaintEntities(List<PrintableEntity> entities)
		{
			//Console.Clear(); <-- that's cheating!
			foreach (var entity in entities)
			{
				PaintEntity(entity);
			}
		}

		public Command GetInputKey()
		{
			if (Console.KeyAvailable) { // <-- this listens to input

				var inputKey = Console.ReadKey(true);

				if (inputKey.Key == ConsoleKey.Escape)     return Command.Quit;
				if (inputKey.Key == ConsoleKey.Spacebar)   return Command.Pause;
				if (inputKey.Key == ConsoleKey.UpArrow)    return Command.Up;
				if (inputKey.Key == ConsoleKey.RightArrow) return Command.Right; 
				if (inputKey.Key == ConsoleKey.DownArrow)  return Command.Down;
				if (inputKey.Key == ConsoleKey.LeftArrow)  return Command.Left;
			}

			return Command.NoInput;
		}

		

	}
}
