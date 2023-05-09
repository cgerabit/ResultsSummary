using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResultsSummary.Models
{
    public class Result

    {
        private int _sanitizeValue(int value)
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 100)
            {
                value = 100;
            }
            return value;
        }

        [Key]
        public int Id { get; set; }


        public int ReactionScore { get
            {
                return _reactionScore;
            }
            set
            {
               _reactionScore =  _sanitizeValue(value);

            }
        }

        public int MemoryScore { get
            {
                return _memoryScore;
            }
            set
            {
                _memoryScore = _sanitizeValue(value);
            }        
        }
        public int VerbalScore
        {
            get
            {
                return _verbalScore;
            }
            set
            {
                _verbalScore = _sanitizeValue(value);
            }
        }

        public int VisualScore
        {
            get
            {
                return _visualScore;
            }
            set
            {
                _visualScore = _sanitizeValue(value);
            }
        }

        [NotMapped]
        public double AverageScore
        {
            get
            {
                var value = (ReactionScore + MemoryScore + VerbalScore + VisualScore) / (double)4;


                return value;
            }
        }
        

        [NotMapped]
        private int _reactionScore = 0;
        [NotMapped]
        private int _memoryScore = 0;
        [NotMapped]
        private int _verbalScore = 0;
        [NotMapped]

        private int _visualScore  = 0;
    }
}
