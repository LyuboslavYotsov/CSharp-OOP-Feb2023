using System;
using WildFarm.Engine;
using WildFarm.IO;

IWriter writer = new ConsoleWriter();
IReader reader = new ConsoleReader();

Engine engine= new Engine(writer, reader);

engine.Run();