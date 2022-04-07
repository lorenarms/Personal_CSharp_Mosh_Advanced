﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace Lesson_21_PropsAndEvents
{
    internal class Dresser
    {
        public event EventHandler<Lamp> DresserFinished;
        public bool finished = false;

        public bool Start(Lamp l)
        {
            WriteLine("Dresser is Activated");

            // check if prop is finished first
            if (finished)
            {
                WriteLine("You have finished this prop.");
                return finished;
            }

            // Dresser game logic
            
            var userInputCode = -999;

            while (userInputCode != 999)
            {
                WriteLine("Input the code for the dresser...");
                var userInputString = ReadLine();
                int.TryParse(userInputString, out userInputCode);

                
                if (userInputCode == 1234)
                {
                    Completed(l);

                    return true;
                }

                WriteLine("That code is incorrect, try again!");
                ReadKey();
                Clear();

            }

            return false;
        }

        private void Completed(Lamp l)
        {
            finished = true;
            DresserFinished?.Invoke(this, l);
        }
    }
}