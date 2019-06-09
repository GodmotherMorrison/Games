using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PegSolitaire.Architecture.Logic
{
    public static class SerializationManager
    {
        private const string Path = "Save.dat";
        public static void Serialize(Game game)
        {
            var fs = new FileStream(Path, FileMode.Create);
            var formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(fs, game);
            }
            catch (SerializationException e)
            {
                Console.WriteLine(@"Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

        }

        public static Game Deserialize()
        {
            var game = new Game();
            if (!File.Exists(Path)) return game;
            var fs = new FileStream(Path, FileMode.Open);

            try
            {
                var formatter = new BinaryFormatter();
                game = (Game)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine(@"Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            return game;
        }
    }
}
