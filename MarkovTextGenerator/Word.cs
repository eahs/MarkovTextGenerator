namespace MarkovTextGenerator
{
    public class Word
    {
        private readonly String _word;
        public int Count { get; set; } = 1;
        public double Probability { get; set; } = 0.0;

        public Word(String word)
        {
            this._word = word;
        }

        public override string ToString() => this._word;
    }
}
