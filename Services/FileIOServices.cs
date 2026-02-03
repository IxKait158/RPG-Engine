using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using RPG_Engine.Characters;
using RPG_Engine.Items;
using Newtonsoft.Json;

namespace RPG_Engine.Services
{
    internal class FileIOServices
    {
        private readonly string _fileName;

        public FileIOServices(string fileName)
        {
            _fileName = fileName;
        }

        public void Save(Hero hero)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto,
            };

            string jsonString = JsonConvert.SerializeObject(hero, settings);
            File.WriteAllText(_fileName, jsonString);
        }

        public Hero Load()
        {
            if (!File.Exists(_fileName))
                return new Hero("Steve");

            var jsonString = File.ReadAllText(_fileName);

            if (string.IsNullOrWhiteSpace(jsonString))
                return new Hero("Steve");

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            var hero = JsonConvert.DeserializeObject<Hero>(jsonString, settings);
            return hero ?? new Hero("Steve");
        }
    }
}

