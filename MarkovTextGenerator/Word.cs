namespace MarkovTextGenerator;

/// <summary>
/// Represents a word and its occurrence count and probability.
/// </summary>
public class Word
{
    /// <summary>
    /// The number of times the word appears following a given word.
    /// </summary>
    public int Count { get; set; } = 1;

    /// <summary>
    /// The probability of the word appearing after a given word.
    /// </summary>
    public double Probability { get; set; } = 0.0;

    /// <summary>
    /// Initializes a new instance of the <see cref="Word"/> class with the specified word.
    /// </summary>
    /// <param name="word">The word.</param>
    public Word(string word)
    {
        this.Value = word;
    }

    public string Value { get; }

    /// <summary>
    /// Returns the word as a string.
    /// </summary>
    /// <returns>The word.</returns>
    public override string ToString() => this.Value;
}
