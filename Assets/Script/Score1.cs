using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts
{

    public class Score1 : System.IComparable<Score1>
    {
        public string Name;
        public int GameScore;
        public Score1(string n, int s)
        {
            Name = n;
            GameScore = s;
        }
        public int CompareTo(Score1 other)
        {
            if (other == null)
                return 0;
            int value = other.GameScore - this.GameScore;
            return value;
        }
        public override string ToString()
        {
            return Name + " : " + GameScore.ToString();
        }
        // Start is called before the first frame update
      
    }
}
