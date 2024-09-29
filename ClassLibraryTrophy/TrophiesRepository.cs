using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTrophy
{
    public class TrophiesRepositoryLib
    {
        public int _nextId = 1;
        public readonly List<Trophy> _trophies = new();
        public TrophiesRepositoryLib()
        {
            _trophies.Add(new Trophy() { Id = _nextId++, Competition = "OlympicsFra", Year = 1980 });
            _trophies.Add(new Trophy() { Id = _nextId++, Competition = "OlympicsFJAP", Year = 1984 });
            _trophies.Add(new Trophy() { Id = _nextId++, Competition = "OlympicsBRAZ", Year = 1990 });
            _trophies.Add(new Trophy() { Id = _nextId++, Competition = "OlympicsAMR", Year = 2000 });
            _trophies.Add(new Trophy() { Id = _nextId++, Competition = "OlympicsCH", Year = 2012 });
        }

        //Get()
        //Returnerer en kopi af listen af alle Trophy objekter: Brug en copy constructor.
        //Get() skal give mulighed for at filtrere på Year.
        //Get() skal give mulighed for at sortere på Competition eller Year.
        public List<Trophy> Get(int? Year = null, string? sortBy = null)
        {
            List<Trophy> list = new List<Trophy>(_trophies);

            // Year
            if (Year != null)
            {
                list = list.Where(item => item.Year == Year).ToList();
            }

            // Sort by Year or Competition
            if (sortBy != null)
            {
                if (sortBy == "competition")
                {
                    list = list.OrderBy(item => item.Competition).ToList();
                }

                if (sortBy == "year")
                {
                    list = list.OrderByDescending(item => item.Year).ToList();
                }
            }

            // Return List
            return list;
        }

        //        GetById(int id)
        //        Returnerer Trophy objektet med det angivne id - eller null.
        public Trophy? GetById(int id)
        {
            return _trophies.FirstOrDefault(t => t.Id == id);
        }
        


        //Add(Trophy trophy)
        //Tilføj id til trophy objektet.Tilføjer trophy til listen.Returnerer Trophy objektet

        public Trophy Add(Trophy trophy)
        {
            trophy.Validate();
            trophy.Id = _nextId++;
            _trophies.Add(trophy);
            return trophy;
        }

        //Remove(int id)
        //Sletter Trophy objektet med det angivne id.Returnerer Trophy objektet - eller null.

        public Trophy? Remove(int id)
        {
            Trophy? trophy = GetById(id);
            if (trophy == null) 
            {
                return null;
            }
            _trophies.Remove(trophy);
            return trophy;
        }

        ////Update(int id, Trophy values)
        //Trophy objektet med det angivne id opdateres med values.
        //Returnerer det opdaterede Trophy objekt - eller null.

        public Trophy? Update(int id, Trophy values)
        {
            values.Validate();
            Trophy? existingtrophy = GetById(id);
            if (existingtrophy == null)
            {
                return null;
            }
            existingtrophy.Id = values.Id;
            existingtrophy.Competition = values.Competition;
            existingtrophy.Year = values.Year;
            return existingtrophy;
        }
    }
}
