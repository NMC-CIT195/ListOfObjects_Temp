using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfObjects.Things
{
    public class Monster
    {
        public enum Mood 
        { 
            happy,
            sad,
            angry
        }

        private string _name;
        private int _age;
        private Mood _attitude;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public Mood Attitude
        {
            get { return _attitude; }
            set { _attitude = value; }
        }

        public string DisplayInfo()
        {
            return $"The monster {_name} is {_age} years old.";
        }

        public override string ToString()
        {
            return $"The monster {_name} is {_age} years old.";
        }

        public Monster()
        {

        }

        public Monster(string name, int age, Mood attitude)
        {
            _name = name;
            _age = age;
            _attitude = attitude;
        }
    }
}
